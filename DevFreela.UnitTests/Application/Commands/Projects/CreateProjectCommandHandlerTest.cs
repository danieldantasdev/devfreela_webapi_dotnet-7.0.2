using DevFreela.Application.Commands.Projects.CreateProject;
using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Repositories.Interfaces.Projects;
using DevFreela.Core.Repositories.Interfaces.Skills;
using DevFreela.Core.Services.Interfaces.UnitOfWorks;
using Moq;

namespace DevFreela.UnitTests.Application.Commands.Projects;

public class CreateProjectCommandHandlerTest
{
    [Fact]
    public async Task InputDataOk_Executed_ReturnProjectId()
    {
        //Arrange
        var projectRepository = new Mock<IProjectRepository>();
        var skillRepository = new Mock<ISkillRepository>();
        var unitOfWorkService = new Mock<IUnitOfWorkService>();

        unitOfWorkService.SetupGet(uow => uow.ProjectRepository).Returns(projectRepository.Object);
        unitOfWorkService.SetupGet(uow => uow.SkillRepository).Returns(skillRepository.Object);

        var createProjectCommand = new CreateProjectCommandInputModel
        {
            Title = "Título de teste",
            Description = "Descrição de Teste",
            IdClient = 1,
            IdFreelancer = 2,
            TotalCost = 1000
        };

        var createProjectCommandHandler = new CreateProjectCommandHandler(unitOfWorkService.Object);

        //Act
        var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

        //Assert
        Assert.True(id.Id >= 0);

        projectRepository.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
    }
}