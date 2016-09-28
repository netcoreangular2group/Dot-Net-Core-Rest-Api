using Simpl.Core.Models;
using Simpl.Core.Databases;
using Dapper;
using System.Threading.Tasks;
using System.Linq;

namespace Simpl.Core.Services
{
    public interface IUserService
    {
        Task<bool> Login(User user);
    }
    public class UserService : IUserService
    {
        public readonly IDatabase _db;
        public UserService(IDatabase db)
        {
            _db = db;
        }
        public async Task<bool> Login(User user)
        {
            using (var connection = _db.OpenConnection())
            {
                var result = (await connection.QueryAsync<User>(
                    @"SELECT Id,UserName,PasswordHash 
                        FROM [dbo].[Core_User]
                        WHERE UserName = @UserName AND PasswordHash = @Password",
                    param: new
                    {
                        UserName = user.UserName,
                        //Password = user.Password
                    })).FirstOrDefault();
                return result != null;
            }
        }
    }
}
