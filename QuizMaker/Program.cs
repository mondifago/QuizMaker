namespace QuizMaker;

class Program
{
    static void Main(string[] args)
    {
        //QuizMakerUI.DiplayProgramMenu();

        Quiz quiz = new Quiz();
        quiz.InputQuestion();
        Console.WriteLine("\nQuiz Details:");
        Console.WriteLine($"Question Number: {quiz.QuestionNumber}");
        Console.WriteLine($"Question: {quiz.Question}");
        Console.WriteLine("Options:");
        for (int i = 0; i < quiz.AnswerOptions.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {quiz.AnswerOptions[i]}");
        }
        Console.WriteLine($"Correct Answer: Option {quiz.CorrectAnswer}");



    }
}

