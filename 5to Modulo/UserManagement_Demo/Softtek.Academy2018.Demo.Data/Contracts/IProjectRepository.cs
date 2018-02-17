using Softtek.Academy2018.Demo.Domain.Model;
using System.Collections.Generic;

namespace Softtek.Academy2018.Demo.Data.Contracts
{
    public interface IProjectRepository
    {
        int Add(Project project);

        ICollection<Project> GetAll();

        bool Exists(string name);

        bool AssignUser(int projectid, int userid);

        bool UserAlreadyOnProject(int projectid, int userid);
    }
}
