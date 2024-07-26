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

        public virtual DbSet<Doctore> Doctores { get; set; } = null!;
        public virtual DbSet<EstadoQuirofano> EstadoQuirofanos { get; set; } = null!;
        public virtual DbSet<EstadoUsuario> EstadoUsuarios { get; set; } = null!;
        public virtual DbSet<EstadosdelosMaterialesQuirurgico> EstadosdelosMaterialesQuirurgicos { get; set; } = null!;
        public virtual DbSet<MaterialesQuirurgico> MaterialesQuirurgicos { get; set; } = null!;
        public virtual DbSet<Medicamento> Medicamentos { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<Quirofano> Quirofanos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TipodeMaterialQuirurgico> TipodeMaterialQuirurgicos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Meditrack;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctore>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK__Doctores__3246951CB517F06E");

                entity.HasIndex(e => e.IdentificacionDoctor, "UQ__Doctores__6C1F6B42DD783C03")
                    .IsUnique();

                entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.IdentificacionDoctor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NacionalidadDoctor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreDoctor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SexoDoctor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TelefonoDoctor)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoQuirofano>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__EstadoQu__9CF49395D211D643");

                entity.ToTable("EstadoQuirofano");

                entity.Property(e => e.IdEstado).HasColumnName("ID_Estado");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.DescripcionEstado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");
            });

            modelBuilder.Entity<EstadoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdEstadoUsuario)
                    .HasName("PK__EstadoUs__2498C345C73207A8");

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

            modelBuilder.Entity<EstadosdelosMaterialesQuirurgico>(entity =>
            {
                entity.HasKey(e => e.IdEstadoMaterialQuirurico)
                    .HasName("PK_ID_Estado_Material_Quirurico");

                entity.Property(e => e.IdEstadoMaterialQuirurico).HasColumnName("ID_Estado_Material_Quirurico");

                entity.Property(e => e.NombreEstadoMaterialQuirurgico)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MaterialesQuirurgico>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PK_ID_Material");

                entity.Property(e => e.IdMaterial).HasColumnName("ID_Material");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoMaterialQuirurgico).HasColumnName("ID_Tipo_Material_Quirurgico");

                entity.Property(e => e.NombreMaterial)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoMaterialQuirurgicoNavigation)
                    .WithMany(p => p.MaterialesQuirurgicos)
                    .HasForeignKey(d => d.IdTipoMaterialQuirurgico)
                    .HasConstraintName("FK_ID_Tipo_Material_Quirurgico_TipodeMaterialQuirurgico");
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.IdMedicamento)
                    .HasName("PK__Medicame__C1C5A04211AB6781");

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
                    .HasName("PK__Paciente__5F365061743D905F");

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

                entity.Property(e => e.SeguroMedico)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SexoPaciente)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TelefonoPaciente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoSanguineo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Quirofano>(entity =>
            {
                entity.HasKey(e => e.IdQuirofano)
                    .HasName("PK__Quirofan__44526D22D68D1ADB");

                entity.Property(e => e.IdQuirofano).HasColumnName("ID_Quirofano");

                entity.Property(e => e.DescripcionEstado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionEstadoQuirofano)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreQuirofano)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoQuirofanoNavigation)
                    .WithMany(p => p.Quirofanos)
                    .HasForeignKey(d => d.EstadoQuirofano)
                    .HasConstraintName("FK__Quirofano__Estad__3B75D760");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__202AD220B5517A99");

                entity.HasIndex(e => e.Nombre, "idx_nombre")
                    .IsUnique();

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

            modelBuilder.Entity<TipodeMaterialQuirurgico>(entity =>
            {
                entity.HasKey(e => e.IdTipoMaterialQuirurgico)
                    .HasName("PK_ID_Tipo_Material_Quirurgico");

                entity.ToTable("TipodeMaterialQuirurgico");

                entity.Property(e => e.IdTipoMaterialQuirurgico).HasColumnName("ID_Tipo_Material_Quirurgico");

                entity.Property(e => e.DescripcionTipoMaterialQuirurgico)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoMaterialQuirurgico)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoMaterialNavigation)
                    .WithMany(p => p.TipodeMaterialQuirurgicos)
                    .HasForeignKey(d => d.EstadoMaterial)
                    .HasConstraintName("FK_EstadoMaterial_EstadosdelosMaterialesQuirurgicos");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__DE4431C546ADFCE4");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(100)
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

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstadoUsuario)
                    .HasConstraintName("FK__Usuario__ID_Esta__3C69FB99");

                entity.HasOne(d => d.NombreRolNavigation)
                    .WithMany(p => p.UsuarioNombreRolNavigations)
                    .HasPrincipalKey(p => p.Nombre)
                    .HasForeignKey(d => d.NombreRol)
                    .HasConstraintName("FK_NombreRol");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.UsuarioRols)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK__Usuario__RolId__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
