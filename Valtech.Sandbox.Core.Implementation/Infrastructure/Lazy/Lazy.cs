using System;
using EPiServer.Framework.Cache;
using EPiServer.Globalization;
using StructureMap;
using Valtech.Sandbox.Core.Infrastructure.Lazy;

namespace Valtech.Sandbox.Core.Implementation.Infrastructure.Lazy
{
    /// <summary>
    /// Lazy initialization of StructureMap dependencies
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Lazy<T> : ILazy<T>
    {
        private IContainer _container;
		public Lazy(IContainer container)
        {
            this._container = container;
        }

        public abstract T Load(IContainer container);
        
        public T Service
        {
	        get
	        {
		        T entity = Load(_container);
                
				return entity;
	        }
        }


    }
}
