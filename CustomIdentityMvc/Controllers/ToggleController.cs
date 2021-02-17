using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomIdentityMvc.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToggleController : ControllerBase
    {
        public ActionResult<bool> Index()
        {
            return Singleton.Flag;
        }

        public ActionResult<bool> Invoke()
        {
            Singleton.Toggle();

            return Singleton.Flag;
        }
    }
}
