namespace GeniyIdiotConsoleApp
{
    public class UserStorage
    {
        public static void SaveFileResult(User user) // записать в файл
        {
            try
            {
                var value = $"{user.Name}#{user.CountRightAnswer}#{user.Diagnosis}";
                FileProvider.Append(@"result.txt", value);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка сохранения!");
            }
        }
        public static List<User> GetUserResults() 
        {
            var value = FileProvider.GetValue(@"result.txt");
            var results = new List<User>();
            
            var lines = value.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach(var item in lines)
            {
                var values = item.Split('#');
                string name = values[0];
                int countRightAnswer = int.Parse(values[1]);
                string diagnosis = values[2];
                User user = new User(name, countRightAnswer, diagnosis);
                results.Add(user);
            }
            return results;

            
        }

    }
}