using DevFreela.Application.InputModels.Projects;
using DevFreela.Application.ViewModels.Projects;

namespace DevFreela.Application.Services.Interfaces.Projects;

public interface IProjectService
{
    List<GetAllProjectViewModel> GetAll(string query);
    GetByIdProjectViewModel GetById(int id);
    int Create(CreateProjectInputModel createProjectInputModel);
    void Update(UpdateProjectInputModel updateProjectInputModel);
    void Delete(int id);
    void CreateComment(CreateCommentProjectInputModel commentProjectInputModel);
    void Start(int id);
    void Finish(int id);
}