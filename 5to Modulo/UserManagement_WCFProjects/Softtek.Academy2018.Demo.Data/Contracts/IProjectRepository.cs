using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Data.Contracts
{
    public interface IProjectRepository
    {
        int Add(Project project);

        ICollection<Project> GetAll();

        bool Exist(string name);
    }
}
