﻿using Collection.Entity.CollectionModel;
using PetaPoco.NetCore;
using System.Collections.Generic;

namespace Collection.PetaPoco.Repositories.Collection {
    public class UserAccountRep
    {
        public object Insert(UserAccount model) {
            return  CollectionDB.GetInstance().Insert(model);
        }

        public int Update(UserAccount model) {
            return CollectionDB.GetInstance().Update(model);
        }

        public int UpdateMemberlevel(int UserAccountId,int Memberlevel) {
            string wherestr = string.Empty;
            wherestr = " AND UserAccountId=" + UserAccountId;
            string sql = string.Format("SET Memberlevel={0} WHERE 1=1 {1}", Memberlevel, wherestr);
            return CollectionDB.GetInstance().Update<UserAccount>(sql);
        }
        public int UpdateIsQrcode(int UserAccountId, int IsQrcode,decimal Rate,decimal DrawFee) {
            string wherestr = string.Empty;
            wherestr = " AND UserAccountId=" + UserAccountId;
            string sql = string.Format("SET IsQrcode={0},Rate={2},DrawFee = {3} WHERE 1=1 {1}", IsQrcode, wherestr, Rate, DrawFee);
            return CollectionDB.GetInstance().Update<UserAccount>(sql);
        }
        public int UpdateRate(int UserAccountId, decimal Rate,decimal UserDrawFee) {
            string wherestr = string.Empty;
            wherestr = " AND UserAccountId=" + UserAccountId;
            string sql = string.Format("SET UserRate={0},UserDrawFee = {2} WHERE 1=1 {1}", Rate, wherestr, UserDrawFee);
            return CollectionDB.GetInstance().Update<UserAccount>(sql);
        }
        public UserAccount GetUserAccount(UserAccount model) {
            #region sql
            string wherestr = string.Empty;
            if (!string.IsNullOrEmpty(model.UserName)) {
                wherestr += " AND (UserName = @0 OR Phone = @0)";
            }
            if (!string.IsNullOrEmpty(model.UserPwd)) {
                wherestr += " AND UserPwd = @1";
            }
            if (model.UserAccountId >0) {
                wherestr += " AND UserAccountId  = @2";
            }
            string sql = string.Format(@"
            SELECT  *
            FROM    dbo.UserAccount
            WHERE   1 = 1
            {0}
            ", wherestr);
            #endregion
            return CollectionDB.GetInstance().SingleOrDefault<UserAccount>(sql,
                              model.UserName, model.UserPwd,model.UserAccountId);
        }
        public Page<UserAccount> GetUserList(int pageindex, int pagesize,string UserName,string Phone,int UserAccountId) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            if (!string.IsNullOrWhiteSpace(UserName)) {
                wherestr += " and UserName =@0 ";
            }
            if (!string.IsNullOrWhiteSpace(Phone)) {
                wherestr += " and Phone =@1 ";
            }
            if (UserAccountId>0) {
                wherestr += " and UserAccountId =@2 ";
            }
            sql = string.Format(@"
SELECT  *
FROM    dbo.UserAccount
WHERE 1=1 {0}
ORDER BY CreateTime DESC", wherestr);
            return CollectionDB.GetInstance().Page<UserAccount>(pageindex, pagesize, sql, UserName, Phone, UserAccountId);
        }
        public List<UserAccount> GetUserList(string UserName, string Phone, int UserAccountId,int IsQrcode) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            if (!string.IsNullOrWhiteSpace(UserName)) {
                wherestr += " and UserName =@0 ";
            }
            if (!string.IsNullOrWhiteSpace(Phone)) {
                wherestr += " and Phone =@1 ";
            }
            if (UserAccountId > 0) {
                wherestr += " and UserAccountId =@2 ";
            }
            if (IsQrcode > 0) {
                wherestr += " and IsQrcode =@3 ";
            }
            sql = string.Format(@"
SELECT  *
FROM    dbo.UserAccount
WHERE 1=1 {0}
ORDER BY CreateTime DESC", wherestr);
            return CollectionDB.GetInstance().Fetch<UserAccount>(sql, UserName, Phone, UserAccountId, IsQrcode);
        }

        public int AddIntegral(int UserAccountId,int Integral,int? Memberlevel) {
            string wherestr = string.Empty;
            wherestr += " AND UserAccountId=" + UserAccountId;
            string setstr = string.Empty;
            if (Memberlevel!=null) {
                setstr += ",Memberlevel="+ Memberlevel;
            }
            string sql = string.Format("SET Integral={0}{2} WHERE 1=1 {1}", Integral, wherestr, setstr);
            return CollectionDB.GetInstance().Update<UserAccount>(sql);
        }
    }
}
