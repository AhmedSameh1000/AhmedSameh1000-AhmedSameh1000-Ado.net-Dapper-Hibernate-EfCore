using EfCore1.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace EfCore3.ConfigurationWallet
{
	public class WalletMapping:ClassMapping<Wallet>
	{
        public WalletMapping()
        {
            Id(c => c.Id, c =>
            {
                c.Generator(Generators.Identity);
                c.Type(NHibernateUtil.Int32);
                c.Column("Id");
                c.UnsavedValue(0);
            });

            Property(c => c.Holder, c =>
            {
                c.Length(50);
                c.Type(NHibernateUtil.AnsiString);
                c.NotNullable(true);
            });  
            Property(c => c.Balance, c =>
            {
                c.Type(NHibernateUtil.Decimal);
                c.NotNullable(true);
            });
            Table("Wallets");
        }

    }

}
