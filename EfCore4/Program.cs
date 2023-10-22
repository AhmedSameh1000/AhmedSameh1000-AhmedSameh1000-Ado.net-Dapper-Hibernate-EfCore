using EfCore4.Data;
using EfCore4.Model;
namespace EfCore4
{
	public static class Program
	{
		static void Main(string[] args)
		{
		



			GetAll().Print();

		}



		public static IEnumerable<Wallet> GetAll()
		{
			var Context=new AppDbContext();
			var Wallets = Context.Wallets;
			return Wallets;
		}

		public static string InsertWallet(Wallet wallet)
		{
			using var Context=new AppDbContext();
			Context.Wallets.Add(wallet);
			var RowEfected = 0;
			try
			{
				 RowEfected = Context.SaveChanges();
			 	 return $"{RowEfected} RowEfected";

			}
			catch
			{
				return $"{RowEfected} RowEfected Faild";
			}
		}
		public static int SendCash(int from, int to, decimal cash)
		{
			using (var Context = new AppDbContext())
			{
				using (var transaction = Context.Database.BeginTransaction())
				{
					var UserTosend = GetById(from);
					var userToRecive = GetById(to);
					if (UserTosend is null || userToRecive is null)
					{
						return -1;
					}
					if (UserTosend.Balance < cash)
					{
						Console.WriteLine("not Enuph Cash");
						return -1;
					}
					var RowsEfected = 0;
					try
					{
						UserTosend.Balance -= cash;
						Context.Update(UserTosend);
						RowsEfected += Context.SaveChanges();
						userToRecive.Balance += cash;
						Context.Update(userToRecive);
						RowsEfected += Context.SaveChanges();
					}
					catch 
					{

					}
					transaction.Commit();
					return RowsEfected;
				}
			}
			
		}

		public static int UpdateWallet(Wallet wallet)
		{
			using var Context=new AppDbContext();
			Context.Wallets.Update(wallet);

			var RowsEfected = 0;
			try
			{
				 RowsEfected = Context.SaveChanges();
				return RowsEfected;
			}
			catch 
			{
				return RowsEfected;
			}
		
		}
		public static void Print<T>(this IEnumerable<T> Source)
		{
			foreach (var source in Source)
			{
				Console.WriteLine(source);
			}
		}

		public static void Print<T>(this T Item) 
		{
			Console.WriteLine(Item);
		}

		public static Wallet GetById(int id)
		{
			using var Context=new AppDbContext();
			var Item = Context.Wallets.Find(id);
			return Item;
		}

		public static int DeleteData(int id)
		{
			var Context=new AppDbContext();
			Context.Wallets.Remove(GetById(id));

			var RowsEfected = 0;
			try
			{
				RowsEfected= Context.SaveChanges();
			}
			catch (Exception)
			{
				
			}
			return RowsEfected;
		}
	}
}