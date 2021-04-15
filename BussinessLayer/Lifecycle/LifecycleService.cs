using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Lifecycle
{
    public class LifecycleService : IScopedInterface, ITransientInterfase, ISingletonInterfase
    {
        private readonly string GuidStrting;

        public LifecycleService()
        {
            GuidStrting = Guid.NewGuid().ToString();
        }
        public string GetGuid()
        {
            return GuidStrting;
        }
    }
}
