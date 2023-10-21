using EfCore1.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace EfCore1
{
	public static class Program
	{
		static void Main(string[] args)
		{

			SendCashV2(2, 1, 5000);
			GetWallets().Print();


		}

		public static void Print(this IEnumerable<Wallet> sourse)
		{
			foreach (var wallet in sourse)
			{
				Console.WriteLine(wallet.ToString());
			}
		}
		public static SqlConnection StartConnection()
		{
			var configuration = new ConfigurationBuilder()
			.AddJsonFile("AppSetting.json")
			.Build();
			var Connection = new SqlConnection(configuration.GetSection("ConStr").Value);
			return Connection;
		}
		public static IEnumerable<Wallet> GetWallets()
		{
			var con = StartConnection();
			var q = "Select * from Wallets";
			SqlCommand command = new SqlCommand(q, con);
			con.Open();
			SqlDataReader Reader = command.ExecuteReader();
			command.CommandType = CommandType.Text;

			var Wallets = new List<Wallet>();


			while (Reader.Read())
			{
				var Wallet = new Wallet()
				{
					Id = Convert.ToInt32(Reader["Id"]),
					Holder = Reader.GetString("Holder"),
					Balance = Reader.GetDecimal("Balance")
				};

				Wallets.Add(Wallet);
			}

			con.Close();

			return Wallets;
		}
		public static void Insert(Wallet wallet)
		{
			
		
			var q = "Insert Into Wallets (Holder,Balance) Values (@Holder,@Balance)";

			var con = StartConnection();
			con.Open();
			SqlCommand command = new SqlCommand(q, con);

			var HolderParametar = new SqlParameter()
			{
				ParameterName = "@Holder",
				SqlDbType = SqlDbType.VarChar,
				Direction = ParameterDirection.Input,
				Value = wallet.Holder
			};
			var BalanceParametar = new SqlParameter()
			{
				ParameterName = "@Balance",
				SqlDbType = SqlDbType.Decimal,
				Direction = ParameterDirection.Input,
				Value = wallet.Balance
			};
			command.Parameters.Add(HolderParametar);
			command.Parameters.Add(BalanceParametar);


			command.CommandType = CommandType.Text;
			command.ExecuteNonQuery();

			con.Close();

		}
		public static void InsertUsingProc(Wallet wallet)
		{

			var con = StartConnection();
			con.Open();
			SqlCommand command = new SqlCommand("AddWallet", con);

			var HolderParametar = new SqlParameter()
			{
				ParameterName = "@Holder",
				SqlDbType = SqlDbType.VarChar,
				Direction = ParameterDirection.Input,
				Value = wallet.Holder
			};
			var BalanceParametar = new SqlParameter()
			{
				ParameterName = "@Balance",
				SqlDbType = SqlDbType.Decimal,
				Direction = ParameterDirection.Input,
				Value = wallet.Balance
			};
			command.Parameters.Add(HolderParametar);
			command.Parameters.Add(BalanceParametar);


			command.CommandType = CommandType.StoredProcedure;
			command.ExecuteNonQuery();

			con.Close();

		}
		public static void UpdateWallet(int Id,string Holder,decimal Balance)
		{
			var con = StartConnection();
			con.Open();
			var q = "Update Wallets set Holder = @Holder,Balance=@Balance where Id=@Id";



			var IdParametar = new SqlParameter()
			{
				ParameterName = "@Id",
				SqlDbType = SqlDbType.Int,
				Direction = ParameterDirection.Input,
				Value = Id
			};		
			var HolderParametar = new SqlParameter()
			{
				ParameterName = "@Holder",
				SqlDbType = SqlDbType.VarChar,
				Direction = ParameterDirection.Input,
				Value = Holder
			};
			var BalanceParametar = new SqlParameter()
			{
				ParameterName = "@Balance",
				SqlDbType = SqlDbType.Decimal,
				Direction = ParameterDirection.Input,
				Value = Balance
			};
			SqlCommand command = new SqlCommand(q, con);
			command.Parameters.Add(HolderParametar);
			command.Parameters.Add(BalanceParametar);
			command.Parameters.Add(IdParametar);
			command.CommandType = CommandType.Text;
			command.ExecuteNonQuery();
			con.Close();
		}
		public static void DeleteWallet(int Id)
		{
			var con = StartConnection();
			con.Open();
			var q = "Delete From  Wallets where Id=@Id";
			var IdParametar = new SqlParameter()
			{
				ParameterName = "@Id",
				SqlDbType = SqlDbType.Int,
				Direction = ParameterDirection.Input,
				Value = Id
			};
			SqlCommand command = new SqlCommand(q, con);
			command.Parameters.Add(IdParametar);
			command.CommandType = CommandType.Text;
			command.ExecuteNonQuery();
			con.Close();
		}
		public static void SendCashV2(int idFrom, int IdTo, decimal amount)
		{
			var con = StartConnection();
			con.Open();
			var Command = con.CreateCommand();
			Command.CommandType = CommandType.Text;
			var Transaction = con.BeginTransaction();
			Command.Transaction = Transaction;

			var IdFromUser = new SqlParameter()
			{
				ParameterName = "@IdFrom",
				SqlDbType = SqlDbType.Int,
				Direction = ParameterDirection.Input,
				Value = idFrom
			};

			var IdToUser = new SqlParameter()
			{
				ParameterName = "@IdTo",
				SqlDbType = SqlDbType.Int,
				Direction = ParameterDirection.Input,
				Value = IdTo
			};

			var AmountFromUser = new SqlParameter()
			{
				ParameterName = "@Amount",
				SqlDbType = SqlDbType.Decimal,
				Direction = ParameterDirection.Input,
				Value = amount
			};

			Command.Parameters.Add(IdFromUser);
			Command.Parameters.Add(IdToUser);
			Command.Parameters.Add(AmountFromUser);

			try
			{
				// Check if there are sufficient funds in the 'IdFrom' account
				Command.CommandText = "SELECT Balance FROM Wallets WHERE Id = @IdFrom";
				decimal balance = (decimal)Command.ExecuteScalar();
				if (balance < amount)
				{
					Console.WriteLine($"No Enaph Cach to Send {amount} Your Balance is {balance}");
					return;
				}

				if (balance >= amount)
				{
					Command.CommandText = "UPDATE Wallets SET Balance = (Balance - @Amount) WHERE Id = @IdFrom";
					Command.ExecuteNonQuery();

					Command.CommandText = "UPDATE Wallets SET Balance = (Balance + @Amount) WHERE Id = @IdTo";
					Command.ExecuteNonQuery();
					Transaction.Commit();
				}
				
					// Insufficient funds, you can handle this case as needed
					// For example, throw an exception or return an error code
				
			}
			catch (Exception)
			{
				try
				{
					Transaction.Rollback();
				}
				catch
				{
					// Handle the rollback failure, if necessary
				}
			}
			finally
			{
				try
				{
					con.Close();
				}
				catch
				{
					// Handle the connection close failure, if necessary
				}
			}
		}
	}
}