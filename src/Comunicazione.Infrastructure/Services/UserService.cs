﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comunicazione.Core.Entities;
using Comunicazione.Infrastructure.DTO;

namespace Comunicazione.Infrastructure.Services
{
    public class UserService
    {
        public static UserAndPostModelView GetUserPosts(User user, IEnumerable<Post> posts )
        {
            var postsView = new Dictionary<int, PostViewModel>();
            foreach (var item in posts)
            {
                var model = new PostViewModel()
                {
                    Content = item.Content,
                    DateUpdated = item.DateUpdated
                };
                postsView.Add(item.PostId, model);
            }


            var response = new UserAndPostModelView()
            {
                Name = user.FirstName,
                Surname = user.LastName,
                UserPosts = postsView
            };

            return response;
        }
    }
}