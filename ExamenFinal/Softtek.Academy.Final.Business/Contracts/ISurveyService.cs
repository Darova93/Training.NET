using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy.Final.Business.Contracts
{
    public interface ISurveyService : IGenericService<Survey>
    {
        int Create(Survey survey);

        bool Update(Survey survey);

        bool Archive(int id);

        bool Restore(int id);

        bool ChangeStatus(int id, Status status);

        ICollection<Survey> GetAvailableSurveys();

        ICollection<Survey> GetReadySurveys();
    }
}
