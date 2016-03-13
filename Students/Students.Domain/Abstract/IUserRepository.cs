﻿using System;
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
        void SaveUser(User user);

        /// <summary>
        /// deletes user which id = userId from database
        /// </summary>
        /// <param name="userId"></param>
        void DeleteUser(int userId);

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
        void ChangePassword(int userId, string newPassword, string oldPassword);

        /// <summary>
        /// depending on newUserRole changes role of the user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newUserRole"></param>
        void ChangeRole(int userId, UserRole newUserRole);

        /// <summary>
        /// depending on newUserStatus changes status of the user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newUserStatus"></param>
        void ChangeStatus(int userId, UserStatus newUserStatus);

        /// <summary>
        /// depending on rateAction increases or decreases user rate by one
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rateAction"></param>
        void ChangeRate(int userId, RateAction rateAction);

        /// <summary>
        /// Sets the LastVisit field to current time of server
        /// </summary>
        /// <param name="userId"></param>
        void SetLastVisit(int userId);

        /// <summary>
        ///     if user is admin of group - group will be destroyed,
        /// your groupId and groupId of all users which belong to
        /// group will be equals null
        ///     else if you are not admin of group - your groupId
        /// will be equals null
        /// </summary>
        /// <param name="userId"></param>
        void LeaveGroup(int userId);
    }
}
