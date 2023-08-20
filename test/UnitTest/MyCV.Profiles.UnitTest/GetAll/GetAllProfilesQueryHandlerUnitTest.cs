using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Repositories;
using MyCV.Application.Profiles.GetAll;
using MyCV.Domain.Entities.DomainErrors;


namespace MyCV.Profiles.UnitTest.GetAll;

public class GetAllProfilesQueryHandlerUnitTest{
    private readonly Mock<IProfileRepository> _moqProfileRepository;

    private readonly GetAllProfilesQueryHandler _handler;

    public GetAllProfilesQueryHandlerUnitTest()
    {
        _moqProfileRepository = new Mock<IProfileRepository>();
        _handler = new  GetAllProfilesQueryHandler(_moqProfileRepository.Object);
    }

   [Fact]
   public async void  HandlerGetAllProfiles_WhenResultIsNullOrEmpty_ShouldReturnNothingToReturnError(){
         //Arrange: Configurar parametros de entrada
        var Query = new GetAllProfilesQuery();

        //Act: Ejecuta el metodo a probar
        var result = await _handler.Handle(Query, default);

        //Assert: Verifica los resultados
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.NotFound);
        result.FirstError.Description.Should().Be(Errors.Experience.NothingToReturn.Description);
    }  

}
