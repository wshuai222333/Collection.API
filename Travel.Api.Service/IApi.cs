﻿using Collection.Api.DTO;
using Collection.Entity;

namespace Collection.Api.Service {
    /// <summary>
    /// 统一api接口类
    /// </summary>
    interface IApi<T> {
        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        ResponseMessageModel Execute(T t);
        ///// <summary>
        ///// 加入提交参数
        ///// </summary>
        ///// <param name="json"></param>
        //void SetData(RequestModel json);
    }
}
