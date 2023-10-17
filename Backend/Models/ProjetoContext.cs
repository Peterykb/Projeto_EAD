using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class ProjetoContext : DbContext
{
    public ProjetoContext()
    {
    }

    public ProjetoContext(DbContextOptions<ProjetoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexao");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.IdAula).HasName("PK__Aulas__B19134FE900A6248");

            entity.Property(e => e.IdAula).HasColumnName("id_aula");
            entity.Property(e => e.Conteudo)
                .IsUnicode(false)
                .HasColumnName("conteudo");
            entity.Property(e => e.ModuloIdModulo).HasColumnName("modulo_id_modulo");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.ModuloIdModuloNavigation).WithMany(p => p.Aulas)
                .HasForeignKey(d => d.ModuloIdModulo)
                .HasConstraintName("FK__Aulas__modulo_id__5165187F");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__CD54BC5A18C9B95D");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.NomeCategoria)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome_categoria");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__Cursos__5D3F7502CD0489E5");

            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.CategoriaIdCategoria).HasColumnName("categoria_id_categoria");
            entity.Property(e => e.Criador)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("criador");
            entity.Property(e => e.DataCriacao).HasColumnName("data_criacao");
            entity.Property(e => e.NomeCurso)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nome_curso");

            entity.HasOne(d => d.CategoriaIdCategoriaNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.CategoriaIdCategoria)
                .HasConstraintName("FK__Cursos__categori__4BAC3F29");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo).HasName("PK__Modulos__B2584DFC0C096AA7");

            entity.Property(e => e.IdModulo).HasColumnName("id_modulo");
            entity.Property(e => e.CursoIdCurso).HasColumnName("curso_id_curso");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.CursoIdCursoNavigation).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.CursoIdCurso)
                .HasConstraintName("FK__Modulos__curso_i__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
