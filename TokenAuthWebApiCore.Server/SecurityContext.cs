using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TokenAuthWebApiCore.Server.Models;

namespace TokenAuthWebApiCore.Server
{
    public class SecurityContext : IdentityDbContext<MyUser>
    {
        public SecurityContext(DbContextOptions<SecurityContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;initial catalog=VS2017Db_TokenAuthWebApiCore.Server;persist security info=True;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }
    }
}