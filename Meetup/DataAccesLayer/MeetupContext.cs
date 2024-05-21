using Meetup.Models;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DataAccesLayer
{
    public class MeetupContext : DbContext
    {
        public MeetupContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Speakers> Speakers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server =CA-R214-PC05\\SQLEXPRESS; Database = Meetupp; Trusted_Connection = True; TrustServerCertificate=True;");
            base.OnConfiguring(options);
        }
    }
}
