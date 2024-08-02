using GeniyIdiotClassLibrary;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Xml.Xsl;
using WinFormsApp1;

namespace GeniyIdiotWinFormsApp
{
    public partial class Form2 : Form
    {
        private int counter = 1;
        private BindingList<Question> questions;
        private Question currentQuestion;
        private int NumberQuestion = 1;
        public User user;
        public int CountQuestion;
        private Form1 _form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
            
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
            if (questions.Count == 0)
            {
                EndGame();
                return;
            }
            counter = 0;
            progressBar1.Value = 0;
            ShowNextQuestion();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            questions = QuestionStorage.GetAll();
            CountQuestion = questions.Count;
            label2.Text = $"Вопрос #{NumberQuestion}";
            progressBar1.Maximum = 11;
            progressBar1.Value = 0;
            timer1.Enabled = true;
            timer1.Interval = 1500;
            timer1.Tick += timer1_Tick;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 11)
            {
                progressBar1.Value = 0;
                counter = 0;
                if (questions.Count == 0)
                {
                    timer1.Stop();
                    EndGame();
                    return;
                }
                ShowNextQuestion();
            }
            else
            {
                counter++;
                progressBar1.Value = counter;
            }
        }
        private void EndGame()
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
    }
    
}
