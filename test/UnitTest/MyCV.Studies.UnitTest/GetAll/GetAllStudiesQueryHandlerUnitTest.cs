using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Repositories;
using MyCV.Application.Studies.GetAll;
using MyCV.Domain.Entities.DomainErrors;



namespace MyCV.Studies.UnitTest.GetAll;

public class GetAllStudiesQueryHandlerUnitTest
{
    private readonly Mock<IStudyRepository> _moqStudyRepository;

    private readonly GetAllStudiesQueryHandler _handler;

    public GetAllStudiesQueryHandlerUnitTest()
    {
        _moqStudyRepository = new Mock<IStudyRepository>();
        _handler = new  GetAllStudiesQueryHandler(_moqStudyRepository.Object);
    }

    [Fact]
    public async void  HandlerGetAllStudies_WhenResultIsNullOrEmpty_ShouldReturnNothingToReturnError(){
         //Arrange: Configurar parametros de entrada
        var Query = new GetAllStudiesQuery();

        //Act: Ejecuta el metodo a probar
        var result = await _handler.Handle(Query, default);

        //Assert: Verifica los resultados
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.NotFound);
        result.FirstError.Description.Should().Be(Errors.Study.NothingToReturn.Description);
    }  


}


