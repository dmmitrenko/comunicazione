using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserViewModelForCreation>();
            CreateMap<Post, PostViewModel>()
                .ForMember(item => item.Author, opt => opt.MapFrom(src => src.User));      
            CreateMap<UserViewModelForCreation, User>();
            CreateMap<PostEditModel, Post>();
            CreateMap<User, UserFullNameModel>();
            CreateMap<User, UserCountFollowersModel>()
                .ForMember(item => item.Followers, opt => opt.MapFrom(src => src.Follower.Count()));
        }
    }
}
