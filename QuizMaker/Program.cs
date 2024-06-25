namespace QuizMaker;

class Program
{
    static void Main(string[] args)
    {
        QuizMakerUI.DiplayProgramMenu();


        Quiz quiz = new Quiz();

        quiz.InputQuestion();

        Console.WriteLine($"\nQuestion {quiz.QuestionNumber}: {quiz.Question}");
        Console.WriteLine($"1. {quiz.AnswerOption1}");
        Console.WriteLine($"2. {quiz.AnswerOption2}");
        Console.WriteLine($"3. {quiz.AnswerOption3}");
        Console.WriteLine($"4. {quiz.AnswerOption4}");
        Console.WriteLine($"Correct Answer: {quiz.CorrectAnswer}");

    }
}

