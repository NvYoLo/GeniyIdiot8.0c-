using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;


namespace GeniyIdiotConsoleApp
{

    internal class Program
    {
        public static void SaveFileResult(string userName, int countRightAnswers, string Diagnosis)
        {
            string filename = @"C:\Users\VSPrudius\source\repos\GeniyIdiot8.0c#\result.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filename, true))
                {
                    writer.WriteLine("{0, -15} |{1, -29} | {2, -11} |", userName, countRightAnswers, Diagnosis);
                    writer.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine("Результат тестирования сохранен!");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Результат тестирования не сохранен!");
            }
        }
        public static void OpenFileResult()
        {
            string filename = @"C:\Users\VSPrudius\source\repos\GeniyIdiot8.0c#\result.txt";
            Console.WriteLine("{0, -15} |{1, 11} | {2, 10} |", "Ваше имя", "Количество правильных ответов", "Ваш диагноз");
            Console.WriteLine("--------------------------------------------------------------");
            using (StreamReader reader = new StreamReader(filename))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        public static string GetDiagnosis(int count, int countQuestion)
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
        public static string[] GetQuestions(int countQuestions)
        {
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей, сколько надо сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько нужно минут для трех уколов?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }
        public static int[] GetAnswer(int countQuestions)
        {
            int[] answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }
        public static int GetRandomNumber(int countQuestions, List<int> numbersBefore)
        {
            Random rnd = new Random();
            int random = rnd.Next(0, countQuestions);
            while (true)
            {
                if (!numbersBefore.Contains(random))
                {
                    numbersBefore.Add(random);
                    break;
                }
                else
                {
                    random = rnd.Next(0, countQuestions);
                }
            }
            return random;

        }
        public static void StartMenu()
        {
            List<int> numbersBefore = new List<int>();
            int countQuestions = 5;
            
            bool flagStartForTest = true;
            while (flagStartForTest)
            {
                numbersBefore.Clear();
                Console.Clear();
                Console.WriteLine("Введите имя пользователя: ");
                string userName = Console.ReadLine();

                string[] questions = GetQuestions(countQuestions);

                int[] answers = GetAnswer(countQuestions);

                int countRightAnswers = 0;

                for (int i = 0; i < countQuestions; i++)
                {

                    int value = GetRandomNumber(countQuestions, numbersBefore);

                    Console.WriteLine($"Вопрос #{i + 1}");
                    Console.WriteLine(questions[value]);
                    while (true)
                    {
                        string userAnswerInput = Console.ReadLine();
                        int userAnswer = 0;
                        bool checkUserAnswer = int.TryParse(userAnswerInput, out userAnswer);

                        if (checkUserAnswer)
                        {
                            int rightAnswer = answers[value];
                            if (userAnswer == rightAnswer)
                            {
                                countRightAnswers++;
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{userName}, Пожалуйста введите число!");
                        }

                    }
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