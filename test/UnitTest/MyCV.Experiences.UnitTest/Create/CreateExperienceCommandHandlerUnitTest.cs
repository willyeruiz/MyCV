

using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Repositories;
using  MyCV.Application.Experiences.Create;
using MyCV.Domain.Entities.DomainErrors;

namespace MyCV.Experiences.UnitTest.Create;

public class CreateExperienceCommandHandlerUnitTest
{
    private readonly Mock<IExperienceRepository> _moqExperienceRepository;

    private readonly Mock<IUnitOfWork> _moqUnitOfWork;

     private readonly CreateExperienceCommandHandler _handler;

    public CreateExperienceCommandHandlerUnitTest( )
    {
        _moqExperienceRepository = new Mock<IExperienceRepository>();
        _moqUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreateExperienceCommandHandler(_moqExperienceRepository.Object, _moqUnitOfWork.Object);
    }

    [Fact]
    public async void  HandlerCreateExperience_WhenAParameterIsNullOrEmpty_ShouldReturnValidationError()
    {
        
        //Arrange: Configurar parametros de entrada
        var command = new CreateExperienceCommand(
            Company: "Bn",
            From: string.Empty,
            To: string.Empty,
            Position: "Programador Sr",
            Description: string.Empty
        );  
        
        //Act: Ejecuta el metodo a probar
        var result = await _handler.Handle(command, default);

        //Assert: Verifica los resultados
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.Validation);
        result.FirstError.Description.Should().Be(Errors.Experience.ShortDescriptionValidation.Description);
        
    }
} 