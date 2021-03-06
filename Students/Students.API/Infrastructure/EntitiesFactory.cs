﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Students.Domain.Entities;
using Students.Domain.ViewModel;

namespace Students.API.Infrastructure
{
    public static class EntitiesFactory
    {
        public static object GetViewModel(object obj, string objectType)
        {
            switch (objectType)
            {
                case EntitiesTypes.User:                    
                    return DefineUserVM((User)obj);
                case EntitiesTypes.UserAnnouncment:
                    return DefineUserAnnouncmentVM((User)obj);
                case EntitiesTypes.HousingAnnouncment:
                    return DefineHousingAnnouncmentVM((HousingAnnouncment)obj);
                case EntitiesTypes.TravelAnnouncment:
                    return DefineTravelAnnouncmentVM((TravelAnnouncment)obj);
                case EntitiesTypes.MarketAnnouncment:
                    return DefineMarketAnnouncmentVM((MarketAnnouncment)obj);
                case EntitiesTypes.ServiceAnnouncment:
                    return DefineServiceAnnouncmentVM((ServiceAnnouncment)obj);
                default:
                    return null;
            }
        }

        public static List<object> GetListViewModel(IQueryable<object> objects, string objectType)
        {
            switch (objectType)
            {
                case EntitiesTypes.User:
                    return DefineUserVMCollection(objects.ToList());
                case EntitiesTypes.UserAnnouncment:
                    return DefineUserAnnouncmentVMCollection(objects.ToList());
                case EntitiesTypes.HousingAnnouncment:
                    return DefineHousingAnnouncmentVMCollection(objects.ToList());
                case EntitiesTypes.TravelAnnouncment:
                    return DefineTravelAnnouncmentVMCollection(objects.ToList());
                case EntitiesTypes.MarketAnnouncment:
                    return DefineMarketAnnouncmentVMCollection(objects.ToList());
                case EntitiesTypes.ServiceAnnouncment:
                    return DefineServiceAnnouncmentVMCollection(objects.ToList());
                case EntitiesTypes.Comment:
                    return DefineCommentVMCollection(objects.ToList());
                default:
                    return null;
            }
        }

        private static UserVM DefineUserVM(User user)
        {
            UserVM userVM = new UserVM()
            {
                Id = user.UserId,
                GroupId = user.GroupId,
                UserName = user.UserName,
                Email = user.Email,
                Photo = user.Photo,
                RegisterDate = user.RegisterDate,
                LastVisit = user.LastVisit,
                Role = user.Role,
                Status = user.Status,
                Rate = user.Rate,
                Country = user.Country,
                City = user.City,
                Address = user.Address,
                University = user.University,
                Faculty = user.Faculty,
                Course = user.Course,
                GroupNumber = user.GroupNumber,
                Phone = user.Phone,
                About = user.About
            };
            return userVM;
        }

        private static List<object> DefineUserVMCollection(ICollection<object> users)
        {
            List<object> usersVM = new List<object>(users.Count);
            foreach (User user in users)
            {
                usersVM.Add(DefineUserVM(user));
            }
            return usersVM;
        }

        private static UserAnnouncmentVM DefineUserAnnouncmentVM(User user)
        {
            UserAnnouncmentVM userVM = new UserAnnouncmentVM()
            {
                UserName = user.UserName,
                Photo = user.Photo,
            };
            return userVM;
        }

        private static List<object> DefineUserAnnouncmentVMCollection(ICollection<object> users)
        {
            List<object> usersVM = new List<object>(users.Count);
            foreach (User user in users)
            {
                usersVM.Add(DefineUserAnnouncmentVM(user));
            }
            return usersVM;
        }

        private static HousingAnnouncmentVM DefineHousingAnnouncmentVM(HousingAnnouncment housingAnnouncment)
        {
            HousingAnnouncmentVM housingAnnouncmentVM = new HousingAnnouncmentVM()
            {
                Id = housingAnnouncment.HousingAnnouncmentId,
                Author = (UserAnnouncmentVM)GetViewModel(housingAnnouncment.User, "UserAnnouncment"),
                AddedDate = housingAnnouncment.AddedDate                
            };            
            HousingAnnouncmentLangVM tempHousingAnnouncmentLangVM;
            foreach (var housingAnnouncmentLangs in housingAnnouncment.HousingAnnouncmentLangs)
            {
                tempHousingAnnouncmentLangVM = new HousingAnnouncmentLangVM()
                {
                    LanguageId = housingAnnouncmentLangs.LanguageId,
                    Title = housingAnnouncmentLangs.Title,
                    Bulletin = housingAnnouncmentLangs.Bulletin
                };
                housingAnnouncmentVM.HousingAnnouncmentLangsVM.Add(tempHousingAnnouncmentLangVM);
            }
            ImageVM tempImageVM;
            foreach (HousingAnnouncmentImage image in housingAnnouncment.HousingAnnouncmentImages)
            {
                tempImageVM = new ImageVM()
                {
                    Url = image.Url
                };
                housingAnnouncmentVM.HousingAnnouncmentImagesVM.Add(tempImageVM);
            }
            return housingAnnouncmentVM;
        }

        private static List<object> DefineHousingAnnouncmentVMCollection(ICollection<object> housingAnnouncments)
        {
            List<object> housingAnnouncmentsVM = new List<object>(housingAnnouncments.Count);
            foreach (HousingAnnouncment housingAnnouncment in housingAnnouncments)
            {
                housingAnnouncmentsVM.Add(DefineHousingAnnouncmentVM(housingAnnouncment));
            }
            return housingAnnouncmentsVM;
        }

        private static TravelAnnouncmentVM DefineTravelAnnouncmentVM(TravelAnnouncment travelAnnouncment)
        {
            TravelAnnouncmentVM travelAnnouncmentVM = new TravelAnnouncmentVM()
            {
                Id = travelAnnouncment.TravelAnnouncmentId,
                Author = (UserAnnouncmentVM)GetViewModel(travelAnnouncment.User, "UserAnnouncment"),
                AddedDate = travelAnnouncment.AddedDate
            };
            TravelAnnouncmentLangVM tempTravelAnnouncmentLangVM;
            foreach (var travelAnnouncmentLangs in travelAnnouncment.TravelAnnouncmentLangs)
            {
                tempTravelAnnouncmentLangVM = new TravelAnnouncmentLangVM()
                {
                    LanguageId = travelAnnouncmentLangs.LanguageId,
                    Title = travelAnnouncmentLangs.Title,
                    Bulletin = travelAnnouncmentLangs.Bulletin
                };
                travelAnnouncmentVM.TravelAnnouncmentLangsVM.Add(tempTravelAnnouncmentLangVM);
            }
            ImageVM tempImageVM;
            foreach (TravelAnnouncmentImage image in travelAnnouncment.TravelAnnouncmentImages)
            {
                tempImageVM = new ImageVM()
                {
                    Url = image.Url
                };
                travelAnnouncmentVM.TravelAnnouncmentImagesVM.Add(tempImageVM);
            }
            return travelAnnouncmentVM;
        }

        private static List<object> DefineTravelAnnouncmentVMCollection(ICollection<object> travelAnnouncments)
        {
            List<object> travelAnnouncmentsVM = new List<object>(travelAnnouncments.Count);
            foreach (TravelAnnouncment travelAnnouncment in travelAnnouncments)
            {
                travelAnnouncmentsVM.Add(DefineTravelAnnouncmentVM(travelAnnouncment));
            }
            return travelAnnouncmentsVM;
        }

        private static MarketAnnouncmentVM DefineMarketAnnouncmentVM(MarketAnnouncment marketAnnouncment)
        {
            MarketAnnouncmentVM marketAnnouncmentVM = new MarketAnnouncmentVM()
            {
                Id = marketAnnouncment.MarketAnnouncmentId,
                Author = (UserAnnouncmentVM)GetViewModel(marketAnnouncment.User, "UserAnnouncment"),
                AddedDate = marketAnnouncment.AddedDate
            };
            MarketAnnouncmentLangVM tempMarketAnnouncmentLangVM;
            foreach (var marketAnnouncmentLangs in marketAnnouncment.MarketAnnouncmentLangs)
            {
                tempMarketAnnouncmentLangVM = new MarketAnnouncmentLangVM()
                {
                    LanguageId = marketAnnouncmentLangs.LanguageId,
                    Title = marketAnnouncmentLangs.Title,
                    Bulletin = marketAnnouncmentLangs.Bulletin
                };
                marketAnnouncmentVM.MarketAnnouncmentLangsVM.Add(tempMarketAnnouncmentLangVM);
            }
            ImageVM tempImageVM;
            foreach (MarketAnnouncmentImage image in marketAnnouncment.MarketAnnouncmentImages)
            {
                tempImageVM = new ImageVM()
                {
                    Url = image.Url
                };
                marketAnnouncmentVM.MarketAnnouncmentImagesVM.Add(tempImageVM);
            }
            return marketAnnouncmentVM;
        }

        private static List<object> DefineMarketAnnouncmentVMCollection(ICollection<object> marketAnnouncments)
        {
            List<object> marketAnnouncmentsVM = new List<object>(marketAnnouncments.Count);
            foreach (MarketAnnouncment marketAnnouncment in marketAnnouncments)
            {
                marketAnnouncmentsVM.Add(DefineMarketAnnouncmentVM(marketAnnouncment));
            }
            return marketAnnouncmentsVM;
        }

        private static ServiceAnnouncmentVM DefineServiceAnnouncmentVM(ServiceAnnouncment serviceAnnouncment)
        {
            ServiceAnnouncmentVM serviceAnnouncmentVM = new ServiceAnnouncmentVM()
            {
                Id = serviceAnnouncment.ServiceAnnouncmentId,
                Author = (UserAnnouncmentVM)GetViewModel(serviceAnnouncment.User, "UserAnnouncment"),
                AddedDate = serviceAnnouncment.AddedDate
            };
            ServiceAnnouncmentLangVM tempServiceAnnouncmentLangVM;
            foreach (var serviceAnnouncmentLangs in serviceAnnouncment.ServiceAnnouncmentLangs)
            {
                tempServiceAnnouncmentLangVM = new ServiceAnnouncmentLangVM()
                {
                    LanguageId = serviceAnnouncmentLangs.LanguageId,
                    Title = serviceAnnouncmentLangs.Title,
                    Bulletin = serviceAnnouncmentLangs.Bulletin
                };
                serviceAnnouncmentVM.ServiceAnnouncmentLangsVM.Add(tempServiceAnnouncmentLangVM);
            }
            ImageVM tempImageVM;
            foreach (ServiceAnnouncmentImage image in serviceAnnouncment.ServiceAnnouncmentImages)
            {
                tempImageVM = new ImageVM()
                {
                    Url = image.Url
                };
                serviceAnnouncmentVM.ServiceAnnouncmentImagesVM.Add(tempImageVM);
            }
            return serviceAnnouncmentVM;
        }

        private static List<object> DefineServiceAnnouncmentVMCollection(ICollection<object> serviceAnnouncments)
        {
            List<object> serviceAnnouncmentsVM = new List<object>(serviceAnnouncments.Count);
            foreach (ServiceAnnouncment serviceAnnouncment in serviceAnnouncments)
            {
                serviceAnnouncmentsVM.Add(DefineServiceAnnouncmentVM(serviceAnnouncment));
            }
            return serviceAnnouncmentsVM;
        }

        private static List<object> DefineCommentVMCollection(ICollection<object> comments)
        {
            List<object> housingCommentsVM = new List<object>(comments.Count);
            CommentVM tempCommentVM;
            ImageVM tempImageVM;
            foreach (HousingComment comment in comments)
            {
                tempCommentVM = new CommentVM()
                {
                    Id = comment.HousingCommentId,
                    AuthorId = comment.AuthorId,
                    Body = comment.Body,
                    AddedDate = comment.AddedDate
                };
                foreach(HousingCommentImage image in comment.HousingCommentImages)
                {
                    tempImageVM = new ImageVM()
                    {
                        Url = image.Url
                    };
                    tempCommentVM.CommentImagesVM.Add(tempImageVM);
                }
                housingCommentsVM.Add(tempCommentVM);
            }
            return housingCommentsVM;
        }
    }
}