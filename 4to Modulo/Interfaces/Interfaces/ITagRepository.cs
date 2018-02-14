using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface ITagRepository
    {
        void AddTag(TagDTO tagDTO);
        void DeleteTag(int tagid);
        void AssignTagtoTask(int taskid, int tagid);
        int CountTask(int tagid);
    }
}
