using System.Collections.Generic;

namespace Softtek.Academy.Final.Domain.Model
{
    public class Survey : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsArchived { get { return false; } set { } }

        public bool IsActive { get { return false; } set { } }

        public Status Status { get { return Status.Draft; } set{ } }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public Survey()
        {
            Questions = new HashSet<Question>();
            Answers = new HashSet<Answer>();
        }
    }
}
