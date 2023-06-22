using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Session2_BoilerPlate.Models;
using Session2_BoilerPlate.Services;

namespace Session2_BoilerPlate.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public UserController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            /* var users = _userServices.GetAllUsers();
             return View(users);*/

            var users = _userServices.GetAllUsers();
            var userModels = _mapper.Map<List<UserModel>>(users);
            return View(userModels);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult AddUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var userModel = _mapper.Map<UserModel>(user);
                _userServices.AddUser(userModel);
                return RedirectToAction("Index");
            }
            return View(user);


            /* if(ModelState.IsValid)
             {
                 _userServices.AddUser(user);
                 return RedirectToAction("Index");
             }
             return View(user);*/
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = _userServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = _mapper.Map<UserModel>(user);

            return View(userViewModel);

            /*var user = _userServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);*/
        }

        [HttpPost]
        public IActionResult EditUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var userModel = _mapper.Map<UserModel>(user);
                _userServices.UpdateUser(userModel);
                return RedirectToAction("Index");
            }
            return View(user);

            /*if (ModelState.IsValid)
            {
                _userServices.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);*/
        }

        [HttpGet]
        public IActionResult GetUser(int id)
        {
            var user = _userServices.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = _mapper.Map<UserModel>(user);

            return View(userViewModel);

            /*var user = _userServices.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);*/
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {

            var user = _userServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            var userViewModel = _mapper.Map<UserModel>(user);

            return View(userViewModel);

            /*var user = _userServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);*/
        }

        [HttpPost]
        public IActionResult DeletedUser(int id)
        {
            _userServices.DeleteUser(id);
            return RedirectToAction("Index");
        }








    }
}
