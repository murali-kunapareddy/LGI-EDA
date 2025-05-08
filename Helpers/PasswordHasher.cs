using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace WISSEN.EDA.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password, out string salt)
        {
            // Generate a random salt
            byte[] saltBytes = new byte[16];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            salt = Convert.ToBase64String(saltBytes);

            // Hash the password with the salt
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000, // Updated to meet the minimum recommended iterations
                numBytesRequested: 32));
            return hashed;
        }

        public static bool VerifyPassword(string password, string salt, string hashedPassword)
        {
            // Convert the salt from string to byte array
            byte[] saltBytes = Convert.FromBase64String(salt);

            // Hash the password with the stored salt
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000, // Updated to match the hashing function
                numBytesRequested: 32));

            // Compare the hashed password with the stored hashed password
            return hashed == hashedPassword;
        }
    }
}
