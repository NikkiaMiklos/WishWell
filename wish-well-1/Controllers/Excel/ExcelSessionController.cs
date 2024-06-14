using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata.Ecma335;

namespace wish_well_1.Controllers.Excel
{
    public class ExcelSessionController
    {
        private string EncryptEmail(string email) {
            return SecurityHelper.Encrypt(email);

        }
        private string HashPassword(string password) {
            return SecurityHelper.Hash(password);
        }
        private bool TryLogin(string email, string password) {
            var hashedPassword = HashPassword(password);
            var encryptedEmail = EncryptEmail(email);

            return false;
        }
        public bool Login(string email, string password) {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
                return false;
            }
 
            return TryLogin(email,password);
        }
    }
}
