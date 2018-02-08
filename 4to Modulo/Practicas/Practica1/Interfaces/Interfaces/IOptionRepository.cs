using DTO.DTO;
using System.Collections.Generic;

namespace Interfaces.Interfaces
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
