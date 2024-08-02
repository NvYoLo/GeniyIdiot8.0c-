
using Newtonsoft.Json;
using System.ComponentModel;

namespace GeniyIdiotClassLibrary
{

    public class QuestionStorage
    {
        
        public static string Path = @"question.json";
        public static void Add(Question question)
        {
            var resultQuestion = GetAll();
            resultQuestion.Add(question);
            Save(resultQuestion);
        }
        public static void Save(BindingList<Question> questionResult)
        {
            var jsonData = JsonConvert.SerializeObject(questionResult, Formatting.Indented);
            FileProvider.Replace(Path, jsonData);
        }

        public static BindingList<Question> GetAll()
        {
           var questions = new BindingList<Question>();
            if (FileProvider.Exists(Path))
            {
                var value = FileProvider.GetValue(Path);
                questions = JsonConvert.DeserializeObject<BindingList<Question>>(value);
            }
            else
            {
                questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
                questions.Add(new Question("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?", 9));
                questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
                questions.Add(new Question("Укол делают каждые полчаса, сколько нужно минут для трех уколов?", 60));
                questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));

                Save(questions);
            }
            return questions;
        }
        public static int DeleteQuestion(int NumberForDel)
        {
            var questions = GetAll();
            if (NumberForDel <= 0 || NumberForDel > questions.Count)
            {
                return -1;
            }
            questions.RemoveAt(NumberForDel - 1);
            Save(questions);
            return 0;
        }

    }
}