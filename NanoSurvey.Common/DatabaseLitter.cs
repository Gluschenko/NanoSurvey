using System;
using System.Collections.Generic;
using System.Text;
using NanoSurvey.Common.Data;
using NanoSurvey.Common.Entities;
using NanoSurvey.Common.Data.Validation;

namespace NanoSurvey.Common
{
    public static class DatabaseLitter
    {
        readonly static string[] randomWords = new string[] {
            "foo", "bar", "baz", "qwe", "qwerty", "123", "cat", "dog", 
            "duck", "meow", "meme", "switch", "is", "a", "boom", "Moscow",
            "Earth", "from", "for", "wow", "girl", "boy", "plus", "minus",
            "horse", "computer", "anime", "language", "AI", "killer",
            "code", "Euclid", "Euler"
        };

        public static void Fill(SurveyDatabaseContext database, int iterations, int questionsCount = 10, int answersCount = 10) 
        {
            var random = new Random();

            for (int i = 0; i < iterations; i++) 
            {
                var survey = new Survey 
                {
                    Title = GenerateLine(randomWords, random, true),
                    Description = GenerateLine(randomWords, random)
                };
                
                database.Surveys.Add(survey);
                database.SaveChanges();
                //
                for (int j = 0; j < questionsCount; j++) 
                {
                    var quest = new Question
                    {
                        SurveyID = survey.ID,
                        Text = GenerateLine(randomWords, random, true),
                        IsMultipleAnswer = i % 2 == 0
                    };
                    database.Questions.Add(quest);
                    database.SaveChanges();
                    //
                    for (int k = 0; k < answersCount; k++)
                    {
                        var answer = new Answer
                        {
                            QuestionID = quest.ID,
                            Text = GenerateLine(randomWords, random, true),
                        };
                        database.Answers.Add(answer);
                    }
                    database.SaveChanges();
                }

                database.SaveChanges();
            }
        }

        public static string GenerateLine(string[] randomWords, Random random, bool isQuestion = false) 
        {
            int num = random.Next(3, 10);
            var words = new List<string>();

            for (int i = 0; i < num; i++)
            {
                words.Add(randomWords[random.Next(0, randomWords.Length)]);
            }

            if (isQuestion)
                words.Add("?");

            return string.Join(" ", words);
        }
    }
}
