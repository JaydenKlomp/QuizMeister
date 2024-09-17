
namespace QuizMester
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string[] Answers { get; set; }
        public string CorrectAnswer { get; set; }

        public Question(string questionText, string[] answers, string correctAnswer)
        {
            QuestionText = questionText;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
    }
}
