using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Context;

namespace CursoResidencia.Application.CreateCurso;

public class CreateCursoHandler : IRequestHandler<CreateCursoCommand, CreateCursoResult>
{
    private readonly ILogger<CreateCursoHandler> _logger;
    private readonly IMapper _mapper;
    //private readonly IHelloWorldService _helloWorldService;
    private readonly ApplicationContext _context;

    public CreateCursoHandler(ILogger<CreateCursoHandler> logger,
                                    IMapper mapper/*,
                                    IHelloWorldService helloWorldService*/,
                                    ApplicationContext context)
    {
        _logger = logger;
        _mapper = mapper;
        //_helloWorldService = helloWorldService;
        _context = context;
    }

    public Task<CreateCursoResult> Handle(CreateCursoCommand request, CancellationToken cancellationToken)
    {
        var result = Salvar(request);
        return Task.FromResult(result);
    }

    private CreateCursoResult Salvar(CreateCursoCommand request)
    {
        if (CursoExiste(request.Nome))
            throw new UnprocessableEntityException("Já existe um curso cadastrado com este nome");

        var curso = new Curso(request.Nome, request.DataInicio, request.DataFim);

        _context.Cursos.Add(curso);
        _context.SaveChanges();

        return new CreateCursoResult(curso);
    }

    private bool CursoExiste(string nome)
    {
        return _context.Cursos.Any(c => c.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper()));
    }
}
