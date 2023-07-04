using Music.Repository.ApplicationContext;
using Music.Web.UnitOfWork;
using Music.Web.Utilities.Contracts;
using Music.Web.Utilities.Implementation;
using Ninject;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Music.Web.IOC
{

    public class NinjectController : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectController()
        {
            ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<Context>().To<Context>();
            ninjectKernel.Bind<IUnitOfWork>().To<UOW>();
            ninjectKernel.Bind<IEmailSender>().To<EmailSender>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, "not found");
            }

            return (IController)ninjectKernel.Get(controllerType);
        }
    }

}