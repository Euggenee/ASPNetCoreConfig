using BussinessLayer.Life;
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
    public class LifeController : ControllerBase
    {
        private readonly IScoupe _scoupe_1;
        private readonly IScoupe _scoupe_2;

        private readonly ITrans _trans_1;
        private readonly ITrans _trans_2;

        private readonly ISingl _singl_1;
        private readonly ISingl _singl_2;

        public LifeController(IScoupe scoupe_1,
                              IScoupe scoupe_2,
                              ITrans trans_1,
                              ITrans trans_2,
                              ISingl singl_1,
                              ISingl singl_2) 
        {

            _scoupe_1 = scoupe_1;
            _scoupe_2 = scoupe_2;
            _trans_1 = trans_1;
            _trans_2 = trans_2;
            _singl_1 = singl_1;
            _singl_2 = singl_2;
        }

        [HttpGet]
        public ActionResult<object> GetGuidStr()
        {
            var scoupeStr_1 = _scoupe_1.GetStr();
            var scoupeStr_2 = _scoupe_2.GetStr();
            var transStr_1 = _trans_1.GetStr();
            var transStr_2 = _trans_2.GetStr();
            var singlStr_1 = _singl_1.GetStr();
            var singlStr_2 = _singl_2.GetStr();

            return new ActionResult<object>(new {
                scoupeStr_1,
                scoupeStr_2,
                transStr_1,
                transStr_2,
                singlStr_1,
                singlStr_2

            });
        }

    }
}
