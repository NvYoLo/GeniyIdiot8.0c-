using GeniyIdiotClassLibrary;
using GeniyIdiotWinFormsApp;
using System.Configuration;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.user = new User(textBoxName.Text);
            form2.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
            form3.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loginButton.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            loginButton.Enabled = !string.IsNullOrWhiteSpace(textBoxName.Text);
        }
    }
}
