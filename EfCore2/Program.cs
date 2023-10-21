using Dapper;
using EfCore1.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Transactions;

namespace EfCore2
{
	public static class Program
	{
		static void Main(string[] args)
		{


			SendCash(1, 2, 100);
			
			var result = GetAllWalllets();
			
			result.Print();


		}
		public static IDbConnection StartConnection()
		{
			var configuration = new ConfigurationBuilder()
			.AddJsonFile("AppSetting.json")
			.Build();
			IDbConnection Connection = new SqlConnection(configuration.GetSection("ConStr").Value);
			return Connection;
		}
		public static void Print<T>(this IEnumerable<T> sourse)
		{
			foreach (var wallet in sourse)
			{
				Console.WriteLine(wallet);
			}
		}
		public static IEnumerable<Wallet> GetAllWalllets()
		{
			var DbConnection = StartConnection();
			var q = "Select * from Wallets";
			var resultAsDynamic = DbConnection.Query<Wallet>(q);
			return resultAsDynamic;
		}
		public static Wallet GetById(int id)
		{
			var DbConnection = StartConnection();
			var q = "Select * from Wallets where Id=@Id";
			var IdParam=new {Id= id};
			var Result = DbConnection.QuerySingleOrDefault<Wallet>(q,IdParam);
			if (Result is null)
				return null;
			return Result;
		}
		
		public static void Insert(Wallet wallet)
		{
			var DbConnection = StartConnection();
			var q = "Insert Into Wallets (Holder,Balance) " +
				"values (@Holder,@Balance)";

			DbConnection.Execute(q, 
				new { Holder = wallet.Holder, Balance = wallet.Balance });
		
		}
		public static void Update(Wallet wallet)
		{
			var db=StartConnection();
			var sql = "Update Wallets set Holder=@Holder,Balance=@Balance" +
				" Where Id =@Id";
			var Parameter = new
			{
				Id = wallet.Id,
				Holder = wallet.Holder,
				Balance = wallet.Balance
			};
			db.Execute(sql, Parameter);
		}	
		public static void Delete(int id)
		{
			var Db=StartConnection();
			var q = "Delete From Wallets Where Id=@Id";
			var IdParam = new { Id = id };
			Db.Execute(q, IdParam);
		}

		public static void SendCash(int from, int to, decimal cash)
		{
			var db = StartConnection();
		

			using (var TransactionScobe = new TransactionScope())
			{
				var UserHowSendCash = GetById(from);
				var UserHowReciveCash = GetById(to);

				if (UserHowSendCash.Balance < cash)
				{
					Console.WriteLine("Not Enuph Money to Send Cash");
					return;
				}

				db.Execute("Update Wallets Set Balance=@Balance Where Id=@Id", new { Id = from, Balance = UserHowSendCash.Balance - cash });
				db.Execute("Update Wallets Set Balance=@Balance Where Id=@Id",new { Id = to, Balance = UserHowReciveCash.Balance + cash });

				TransactionScobe.Complete();
			}
	

		


		}
	
	}
}
