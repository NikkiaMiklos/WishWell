namespace wish_well_1.Controllers.Csv
{
    public class UserCsvController
    {
        public bool CheckIfUserExists(string email)
        {
            var userExists = false;
            CsvController.ReadEachUserByLambda((User user) => {
                if (user.Email == email)
                {
                    userExists = true;
                }
            });
            return userExists;
        }
        public bool UserAdd(string name, string email, string pass)
        {
            var hashedPassword = SecurityHelper.Hash(pass);
            var encryptedEmail = SecurityHelper.Encrypt(email);
            if (!CheckIfUserExists(email))
            {
                return CsvController.AddUser(name, encryptedEmail, hashedPassword);
            }
            else
            {
                return true;
            }
        }
     }
}

