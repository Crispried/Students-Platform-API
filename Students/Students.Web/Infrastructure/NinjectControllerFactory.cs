using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Students.Domain.Abstract;
using Students.Domain.Concrete;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;

namespace Students.Web.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IUserRepository>().To<EFUserRepository>();
            ninjectKernel.Bind<IGroupRepository>().To<EFGroupRepository>();
            ninjectKernel.Bind<IHousingAnnouncmentRepository>().To<EFHousingAnnouncmentRepository>();
            ninjectKernel.Bind<ITravelAnnouncmentRepository>().To<EFTravelAnnouncmentRepository>();
            ninjectKernel.Bind<IMarketAnnouncmentRepository>().To<EFMarketAnnouncmentRepository>();
            ninjectKernel.Bind<IServiceAnnouncmentRepository>().To<EFServiceAnnouncmentRepository>();
            ninjectKernel.Bind<IPrivateMessageRepository>().To<EFPrivateMessageRepository>();
            ninjectKernel.Bind<ICommentRepository>().To<EFCommentRepository>();

        }
    }