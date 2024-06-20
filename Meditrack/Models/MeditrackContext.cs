using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Meditrack.Models
{
    public partial class MeditrackContext : DbContext
    {
        public MeditrackContext()
        {
        }

        public MeditrackContext(DbContextOptions<MeditrackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EstadoUsuario> EstadoUsuarios { get; set; } = null!;
        public virtual DbSet<Medicamento> Medicamentos { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=LAPTOP-S0US5BOR\\MSSQLSERVER01;Initial Catalog=Meditrack;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdEstadoUsuario)
                    .HasName("PK__EstadoUs__2498C345ABFC02E4");

                entity.ToTable("EstadoUsuario");

                entity.Property(e => e.IdEstadoUsuario).HasColumnName("ID_Estado_Usuario");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreEstadoUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Estado_Usuario");

                entity.Property(e => e.UltimaModificacion)
                    .HasColumnType("date")
                    .HasColumnName("Ultima_Modificacion")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.IdMedicamento)
                    .HasName("PK__Medicame__C1C5A04279ADD9B6");

                entity.Property(e => e.IdMedicamento).HasColumnName("ID_Medicamento");

                entity.Property(e => e.Distribuidor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.Property(e => e.NombreMedicamento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoMedicamento)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__5F36506170339A50");

                entity.Property(e => e.IdPaciente).HasColumnName("ID_Paciente");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.HistorialMedico).HasColumnType("text");

                entity.Property(e => e.IdentificacionPaciente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NacionalidadPaciente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePaciente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SexoPaciente)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TelefonoPaciente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoSanguineo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__202AD220B5D1DF9D");

                entity.Property(e => e.IdRol).HasColumnName("ID_Rol");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Creacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__DE4431C58526414B");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeRegistro)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEstadoUsuario)
                    .HasColumnName("ID_Estado_Usuario")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstadoUsuario)
                    .HasConstraintName("FK__Usuario__ID_Esta__35BCFE0A");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK__Usuario__RolId__34C8D9D1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
