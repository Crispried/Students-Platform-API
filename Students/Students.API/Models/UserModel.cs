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

	    public User Find(string username)
	    {
	        return _listAccounts.FirstOrDefault(acc => acc.UserName.Equals(username));
	    }

	    public User Login(string username, string password)
	    {
	        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
	        {
                return null;
            }

            return _listAccounts.FirstOrDefault(acc => acc.UserName.Equals(username) && acc.Password.Equals(password));
	    }
	}
}