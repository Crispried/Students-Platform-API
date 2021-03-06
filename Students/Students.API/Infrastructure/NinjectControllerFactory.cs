﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Students.Domain.Abstract;
using Students.Domain.Concrete;
using Ninject;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Ninject.Syntax;
using Ninject.Web.Common;

namespace Students.API.Infrastructure
{
    public class NinjectControllerFactory
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            // Install our Ninject-based IDependencyResolver into the Web API config
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }

        private static void RegisterServices(StandardKernel kernel)
        {
            kernel.Bind<IUserRepository>().To<EFUserRepository>();
            kernel.Bind<IGroupRepository>().To<EFGroupRepository>();
            kernel.Bind<IHousingAnnouncmentRepository>().To<EFHousingAnnouncmentRepository>();
            kernel.Bind<ITravelAnnouncmentRepository>().To<EFTravelAnnouncmentRepository>();
            kernel.Bind<IMarketAnnouncmentRepository>().To<EFMarketAnnouncmentRepository>();
            kernel.Bind<IServiceAnnouncmentRepository>().To<EFServiceAnnouncmentRepository>();
            kernel.Bind<IPrivateMessageRepository>().To<EFPrivateMessageRepository>();
            kernel.Bind<ICommentRepository>().To<EFCommentRepository>();
        }
    }

    public class NinjectDependencyScope : IDependencyScope
    {
        IResolutionRoot resolver;

        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return resolver.TryGet(serviceType);
        }

        public System.Collections.Generic.IEnumerable<object> GetServices(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return resolver.GetAll(serviceType);
        }

        public void Dispose()
        {
            IDisposable disposable = resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            resolver = null;
        }
    }

    // This class is the resolver, but it is also the global scope
    // so we derive from NinjectScope.
    public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver
    {
        IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }
}