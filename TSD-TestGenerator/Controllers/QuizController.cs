using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSDTestGenerator.DTO;
using TSDTestGenerator.Model;

namespace TSDTestGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        // GET api/quiz
        [HttpGet]
        public ActionResult<IEnumerable<QuestionDto>> Get([FromQuery(Name = "number")] int? number)
        {
            if (!number.HasValue)
            {
                number = 10;
            }
            using (QuizDBContext quizDbContext = new QuizDBContext())
            {
                List<Question> questions = quizDbContext.Question.ToList();
                List<QuestionAnswer> questionAnswers = quizDbContext.QuestionAnswer.ToList();
                List<Answer> answers = quizDbContext.Answer.ToList();
                foreach (QuestionAnswer questionAnswer in questionAnswers)
                {
                    questionAnswer.Answer = answers.Find(answer => answer.Id == questionAnswer.AnswerId);
                    questions.Find(question => question.Id == questionAnswer.QuestionId).QuestionAnswer.Add(questionAnswer);
                }
                return new Randomizer().getRandomQuestions(quizDbContext.Question.ToList(), number.Value).Select(q => new QuestionDto(q)).ToList();
            }
        }

        // POST api/quiz/question
        [HttpPost("question")]
        public ActionResult Post([FromBody] QuestionDto questionDto)
        {
            if(questionDto == null || questionDto.Answers == null || questionDto.Answers.Count <= 0 || string.IsNullOrEmpty(questionDto.Content))
            {
                return BadRequest();
            }

            foreach(AnswerDto answer in questionDto.Answers)
            {
                if (string.IsNullOrEmpty(answer.Content))
                {
                    return BadRequest();
                }
            }

            using (QuizDBContext quizDbContext = new QuizDBContext())
            {
                int newQuestionId = quizDbContext.Question.Max(q => q.Id) + 1;
                Question question = questionDto.Question;
                question.Id = newQuestionId;

                ICollection<QuestionAnswer> questionAnswers = question.QuestionAnswer;

                question.QuestionAnswer = new List<QuestionAnswer>();

                quizDbContext.Question.Add(question);

                

                int newQuestionAnswerId = quizDbContext.QuestionAnswer.Max(q => q.Id) + 1;
                int newAnswerId = quizDbContext.Answer.Max(q => q.Id) + 1;

                foreach (QuestionAnswer questionAnswer in questionAnswers)
                {
                    questionAnswer.Id = newQuestionAnswerId;

                    Answer answer = questionAnswer.Answer;
                    answer.Id = newAnswerId;

                    questionAnswer.Answer = null;
                    questionAnswer.AnswerId = answer.Id;
                    questionAnswer.QuestionId = question.Id;
                    quizDbContext.Answer.Add(answer);

                    quizDbContext.QuestionAnswer.Add(questionAnswer);

                    newQuestionAnswerId++;
                    newAnswerId++;
                }

                quizDbContext.SaveChanges();
            }

            return Ok();
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }


}
