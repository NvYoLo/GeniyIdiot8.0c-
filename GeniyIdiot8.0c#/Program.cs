using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;


namespace GeniyIdiotConsoleApp
{
    public partial class Program
    {
    
        public static void AddQuestion()
        {
            Console.WriteLine("Введите текст вопроса : ");
            string newQuestion = Console.ReadLine();
            Console.WriteLine("Введите ответ на данный вопрос : ");
            int newAnswer = GetDefNumber();
            var Question = new Question(newQuestion, newAnswer);
            QuestionStorage.Add(Question);
        }
        public static void StartMenu() // основная логика программы
        {
            
            bool flagStartForTest = true;
            while (flagStartForTest)
            {
                Console.WriteLine("Введите имя пользователя: ");
                User user = new User(Console.ReadLine());
                QuestionStorage questionStorage = new QuestionStorage();
                var questions = questionStorage.GetAll();
                
                int countQuestions = questions.Count;
                
                var random = new Random();

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine($"Вопрос #{i + 1}");
                    var randomQuestionIndex = random.Next(0, questions.Count);
                    Console.WriteLine(questions[randomQuestionIndex].Text);
                    int userAnswer = GetDefNumber();
                    if (userAnswer == questions[randomQuestionIndex].Answer)
                    {
                        user.AcceptRightAnswer();
                    }
                    questions.RemoveAt(randomQuestionIndex);
                }
                
                Console.Clear();
                Console.Write($"{user.Name}, Ваш диагноз: ");
                user.Diagnosis = UserDiagnoseResult.GetDiagnosis(user.CountRightAnswer,countQuestions);
                Console.WriteLine(user.Diagnosis);
                Console.WriteLine($"Количество правильных ответов: {user.CountRightAnswer}");
                Console.WriteLine("--------------------------------------------------------------");
                UserStorage.SaveFileResult(user);
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

        public static void OpenFileResult()
        {
            var AllResult = UserStorage.GetUserResults();
            Console.WriteLine(new string('-', 90));
            Console.WriteLine("{0, -20} | {1, -35} | {2, -30}", "Имя", "Количество правильных ответов", "Диагноз");
            Console.WriteLine(new string('-', 90));
            foreach (var Result in AllResult)
            {
                Console.WriteLine(String.Format("{0, -20} | {1, -35} | {2, -5}", Result.Name, Result.CountRightAnswer, Result.Diagnosis));
            }
            Console.WriteLine(new string('-', 90));

        }

        static void Main(string[] args)
        {
            
            bool flagStartMenu = true;
            while (flagStartMenu)
            {
                Console.WriteLine("1. Пройти тестирование" +
                "\n2. Посмотреть результаты" +
                "\n3. Очистить консольное меню" +
                "\n4. Добавить вопрос"+
                "\n5. Закрыть приложение");
                string InputSelect = Console.ReadLine();
                int choise = 0;
                bool choice_bool = int.TryParse(InputSelect, out choise);
                switch (choise)
                {
                    case 1:{StartMenu();}; break;
                    case 2: { OpenFileResult(); }; break;
                    case 3: Console.Clear(); break;
                    case 4: { AddQuestion(); }; break;
                    case 5: { flagStartMenu = false; }; break;
                    default:Console.WriteLine("Такого пункта меню нет, попробуйте ввести заново");break;
                }
            }
        }

    }
}