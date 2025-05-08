using Analyzer.Data;
using Analyzer.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

namespace Analyzer.Controllers
{
    /// <summary>
    /// Controller for handling analyzer operations.
    /// </summary>
    public class AnalyzerController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<AnalyzerController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        // Inject the web host environment to get access to web root path
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzerController"/> class.
        /// </summary>
        /// <param name="environment">The web host environment.</param>
        /// <param name="logger">The logger instance.</param>
        /// <param name="context">The application database context.</param>
        /// <param name="configuration">The configuration instance.</param>
        public AnalyzerController(IWebHostEnvironment environment,
            ILogger<AnalyzerController> logger,
            ApplicationDbContext context,
            IConfiguration configuration)
        {
            _environment = environment;
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Displays the index view.
        /// </summary>
        /// <returns>The index view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Handles file upload and saves the dump file.
        /// </summary>
        /// <param name="model">The file upload model containing the file and metadata.</param>
        /// <returns>A JSON result indicating success or failure and the file details.</returns>
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        [RequestSizeLimit(104857600)]
        public async Task<IActionResult> Dump([FromForm] FileUploadModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // get the dump type from form
                var dumpType = model.DumpType;

                // Create a GUID for the file name (without extension)
                var fileGuid = Guid.NewGuid().ToString();

                // Determine upload path - changed to uploads/thread
                string uploadsFolder = dumpType switch
                {
                    "Thread" => Path.Combine(_environment.WebRootPath, _configuration["Thread:DumpFolder"] ?? Path.Combine("uploads", "thread")),
                    "GC" => Path.Combine(_environment.WebRootPath, _configuration["GC:DumpFolder"] ?? Path.Combine("uploads", "gc")),
                    "Heap" => Path.Combine(_environment.WebRootPath, _configuration["Heap:DumpFolder"] ?? Path.Combine("uploads", "heap")),
                };

                //var uploadsFolder = Path.Combine(_environment.WebRootPath, _configuration["Thread:DumpFolder"] ?? Path.Combine("uploads", "thread"));

                // Create directory if it doesn't exist
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Save file with just the GUID (no original filename)
                var filePath = Path.Combine(uploadsFolder, fileGuid);

                // Save file to disk
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File!.CopyToAsync(fileStream);
                }

                // Create a new DumpFile record
                var dumpFile = new DumpFile
                {
                    OriginalFileName = model.File.FileName,
                    DumpFileType = dumpType,
                    FileGuid = fileGuid,
                    FileType = model.File.ContentType,
                    FileSize = model.File.Length,
                    Description = model.Description,
                    ApplicationId = model.ApplicationId,
                    // Get the current user or set a default if not available
                    UploadedBy = User.Identity?.Name ?? "Anonymous",
                    UploadedAt = DateTime.UtcNow
                };

                // Save to database
                _context.DumpFiles.Add(dumpFile);
                await _context.SaveChangesAsync();

                // Store file information in ViewData to display in the view
                ViewData["FileUploaded"] = true;
                ViewData["FileName"] = model.File.FileName;
                ViewData["FileSize"] = model.File.Length;
                ViewData["FilePath"] = dumpFile.DumpFilePath;
                ViewData["FileId"] = dumpFile.Id;
                ViewData["FileGUID"] = dumpFile.FileGuid;
                ViewData["FileType"] = dumpType;
                ViewData["ApplicationName"] = model.ApplicationName;

                _logger.LogInformation($"File uploaded successfully: {model.File.FileName}, " +
                              $"Size: {model.File.Length} bytes, GUID: {fileGuid}, Type: {dumpType}");

                // Return a JSON response with the fileGuid
                return Json(new { success = true, fileGuid = fileGuid, fileName = model.File.FileName, fileSize = model.File.Length, fileType = dumpType });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error uploading file: {ex.Message}");
                ModelState.AddModelError("File", $"Error uploading file: {ex.Message}");
                return View(model);
            }
        }


        /// <summary>
        /// Displays the thread view.
        /// </summary>
        /// <returns>The thread view.</returns>
        public IActionResult Thread()
        {
            var model = new FileUploadModel
            {
                Applications = GetApplications(), // Populate applications
                DumpType = "Thread" // Set the dump type to Thread
            };
            return View(model);
        }

        /// <summary>
        /// Displays the heap view.
        /// </summary>
        /// <returns>The heap view.</returns>
        public IActionResult Heap()
        {
            var model = new FileUploadModel
            {
                Applications = GetApplications(), // Populate applications
                DumpType = "Heap" // Set the dump type to Heap
            };
            return View(model);
        }

        /// <summary>
        /// Displays the Garbage Collection view.
        /// </summary>
        /// <returns>The GC view.</returns>
        public IActionResult GC()
        {
            var model = new FileUploadModel
            {
                Applications = GetApplications(), // Populate applications
                DumpType = "GC" // Set the dump type to GC
            };
            return View(model);
        }


        /// <summary>
        /// Analyzes the thread dump file.
        /// </summary>
        /// <param name="threadDumpFile">The name of the thread dump file to analyze.</param>
        /// <returns>A JSON result indicating success or failure and the output path.</returns>
        [HttpPost]
        public async Task<IActionResult> AnalyzeThreadDump(string threadDumpFile)
        {
            try
            {
                // get paths from configuration
                string jarFile = _configuration["Thread:JarFile"] ?? "jca4168.jar";
                string jarFolder = _configuration["Thread:JarFolder"] ?? Path.Combine("tools", "jar");
                string dumpFolder = _configuration["Thread:DumpFolder"] ?? Path.Combine("uploads", "thread");
                string outputFolder = _configuration["Thread:OutputFolder"] ?? Path.Combine("reports", "thread");
                string webRootPath = _environment.WebRootPath;

                // check for output folder - if not create one
                if (!Directory.Exists(Path.Combine(webRootPath, outputFolder)))
                {
                    Directory.CreateDirectory(Path.Combine(webRootPath, outputFolder));
                }

                // Define output path for HTML analysis file
                string jarFilePath = Path.Combine(webRootPath, jarFolder, jarFile);
                string threadDumpFilePath = Path.Combine(webRootPath, dumpFolder, threadDumpFile);
                string outputFilePath = Path.Combine(webRootPath, outputFolder, threadDumpFile + "_analysis.html");

                //string argument = $"-jar \"{jarFilePath}\" \"{threadDumpFilePath}\" \"{outputFilePath}\"";

                // Create process to run Java and execute the JAR
                var processInfo = new ProcessStartInfo
                {
                    FileName = "java",
                    Arguments = $"-jar \"{jarFilePath}\" \"{threadDumpFilePath}\" \"{outputFilePath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                // Execute the process
                using (var process = new Process { StartInfo = processInfo })
                {
                    try
                    {
                        process.Start();
                        string output = await process.StandardOutput.ReadToEndAsync();
                        string error = await process.StandardError.ReadToEndAsync();
                        await process.WaitForExitAsync();

                        if (process.ExitCode != 0)
                        {
                            throw new Exception($"Thread dump analysis failed: {error}");
                        }

                        // Fetch the DumpFile record from the database
                        var dumpFile = await _context.DumpFiles.FirstOrDefaultAsync(df => df.FileGuid == threadDumpFile);
                        if (dumpFile == null)
                        {
                            throw new Exception($"Dump file with GUID {threadDumpFile} not found.");
                        }

                        // Update the DumpFile record with analysis details
                        dumpFile.AnalyzedBy = User.Identity?.Name ?? "Anonymous"; // Set the current user or a default
                        dumpFile.AnalyzedAt = DateTime.UtcNow; // Set the current timestamp

                        // Save changes to the database
                        _context.DumpFiles.Update(dumpFile);
                        await _context.SaveChangesAsync();

                        return Json(new { success = true, outputPath = outputFilePath });
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error analyzing thread dump: {ex.Message}");
                        return Json(new { success = false, error = ex.Message });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error analyzing thread dump: {ex.Message}");
                return Json(new { success = false, error = ex.Message });
            }
        }

        /// <summary>
        /// Analyzes the garbage collection dump file.
        /// </summary>
        /// <param name="gcDumpFile">The name of the garbage collection dump file to analyze.</param>
        /// <returns>A JSON result indicating success or failure and the output path.</returns>
        [HttpPost]
        public async Task<IActionResult> AnalyzeGCDump(string gcDumpFile)
        {
            // get paths from configuration
            string jarFile = _configuration["GC:JarFile"] ?? "gcviewer-1.36.jar";
            string jarFolder = _configuration["GC:JarFolder"] ?? Path.Combine("tools", "jar");
            string dumpFolder = _configuration["GC:DumpFolder"] ?? Path.Combine("uploads", "gc");
            string outputFolder = _configuration["GC:OutputFolder"] ?? Path.Combine("reports", "gc");
            string webRootPath = _environment.WebRootPath;

            string gcAnalysisFilePath = Path.Combine(webRootPath, outputFolder, gcDumpFile);

            // if corresponding analysis file exists, then process html conversion
            if (System.IO.File.Exists(gcAnalysisFilePath + "_summary.csv"))
            {
                var retval = Report2Html(gcAnalysisFilePath);
                if (!retval)
                {
                    return Json(new { success = false, error = "Error generating HTML report." });
                }
                // return the path to the report file
                return Json(new { success = true, outputPath = gcAnalysisFilePath + "_summary.html" });
            }
            else
            {
                try
                {
                    // check for output folder - if not create one
                    if (!Directory.Exists(Path.Combine(webRootPath, outputFolder)))
                    {
                        Directory.CreateDirectory(Path.Combine(webRootPath, outputFolder));
                    }

                    // Define output path for HTML analysis file
                    string jarFilePath = Path.Combine(webRootPath, jarFolder, jarFile);
                    string gcDumpFilePath = Path.Combine(webRootPath, dumpFolder, gcDumpFile);
                    string outputCSVFilePath = Path.Combine(webRootPath, outputFolder, gcDumpFile + "_summary.csv");
                    string outputPNGFilePath = Path.Combine(webRootPath, outputFolder, gcDumpFile + "_summary.png");

                    //string argument = $"-jar \"{jarFilePath}\" \"{threadDumpFilePath}\" \"{outputFilePath}\"";

                    // Create process to run Java and execute the JAR
                    var processInfo = new ProcessStartInfo
                    {
                        FileName = "java",
                        Arguments = $"-jar \"{jarFilePath}\" \"{gcDumpFilePath}\" \"{outputCSVFilePath}\" \"{outputPNGFilePath}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    // Execute the process
                    using (var process = new Process { StartInfo = processInfo })
                    {
                        try
                        {
                            process.Start();
                            string output = await process.StandardOutput.ReadToEndAsync();
                            string error = await process.StandardError.ReadToEndAsync();
                            await process.WaitForExitAsync();

                            if (process.ExitCode != 0)
                            {
                                throw new Exception($"GC dump analysis failed: {error}");
                            }

                            // Fetch the DumpFile record from the database
                            var dumpFile = await _context.DumpFiles.FirstOrDefaultAsync(df => df.FileGuid == gcDumpFile);
                            if (dumpFile == null)
                            {
                                throw new Exception($"Dump file with GUID {gcDumpFile} not found.");
                            }

                            // Update the DumpFile record with analysis details
                            dumpFile.AnalyzedBy = User.Identity?.Name ?? "Anonymous"; // Set the current user or a default
                            dumpFile.AnalyzedAt = DateTime.UtcNow; // Set the current timestamp

                            // Save changes to the database
                            _context.DumpFiles.Update(dumpFile);
                            await _context.SaveChangesAsync();

                            // build html from csv & png
                            var retval = Report2Html(gcDumpFilePath);
                            if (!retval)
                            {
                                return Json(new { success = false, error = "Error generating HTML report." });
                            }
                            return Json(new { success = true, outputPath = outputCSVFilePath });
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError($"Error analyzing GC dump: {ex.Message}");
                            return Json(new { success = false, error = ex.Message });
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error analyzing GC dump: {ex.Message}");
                    return Json(new { success = false, error = ex.Message });
                }
            }
        }

        /// <summary>
        /// Fetches a list of applications from the database.
        /// </summary>
        /// <returns>A list of <see cref="Application"/> objects.</returns>
        public List<Application> GetApplications()
        {
            // Fetch applications from the database
            var applications = _context.Applications.ToList();
            // Return the list of applications
            return applications;
        }

        private bool Report2Html(string gcAnalysisFilePath)
        {
            try
            {
                var gcDumpFile = Path.GetFileName(gcAnalysisFilePath);
                // do html conversion
                var report = Helper.CSV2HTML.ConvertGCAnalysisToHtml(gcAnalysisFilePath + "_summary.csv",
                    gcAnalysisFilePath + "_summary.png");
                // save the report file
                string reportFilePath = gcAnalysisFilePath + "_summary.html";
                using (var writer = new StreamWriter(reportFilePath))
                {
                    writer.Write(report);
                }
                // update AnalyzedAt and AnalyzedBy in the database
                var dumpFile = _context.DumpFiles.FirstOrDefault(df => df.FileGuid == gcDumpFile);
                if (dumpFile == null)
                {
                    return false;
                }
                // Update the DumpFile record with analysis details
                dumpFile.AnalyzedBy = User.Identity?.Name ?? "Anonymous"; // Set the current user or a default
                dumpFile.AnalyzedAt = DateTime.UtcNow; // Set the current timestamp
                                                       // Save changes to the database
                _context.DumpFiles.Update(dumpFile);
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error analyzing GC dump: {ex.Message}");
                return false;
            }
        }
    }
}
