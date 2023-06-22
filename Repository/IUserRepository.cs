using Session2_BoilerPlate.Models;

namespace Session2_BoilerPlate.Repository
{
    public interface IUserRepository
    {
        bool AddUser(UserModel user);

        UserModel GetUserById(int userId);
        bool UpdateUser(UserModel model);

        bool DeleteUser(int userId);

        List<UserModel> GetAllUsers();

    }
}
