namespace WebBanGiay.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DoAn_WebBanGiay.Models.myDbQL_BanGiay>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DoAn_WebBanGiay.Models.myDbQL_BanGiay";
        }

        protected override void Seed(DoAn_WebBanGiay.Models.myDbQL_BanGiay context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
