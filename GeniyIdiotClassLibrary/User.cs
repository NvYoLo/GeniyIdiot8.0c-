using Newtonsoft.Json;
namespace GeniyIdiotClassLibrary
{

    public class User
    {
        public string Name;
        public int CountRightAnswer;
        public string Diagnosis;
        [JsonConstructor]
        public User(string name)
        {
            Name = name;
            CountRightAnswer = 0;
            Diagnosis = "";
        }
        
        public User(string name, int countRightAnswer, string diagnosis)
        {
            Name = name;
            CountRightAnswer = countRightAnswer;
            Diagnosis = diagnosis;
        }
        public void AcceptRightAnswer()
        {
            CountRightAnswer++;
        }

    }
}