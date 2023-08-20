using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Repositories;
using MyCV.Application.Experiences.GetAll;
using MyCV.Domain.Entities.DomainErrors;


namespace MyCV.Experiences.UnitTest.GetAll;

public class GetAllExperiencesQueryHandlerUnitTest{

    private readonly Mock<IExperienceRepository> _moqExperienceRepository;

    private readonly GetAllExperiencesQueryHandler _handler;

    public GetAllExperiencesQueryHandlerUnitTest()
    {
        _moqExperienceRepository = new Mock<IExperienceRepository>();
        _handler = new  GetAllExperiencesQueryHandler(_moqExperienceRepository.Object);
    }

    [Fact]
    public async void  HandlerGetAllExperience_WhenResultIsNullOrEmpty_ShouldReturnNothingToReturnError(){
         //Arrange: Configurar parametros de entrada
        var Query = new GetAllExperiencesQuery();

        //Act: Ejecuta el metodo a probar
        var result = await _handler.Handle(Query, default);

        //Assert: Verifica los resultados
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.NotFound);
        result.FirstError.Description.Should().Be(Errors.Experience.NothingToReturn.Description);
    }
}