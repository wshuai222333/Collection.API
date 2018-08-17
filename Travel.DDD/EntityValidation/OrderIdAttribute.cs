using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.DDD.EntityValidation {
    
        /// <summary>
        /// 订单号验证
        /// </summary>
        [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
        public class OrderIdAttribute : EntityValidationAttribute {
            public OrderIdAttribute(MessageType messageType, params object[] args) :
                base(messageType, args) { }
            public override bool IsValid(object value) {
                if (value == null)
                    return false;
                else
                    return rOrderId.IsMatch(value.ToString().Trim());
            }
        }
    }
