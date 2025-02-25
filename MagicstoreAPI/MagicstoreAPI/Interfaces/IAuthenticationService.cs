using MagicstoreAPI.Infrastructures.DTO;

namespace MagicstoreAPI.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UsersToken> Authenticate(string Name, string Password);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> main
