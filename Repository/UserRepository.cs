using Microsoft.EntityFrameworkCore;
using Session2_BoilerPlate.AppDbContext;
using Session2_BoilerPlate.Models;

namespace Session2_BoilerPlate.Repository
{
    public class UserRepository : IUserRepository
    {
        UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbContext)
        { 
            _userDbContext = userDbContext;
        }

        public List<UserModel> GetAllUsers()
        {
            return _userDbContext.users.ToList();
        }

        public bool AddUser(UserModel user)
        {
            _userDbContext.users.Add(user);
            return _userDbContext.SaveChanges() == 1 ? true : false;
        }

        public UserModel GetUserById(int userId)
        {
            var user = _userDbContext.users
                .Where(u => u.UserId == userId)
                .Select(u => new UserModel
                {
                   UserId = u.UserId,
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   Email = u.Email,
                   Address = u.Address

                })
                .FirstOrDefault();

            return user;
        }

        public bool UpdateUser(UserModel model)
        {
            
            var user = _userDbContext.users.FirstOrDefault(u => u.UserId == model.UserId);

            if (user == null)
                return false;

          
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Address = model.Address;
            _userDbContext.SaveChanges();

            return true;
        }



        public bool DeleteUser(int userId)
        {
            var user = _userDbContext.users.Find(userId);
            if (user != null)
            {
                _userDbContext.users.Remove(user);
                _userDbContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
