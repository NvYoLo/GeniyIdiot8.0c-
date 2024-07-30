using GeniyIdiotClassLibrary;
using System.Xml.Xsl;
using WinFormsApp1;

namespace GeniyIdiotWinFormsApp
{
    public partial class Form2 : Form
    {
        private List<Question> questions;
        private Question currentQuestion;
        private int NumberQuestion = 1;
        public User user;
        public int CountQuestion;
        private Form1 _form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            _form1  = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userAnswer = GetDefNumber(textBoxAnswer.Text);
            
            while (userAnswer == -1)
            {
                return;
            }
            var rightAnswer = currentQuestion.Answer;
            if (userAnswer == rightAnswer)
            {
                user.CountRightAnswer++;
            }
            textBoxAnswer.Clear();
            var endGame = questions.Count == 0;
            if (endGame)
            {
                user.Diagnosis = UserDiagnoseResult.GetDiagnosis(user.CountRightAnswer, CountQuestion);
                var dialogResult = MessageBox.Show($"{user.Name}, Ваш диагноз {user.Diagnosis}. ",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                button1.Enabled = false;
                UserStorage.SaveFileResult(user);
                if (dialogResult == DialogResult.OK)
                {
                    _form1.Show();
                    this.Close();
                }
                return;
            }
            ShowNextQuestion();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            questions = QuestionStorage.GetAll();
            CountQuestion = questions.Count;
            label2.Text = $"Вопрос #{NumberQuestion}";
            ShowNextQuestion();

        }

        private void ShowNextQuestion()
        {
            label2.Text = $"Вопрос #{NumberQuestion++}";
            var random = new Random();
            var randomQuestionIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomQuestionIndex];
            label1.Text = currentQuestion.Text;
            questions.Remove(currentQuestion);

        }
        public static int GetDefNumber(string number) // проверка на дурака
        {
            try
            {
                return int.Parse(number);
            }
            catch (FormatException e)
            {
                MessageBox.Show($"Введите число! ");
                
            }
            catch (OverflowException e)
            {
                MessageBox.Show($"Ответ слишком длинный! ");
            }
            return -1;

        }
    }
}
