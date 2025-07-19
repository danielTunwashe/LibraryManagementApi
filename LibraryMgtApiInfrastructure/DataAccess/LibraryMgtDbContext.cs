
using LibraryMgtApiDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryMgtApiInfrastructure.DataAccess
{
    //inheriting from DbContext, which is the primary class responsible for interacting with the database in Entity Framework Core.
    public class LibraryMgtDbContext : DbContext
    {
        //It allows EF Core to know how to connect to the database, what features to enable (lazy loading, tracking behavior, etc.),
        //and which database provider to use. 
        public LibraryMgtDbContext(DbContextOptions<LibraryMgtDbContext> options)
            //So, you're passing the options from your constructor to the base class so it can initialize all its internal infrastructure.
            : base(options)
        {
        }

        // DbSet properties represent the tables in your database.
        public DbSet<User> users { get; set; }
        public DbSet<UserProfile> userProfiles { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<BookGenre> bookGenres { get; set; }
        public DbSet<Book> books { get; set; }


        //is like your blueprint configuration method for defining how your C# classes map to SQL tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Here you can configure your entities, relationships, and other model configurations.
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<UserProfile>()
                .HasKey(up => up.Id);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId);

            modelBuilder.Entity<Author>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            // Composite primary key for BookGenre
            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });

            modelBuilder.Entity<Genre>()
                .HasKey(genres => genres.Id);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.BookGenres)
                .WithOne(bg => bg.Book)
                .HasForeignKey(bg => bg.BookId);

            modelBuilder.Entity<Genre>()
                .HasMany(g => g.BookGenres)
                .WithOne(bg => bg.Genre)
                .HasForeignKey(bg => bg.GenreId);

        }
    }

}
