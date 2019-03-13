namespace WebApplication9.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=opimaModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Bairro> Bairro { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Posicao> Posicao { get; set; }
        public virtual DbSet<TipoCadastro> TipoCadastro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Bairro>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Bairro>()
                .HasMany(e => e.Endereco)
                .WithOptional(e => e.Bairro)
                .HasForeignKey(e => e.codigo_bairro);

            modelBuilder.Entity<Cidade>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Cidade>()
                .HasMany(e => e.Bairro)
                .WithOptional(e => e.Cidade)
                .HasForeignKey(e => e.codigo_cidade);

            modelBuilder.Entity<Cidade>()
                .HasMany(e => e.Endereco)
                .WithOptional(e => e.Cidade)
                .HasForeignKey(e => e.codigo_cidade);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.rua)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.numero)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.telefone_residencial)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.telefone_celular)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.tipo_endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Cidade)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.codigo_estado);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Endereco)
                .WithOptional(e => e.Estado)
                .HasForeignKey(e => e.codigo_estado);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.profissao)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.nacionalidade)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.pai)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.mae)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.cnpj)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.numero_oab)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Endereco)
                .WithOptional(e => e.Pessoa)
                .HasForeignKey(e => e.codigo_pessoa);

            modelBuilder.Entity<Posicao>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Posicao>()
                .HasMany(e => e.Pessoa)
                .WithOptional(e => e.Posicao)
                .HasForeignKey(e => e.codigo_posicao_parte);

            modelBuilder.Entity<TipoCadastro>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<TipoCadastro>()
                .HasMany(e => e.Pessoa)
                .WithOptional(e => e.TipoCadastro)
                .HasForeignKey(e => e.codigo_tipo_cadastro);
        }
    }
}
