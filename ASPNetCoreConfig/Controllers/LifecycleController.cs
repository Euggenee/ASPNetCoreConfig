using BussinessLayer.Lifecycle;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreConfig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifecycleController : ControllerBase
    {
        private readonly IScopedInterface _scopedInterface_1;
        private readonly IScopedInterface _scopedInterface_2;

        private readonly ITransientInterfase _transientInterfase_1;
        private readonly ITransientInterfase _transientInterfase_2;

        private readonly ISingletonInterfase _singletonInterfase_1;
        private readonly ISingletonInterfase _singletonInterfase_2;

        public LifecycleController(IApplicationDbContext applicationDbContext,
                                   IScopedInterface scopedInterface_1,
                                   IScopedInterface scopedInterface_2,
                                   ITransientInterfase transientInterfase_1,
                                   ITransientInterfase transientInterfase_2,
                                   ISingletonInterfase singletonInterfase_1,
                                   ISingletonInterfase singletonInterfase_2
            )
        {
            _scopedInterface_1 = scopedInterface_1;
            _scopedInterface_2 = scopedInterface_2;
            _transientInterfase_1 = transientInterfase_1;
            _transientInterfase_2 = transientInterfase_2;
            _singletonInterfase_1 = singletonInterfase_1;
            _singletonInterfase_2 = singletonInterfase_2;
        }

        [HttpGet]
        [Route("display-lifetime")]
        public ActionResult<object> DisplayLifetime()
        {
            var _scopedGuid_1 = _scopedInterface_1.GetGuid();
            var _scopedGuid_2 = _scopedInterface_2.GetGuid();

            var _transientGuid_1 = _transientInterfase_1.GetGuid();
            var _transientGuid_2 = _transientInterfase_2.GetGuid();

            var _singletonGuid_1 = _singletonInterfase_1.GetGuid();
            var _singletonGuid_2 = _singletonInterfase_2.GetGuid();

            return new ActionResult<object>(
         new { _scopedGuid_1, _scopedGuid_2, _transientGuid_1, _transientGuid_2, _singletonGuid_1, _singletonGuid_2 }
               );
        }
    }
}
