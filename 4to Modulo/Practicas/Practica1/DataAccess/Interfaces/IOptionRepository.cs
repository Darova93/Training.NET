using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;

namespace DataAccess.Interfaces
{
    public interface IOptionRepository
    {
        List<OptionDTO> GetAll();

        OptionDTO GetById(int entityId);

        void Add(OptionDTO entity);

        void Update(OptionDTO entity);

        void Delete(int entityId);

        int CountOption();
    }
}
