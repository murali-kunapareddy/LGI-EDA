using Analyzer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Analyzer.Controllers
{
    /// <summary>
    /// Controller for handling report-related actions.
    /// </summary>
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsController"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
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
        /// Gets the dump files.
        /// </summary>
        /// <returns>A JSON result containing the dump files.</returns>
        [HttpGet]
        public IActionResult GetDumpFiles()
        {
            var dumpFiles = _context.DumpFiles
                .Select(t => new
                {
                    t.Id,
                    t.OriginalFileName,
                    t.FileGuid,
                    t.FileType,
                    ApplicationName = t.Application != null ? t.Application.Name : null, // Handle possible null reference
                    t.DumpFileType,
                    t.FileSize,
                    t.Description,
                    t.UploadedBy,
                    t.UploadedAt,
                    t.DumpFilePath,
                    t.AnalyzedBy,
                    t.AnalyzedAt,
                    t.OutputFilePath
                })
                .ToList();

            return Json(new { data = dumpFiles });
        }

        [HttpGet]
        public IActionResult Report2Html(string gcDumpFilePath)
        {
            try
            {
                var gcDumpFile = Path.GetFileName(gcDumpFilePath);
                // do html conversion
                var report = Helper.CSV2HTML.ConvertGCAnalysisToHtml(gcDumpFilePath + "_summary.csv",
                    gcDumpFilePath + "_summary.png");
                // save the report file
                string reportFilePath = gcDumpFilePath + "_summary.html";
                using (var writer = new StreamWriter(reportFilePath))
                {
                    writer.Write(report);
                }
                // update AnalyzedAt and AnalyzedBy in the database
                var dumpFile = _context.DumpFiles.FirstOrDefault(df => df.FileGuid == gcDumpFile);
                if (dumpFile == null)
                {
                    return View("Index");
                }
                // Update the DumpFile record with analysis details
                dumpFile.AnalyzedBy = User.Identity?.Name ?? "Anonymous"; // Set the current user or a default
                dumpFile.AnalyzedAt = DateTime.UtcNow; // Set the current timestamp
                                                       // Save changes to the database
                _context.DumpFiles.Update(dumpFile);
                _context.SaveChangesAsync();
                return View("Index");
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }
    }
}
