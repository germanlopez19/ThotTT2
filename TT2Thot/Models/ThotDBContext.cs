namespace TT2Thot.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

       public partial class ThotDBContext : DbContext
    {
        public ThotDBContext()
            : base("name=ThotContext")
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Asignatura> Asignaturas { get; set; }
        public virtual DbSet<Calificacion> Calificacions { get; set; }
        public virtual DbSet<Pregunta> Preguntas { get; set; }
        public virtual DbSet<Respuesta> Respuestas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tema> Temas { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Unidad> Unidads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Asignatura>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Respuesta>()
                .Property(e => e.Respuesta1)
                .IsUnicode(false);

            modelBuilder.Entity<Tema>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Tema>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Tema>()
                .Property(e => e.Contenido)
                .IsUnicode(false);

            modelBuilder.Entity<Tema>()
                .Property(e => e.Bibliografia)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .Property(e => e.FecharRealizacion)
                .IsFixedLength();

            
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<Test>()
                .HasRequired(n => n.ApplicationUser)
                .WithMany(a => a.Tests)
                //.HasForeignKey(n => n.ApplicationUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unidad>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Unidad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<TT2Thot.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}
