using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FoodAPI.Models
{
    public partial class FoodRecipesContext : DbContext
    {
        public FoodRecipesContext()
        {
        }

        public FoodRecipesContext(DbContextOptions<FoodRecipesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SavedFoodTable> SavedFoodTable { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               // optionsBuilder.UseSqlServer("Server=tcp:foodrecipes.database.windows.net,1433;Initial Catalog=FoodRecipes;Persist Security Info=False;User ID=Jot27036778;Password=Lol350035;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SavedFoodTable>(entity =>
            {
                entity.HasKey(e => e.SavedFoodId)
                    .HasName("PK__SavedFoo__49B33FD4F84630B4");

                entity.Property(e => e.SavedFoodId).HasColumnName("SavedFoodID");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.Uri)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.U)
                    .WithMany(p => p.SavedFoodTable)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("FK__SavedFoodTa__UID__5070F446");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserTabl__1788CCAC25CE24AB");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
