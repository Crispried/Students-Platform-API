using System;
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
                case EntitiesTypes.UserType:                    
                    return DefineUserVM((User)obj);
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
                case EntitiesTypes.UserType:
                    return DefineUserVMCollection(objects.ToList());
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

        private static UserVM  DefineUserVM(User user)
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
            foreach(User user in users)
            {
                usersVM.Add(DefineUserVM(user));
            }
            return usersVM;
        }

        private static HousingAnnouncmentVM DefineHousingAnnouncmentVM(HousingAnnouncment housingAnnouncment)
        {
            HousingAnnouncmentVM housingAnnouncmentVM = new HousingAnnouncmentVM()
            {
                Id = housingAnnouncment.HousingAnnouncmentId,
                AuthorId = housingAnnouncment.AuthorId,
                AddedDate = housingAnnouncment.AddedTime                
            };
            HousingAnnouncmentLangVM tempHousingAnnouncmentLangVM;
            foreach (var housingAnnouncmentLangs in housingAnnouncment.HousingAnnouncmentLangs)
            {
                tempHousingAnnouncmentLangVM = new HousingAnnouncmentLangVM()
                {
                    Title = housingAnnouncmentLangs.Title,
                    Bulletin = housingAnnouncmentLangs.Bulletin
                };
                housingAnnouncmentVM.HousingAnnouncmentLangsVM.Add(tempHousingAnnouncmentLangVM);
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
                AuthorId = travelAnnouncment.AuthorId,
                AddedDate = travelAnnouncment.AddedTime
            };
            TravelAnnouncmentLangVM tempTravelAnnouncmentLangVM;
            foreach (var travelAnnouncmentLangs in travelAnnouncment.TravelAnnouncmentLangs)
            {
                tempTravelAnnouncmentLangVM = new TravelAnnouncmentLangVM()
                {
                    Title = travelAnnouncmentLangs.Title,
                    Bulletin = travelAnnouncmentLangs.Bulletin
                };
                travelAnnouncmentVM.TravelAnnouncmentLangsVM.Add(tempTravelAnnouncmentLangVM);
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
                AuthorId = marketAnnouncment.AuthorId,
                AddedDate = marketAnnouncment.AddedTime
            };
            MarketAnnouncmentLangVM tempMarketAnnouncmentLangVM;
            foreach (var marketAnnouncmentLangs in marketAnnouncment.MarketAnnouncmentLangs)
            {
                tempMarketAnnouncmentLangVM = new MarketAnnouncmentLangVM()
                {
                    Title = marketAnnouncmentLangs.Title,
                    Bulletin = marketAnnouncmentLangs.Bulletin
                };
                marketAnnouncmentVM.MarketAnnouncmentLangsVM.Add(tempMarketAnnouncmentLangVM);
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
                AuthorId = serviceAnnouncment.AuthorId,
                AddedDate = serviceAnnouncment.AddedTime
            };
            ServiceAnnouncmentLangVM tempServiceAnnouncmentLangVM;
            foreach (var serviceAnnouncmentLangs in serviceAnnouncment.ServiceAnnouncmentLangs)
            {
                tempServiceAnnouncmentLangVM = new ServiceAnnouncmentLangVM()
                {
                    Title = serviceAnnouncmentLangs.Title,
                    Bulletin = serviceAnnouncmentLangs.Bulletin
                };
                serviceAnnouncmentVM.ServiceAnnouncmentLangsVM.Add(tempServiceAnnouncmentLangVM);
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
            foreach (HousingComment comment in comments)
            {
                tempCommentVM = new CommentVM()
                {
                    Id = comment.HousingCommentId,
                    AuthorId = comment.AuthorId,
                    Body = comment.Body,
                    AddedDate = comment.AddedTime
                };
                housingCommentsVM.Add(tempCommentVM);
            }
            return housingCommentsVM;
        }
    }
}