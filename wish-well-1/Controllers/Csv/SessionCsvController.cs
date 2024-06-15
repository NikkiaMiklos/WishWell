namespace wish_well_1.Controllers
{
    public class SessionCsvController
    {

        private bool TryLogin(string email, string password) {
            var hashedPassword = SecurityHelper.Hash(password);
            var encryptedEmail = SecurityHelper.Encrypt(email);

            var found = false;
            CsvController.ReadEachUserByLambda((User user) => {
                if (user.Password == hashedPassword && user.Email == encryptedEmail) {
                    found = true;
                }
            });
            return found;
        }

        public bool Login(string email, string password) {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
                return false;
            }

            return TryLogin(email,password);
        }
    }
}
