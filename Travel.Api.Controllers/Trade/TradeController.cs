using Collection.Api.DTO;
using Collection.Api.DTO.Trade;
using Collection.Api.Service.Trade;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Collection.Api.Controllers.Trade {
    [Produces("application/json")]
    [Route("api/Trade")]
    [EnableCors("AllowSameDomain")]
    public class TradeController : BaseController {
        #region 注入服务
        public AddTradeService addTradeService { get; set; }

        public GetTradeListService getTradeListService { get; set; }
        #endregion

        [Route("AddTrade"), HttpPost]
        public async Task<ResponseMessageModel> AddTrade([FromBody]RequestAddTrade model) {
            return await Task.Run(() => addTradeService.Execute(model));
        }
       
        [Route("GetTradeList"), HttpPost]
        public async Task<ResponseMessageModel> GetTradeList([FromBody]RequestGetTradeList model) {
            return await Task.Run(() => getTradeListService.Execute(model));
        }
       
    }
}
