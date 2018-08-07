

using Collection.DDD.Config;
using PetaPoco.NetCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Collection.Entity.CollectionModel
{

	 public partial class CollectionDB : Database
     {
        private static SqlConnection con;
        /// <summary>
        /// open the connection
        /// </summary>
        /// <returns></returns>
        private static SqlConnection OpenConnection()
        {
            if (con == null)
            {
                con = new SqlConnection(GetConn());
            }
            else
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
            }
            return con;
        }

		private static string GetConn()
        {
            return JsonConfig.JsonRead("collectioConnection");
        }

        private static SqlConnection OpenConnection(string name)
        {
            if (con == null)
            {
                con = new SqlConnection(JsonConfig.JsonRead(name));
            }
            else
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
            }
            return con;
        }


        public CollectionDB() : base(OpenConnection())
        {
            CommonConstruct();
        }

        public CollectionDB(string connectionStringName) : base(OpenConnection(connectionStringName))
        {
            CommonConstruct();
        }

        partial void CommonConstruct();

        public interface IFactory
        {
            CollectionDB GetInstance();
        }

        public static IFactory Factory { get; set; }
        public static CollectionDB GetInstance()
        {
            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance();
            else
                return new CollectionDB();
        }

        [ThreadStatic] static CollectionDB _instance;

        public override void OnBeginTransaction()
        {
            if (_instance == null)
                _instance = this;
        }

        public override void OnEndTransaction()
        {
            if (_instance == this)
                _instance = null;
        }

		public static int BulkUpdate<T>(string tableName, List<T> data, Func<T, string> funColumns) 
        {
            try
            {
			    using (SqlConnection conn = OpenConnection())
                {
                    conn.Open();

                    String sql = "";

                    foreach (var item in data)
                    {
                        sql += string.Format("UPDATE dbo.[{0}] SET {1} ;", tableName, funColumns(item));
                    }

                    SqlCommand comm = new SqlCommand()
                    {
                        CommandText = sql,
                        Connection = conn
                    };

                    return comm.ExecuteNonQuery();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public class Record<T> where T : new()
        {
            public static CollectionDB repo { get { return CollectionDB.GetInstance(); } }
            public bool IsNew() { return repo.IsNew(this); }
            public object Insert() { return repo.Insert(this); }

            public void Save() { repo.Save(this); }
            public int Update() { return repo.Update(this); }

            public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
            public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
            public static int Update(Sql sql) { return repo.Update<T>(sql); }
            public int Delete() { return repo.Delete(this); }
            public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
            public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
            public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
            public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
            public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
            public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
            public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
            public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
            public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
            public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
            public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
            public static T Single(Sql sql) { return repo.Single<T>(sql); }
            public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
            public static T First(Sql sql) { return repo.First<T>(sql); }
            public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
            public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }

            public static List<T> Fetch(int page, int itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }

            public static List<T> SkipTake(int skip, int take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
            public static List<T> SkipTake(int skip, int take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
            public static Page<T> Page(int page, int itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
            public static Page<T> Page(int page, int itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
            public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
            public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }

        }

    }


	
	 [TableName("dbo.Advice")]
	 [PrimaryKey("AdviceId")]
	 [ExplicitColumns]
     public partial class Advice:CollectionDB.Record<Advice>
	 {
		
		[Column] public int AdviceId {get;set;}
		[Column] public int? UserAccountId {get;set;}
		[Column] public string AdviceContent {get;set;}
		[Column] public DateTime? CreateTime {get;set;}
		
	 }
	
	 [TableName("dbo.Problem")]
	 [PrimaryKey("ProblemId")]
	 [ExplicitColumns]
     public partial class Problem:CollectionDB.Record<Problem>
	 {
		
		[Column] public int ProblemId {get;set;}
		[Column] public DateTime? CreateTime {get;set;}
		[Column] public string Title {get;set;}
		[Column] public string Body {get;set;}
		[Column] public DateTime? MotifyTime {get;set;}
		
	 }
	
	 [TableName("dbo.BankCard")]
	 [PrimaryKey("BankCardId")]
	 [ExplicitColumns]
     public partial class BankCard:CollectionDB.Record<BankCard>
	 {
		
		[Column] public int BankCardId {get;set;}
		[Column] public string CardId {get;set;}
		[Column] public string BankName {get;set;}
		[Column] public string BankCode {get;set;}
		[Column] public string Phone {get;set;}
		[Column] public string AcctName {get;set;}
		[Column] public int? Type {get;set;}
		[Column] public int? UserAccountId {get;set;}
		[Column] public DateTime? CreateTime {get;set;}
		[Column] public string AcctIdCard {get;set;}
		
	 }
	
	 [TableName("dbo.Agent")]
	 [PrimaryKey("AgentId")]
	 [ExplicitColumns]
     public partial class Agent:CollectionDB.Record<Agent>
	 {
		
		[Column] public int AgentId {get;set;}
		[Column] public string MerchantName {get;set;}
		[Column] public string MerchantIP {get;set;}
		[Column] public DateTime? CreateTime {get;set;}
		[Column] public long? CreateUserID {get;set;}
		[Column] public DateTime? UpdateTime {get;set;}
		[Column] public long? UpdateUserID {get;set;}
		[Column] public string MerchantCode {get;set;}
		[Column] public string UserKey {get;set;}
		
	 }
	
	 [TableName("dbo.AgentTrade")]
	 [PrimaryKey("AgentTradeId")]
	 [ExplicitColumns]
     public partial class AgentTrade:CollectionDB.Record<AgentTrade>
	 {
		
		[Column] public int AgentTradeId {get;set;}
		[Column] public string TradeOrderId {get;set;}
		[Column] public decimal? Amount {get;set;}
		[Column] public string CardId {get;set;}
		[Column] public string MobileNo {get;set;}
		[Column] public string BankNum {get;set;}
		[Column] public string AcctCardNo {get;set;}
		[Column] public string AcctName {get;set;}
		[Column] public string AcctIdCard {get;set;}
		[Column] public decimal? TradeRate {get;set;}
		[Column] public DateTime? CreateTime {get;set;}
		[Column] public int? State {get;set;}
		[Column] public string PlatFormId {get;set;}
		[Column] public int? AgentId {get;set;}
		[Column] public string RetUrl {get;set;}
		[Column] public string BgRetUrl {get;set;}
		[Column] public string Subject {get;set;}
		
	 }
	
	 [TableName("dbo.UserAccount")]
	 [PrimaryKey("UserAccountId")]
	 [ExplicitColumns]
     public partial class UserAccount:CollectionDB.Record<UserAccount>
	 {
		
		[Column] public int UserAccountId {get;set;}
		[Column] public string UserName {get;set;}
		[Column] public string UserPwd {get;set;}
		[Column] public DateTime? CreateTime {get;set;}
		[Column] public DateTime? ModifyTime {get;set;}
		[Column] public int? Memberlevel {get;set;}
		[Column] public string Phone {get;set;}
		[Column] public int? Integral {get;set;}
		
	 }
	
	 [TableName("dbo.Trade")]
	 [PrimaryKey("TradeId")]
	 [ExplicitColumns]
     public partial class Trade:CollectionDB.Record<Trade>
	 {
		
		[Column] public int TradeId {get;set;}
		[Column] public string TradeOrderId {get;set;}
		[Column] public decimal? Amount {get;set;}
		[Column] public string CardId {get;set;}
		[Column] public string MobileNo {get;set;}
		[Column] public string BankName {get;set;}
		[Column] public string BankNum {get;set;}
		[Column] public string AcctCardNo {get;set;}
		[Column] public string AcctName {get;set;}
		[Column] public string AcctIdCard {get;set;}
		[Column] public decimal? TradeRate {get;set;}
		[Column] public string TradeRateCode {get;set;}
		[Column] public DateTime? CreateTime {get;set;}
		[Column] public int? State {get;set;}
		[Column] public string FailMessage {get;set;}
		[Column] public int? UserAccountId {get;set;}
		[Column] public string PlatFormId {get;set;}
		
	 }

}








