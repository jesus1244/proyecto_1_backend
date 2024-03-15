using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace proyecto.Services.DbcontextConnect;

public partial class BryamProyectoContext : DbContext
{
    public BryamProyectoContext()
    {
    }

    public BryamProyectoContext(DbContextOptions<BryamProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<FormularioPrincipal> FormularioPrincipals { get; set; }

    public virtual DbSet<Programa> Programas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=hola-bd-qa.ckeqxfmdqgne.us-east-1.rds.amazonaws.com;Database=BryamProyecto;Username=h0l4dmin;Password=kwkMIlPzfWhDBjFhe2CR");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clases_pkey");

            entity.ToTable("clases");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCurso).HasColumnName("idCurso");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("curso_pky");

            entity.ToTable("curso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPrograma).HasColumnName("idPrograma");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdProgramaNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdPrograma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("curso_idPrograma_fkey");
        });

        modelBuilder.Entity<FormularioPrincipal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("formularioPrincipal");

            entity.Property(e => e.FechaClaseRealizada)
                .HasColumnType("character varying")
                .HasColumnName("fechaClaseRealizada");
            entity.Property(e => e.HorasRealizadas)
                .HasColumnType("character varying")
                .HasColumnName("horasRealizadas");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdClase).HasColumnName("idClase");
            entity.Property(e => e.IdCurso).HasColumnName("idCurso");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.TemaClase)
                .HasColumnType("character varying")
                .HasColumnName("temaClase");

            entity.HasOne(d => d.IdClaseNavigation).WithMany()
                .HasForeignKey(d => d.IdClase)
                .HasConstraintName("formularioPrincipal_idClase_fkey");

            entity.HasOne(d => d.IdCursoNavigation).WithMany()
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("formularioPrincipal_idCurso_fkey");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("formularioPrincipal_idUsuario_fkey");
        });

        modelBuilder.Entity<Programa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("programas_pkey");

            entity.ToTable("programas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasColumnType("character varying")
                .HasColumnName("apellido");
            entity.Property(e => e.FechaInscripcion).HasColumnName("fechaInscripcion");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario1)
                .HasColumnType("character varying")
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
