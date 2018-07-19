using Collection.DDD;
using Collection.DDD.Config;
using Collection.DDD.SOA;
using Newtonsoft.Json;
using System;
using System.Text;

namespace CollectiongInstallmentService {

    public abstract class ProcessorBase<TResponse, TResult> {
        private const string RequestEncodingName = "UTF-8";
        private const string ParameterEncodingName = "UTF-8";


        /// <summary>
        /// 执行调用api
        /// </summary>
        /// <returns></returns>
        public ExecResult<TResult> Execute() {
            var result = new ExecResult<TResult>();
            var target = string.Empty;
            var request = string.Empty;
            var response = string.Empty;
            DateTime? reqTime = null;
            DateTime? resTime = null;
            try {
                target = GetRequestUrl();
                request = PrepareRequest();
                reqTime = DateTime.Now;
                response = Collection.DDD.Utils.Http.HttpRequest.HttpRequestUtility.SendPostRequestCore(target, request, RequestEncodingName, null);
                resTime = DateTime.Now;
                result = ParseResponse(response);
            } catch (Exception ex) {
                Collection.DDD.Logger.LoggerFactory.Instance.Logger_Error(ex, "InstallmentService");
                result = new ExecResult<TResult> {
                    Success = false,
                    Message = ex.Message
                };
            }
            if (reqTime.HasValue) {
                Collection.DDD.Logger.LoggerFactory.Instance.Logger_Info(
                    string.Format("target:{1}{0}reqTime:{2:yyyy-MM-dd HH:mm:ss.fff}{0}request:{3}{0}resTime:{4:yyyy-MM-dd HH:mm:ss.fff}{0}response:{5}{0}",
                        Environment.NewLine, target, reqTime, request, resTime, response)
                    , "InstallmentService");
            }
            return result;
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private ExecResult<TResult> ParseResponse(string response) {
            var result = new ExecResult<TResult>();
            var view = JsonConvert.DeserializeObject<ResponseSignView>(response);
            if (!string.IsNullOrWhiteSpace(view.data)) {
                var signresponse = Encrpty.AESDecrypt(view.data, JsonConfig.JsonRead("aesKey", "Installment"));
                var responseView = JsonConvert.DeserializeObject<ResponseView>(signresponse);
                if (responseView.result == "100" || responseView.result == "200") {
                    Collection.DDD.Logger.LoggerFactory.Instance.Logger_Info(string.Format("response：{0},data:{1}", response, responseView.data), "InstallmentService");
                    result.Result = JsonConvert.DeserializeObject<TResult>(responseView.data);
                } else {
                    result.Success = false;
                    result.Message = responseView.errorMessage;
                }
            } else {
                result.Success = false;
                result.Message = view.sign;
            }
            return result;
        }

        /// <summary>
        /// 接口名称
        /// </summary>
        protected abstract string RequestService { get; }

        /// <summary>
        /// 接口地址
        /// </summary>
        protected abstract string ServiceAddress { get; }

        /// <summary>
        /// 是否添加时间戳
        /// </summary>
        protected virtual bool RequireTimeStamp {
            get { return true; }
        }

        /// <summary>
        /// 请求参数
        /// </summary>
        /// <returns></returns>
        protected abstract string PrepareRequestCore();

        protected virtual TResult ParseResponseCore(TResponse response) {
            throw new InvalidOperationException();
        }
        #region 方法
        /// <summary>
        /// 获取请求url
        /// </summary>
        /// <returns></returns>
        private string GetRequestUrl() {
            return ServiceAddress;
        }


        private string PrepareRequest() {
            var encoding = Encoding.GetEncoding(ParameterEncodingName);
            var parametersJson = PrepareRequestCore();

            var md5Str = Encrpty.MD5Encrypt(parametersJson + JsonConfig.JsonRead("md5Key", "Installment"));
            var aesStr = Encrpty.AESEecrypt(parametersJson, JsonConfig.JsonRead("aesKey", "Installment"));

            Collection.DDD.Logger.LoggerFactory.Instance.Logger_Info(string.Format("提交参数：{0}", parametersJson), "InstallmentService");

            var request = new RequestView() {
                data = aesStr,
                midPlatform = JsonConfig.JsonRead("md5Key", "midPlatform"),
                sign = md5Str,
                version = JsonConfig.JsonRead("md5Key", "version")
            };
            return JsonConvert.SerializeObject(request);
        }


        #endregion

        #region 返回信息实体
        /// <summary>
        /// 返回实体类
        /// </summary>
        class ResponseView {
            public string result { get; set; }
            public string data { get; set; }
            public string errorCode { get; set; }
            public string errorMessage { get; set; }

        }
        class ResponseSignView {
            public string sign { get; set; }
            public string data { get; set; }

        }
        #endregion

        #region 请求信息实体

        class RequestView {
            public string sign { get; set; }
            public string data { get; set; }
            public string midPlatform { get; set; }
            public string version { get; set; }
        }
        #endregion

    }
    public abstract class ProcessorBase<T> : ProcessorBase<T, T> {
    }
}
