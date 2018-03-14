using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy.Final.Data.Contracts
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        int Create(Survey survey);

        bool Update(Survey survey);

        bool Archive(int id);

        bool Restore(int id);

        bool ChangeStatus(int id, Status status);

        bool SurveyExists(int id);
    }
}
