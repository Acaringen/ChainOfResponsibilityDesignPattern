using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResponsibility.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-2R1QUB5;initial catalog=DesignPattern;integrated security=true;TrustServerCertificate=True;");
        }

        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
