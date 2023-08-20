using MyCV.Domain.Common.Primitives;
using MyCV.Domain.Repositories;
using MyCV.Application.Skills.GetAll;
using MyCV.Domain.Entities.DomainErrors;


namespace MyCV.Skills.UnitTest.GetAll;

public class GetAllSkillsQueryHandlerUnitTest{
    private readonly Mock<ISkillRepository> _moqSkillRepository;

    private readonly GetAllSkillsQueryHandler _handler;

 public GetAllSkillsQueryHandlerUnitTest()
    {
        _moqSkillRepository = new Mock<ISkillRepository>();
        _handler = new  GetAllSkillsQueryHandler(_moqSkillRepository.Object);
    }

   [Fact]
   public async void  HandlerGetAllSkills_WhenResultIsNullOrEmpty_ShouldReturnNothingToReturnError(){
         //Arrange: Configurar parametros de entrada
        var Query = new GetAllSkillsQuery();

        //Act: Ejecuta el metodo a probar
        var result = await _handler.Handle(Query, default);

        //Assert: Verifica los resultados
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.NotFound);
        result.FirstError.Description.Should().Be(Errors.Skill.NothingToReturn.Description);
    }  

}
