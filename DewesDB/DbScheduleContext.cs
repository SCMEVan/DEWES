using DEWESDb.Table;
using Microsoft.EntityFrameworkCore;

namespace DEWESDb
{
    public class DbScheduleContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Конфигурация по умолчанию для миграций и тестовых запусков
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=IVAN-PC\SQLEXPRESS;Database=DEWES;User Id=sa;Password=qwerty_123;");
        }

        public DbScheduleContext(){}
        public DbScheduleContext(DbContextOptions dbContextOptions) : base(dbContextOptions){}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}