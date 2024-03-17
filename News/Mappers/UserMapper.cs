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
            };
        }

        public static UserDto ToUserWithArticleDto(this User userModel)
        {
            return new UserArticleDto
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Articles = userModel.Articles?.Select(a => a.ToArticleDto()).ToList()
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Name = userDto.Name,
                Username = userDto.Username,
                Password = userDto.Password,
                Status = userDto.Status
            };
        }
    }
}