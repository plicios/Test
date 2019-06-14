using System;
using System.Collections.Generic;

namespace TSDTestGenerator.Model
{
    public partial class Question
    {
        public Question()
        {
            QuestionAnswer = new HashSet<QuestionAnswer>();
        }

        public int Id { get; set; }
        public string Content { get; set; }

        public ICollection<QuestionAnswer> QuestionAnswer { get; set; }
    }
}
