using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata.Ecma335;

namespace wish_well_1.Controllers.Excel
{
    public static class ExcelSession
    {
        private static string EncryptEmail(string email) {
            return SecurityHelper.Encrypt(email);

        }
        private static string HashPassword(string password) {
            return SecurityHelper.GetHashString(password);
        }
        private static bool TryLogin(string email, string password) {
            var hashedPassword = HashPassword(password);
            var encryptedEmail = EncryptEmail(email);

            return false;
        }
        public static bool Login(string email, string password) {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
                return false;
            }
 
            return TryLogin(email,password);
        }
    }
}
