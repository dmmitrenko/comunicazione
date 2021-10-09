using AutoMapper;
using Comunicazione.Core.Entities;
using Comunicazione.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Post, PostViewModel>();
            }).CreateMapper();

            return config;
        }
    }
}
