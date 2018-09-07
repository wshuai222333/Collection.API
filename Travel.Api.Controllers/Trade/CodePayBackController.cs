using Microsoft.AspNetCore.Mvc;

namespace Collection.Api.Controllers.Trade {
    [Route("CodePayBack")]
    public class CodePayBackController : BaseController {
        public ActionResult PayBack() {
            return View();
        }
    }
}
