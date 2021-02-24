using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101Assignment2Navaneeth.Controllers
{
    public class MathController : ApiController
    {
        // create a controller which inputs two numbers and returns the difference
        [HttpGet]
        [Route("api/math/Difference/{var1}/{var2}")]
        public int Difference(int var1, int var2)
        {
            return var1 - var2;
        }
        [HttpGet]
        [Route("api/math/Addition/{var1}/{var2}")]
        public int Addition(int var1, int var2)
        {
            return var1 + var2;
        }
    }
}
