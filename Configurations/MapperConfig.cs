using AutoMapper;
using Session2_BoilerPlate.AppDbContext;
using Session2_BoilerPlate.Models;

namespace Session2_BoilerPlate.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<User,UserModel>().ReverseMap();
        }
    }
}
