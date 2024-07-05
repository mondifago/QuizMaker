using System.Xml.Serialization;

namespace QuizMaker;

class Program
{
    static void Main(string[] args)
    {
        var quizList = new List<Quiz>();

        QuizMakerUI quizMakerUI = new QuizMakerUI(quizList);
        quizMakerUI.DisplayProgramMenu();

        XmlSerializer writer = new XmlSerializer(typeof(List<Quiz>));
        var path = @"/Users/ugochukwumaduakor/Projects/QuizMaker/QuizMaker/bin/Debug/net7.0/Quizlist.xml";

        using (FileStream file = File.Create(path))
        {
            writer.Serialize(file, quizList);
        }
    }
}

