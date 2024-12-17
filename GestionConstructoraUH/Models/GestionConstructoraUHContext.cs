using Microsoft.EntityFrameworkCore;


namespace GestionConstructoraUH.Models
{
    public class GestionConstructoraUHContext : DbContext
    {
        public GestionConstructoraUHContext(DbContextOptions<GestionConstructoraUHContext> options)
            : base(options)
        {
        }

        // DbSets para las tablas
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de Empleado
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);
                entity.HasIndex(e => e.CorreoElectronico).IsUnique();
                entity.Property(e => e.Direccion).HasDefaultValue("San José");

                entity.Property(e => e.Salario)
                      .HasColumnType("decimal(10,2)")
                      .HasDefaultValue(250000);

                entity.Property(e => e.CategoriaLaboral)
                      .HasMaxLength(20);
            });

            // Configuración de Proyecto
            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(p => p.IdProyecto);
                entity.HasIndex(p => p.CodigoProyecto).IsUnique();
                entity.Property(p => p.NombreProyecto).IsRequired();
            });

            // Configuración de Asignacion
            modelBuilder.Entity<Asignacion>(entity =>
            {
                entity.HasKey(a => a.IdAsignacion);

                entity.HasOne(a => a.Empleado)
                      .WithMany(e => e.Asignaciones)
                      .HasForeignKey(a => a.IdEmpleado)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Proyecto)
                      .WithMany(p => p.Asignaciones)
                      .HasForeignKey(a => a.IdProyecto)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(a => new { a.IdEmpleado, a.IdProyecto }).IsUnique();
            });
        }
    }
}

