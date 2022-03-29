using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace bank.Models
{
    public partial class BankingProjectContext : DbContext
    {
        public BankingProjectContext()
        {
        }

        public BankingProjectContext(DbContextOptions<BankingProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Benificiary> Benificiary { get; set; }
        public virtual DbSet<Custinfo> Custinfo { get; set; }
        public virtual DbSet<Register> Register { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-M471DVV\\SQLEXPRESS;Initial Catalog=BankingProject;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Accountno);

                entity.ToTable("account");

                entity.Property(e => e.Accountno)
                    .HasColumnName("accountno")
                    .ValueGeneratedNever();

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.Rid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_account_register");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Adminid)
                    .HasColumnName("adminid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Benificiary>(entity =>
            {
                entity.HasKey(e => e.Benaccountno);

                entity.ToTable("benificiary");

                entity.Property(e => e.Benaccountno)
                    .HasColumnName("benaccountno")
                    .ValueGeneratedNever();

                entity.Property(e => e.Accountno).HasColumnName("accountno");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasColumnName("nickname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountnoNavigation)
                    .WithMany(p => p.Benificiary)
                    .HasForeignKey(d => d.Accountno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_benificiary_account");
            });

            modelBuilder.Entity<Custinfo>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.ToTable("custinfo");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Aadhar).HasColumnName("aadhar");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Middlename)
                    .IsRequired()
                    .HasColumnName("middlename")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile).HasColumnName("mobile");

                entity.Property(e => e.Occupation)
                    .HasColumnName("occupation")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.ToTable("register");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.Accountno).HasColumnName("accountno");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Transactionpass)
                    .IsRequired()
                    .HasColumnName("transactionpass")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasColumnName("userid")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.Transactionno)
                    .HasName("PK_transaction");

                entity.ToTable("transactions");

                entity.Property(e => e.Transactionno).HasColumnName("transactionno");

                entity.Property(e => e.Accountno).HasColumnName("accountno");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Benaccountno).HasColumnName("benaccountno");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountnoNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Accountno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transaction_account");

                entity.HasOne(d => d.BenaccountnoNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Benaccountno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transaction_benificiary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
