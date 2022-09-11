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
    public DbSet<ProfessorCurso> ProfessorCursos { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Aula> Aulas { get; set; }
    public DbSet<CursoAula> CursoAulas { get; set; }
    public DbSet<Simulado> Simulados { get; set; }
    public DbSet<VisualizacaoAula> VisualizacaoAulas { get; set; }
    public DbSet<SimuladoQuestaoProva> SimuladoQuestoesProva { get; set; }

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
        builder.ApplyConfiguration(new CursoAulaConfiguration());
        builder.ApplyConfiguration(new ProfessorCursoConfiguration());
        builder.ApplyConfiguration(new AlunoConfiguration());
        builder.ApplyConfiguration(new AulaConfiguration());
        builder.ApplyConfiguration(new VisualizacaoAulaConfiguration());
        builder.ApplyConfiguration(new QuestaoProvaConfiguration());
        builder.ApplyConfiguration(new SimuladoConfiguration());
        builder.ApplyConfiguration(new RespostaQuestaoSimuladoConfiguration());
        builder.ApplyConfiguration(new ApplicationUserConfiguration());
        builder.ApplyConfiguration(new PodcastConfiguration());
        builder.ApplyConfiguration(new SimuladoQuestaoProvaConfiguration());
    }
}
