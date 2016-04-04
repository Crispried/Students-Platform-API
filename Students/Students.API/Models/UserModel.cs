using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Students.Domain.Entities;

namespace Students.API.Models
{
	public class UserModel
	{
		private readonly List<User> _listAccounts = new List<User>();

	    public UserModel()
	    {
			_listAccounts.Add(new User
			{
			    UserName = "acc1",
                Password = "111",
                Role = UserRole.Admin
			});

            _listAccounts.Add(new User
            {
                UserName = "acc2",
                Password = "111",
                Role = UserRole.Moderator
            });

            _listAccounts.Add(new User
            {
                UserName = "acc3",
                Password = "111",
                Role = UserRole.User
            });
        }

	    public User Find(string username)
	    {
	        return _listAccounts.FirstOrDefault(acc => acc.UserName.Equals(username));
	    }

	    public User Login(string username, string password)
	    {
	        return _listAccounts.FirstOrDefault(acc => acc.UserName.Equals(username) && acc.Password.Equals(password));
	    }
	}
}