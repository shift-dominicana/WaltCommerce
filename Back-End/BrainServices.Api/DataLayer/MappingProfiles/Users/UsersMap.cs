using AutoMapper;
using DataLayer.Models.Users;
using DataLayer.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.MappingProfiles.Users
{
    public class UsersMap:Profile
    {
        public UsersMap()
        {
            CreateMap<User,UserViewModel>();
        }
    }
}
