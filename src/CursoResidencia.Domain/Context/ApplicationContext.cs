using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CursoResidencia.Domain.Context.Configuration;

namespace CursoResidencia.Domain.Context;

public class ApplicationContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Modulo> Modulos { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Aula> Aulas { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new CursoConfiguration());
        builder.ApplyConfiguration(new ModuloConfiguration());
        builder.ApplyConfiguration(new ProfessorConfiguration());
        builder.ApplyConfiguration(new AlunoConfiguration());
        builder.ApplyConfiguration(new AulaConfiguration());
        builder.ApplyConfiguration(new ApplicationUserConfiguration());
    }
}
