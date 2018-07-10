﻿using Collection.Api.DTO;
using Collection.DDD;
using Collection.DDD.Logger;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;

namespace Collection.Api.Service {
    public abstract class ApiOriBase<P> : ApiBaseBase<P>
        where P : RequestOriBaseModel, new() {
        //初始化异步锁
        private static SemaphoreSlim _mutex = new SemaphoreSlim(5);

        protected ApiOriBase() {
        }
        /// <summary>
        /// 用户信息仓储
        /// </summary>
        //public InterfaceAccountRep interfaceAccountRep { get; set; }
        /// <summary>
        /// 返回实体
        /// </summary>
        public ResponseMessageModel Result { get; set; }

        public P Parameter { get; set; }

        protected abstract void ExecuteMethod();

        public override ResponseMessageModel Execute(P t) {
            _mutex.Wait();
            try {
                Parameter = t;
                Validate();
                ExecuteMethod();
            } catch (Exception ex) {
                #region 异常处理
                this.Result.Data = null;
                this.Result.ErrorCode = "9999";
                this.Result.Message = ex.Message;
                this.Result.IsSuccess = false;
                //日志记录
                StringBuilder DebugeInfo = new StringBuilder();
                DebugeInfo.Append("Parameter:" + JsonConvert.SerializeObject(this.Parameter) + "\r\n");
                DebugeInfo.Append("Exception:" + ex.Message + "|" + ex.StackTrace + "\r\n");
                LoggerFactory.Instance.Logger_Debug(DebugeInfo.ToString(), "ExecuteMethodError");
                #endregion
            }
            //异步锁释放
            _mutex.Release();
            return Result;
        }

        /// <summary>
        /// 验证
        /// </summary>
        protected void Validate() {
            //var _interfaceAccount = interfaceAccountRep.GetInterfaceAccount(new InterfaceAccount() { MerchantCode = this.Parameter.MerchantId });

            //验证sign
            if (!this.Parameter.Sign.Equals(GetMySign("5d39980acc6e4d6f91b04720c3414ef6"))) {
                throw new ApiSignException("Sign");
            }
            ////验证数据 
            //if (!this.Parameter.IsValid)
            //{
            //    throw new ValidationException("IsValid", this.Parameter.GetRuleViolationMessages());
            //}
        }
        /// <summary>
        /// 获取MySign
        /// </summary>
        private string GetMySign(string userkey) {
            //MySign =(MerchantId = 12345 & TimesTamp = 2017 - 01 - 25 10:21:49 & Ip=167.0.12.31 & MAC = aaaa)+UserKey的值
            string MySign = Encrpty.MD5Encrypt(string.Format(@"MerchantId={0}&TimesTamp={1}&Ip={2}&Mac={3}{4}"
                        , this.Parameter.MerchantId
                        , this.Parameter.TimesTamp
                        , this.Parameter.Ip
                        , this.Parameter.Mac
                        , userkey));

            return MySign;
        }

    }
}
