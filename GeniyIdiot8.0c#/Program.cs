using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;


namespace GeniyIdiotConsoleApp
{

    internal class Program
    {
        public static void SaveFileResult(string userName, int countRightAnswers, string Diagnosis) // записать в файл
        {
            string filename = @"result.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    writer.WriteLine($"{userName}#{countRightAnswers}#{Diagnosis}");
                    Console.WriteLine("Результат тестирования сохранен!");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Результат тестирования не сохранен!");
            }
        }
        public static void OpenFileResult() // открыть файл для чтения результатов
        {
            string filename = @"result.txt";
            Console.WriteLine("{0, -15} |{1, 11} | {2, 10} |", "Ваше имя", "Количество правильных ответов", "Ваш диагноз");
            Console.WriteLine("--------------------------------------------------------------");
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split('#');
                    string name = values[0];
                    int countRightAnswer = int.Parse(values[1]);
                    string diagnosis = values[2];
                    Console.WriteLine("{0, -15} |               {1, -14} |    {2, -8} |", name, countRightAnswer, diagnosis);
                }
                Console.WriteLine("--------------------------------------------------------------");
            }
        }
        public static string GetDiagnosis(int count, int countQuestion) // получить диагноз
        {
            double resultInPercent = ((double)count / countQuestion) * 100;
            var result = new Dictionary<int, string>
            {
                {0, "Идиот" },
                {1, "Кретин" },
                {20, "Дурак" },
                {40, "Нормальный" },
                {60, "Талант" },
                {80, "Гений" }
            };
            string rating = "Unknown";
            foreach (var item in result)
            {
                if (resultInPercent < item.Key)
                {
                    break;
                }
                rating = item.Value;
            }
            return rating;

        }
        public static List<string> GetQuestions() // получить вопрос
        {
            List<string> questions = new List<string>();
            questions.Add("Сколько будет два плюс два умноженное на два?");
            questions.Add("Бревно нужно распилить на 10 частей, сколько надо сделать распилов?");
            questions.Add("На двух руках 10 пальцев. Сколько пальцев на 5 руках?");
            questions.Add("Укол делают каждые полчаса, сколько нужно минут для трех уколов?");
            questions.Add("Пять свечей горело, две потухли. Сколько свечей осталось?");
            return questions;
        }
        public static List<int> GetAnswer() // получить ответ
        {
            List<int> answers = new List<int>();
            answers.Add(6);
            answers.Add(9);
            answers.Add(25);
            answers.Add(60);
            answers.Add(2);
            return answers;
        }
        
        public static void StartMenu() // основная логика программы
        {
            bool flagStartForTest = true;
            while (flagStartForTest)
            {
               
                Console.WriteLine("Введите имя пользователя: ");
                string userName = Console.ReadLine();

                var questions = GetQuestions();

                var answers = GetAnswer();
                int countQuestions = questions.Count;

                int countRightAnswers = 0;
                var random = new Random();

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine($"Вопрос #{i + 1}");
                    var randomQuestionIndex = random.Next(0, questions.Count);
                    Console.WriteLine(questions[randomQuestionIndex]);
                    int userAnswer = GetDefNumber();
                    if (userAnswer == answers[randomQuestionIndex])
                    {
                        countRightAnswers++;
                    }
                    questions.RemoveAt(randomQuestionIndex);
                    answers.RemoveAt(randomQuestionIndex);
                }
                Console.Clear();
                Console.Write($"{userName}, Ваш диагноз: ");
                Console.WriteLine(GetDiagnosis(countRightAnswers, countQuestions));
                Console.WriteLine($"Количество правильных ответов: {countRightAnswers}");
                Console.WriteLine("--------------------------------------------------------------");
                string Diagnosis = GetDiagnosis(countRightAnswers, countQuestions);
                SaveFileResult(userName, countRightAnswers, Diagnosis);
                flagStartForTest = false;

            }
        }
        public static int GetDefNumber() // проверка на дурака
        {
            while (true)
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Введите пожалуйста число!");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Число слишком большое! Введите число менее длинное");
                }
            }
        }

        static void Main(string[] args)
        {
            bool flagStartMenu = true;
            while (flagStartMenu)
            {
                Console.WriteLine("1. Пройти тестирование" +
                "\n2. Посмотреть результаты" +
                "\n3. Очистить консольное меню" +
                "\n4. Закрыть приложение");
                string InputSelect = Console.ReadLine();
                int choise = 0;
                bool choice_bool = int.TryParse(InputSelect, out choise);
                switch (choise)
                {
                    case 1:
                        {
                            StartMenu();
                        }; break;
                    case 2: { OpenFileResult(); }; break;
                    case 3: Console.Clear(); break;
                    case 4: { flagStartMenu = false; }; break;
                    default:
                        Console.WriteLine("Такого пункта меню нет, попробуйте ввести заново");
                        break;
                }
            }



        }
    }
}