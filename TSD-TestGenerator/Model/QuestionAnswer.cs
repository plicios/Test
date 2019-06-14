using System;
using System.Collections.Generic;

namespace TSDTestGenerator.Model
{
    public partial class QuestionAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }

        public Answer Answer { get; set; }
        public Question Question { get; set; }
    }
}
