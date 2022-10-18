using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_Api.Models
{
    public partial class ClinicaMedicaContext : DbContext
    {
        public ClinicaMedicaContext()
        {
        }

        public ClinicaMedicaContext(DbContextOptions<ClinicaMedicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccess> TblAccesses { get; set; } = null!;
        public virtual DbSet<TblAccessRole> TblAccessRoles { get; set; } = null!;
        public virtual DbSet<TblCargo> TblCargos { get; set; } = null!;
        public virtual DbSet<TblClinica> TblClinicas { get; set; } = null!;
        public virtual DbSet<TblCompra> TblCompras { get; set; } = null!;
        public virtual DbSet<TblComprasDetalle> TblComprasDetalles { get; set; } = null!;
        public virtual DbSet<TblConsulta> TblConsultas { get; set; } = null!;
        public virtual DbSet<TblDiagnostico> TblDiagnosticos { get; set; } = null!;
        public virtual DbSet<TblEmpleado> TblEmpleados { get; set; } = null!;
        public virtual DbSet<TblExamene> TblExamenes { get; set; } = null!;
        public virtual DbSet<TblExamenesConsulta> TblExamenesConsultas { get; set; } = null!;
        public virtual DbSet<TblHabitacione> TblHabitaciones { get; set; } = null!;
        public virtual DbSet<TblLoteProducto> TblLoteProductos { get; set; } = null!;
        public virtual DbSet<TblMarca> TblMarcas { get; set; } = null!;
        public virtual DbSet<TblPaciente> TblPacientes { get; set; } = null!;
        public virtual DbSet<TblPacientesHabitacione> TblPacientesHabitaciones { get; set; } = null!;
        public virtual DbSet<TblProducto> TblProductos { get; set; } = null!;
        public virtual DbSet<TblProveedor> TblProveedors { get; set; } = null!;
        public virtual DbSet<TblReceta> TblRecetas { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblUsuario> TblUsuarios { get; set; } = null!;
        public virtual DbSet<TblVenta> TblVentas { get; set; } = null!;
        public virtual DbSet<TblVentasDetalle> TblVentasDetalles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAccess>(entity =>
            {
                entity.HasKey(e => e.IdAccess);

                entity.ToTable("TBL_Access");

                entity.Property(e => e.IdAccess).HasColumnName("idAccess");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<TblAccessRole>(entity =>
            {
                entity.HasKey(e => e.IdAccessRoles);

                entity.ToTable("TBL_AccessRoles");

                entity.Property(e => e.IdAccessRoles).HasColumnName("idAccessRoles");

                entity.Property(e => e.IdAccess).HasColumnName("idAccess");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.HasOne(d => d.IdAccessNavigation)
                    .WithMany(p => p.TblAccessRoles)
                    .HasForeignKey(d => d.IdAccess)
                    .HasConstraintName("FK_TBL_AccessRoles_TBL_Access");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.TblAccessRoles)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_TBL_AccessRoles_TBL_Roles");
            });

            modelBuilder.Entity<TblCargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PK_Cargo");

                entity.ToTable("TBL_Cargos");

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblClinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK_Clinica");

                entity.ToTable("TBL_Clinicas");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCompra>(entity =>
            {
                entity.HasKey(e => e.IdCompras);

                entity.ToTable("TBL_Compras");

                entity.Property(e => e.IdCompras).HasColumnName("idCompras");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaOrden)
                    .HasColumnType("date")
                    .HasColumnName("fecha_orden");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.NoOrden).HasColumnName("no_Orden");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.TblCompras)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_Compras_TBL_Proveedor");
            });

            modelBuilder.Entity<TblComprasDetalle>(entity =>
            {
                entity.HasKey(e => e.IdComprasDetalle);

                entity.ToTable("TBL_ComprasDetalle");

                entity.Property(e => e.IdComprasDetalle).HasColumnName("idComprasDetalle");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.TblComprasDetalles)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ComprasDetalle_TBL_Compras");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.TblComprasDetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ComprasDetalle_TBL_Productos");
            });

            modelBuilder.Entity<TblConsulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK_consulta");

                entity.ToTable("TBL_Consultas");

                entity.HasIndex(e => e.IdDiagnostico, "UQ_Diagnostico")
                    .IsUnique();

                entity.HasIndex(e => e.IdReceta, "UQ_Receta")
                    .IsUnique();

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdDiagnostico)
                    .IsRequired()
                    .HasColumnName("idDiagnostico");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.IdReceta)
                    .IsRequired()
                    .HasColumnName("idReceta");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.TblConsulta)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK_consulta_Clinica");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.TblConsulta)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK_consulta_Empleado");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.TblConsulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK_consulta_Paciente");
            });

            modelBuilder.Entity<TblDiagnostico>(entity =>
            {
                entity.HasKey(e => e.IdDiagnostico)
                    .HasName("PK_Diagnostico");

                entity.ToTable("TBL_Diagnosticos");

                entity.HasIndex(e => e.IdDiagnostico, "IX_Diagnostico")
                    .IsUnique();

                entity.Property(e => e.IdDiagnostico)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idDiagnostico");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDiagnosticoNavigation)
                    .WithOne(p => p.TblDiagnostico)
                    .HasPrincipalKey<TblConsulta>(p => p.IdDiagnostico)
                    .HasForeignKey<TblDiagnostico>(d => d.IdDiagnostico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diagnostico_consulta");
            });

            modelBuilder.Entity<TblEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK_Empleado");

                entity.ToTable("TBL_Empleados");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoEmpleado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("FK_Empleado_Cargo");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK_Empleado_Clinica");
            });

            modelBuilder.Entity<TblExamene>(entity =>
            {
                entity.HasKey(e => e.IdExamen)
                    .HasName("PK_Examen");

                entity.ToTable("TBL_Examenes");

                entity.Property(e => e.IdExamen).HasColumnName("idExamen");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblExamenesConsulta>(entity =>
            {
                entity.HasKey(e => e.IdExamenConsulta)
                    .HasName("PK_ExamenConsulta");

                entity.ToTable("TBL_ExamenesConsultas");

                entity.Property(e => e.IdExamenConsulta).HasColumnName("idExamenConsulta");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.IdExamen).HasColumnName("idExamen");

                entity.HasOne(d => d.IdConsultaNavigation)
                    .WithMany(p => p.TblExamenesConsulta)
                    .HasForeignKey(d => d.IdConsulta)
                    .HasConstraintName("FK_ExamenConsulta_consulta");

                entity.HasOne(d => d.IdExamenNavigation)
                    .WithMany(p => p.TblExamenesConsulta)
                    .HasForeignKey(d => d.IdExamen)
                    .HasConstraintName("FK_ExamenConsulta_Examen");
            });

            modelBuilder.Entity<TblHabitacione>(entity =>
            {
                entity.HasKey(e => e.IdHabitacion)
                    .HasName("PK_Habitaciones");

                entity.ToTable("TBL_Habitaciones");

                entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.TblHabitaciones)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK_Habitaciones_Clinica");
            });

            modelBuilder.Entity<TblLoteProducto>(entity =>
            {
                entity.HasKey(e => e.IdLoteProducto)
                    .HasName("PK_Lote_Producto");

                entity.ToTable("TBL_Lote_Productos");

                entity.Property(e => e.IdLoteProducto).HasColumnName("id_Lote_Producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaExpiracion).HasColumnType("date");

                entity.Property(e => e.NoLote).HasColumnName("no_lote");
            });

            modelBuilder.Entity<TblMarca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK_Marca");

                entity.ToTable("TBL_Marcas");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPaciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK_Paciente");

                entity.ToTable("TBL_Pacientes");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoAfiliacion).HasColumnName("no_afiliacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPacientesHabitacione>(entity =>
            {
                entity.HasKey(e => e.IdPacHab)
                    .HasName("PK_pacientesHabitaciones");

                entity.ToTable("TBL_PacientesHabitaciones");

                entity.Property(e => e.IdPacHab).HasColumnName("idPac_Hab");

                entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.TblPacientesHabitaciones)
                    .HasForeignKey(d => d.IdHabitacion)
                    .HasConstraintName("FK_pacientesHabitaciones_Habitaciones");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.TblPacientesHabitaciones)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK_pacientesHabitaciones_Paciente");
            });

            modelBuilder.Entity<TblProducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK_Producto");

                entity.ToTable("TBL_Productos");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdLoteProducto).HasColumnName("idLote_Producto");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.TblProductos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK_Producto_Clinica");

                entity.HasOne(d => d.IdLoteProductoNavigation)
                    .WithMany(p => p.TblProductos)
                    .HasForeignKey(d => d.IdLoteProducto)
                    .HasConstraintName("FK_Producto_Lote");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.TblProductos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Producto_Marca");
            });

            modelBuilder.Entity<TblProveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.ToTable("TBL_Proveedor");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblReceta>(entity =>
            {
                entity.HasKey(e => e.IdReceta)
                    .HasName("PK_Receta");

                entity.ToTable("TBL_Recetas");

                entity.Property(e => e.IdReceta)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idReceta");

                entity.Property(e => e.FechaEmision).HasColumnType("date");

                entity.Property(e => e.Serie)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRecetaNavigation)
                    .WithOne(p => p.TblReceta)
                    .HasPrincipalKey<TblConsulta>(p => p.IdReceta)
                    .HasForeignKey<TblReceta>(d => d.IdReceta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receta_consulta");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("TBL_Roles");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Usuario");

                entity.ToTable("TBL_Usuarios");

                entity.HasIndex(e => e.IdEmpleado, "idEmpleado")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithOne(p => p.TblUsuario)
                    .HasForeignKey<TblUsuario>(d => d.IdEmpleado)
                    .HasConstraintName("FK_TBL_Usuarios_TBL_Empleados");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_TBL_Usuarios_TBL_Roles");
            });

            modelBuilder.Entity<TblVenta>(entity =>
            {
                entity.HasKey(e => e.IdVentas);

                entity.ToTable("TBL_Ventas");

                entity.Property(e => e.IdVentas).HasColumnName("idVentas");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Serie)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVentasDetalle>(entity =>
            {
                entity.HasKey(e => e.IdVentasDetalle);

                entity.ToTable("TBL_VentasDetalle");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.TblVentasDetalles)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_VentasDetalle_TBL_Productos");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.TblVentasDetalles)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_VentasDetalle_TBL_Ventas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
