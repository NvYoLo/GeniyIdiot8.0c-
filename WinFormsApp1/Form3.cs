using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeniyIdiotClassLibrary;
using WinFormsApp1;

namespace GeniyIdiotWinFormsApp
{
    public partial class Form3 : Form
    {
        private Form1 _form1;
        public Form3(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Имя",
                Name = "columnName",
                ValueType = typeof(string),
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Кол-во правильных ответов",
                Name = "columnCountAnswer",
                ValueType = typeof(int),
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Диагноз",
                Name = "columnResultDiagnoses",
                ValueType = typeof(string),
            });
            var AllResult = UserStorage.GetUserResults();
            dataGridView1.DataSource = AllResult;
            for (int i = 0; i < AllResult.Count; i++)
            {
                dataGridView1.Rows[i].Cells["columnName"].Value = AllResult[i].Name;
                dataGridView1.Rows[i].Cells["columnCountAnswer"].Value = AllResult[i].CountRightAnswer;
                dataGridView1.Rows[i].Cells["columnResultDiagnoses"].Value = AllResult[i].Diagnosis;
            }

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            _form1.Show();            
        }
    }


}
