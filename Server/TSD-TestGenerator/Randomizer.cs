using System.Collections.Generic;
using System.Linq;
using System;
using TSDTestGenerator.Model;


namespace TSDTestGenerator.Controllers
{
    public class Randomizer
    {
        public Randomizer()
        {

        }

        public List<Question> getRandomQuestions(List<Question> allQuestions, int numberOfQuestions)
        {
            Random rand = new Random();
            List<Question> randomQuestions = allQuestions
                .Where(b => (Enumerable
                .Repeat(0, numberOfQuestions)
                .Select(i => rand.Next(0, allQuestions.Count()))
                .ToArray())
                .Contains(b.Id)).ToList();

            return randomQuestions;
        }



    }
}
