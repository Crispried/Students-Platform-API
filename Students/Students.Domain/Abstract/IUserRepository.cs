using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Students.Domain.Entities;
using System.Threading.Tasks;

namespace Students.Domain.Abstract
{
    public interface IUserRepository
    {
        /// <summary>
        /// get all users from database
        /// </summary>
        IQueryable<User> Users { get; }

        /// <summary>
        /// saves user in database
        /// </summary>
        /// <param name="user"></param>
        bool SaveUser(User user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Login(string username, string password);

        /// <summary>
        /// deletes user which id = userId from database
        /// </summary>
        /// <param name="userId"></param>
        bool DeleteUser(int userId);

        /// <summary>
        /// returns user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetUserById(int userId);

        /// <summary>
        /// returns user by username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetUserByUserName(string userName);

        /// <summary>
        /// returns user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetUserByEmail(string email);

        /// <summary>
        /// if oldPassword is validate (user.Password == oldPassword) changes user's password to newPassword
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newPassword"></param>
        /// <param name="oldPassword"></param>
        bool ChangePassword(int userId, string newPassword, string oldPassword);

        /// <summary>
        /// depending on newUserRole changes role of the user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newUserRole"></param>
        bool ChangeRole(int userId, UserRole newUserRole);

        /// <summary>
        /// depending on newUserStatus changes status of the user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newUserStatus"></param>
        bool ChangeStatus(int userId, UserStatus newUserStatus);

        /// <summary>
        /// depending on rateAction increases or decreases user rate by one
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rateAction"></param>
        bool ChangeRate(int userId, RateAction rateAction);

        /// <summary>
        /// Sets the LastVisit field to current time of server
        /// </summary>
        /// <param name="userId"></param>
        bool SetLastVisit(int userId);

        /// <summary>
        ///     if user is admin of group - group will be destroyed,
        /// your groupId and groupId of all users which belong to
        /// group will be equals null
        ///     else if you are not admin of group - your groupId
        /// will be equals null
        /// </summary>
        /// <param name="userId"></param>
        bool LeaveGroup(int userId);
    }
}
