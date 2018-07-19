using Collection.Api.DTO;
using Collection.Api.DTO.User;
using Collection.Api.Service.User;
using CollectionApi.DTO.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Collection.Api.Controllers.User {
    [Produces("application/json")]
    [Route("api/User")]
    [EnableCors("AllowSameDomain")]
    public class UserController : BaseController {
        #region 注入服务
        public RegisteredService registeredService { get; set; }

        public UserLoginService userLoginService { get; set; }
        
        public ModifyPasswordService modifyPasswordService { get; set; }

        public AddAdviceService addAdviceService { get; set; }

        public GetUserListService getUserListService { get; set; }

        public AddProblemService addProblemService { get; set; }

        public GetProblemListService getProblemListService { get; set; }

        public GetProblemService getProblemService { get; set; }

        public ModifyProblemService modifyProblemService { get; set; }

        public DeleteProblemService deleteProblemService { get; set; }

        public ModifyMemberlevelService modifyMemberlevelService { get; set; }
        #endregion
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("Registered"), HttpPost]
        public async Task<ResponseMessageModel> Registered([FromBody]RequestRegisteredModel model) {
            return await Task.Run(() => registeredService.Execute(model));
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UserLogin"), HttpPost]
        public async Task<ResponseMessageModel> UserLogin([FromBody]RequestUserLoginModel model) {
            return await Task.Run(() => userLoginService.Execute(model));
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("UserPassword"), HttpPost]
        public async Task<ResponseMessageModel> UserPassword([FromBody]RequestModifyPassword model) {
            return await Task.Run(() => modifyPasswordService.Execute(model));
        }
     
        [Route("AddAdvice"), HttpPost]
        public async Task<ResponseMessageModel> AddAdvice([FromBody]RequestAddAdvice model) {
            return await Task.Run(() => addAdviceService.Execute(model));
        }
        [Route("UserList"), HttpPost]
        public async Task<ResponseMessageModel> UserList([FromBody]RequestGetUserList model) {
            return await Task.Run(() => getUserListService.Execute(model));
        }
        [Route("AddProblem"), HttpPost]
        public async Task<ResponseMessageModel> AddProblem([FromBody]RequestAddProblem model) {
            return await Task.Run(() => addProblemService.Execute(model));
        }
        [Route("GetProblemList"), HttpPost]
        public async Task<ResponseMessageModel> GetProblemList([FromBody]RequestGetProblemList model) {
            return await Task.Run(() => getProblemListService.Execute(model));
        }
        [Route("GetProblem"), HttpPost]
        public async Task<ResponseMessageModel> GetProblem([FromBody]RequestGetProblem model) {
            return await Task.Run(() => getProblemService.Execute(model));
        }
        [Route("ModifyProblem"), HttpPost]
        public async Task<ResponseMessageModel> ModifyProblem([FromBody]RequestModifyProblem model) {
            return await Task.Run(() => modifyProblemService.Execute(model));
        }
        [Route("DeleteProblem"), HttpPost]
        public async Task<ResponseMessageModel> DeleteProblem([FromBody]RequestDeleteProblem model) {
            return await Task.Run(() => deleteProblemService.Execute(model));
        }
        [Route("ModifyMemberlevel"), HttpPost]
        public async Task<ResponseMessageModel> ModifyMemberlevel([FromBody]RequestModifyMemberlevel model) {
            return await Task.Run(() => modifyMemberlevelService.Execute(model));
        }
    }
}
