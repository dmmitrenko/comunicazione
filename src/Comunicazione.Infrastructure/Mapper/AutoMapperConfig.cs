using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Core.Views.Users;
using Comunicazione.Core.Views.Adrresses;
using Comunicazione.Core.Views.Comments;
using Comunicazione.Core.Views.Posts;
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
            CreateMap<UserViewModelForCreation, User>();
            CreateMap<User, UserFullNameModel>();
            CreateMap<User, UserCountFollowersModel>()
                .ForMember(item => item.Followers, opt => opt.MapFrom(src => src.Followee.Count()));
            

            CreateMap<PostEditModel, Post>();
            CreateMap<Post, PostViewModel>()
                .ForMember(item => item.Author, opt => opt.MapFrom(src => src.User));

            CreateMap<CommentViewModelForCreation, Comment>();
            CreateMap<Comment, CommentViewModel>()
                .ForMember(item => item.Author, opt => opt.MapFrom(src => src.User));
            CreateMap<Comment, ReplyViewModel>();
                //.ForMember(item => item.Author, opt => opt.MapFrom(src => src.User));

            CreateMap<AddressViewModelForCreation, Address>();
            CreateMap<Address, AddressViewModel>()
                .ForMember(item => item.Resident, opt => opt.MapFrom(src => src.User));
        }
    }
}
