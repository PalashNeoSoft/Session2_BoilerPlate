using Session2_BoilerPlate.Models;

namespace Session2_BoilerPlate.Services
{
    public interface IUserServices
    {
        bool AddUser(UserModel user);

        bool UpdateUser(UserModel user);

        bool DeleteUser(int userId);

        UserModel GetUser(int userId);
        List<UserModel> GetAllUsers();

    }
}
