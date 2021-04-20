using Milenium.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Milenium.ControllerFactories
{
    public class LocalizationControllerFactory : IControllerFactory
    {
        private readonly IControllerFactory innerControllerFactory;
        private readonly LocalizationManager localizationManager;

        public LocalizationControllerFactory()
        {
            innerControllerFactory = new DefaultControllerFactory();
            localizationManager = new LocalizationManager();
        }
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            localizationManager.SetSelectedCultureInfo(requestContext.HttpContext);
            return innerControllerFactory.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return innerControllerFactory.GetControllerSessionBehavior(requestContext, controllerName);
        }

        public void ReleaseController(IController controller)
        {
            innerControllerFactory.ReleaseController(controller);
        }
    }
}