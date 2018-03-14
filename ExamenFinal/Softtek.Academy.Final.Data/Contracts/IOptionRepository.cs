using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy.Final.Data.Contracts
{
    public interface IOptionRepository
    {
        ICollection<Option> GetQuestionOptions(int id);
    }
}
