
namespace GeniyIdiotConsoleApp
{

    public class QuestionStorage
    {
        public static void Add(Question question)
        {
            var value = $"{question.Text}#{question.Answer}";
            FileProvider.Append(@"question.txt", value);

        }

        public List<Question> GetAll()
        {
            List<Question> questions = new List<Question>();
            if (FileProvider.Exists(@"question.txt"))
            {
                var value = FileProvider.GetValue(@"question.txt");
                var lines = value.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in lines)
                {
                    var values = item.Split('#');
                    string questionText = values[0];
                    int questionAnswer = int.Parse(values[1]);
                    var results = new Question(questionText, questionAnswer);
                    questions.Add(results);
                }
            }
            else 
            {
                questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
                questions.Add(new Question("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?", 9));
                questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
                questions.Add(new Question("Укол делают каждые полчаса, сколько нужно минут для трех уколов?", 60));
                questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));

                foreach (var question in questions)
                {
                    Add(question);
                }
            }

            return questions;
        }


    }
}