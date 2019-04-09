using Microsoft.EntityFrameworkCore;

namespace SqlServerRepository.DataObject
{
    public partial class SqlServerDbContext : DbContext
    {
        private const string ConnectionString =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\project\\C#\\Parking\\SqlServerRepository\\db.mdf;Integrated Security=True;Connect Timeout=30";

        public SqlServerDbContext()
        {
        }

        public SqlServerDbContext(
            DbContextOptions<SqlServerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BoyDo> Boy { get; set; }
        public virtual DbSet<BoyLotDo> BoyLot { get; set; }
        public virtual DbSet<LotSpotDo> LotSpot { get; set; }
        public virtual DbSet<TicketDo> Ticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<BoyDo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<BoyLotDo>(entity =>
            {
                entity.HasKey(e => new {e.BoyId, e.LotId});

                entity.Property(e => e.BoyId)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.LotId)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LotSpotDo>(entity =>
            {
                entity.HasKey(e => new {e.LotId, e.SpotId})
                    .HasName("PK__LotSpot__2776AA556F16D603");

                entity.Property(e => e.LotId)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SpotId)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TicketDo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CarId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.LotId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SpotId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });
        }
    }
}