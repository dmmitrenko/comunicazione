﻿using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Infrastructure.DTO;
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
            CreateMap<Post, PostViewModel>();
            CreateMap<UserViewModelForCreation, User>();
            CreateMap<PostAddModel, Post>();
            CreateMap<User, UserFullNameModel>();
        }
    }
}
