using Comunicazione.Core.Repositories;
using Comunicazione.Core.Services;
using Comunicazione.Infrastructure.Logging;
using Comunicazione.Infrastructure.Repositories;
using Comunicazione.Infrastructure.Services;
using Comunicazione.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunicazione.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IFollowRepository, FollowRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IFollowService, FollowService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IAddressService, AddressService>();
        }



    }
}
