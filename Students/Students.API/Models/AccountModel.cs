using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.API.Models
{
	public class AccountModel
	{
		private readonly List<Account> _listAccounts = new List<Account>();

	    public AccountModel()
	    {
			_listAccounts.Add(new Account
			{
			    Username = "acc1",
                Password = "111",
                Roles = new string[]
                {
                    "superadmin", "admin", "employee"
                }
			});

            _listAccounts.Add(new Account
            {
                Username = "acc2",
                Password = "111",
                Roles = new string[]
                {
                    "admin", "employee"
                }
            });

            _listAccounts.Add(new Account
            {
                Username = "acc3",
                Password = "111",
                Roles = new string[]
                {
                    "employee"
                }
            });
        }

	    public Account Find(string username)
	    {
	        return _listAccounts.FirstOrDefault(acc => acc.Username.Equals(username));
	    }

	    public Account Login(string username, string password)
	    {
	        return _listAccounts.FirstOrDefault(acc => acc.Username.Equals(username) && acc.Password.Equals(password));
	    }
	}
}