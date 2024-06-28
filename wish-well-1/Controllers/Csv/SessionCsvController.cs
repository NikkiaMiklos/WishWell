namespace wish_well_1.Controllers
{
    public class SessionCsvController
    {

        private User? TryLogin(string email, string password) {
            var hashedPassword = SecurityHelper.Hash(password);
            var encryptedEmail = SecurityHelper.Encrypt(email);

            User? found = null;
            CsvController.ReadEachUserByLambda((User user) => {
                if (user.Password == hashedPassword && user.Email == encryptedEmail) {
                    found = user;
                }
            });
            return found;
        }

        public User? Login(string email, string password) {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
                return null;
            }

            return TryLogin(email,password);
        }
    }
}
