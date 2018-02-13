using DTO.DTO;
using System.Collections.Generic;

namespace Interfaces.Interfaces
{
    public interface IAsingationRepository
    {
        void Add(AsignationDTO entity);

        void Delete(int id);

        void Update(AsignationDTO entity);

        int Count();

        List<AsignationDTO> GetAll();

        AsignationDTO GetById(int id);
    }
}
