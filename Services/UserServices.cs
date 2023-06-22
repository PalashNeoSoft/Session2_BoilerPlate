using Session2_BoilerPlate.Models;
using Session2_BoilerPlate.Repository;

namespace Session2_BoilerPlate.Services
{
    public class UserServices : IUserServices
    {
         readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(UserModel user)
        {
            var userExists = _userRepository.GetUserById(user.UserId);
            if (userExists == null)
            {
                return _userRepository.AddUser(user);
            }
            return false;
        }

        public bool DeleteUser(int userId)
        {
            return _userRepository.DeleteUser(userId);
        }

        public UserModel GetUser(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public bool UpdateUser(UserModel user)
        {
            return _userRepository.UpdateUser(user);    
        }

        public List<UserModel> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
