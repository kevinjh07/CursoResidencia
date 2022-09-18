using CursoResidencia.Application.CreateAluno;
using CursoResidencia.Domain.Interfaces.Services;
using CursoResidencia.Domain.Models;

namespace CursoResidencia.Api.UnitTests.Controllers;

public class AlunosControllerTest
{
    [Fact]
    public async Task Should_Post_Create_Aluno_Command_To_Mediator()
    {
        //arrange
        var mediatorMock = new Mock<IMediator>();
        var alunoService = new Mock<IAlunoService>();
        var createAlunoResult = new CreateAlunoResult();
        var command = new CreateAlunoCommand
        {
            NomeCompleto = "Gabrielle Ferreira",
            Cpf = "73535953022",
            Crm = "243523",
            Email = "gferreira_1@gmail.com",
            Senha = "gferreira_1",
            ConfirmacaoSenha = "gferreira_1"
        };

        //act
        mediatorMock.Setup(x => x.Send(command, CancellationToken.None)).ReturnsAsync(createAlunoResult);

        var controller = new AlunosController(mediatorMock.Object, alunoService.Object);
        var result = await controller.Post(command);

        //assert
        mediatorMock.VerifyAll();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Should_Post_Id_To_Aluno_Service()
    {
        //arrange
        var mediatorMock = new Mock<IMediator>();
        var alunoService = new Mock<IAlunoService>();
        var getALunoResult = new Aluno();

        //act
        alunoService.Setup(x => x.GetById(1)).Returns(getALunoResult);

        var controller = new AlunosController(mediatorMock.Object, alunoService.Object);
        var result = controller.Get(1);

        //assert
        mediatorMock.VerifyAll();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Should_Return_List_From_Aluno_Service()
    {
        //arrange
        var mediatorMock = new Mock<IMediator>();
        var alunoService = new Mock<IAlunoService>();
        var getALunoResult = new Aluno();

        //act
        alunoService.Setup(x => x.GetAll()).Returns(new List<Aluno>());

        var controller = new AlunosController(mediatorMock.Object, alunoService.Object);
        var result = controller.GetAll();

        //assert
        mediatorMock.VerifyAll();
        Assert.NotNull(result);
    }
}
