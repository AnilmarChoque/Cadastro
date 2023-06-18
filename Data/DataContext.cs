using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cadastro.Models;
using Cadastro.Models.Enuns;

namespace Cadastro.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData
            (
                new Usuario() { Id = 1, Nome = "Lucas", Cpf=30145952096, Email="lucas@gmail.com", Senha = "lucas312", Preferencia=ClasseEnum.Padrao},
                new Usuario() { Id = 2, Nome = "Jorge", Cpf=50730307026, Email="jorge@gmail.com", Senha = "jorge123", Preferencia=ClasseEnum.Idoso},
                new Usuario() { Id = 3, Nome = "Davi", Cpf=34329462010, Email="davi@outlook.com", Senha = "davi321", Preferencia=ClasseEnum.Cadeirante},
                new Usuario() { Id = 4, Nome = "Maria", Cpf=27730060035, Email="maria@hotmail.com", Senha = "maria231", Preferencia=ClasseEnum.Gestante}
            );
        }
    }
}