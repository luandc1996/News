using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Dtos.User;
using News.Models;

namespace News.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Username = userModel.Username,
                Password = userModel.Password,
                Status = userModel.Status,
                Articles = userModel.Articles.Select(a => a.ToArticleDto()).ToList()
            };
        }
    }
}