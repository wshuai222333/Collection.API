using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.DDD.EntityValidation
{
    /// <summary>
    /// 数字验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class MoneyAttribute : EntityValidationAttribute {
        public MoneyAttribute(MessageType messageType, params object[] args) :
            base(messageType, args) { }
        public override bool IsValid(object value) {
            if (value == null)
                return false;
            else
                return rcheckMoneyFormat.IsMatch(value.ToString().Trim());
        }
    }
}
