using Collection.Api.DTO.Middle;
using Collection.DDD.Logger;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Collection.Api.Controllers {
    [ApiController]
    [Produces("application/json")]
    [Route("api/Test")]
    [EnableCors("AllowSameDomain")]
    public class TestController : Controller {
        [Route("test")]
        [HttpGet]
        public dynamic User() {
            string aaa = "接口显示测试页面";
            return new {
                aaa = aaa
            };
        }
        [Route("TestPay"),HttpPost]
        public string TestPay(AgentResponseModel model) {
            string paynotifystr = JsonConvert.SerializeObject(model);
            LoggerFactory.Instance.Logger_Info(paynotifystr, "TestPay");
            return "success";
        }
    }
}
