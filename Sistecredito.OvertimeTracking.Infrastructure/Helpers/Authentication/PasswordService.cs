using Sistecredito.OvertimeTracking.Infrastructure.Interfaces.Authentication;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Sistecredito.OvertimeTracking.Infrastructure.Helpers.Authentication
{
    public class PasswordService : IPasswordService
    {
        public string EncryptPassword(string password)
        {
            // Generar un salt aleatorio
            string salt = BCryptNet.GenerateSalt();

            // Generar el hash de la contraseña con el salt
            string hashedPassword = BCryptNet.HashPassword(password, salt);

            return hashedPassword;
        }

        public async Task<bool> VerifyPassword(string password, string hashedPassword)
        {
            return BCryptNet.Verify(password, hashedPassword);
        }
    }
}
