using Collection.DDD.EntityValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Collection.Api.DTO.Trade
{
    public class RequestTradePay : RequestOriBaseModel {

        [Required(ErrorMessage = "必须填写")]
        public string Subject { get; set; }
        [MoneyAttribute(MessageType.MoneyField, null, ErrorMessage = "交易金额格式有误!")]
        public string TransAmt { get; set; }
        [Required(ErrorMessage = "必须填写")]
        public string CardId { get; set; }
        [Required(ErrorMessage = "必须填写")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "必须填写")]
        public string AcctName { get; set; }
        [Required(ErrorMessage = "必须填写")]
        public string AcctIdcard { get; set; }
        [Required(ErrorMessage = "必须填写")]
        public string BankNum { get; set; }
        [Required(ErrorMessage = "必须填写")]
        public string AcctCardno { get; set; }
        [Required(ErrorMessage = "必须填写")]
        public string RetUrl { get; set; }
        [Required(ErrorMessage = "必须填写")]
        public string BgRetUrl { get; set; }

        public string MerPriv { get; set; }
        
        public string Extension { get; set; }
        [Required(ErrorMessage = "必须填写")]
        public string OrderId { get; set; }
        [MoneyAttribute(MessageType.MoneyField, null, ErrorMessage = "交易手续费率格式有误!")]
        public string TradeRate { get; set; }
        [MoneyAttribute(MessageType.MoneyField, null, ErrorMessage = "单笔提现费格式有误!")]
        public string DrawFee { get; set; }
    }
}
