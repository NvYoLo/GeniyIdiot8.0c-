using GeniyIdiotClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace GeniyIdiotWinFormsApp
{
    public partial class Form4 : Form
    {

        public Form4()
        {

            InitializeComponent();
            InitializeDataGridView();
            textBox1.TextChanged += textBoxes_TextChanged;
            textBox2.TextChanged += textBoxes_TextChanged;
        }



        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Id",
                Name = "columnId",
                ValueType = typeof(string),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var allQuestion = QuestionStorage.GetAll();
            var result = QuestionStorage.DeleteQuestion(int.Parse(textBox3.Text));
            if (result == 0)
            {
                ShowGridView();
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Нет номера такого вопроса!");
                textBox3.Clear();
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            ShowGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Question = new Question(textBox1.Text, int.Parse(textBox2.Text));
            QuestionStorage.Add(Question);
            ShowGridView();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void ShowGridView()
        {
            var AllResult = QuestionStorage.GetAll();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AllResult;
            dataGridView1.Columns["Text"].Width = 420;
            dataGridView1.Columns["Answer"].Width = 50;
            for (int i = 0; i < AllResult.Count; i++)
            {
                dataGridView1.Rows[i].Cells["columnId"].Value = i + 1;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = !string.IsNullOrWhiteSpace(textBox3.Text);
        }
    }
}
