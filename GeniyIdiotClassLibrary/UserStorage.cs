using Newtonsoft.Json;
using System.Xml.Linq;

namespace GeniyIdiotClassLibrary
{

    public class UserStorage
    {
        public static string Path = @"result.json";
        public static void SaveFileResult(User user) // записать в файл
        {
            var userResult = GetUserResults();
            userResult.Add(user);
            Save(userResult);

        }
        public static List<User> GetUserResults()
        {

            if (!FileProvider.Exists(Path))
            {
                return new List<User>();
            }
            var value = FileProvider.GetValue(Path);
            var userResult = JsonConvert.DeserializeObject<List<User>>(value);
            return userResult;


        }
        public static void Save(List<User> userResult)
        {
            var jsonData = JsonConvert.SerializeObject(userResult, Formatting.Indented);
            FileProvider.Replace(Path, jsonData);
        }
    }

}