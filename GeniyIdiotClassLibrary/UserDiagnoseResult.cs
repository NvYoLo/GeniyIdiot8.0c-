namespace GeniyIdiotClassLibrary
{

    public class UserDiagnoseResult
    {
        public static string GetDiagnosis(int count, int countQuestions)
        {
            double resultInPercent = ((double)count / countQuestions) * 100;
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
    }
}