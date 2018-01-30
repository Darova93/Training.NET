using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Questions
    {
        public string Text { get; set; }
        public int Id { get; set; }
        public bool Isrequired { get; set; }
        public QuestionType QuestionType { get; set; }

        public Questions(int id, string text, bool isrequired, QuestionType questionType)
        {
            Id = id;
            Text = text;
            Isrequired = isrequired;
            QuestionType = questionType;
        }



    }

}
