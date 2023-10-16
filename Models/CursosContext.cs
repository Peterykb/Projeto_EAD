using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class CursosContext : DbContext
{
    public CursosContext()
    {
    }

    public CursosContext(DbContextOptions<CursosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexao");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__categori__CD54BC5AE71C329A");

            entity.ToTable("categorias");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Categoria1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("categoria");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__Curso__5D3F7502B8635086");

            entity.ToTable("Curso");

            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.CategoriaIdCategoria).HasColumnName("categoria_id_categoria");
            entity.Property(e => e.Criador)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("criador");
            entity.Property(e => e.DataCriacao)
                .HasColumnType("datetime")
                .HasColumnName("data_criacao");
            entity.Property(e => e.Nome)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nome");

            entity.HasOne(d => d.CategoriaIdCategoriaNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.CategoriaIdCategoria)
                .HasConstraintName("FK__Curso__categoria__4BAC3F29");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo).HasName("PK__Modulos__B2584DFCAC8B3C68");

            entity.Property(e => e.IdModulo).HasColumnName("id_modulo");
            entity.Property(e => e.Aula)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("aula");
            entity.Property(e => e.CursoIdCurso).HasColumnName("curso_id_curso");
            entity.Property(e => e.Modulo1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("modulo");

            entity.HasOne(d => d.CursoIdCursoNavigation).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.CursoIdCurso)
                .HasConstraintName("FK__Modulos__curso_i__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
