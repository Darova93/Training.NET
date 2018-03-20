using System.Collections.Generic;

namespace Softtek.Academy.Final.WebAPI.Models
{
    public class QuestionDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int QuestionTypeId { get; set; }

        public ICollection<OptionDTO> Options { get; set; }
    }
}