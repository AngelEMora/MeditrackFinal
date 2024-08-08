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

        public virtual DbSet<CalendarioCirugia> CalendarioCirugias { get; set; } = null!;
        public virtual DbSet<CasaComercial> CasaComercials { get; set; } = null!;
        public virtual DbSet<Distribuidor> Distribuidors { get; set; } = null!;
        public virtual DbSet<Doctore> Doctores { get; set; } = null!;
        public virtual DbSet<EspecialidadesMedica> EspecialidadesMedicas { get; set; } = null!;
        public virtual DbSet<EstadoQuirofano> EstadoQuirofanos { get; set; } = null!;
        public virtual DbSet<EstadoUsuario> EstadoUsuarios { get; set; } = null!;
        public virtual DbSet<EstadosCirugia> EstadosCirugias { get; set; } = null!;
        public virtual DbSet<EstadosdelosMaterialesQuirurgico> EstadosdelosMaterialesQuirurgicos { get; set; } = null!;
        public virtual DbSet<InventarioMaterialesCirugium> InventarioMaterialesCirugia { get; set; } = null!;
        public virtual DbSet<InventarioMedicamentosCirugium> InventarioMedicamentosCirugia { get; set; } = null!;
        public virtual DbSet<KitMaterialesDetalle> KitMaterialesDetalles { get; set; } = null!;
        public virtual DbSet<KitMedicamentoDetalle> KitMedicamentoDetalles { get; set; } = null!;
        public virtual DbSet<KitsMaterialesQuirurgico> KitsMaterialesQuirurgicos { get; set; } = null!;
        public virtual DbSet<KitsMedicamento> KitsMedicamentos { get; set; } = null!;
        public virtual DbSet<MaterialesQuirurgico> MaterialesQuirurgicos { get; set; } = null!;
        public virtual DbSet<Medicamento> Medicamentos { get; set; } = null!;
        public virtual DbSet<MovimientoInventario> MovimientoInventarios { get; set; } = null!;
        public virtual DbSet<OcupacionMedica> OcupacionMedicas { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<ProcedimientosQuirurgico> ProcedimientosQuirurgicos { get; set; } = null!;
        public virtual DbSet<Quirofano> Quirofanos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TipodeMaterialQuirurgico> TipodeMaterialQuirurgicos { get; set; } = null!;
        public virtual DbSet<TiposdeMedicamento> TiposdeMedicamentos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=Meditrack;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalendarioCirugia>(entity =>
            {
                entity.HasKey(e => e.IdCirugia)
                    .HasName("PK_ID_Cirugia");

                entity.Property(e => e.IdCirugia).HasColumnName("ID_Cirugia");

                entity.Property(e => e.FechaHoraCirugia).HasColumnType("datetime");

                entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");

                entity.Property(e => e.IdEstadoCirugias).HasColumnName("ID_Estado_Cirugias");

                entity.Property(e => e.IdPaciente).HasColumnName("ID_Paciente");

                entity.Property(e => e.IdProcedimiento).HasColumnName("ID_Procedimiento");

                entity.Property(e => e.IdQuirofano).HasColumnName("ID_Quirofano");

                entity.Property(e => e.Observaciones).HasColumnType("text");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.CalendarioCirugia)
                    .HasForeignKey(d => d.IdDoctor)
                    .HasConstraintName("FK_ID_Doctor_Doctoress");

                entity.HasOne(d => d.IdEstadoCirugiasNavigation)
                    .WithMany(p => p.CalendarioCirugia)
                    .HasForeignKey(d => d.IdEstadoCirugias)
                    .HasConstraintName("FK_ID_Estado_Cirugias_EstadosCirugiass");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.CalendarioCirugia)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK_ID_Paciente_Pacientes");

                entity.HasOne(d => d.IdProcedimientoNavigation)
                    .WithMany(p => p.CalendarioCirugia)
                    .HasForeignKey(d => d.IdProcedimiento)
                    .HasConstraintName("FK_ID_Procedimiento_ProcedimientosQuirurgicos");

                entity.HasOne(d => d.IdQuirofanoNavigation)
                    .WithMany(p => p.CalendarioCirugia)
                    .HasForeignKey(d => d.IdQuirofano)
                    .HasConstraintName("FK_ID_Quirofano_Quirofanos");
            });

            modelBuilder.Entity<CasaComercial>(entity =>
            {
                entity.HasKey(e => e.IdCasaComercial)
                    .HasName("PK__CasaCome__1B25085AD8358B7D");

                entity.ToTable("CasaComercial");

                entity.Property(e => e.IdCasaComercial).HasColumnName("ID_CasaComercial");

                entity.Property(e => e.CorreoCasaComercial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionCasaComercial)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCasaComercial)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoCasaComercial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WebCasaComercial)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Distribuidor>(entity =>
            {
                entity.HasKey(e => e.IdDistribuidor)
                    .HasName("PK__Distribu__9009C5F6FA301773");

                entity.ToTable("Distribuidor");

                entity.Property(e => e.IdDistribuidor).HasColumnName("ID_Distribuidor");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionDistribuidor)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdCasaComercial).HasColumnName("ID_CasaComercial");

                entity.Property(e => e.NombreDistribuidor)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoDistribuidor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDistribuidor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCasaComercialNavigation)
                    .WithMany(p => p.Distribuidors)
                    .HasForeignKey(d => d.IdCasaComercial)
                    .HasConstraintName("FK_Distribuidor_CasaComercial");
            });

            modelBuilder.Entity<Doctore>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK__Doctores__3246951CB517F06E");

                entity.HasIndex(e => e.IdentificacionDoctor, "UQ__Doctores__6C1F6B42DD783C03")
                    .IsUnique();

                entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.IdEspecialidad).HasColumnName("ID_Especialidad");

                entity.Property(e => e.IdOcupacion).HasColumnName("ID_Ocupacion");

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

                entity.HasOne(d => d.IdEspecialidadNavigation)
                    .WithMany(p => p.Doctores)
                    .HasForeignKey(d => d.IdEspecialidad)
                    .HasConstraintName("FK_ID_Especialidad_EspecialidadesMedicas");

                entity.HasOne(d => d.IdOcupacionNavigation)
                    .WithMany(p => p.Doctores)
                    .HasForeignKey(d => d.IdOcupacion)
                    .HasConstraintName("FK_ID_Ocupacion_OcupacionMedica");
            });

            modelBuilder.Entity<EspecialidadesMedica>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidad)
                    .HasName("PK__Especial__5D7732D76C7BF7BA");

                entity.Property(e => e.IdEspecialidad).HasColumnName("ID_Especialidad");

                entity.Property(e => e.NombreEspecialidad)
                    .HasMaxLength(100)
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

            modelBuilder.Entity<EstadosCirugia>(entity =>
            {
                entity.HasKey(e => e.IdEstadoCirugias)
                    .HasName("PK__EstadosC__610A096B94F34BAB");

                entity.Property(e => e.IdEstadoCirugias)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Estado_Cirugias");

                entity.Property(e => e.NombreEstadosCirugia)
                    .HasMaxLength(50)
                    .IsUnicode(false);
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

            modelBuilder.Entity<InventarioMaterialesCirugium>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PK_ID_Inventario");

                entity.Property(e => e.IdInventario).HasColumnName("ID_Inventario");

                entity.Property(e => e.IdCirugia).HasColumnName("ID_Cirugia");

                entity.Property(e => e.IdKitsCirugias).HasColumnName("ID_Kits_Cirugias");

                entity.HasOne(d => d.IdCirugiaNavigation)
                    .WithMany(p => p.InventarioMaterialesCirugia)
                    .HasForeignKey(d => d.IdCirugia)
                    .HasConstraintName("FK_ID_Cirugia_CalendarioCirugiass");

                entity.HasOne(d => d.IdKitsCirugiasNavigation)
                    .WithMany(p => p.InventarioMaterialesCirugia)
                    .HasForeignKey(d => d.IdKitsCirugias)
                    .HasConstraintName("FK_ID_Kits_Cirugias_KitsMaterialesQuirúrgicoss");
            });

            modelBuilder.Entity<InventarioMedicamentosCirugium>(entity =>
            {
                entity.HasKey(e => e.IdInventarioMedicamento)
                    .HasName("PK_ID_Inventario_Medicamento");

                entity.Property(e => e.IdInventarioMedicamento).HasColumnName("ID_Inventario_Medicamento");

                entity.Property(e => e.IdCirugia).HasColumnName("ID_Cirugia");

                entity.Property(e => e.IdKitsMedicamentos).HasColumnName("ID_Kits_Medicamentos");

                entity.HasOne(d => d.IdCirugiaNavigation)
                    .WithMany(p => p.InventarioMedicamentosCirugia)
                    .HasForeignKey(d => d.IdCirugia)
                    .HasConstraintName("FK_ID_Cirugia_CalendarioCirugias");

                entity.HasOne(d => d.IdKitsMedicamentosNavigation)
                    .WithMany(p => p.InventarioMedicamentosCirugia)
                    .HasForeignKey(d => d.IdKitsMedicamentos)
                    .HasConstraintName("FK_ID_Kits_Medicamentos");
            });

            modelBuilder.Entity<KitMaterialesDetalle>(entity =>
            {
                entity.HasKey(e => e.KitDetalleId);

                entity.ToTable("KitMaterialesDetalle");

                entity.Property(e => e.KitDetalleId).HasColumnName("KitDetalleID");

                entity.Property(e => e.IdKitsCirugias).HasColumnName("ID_Kits_Cirugias");

                entity.Property(e => e.IdMaterial).HasColumnName("ID_Material");

                entity.Property(e => e.Notas).IsUnicode(false);

                entity.HasOne(d => d.IdKitsCirugiasNavigation)
                    .WithMany(p => p.KitMaterialesDetalles)
                    .HasForeignKey(d => d.IdKitsCirugias)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KitMaterialesDetalle_KitsMaterialesQuirurgicos");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.KitMaterialesDetalles)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KitMaterialesDetalle_MaterialesQuirurgicos");
            });

            modelBuilder.Entity<KitMedicamentoDetalle>(entity =>
            {
                entity.HasKey(e => e.KitMedicamentoId)
                    .HasName("PK_KitMedicamento");

                entity.ToTable("KitMedicamentoDetalle");

                entity.Property(e => e.KitMedicamentoId).HasColumnName("KitMedicamentoID");

                entity.Property(e => e.IdKitsMedicamento).HasColumnName("ID_Kits_Medicamento");

                entity.Property(e => e.IdMedicamento).HasColumnName("ID_Medicamento");

                entity.HasOne(d => d.IdKitsMedicamentoNavigation)
                    .WithMany(p => p.KitMedicamentoDetalles)
                    .HasForeignKey(d => d.IdKitsMedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KitMedicamentoDetalle_KitsMedicamentos");

                entity.HasOne(d => d.IdMedicamentoNavigation)
                    .WithMany(p => p.KitMedicamentoDetalles)
                    .HasForeignKey(d => d.IdMedicamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KitMedicamentoDetalle_Medicamentos");
            });

            modelBuilder.Entity<KitsMaterialesQuirurgico>(entity =>
            {
                entity.HasKey(e => e.IdKitsCirugias)
                    .HasName("PK_ID_Kit");

                entity.Property(e => e.IdKitsCirugias).HasColumnName("ID_Kits_Cirugias");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.NombreKit)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KitsMedicamento>(entity =>
            {
                entity.HasKey(e => e.IdKitsMedicamentos)
                    .HasName("PK_ID_Kit_Medicamentos");

                entity.Property(e => e.IdKitsMedicamentos).HasColumnName("ID_Kits_Medicamentos");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.NombreKit)
                    .HasMaxLength(100)
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

                entity.Property(e => e.IdMovimiento).HasColumnName("ID_Movimiento");

                entity.Property(e => e.IdTipoMaterialQuirurgico).HasColumnName("ID_Tipo_Material_Quirurgico");

                entity.Property(e => e.NombreMaterial)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMovimientoNavigation)
                    .WithMany(p => p.MaterialesQuirurgicos)
                    .HasForeignKey(d => d.IdMovimiento)
                    .HasConstraintName("FK_ID_Movimiento_MovimientoInventario");

                entity.HasOne(d => d.IdTipoMaterialQuirurgicoNavigation)
                    .WithMany(p => p.MaterialesQuirurgicos)
                    .HasForeignKey(d => d.IdTipoMaterialQuirurgico)
                    .HasConstraintName("FK_ID_Tipo_Material_Quirurgico_TipodeMaterialQuirurgico");
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.IdMedicamento)
                    .HasName("PK__Medicame__C1C5A042F4FA6ECB");

                entity.Property(e => e.IdMedicamento).HasColumnName("ID_Medicamento");

                entity.Property(e => e.Distribuidor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFabricacion).HasColumnType("date");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.Property(e => e.IdMovimiento).HasColumnName("ID_Movimiento");

                entity.Property(e => e.IdTipoMedicamento).HasColumnName("ID_Tipo_Medicamento");

                entity.Property(e => e.Lote)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreMedicamento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMovimientoNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.IdMovimiento)
                    .HasConstraintName("FK_ID_Movimientoo_MovimientoInventario");

                entity.HasOne(d => d.IdTipoMedicamentoNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.IdTipoMedicamento)
                    .HasConstraintName("FK_ID_Tipo_Medicamento_TiposdeMedicamentos");
            });

            modelBuilder.Entity<MovimientoInventario>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento)
                    .HasName("PK_ID_Movimiento");

                entity.ToTable("MovimientoInventario");

                entity.Property(e => e.IdMovimiento).HasColumnName("ID_Movimiento");

                entity.Property(e => e.NombreMovimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OcupacionMedica>(entity =>
            {
                entity.HasKey(e => e.IdOcupacion)
                    .HasName("PK__Ocupacio__F231BE6212B39483");

                entity.ToTable("OcupacionMedica");

                entity.Property(e => e.IdOcupacion).HasColumnName("ID_Ocupacion");

                entity.Property(e => e.DescripcionOcupacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NombreOcupacion)
                    .HasMaxLength(100)
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

            modelBuilder.Entity<ProcedimientosQuirurgico>(entity =>
            {
                entity.HasKey(e => e.IdProcedimiento)
                    .HasName("PK_ID_Procedimiento");

                entity.Property(e => e.IdProcedimiento).HasColumnName("ID_Procedimiento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProcedimiento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RiesgosComplicaciones).HasColumnType("text");
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

            modelBuilder.Entity<TiposdeMedicamento>(entity =>
            {
                entity.HasKey(e => e.IdTipoMedicamento)
                    .HasName("PK__TiposdeM__84CA9336EE75CB0E");

                entity.Property(e => e.IdTipoMedicamento).HasColumnName("ID_Tipo_Medicamento");

                entity.Property(e => e.DescripcionTipoMedicamento)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTipoMedicamento)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Restricciones).IsUnicode(false);
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
