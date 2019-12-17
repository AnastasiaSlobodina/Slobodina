namespace Афиша_Событий.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Allocation> Allocation { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<DateEvent> DateEvent { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Event_Type> Event_Type { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Admin)
                .HasForeignKey(e => e.Admin_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.NameC)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Category_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Place)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.City_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DateEvent>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.DateEvent)
                .HasForeignKey(e => e.DateEvent_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.NameE)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Duration)
                .HasPrecision(6);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.DateEvent)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.Event_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Event_Type)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.Event_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place>()
                .Property(e => e.NameP)
                .IsUnicode(false);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.Allocation)
                .WithRequired(e => e.Place)
                .HasForeignKey(e => e.Place_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Place)
                .HasForeignKey(e => e.Place_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.NameS)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.Status_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.Code_of_ticket)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .Property(e => e.NameT)
                .IsUnicode(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Event_Type)
                .WithRequired(e => e.Type)
                .HasForeignKey(e => e.Type_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Identification)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Ticket)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_FK);
        }
    }
}
