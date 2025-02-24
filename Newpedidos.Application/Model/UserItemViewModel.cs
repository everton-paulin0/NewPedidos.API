using System;
using System.Collections.Generic;
using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Model
{
    public class UserItemViewModel
    {
        public UserItemViewModel(int id, string username, string userEmail, string password)
        {
            Id = id;
            Username = username;
            UserEmail = userEmail;
            Password = password;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }

        public static UserItemViewModel FromEntityUser(User user)
           => new(user.Id, user.UserEmail, user.UserEmail, user.Password);
    }
}
