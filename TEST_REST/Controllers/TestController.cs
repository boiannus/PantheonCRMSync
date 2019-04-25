using OmniMCloudPantheonWebApi.Helpers;
using System;
using System.Web.Http;

namespace TEST_REST.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string Get(string poruka)
        {
            return poruka;
        }

        [HttpPost]
        public string Post(string poruka, [FromBody]string bodyparam)
        {
            try
            {
                OmniHelper.Logger(bodyparam);
                return bodyparam;
            }
            catch(Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
