using AMZEnterpriseWebsite.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMZEnterpriseWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Certificate

            builder.Entity<Certificate>()
                .Property(x => x.Title)
                .HasMaxLength(256)
                .IsRequired();

            builder.Entity<Certificate>()
                .Property(x => x.Url)
                .HasMaxLength(1000);

            #endregion

            #region Contact

            builder.Entity<Contact>()
                .Property(x => x.UserFullName)
                .HasMaxLength(256)
                .IsRequired();

            builder.Entity<Contact>()
                .Property(x => x.EmailOrPhoneNumber)
                .HasMaxLength(256)
                .IsRequired();

            builder.Entity<Contact>()
                .Property(x => x.Subject)
                .HasMaxLength(256)
                .IsRequired();

            builder.Entity<Contact>()
                .Property(x => x.Body)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Entity<Contact>()
                .Property(x => x.Ip)
                .HasMaxLength(256)
                .IsRequired();

            #endregion

            #region Post

            builder.Entity<Post>()
                .Property(x => x.Title)
                .HasMaxLength(256)
                .IsRequired();

            builder.Entity<Post>()
                .Property(x => x.Body)
                .HasMaxLength(10000)
                .IsRequired();

            builder.Entity<Post>()
                .Property(x => x.Tags)
                .HasMaxLength(1000);

            #endregion

            #region PostCategory

            builder.Entity<PostCategory>()
                .Property(x => x.Title)
                .HasMaxLength(256)
                .IsRequired();

            #endregion

            #region PostComment

            builder.Entity<PostComment>()
                .Property(x => x.UserFullName)
                .HasMaxLength(256);

            builder.Entity<PostComment>()
                .Property(x => x.Email)
                .HasMaxLength(256);

            builder.Entity<PostComment>()
                .Property(x => x.Body)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Entity<PostComment>()
                .Property(x => x.Ip)
                .HasMaxLength(256)
                .IsRequired();

            #endregion

            #region Setting

            builder.Entity<Setting>()
                .Property(x => x.Phone1)
                .HasMaxLength(20);

            builder.Entity<Setting>()
                .Property(x => x.Phone2)
                .HasMaxLength(20);

            builder.Entity<Setting>()
                .Property(x => x.Email1)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.Email2)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.Instagram)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.Telegram)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.GooglePlus)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.FaceBook)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.LinkedIn)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.Youtube)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.Aparat)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.GitHub)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.WalletName1)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.WalletAddress1)
                .HasMaxLength(1000);

            builder.Entity<Setting>()
                .Property(x => x.WalletName2)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.WalletAddress2)
                .HasMaxLength(1000);

            builder.Entity<Setting>()
                .Property(x => x.WalletName3)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.WalletAddress3)
                .HasMaxLength(1000);

            builder.Entity<Setting>()
                .Property(x => x.WalletName4)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.WalletAddress4)
                .HasMaxLength(1000);

            builder.Entity<Setting>()
                .Property(x => x.WalletName5)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.WalletAddress5)
                .HasMaxLength(1000);

            builder.Entity<Setting>()
                .Property(x => x.WalletName6)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.WalletAddress6)
                .HasMaxLength(1000);

            builder.Entity<Setting>()
                .Property(x => x.WalletName7)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.WalletAddress7)
                .HasMaxLength(1000);

            builder.Entity<Setting>()
                .Property(x => x.WalletName8)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.WalletAddress8)
                .HasMaxLength(1000);

            builder.Entity<Setting>()
                .Property(x => x.WalletName9)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.WalletAddress9)
                .HasMaxLength(1000);

            builder.Entity<Setting>()
                .Property(x => x.WalletName10)
                .HasMaxLength(256);

            builder.Entity<Setting>()
                .Property(x => x.WalletAddress10)
                .HasMaxLength(1000);
            #endregion

            #region User

            builder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(256)
                .IsRequired();

            builder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(256)
                .IsRequired();

            builder.Entity<User>()
                .Property(x => x.Biography)
                .HasMaxLength(1000);

            #endregion


            base.OnModelCreating(builder);
        }

        public DbSet<User> ApplicationUser { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<ProgressBar> ProgressBars { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<ProgressBar> MyProgresses { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
