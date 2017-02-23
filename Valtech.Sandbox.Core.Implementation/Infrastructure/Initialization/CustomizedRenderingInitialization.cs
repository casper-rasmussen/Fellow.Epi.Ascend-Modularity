using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using Valtech.Sandbox.Core.Implementation.Infrastructure.Mvc;

namespace Valtech.Sandbox.Core.Implementation.Infrastructure.Initialization
{
    [InitializableModule]
    public class CustomizedRenderingInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            //Add custom view engine allowing partials to be placed in additional locations
            //Note that we add it first in the list to optimize view resolving when using DisplayFor/PropertyFor
            ViewEngines.Engines.Insert(0, new EPiServerViewEngine());

        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}
