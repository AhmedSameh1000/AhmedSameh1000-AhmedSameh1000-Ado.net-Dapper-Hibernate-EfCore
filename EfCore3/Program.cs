using EfCore1.Model;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using Configuration = NHibernate.Cfg.Configuration;

namespace EfCore3
{
	public static class Program
	{
		static void Main(string[] args)
		{
			SendCash(2, 1, 50000);
			AllWallets().Print();
		}
		public static ISession CreateSession()
		{
			var Config = new ConfigurationBuilder()
				.AddJsonFile("AppSetting.json")
				.Build();
			var ConStr = Config.GetSection("ConStr").Value;
			var Mapper = new ModelMapper();
			Mapper.AddMappings(typeof(Wallet).Assembly.ExportedTypes);
			HbmMapping DomapinMapping = Mapper.CompileMappingForAllExplicitlyAddedEntities();
			var HbConfig = new Configuration();
			HbConfig.DataBaseIntegration(c =>
			{
				c.Driver<MicrosoftDataSqlClientDriver>();
				c.Dialect<MsSql2012Dialect>();
				c.ConnectionString = ConStr;
				//c.LogSqlInConsole = true;
				//c.LogFormattedSql = true;
			});
			HbConfig.AddMapping(DomapinMapping);


			var SessionFactory=HbConfig.BuildSessionFactory();
			var Session=SessionFactory.OpenSession();
			return Session;
		}
		public static IEnumerable<Wallet> AllWallets()
		{
			using (var Session = CreateSession())
			{
				using var Transaction = Session.BeginTransaction();
				var Wallets = Session.Query<Wallet>();
				return Wallets.ToList();
			}
		}	
		public static Wallet GetById(int id)
		{
			using (var Session = CreateSession())
			{
				using var Transaction = Session.BeginTransaction();
				var Wallet = Session.Query<Wallet>().FirstOrDefault(c=>c.Id==id);
				return Wallet;
			}
		}
		public static void Print<T>(this IEnumerable<T> Source)
		{
			foreach (var item in Source)
			{
				Console.WriteLine($"{item}");
			}
		}
		public static void Insert(Wallet wallet)
		{

			using (var Session = CreateSession())
			{
				using var Transaction = Session.BeginTransaction();
			
				Session.Save(wallet);
				Transaction.Commit();
			}
		}
	
		public static void Update(Wallet wallet)
		{
			using (var Session = CreateSession())
			{
				using var Transaction = Session.BeginTransaction();

				Session.Update(wallet);
				Transaction.Commit();
			}
		}
		public static void Delete(int ID)
		{
			using (var Session = CreateSession())
			{
				using var Transaction = Session.BeginTransaction();
				var Walllet = GetById(ID);
				if (Walllet is null)
				{
					return;
				}
				Session.Delete(Walllet);
				Transaction.Commit();
			}
		}

		public static void SendCash(int from,int to,int amount)
		{
			using (var Session = CreateSession())
			{
				using var Transaction = Session.BeginTransaction();
			
				var UserToSend=GetById(from);
				var UserToRecive=GetById(to);
				if (UserToSend.Balance < amount)
				{
					return;
				}
				UserToSend.Balance -= amount;
				UserToRecive.Balance += amount;

				Session.Update(UserToSend);
				Session.Update(UserToRecive);
				Transaction.Commit();
			}
		}
	}
}
