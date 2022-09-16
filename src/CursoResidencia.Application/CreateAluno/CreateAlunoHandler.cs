using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Context;
using Microsoft.AspNetCore.Identity;

namespace CursoResidencia.Application.CreateAluno;

public class CreateAlunoHandler : IRequestHandler<CreateAlunoCommand, CreateAlunoResult>
{
    private readonly ApplicationContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public CreateAlunoHandler(ApplicationContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<CreateAlunoResult> Handle(CreateAlunoCommand request, CancellationToken cancellationToken)
    {
        ValidarEmail(request.Email);
        ValidarCpf(request.Cpf);

        var usuario = new ApplicationUser
        {
            Nome = request.NomeCompleto,
            UserName = request.Email,
            Email = request.Email,
            EmailConfirmed = true,
            Situacao = Situacao.Ativo
        };

        var result = await _userManager.CreateAsync(usuario, request.Senha);
        if (!result.Succeeded)
            throw new UnprocessableEntityException("Não foi possível cadastrar o usuário, tente novamente");

        await _userManager.AddToRoleAsync(usuario, "Aluno");

        var aluno = new Aluno(
            request.NomeCompleto,
            request.Email,
            request.Cpf,
            request.Crm,
            usuario.Id);
        _context.Alunos.Add(aluno);
        _context.SaveChanges();

        return await Task.FromResult(new CreateAlunoResult(aluno));
    }

    private void ValidarEmail(string email)
    {
        var emailExiste = _context.Alunos.Any(a => a.Email.Trim().ToUpper() == email.Trim().ToUpper());
        if (emailExiste)
            throw new UnprocessableEntityException("E-mail já cadastrado");
    }

    private void ValidarCpf(string cpf)
    {
        var cpfExiste = _context.Alunos.Any(a => a.Cpf.Trim().ToUpper() == cpf.Trim().ToUpper());
        if (cpfExiste)
            throw new UnprocessableEntityException("CPF já cadastrado");
    }
}
