namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginButton = new Button();
            textBoxName = new TextBox();
            groupBox1 = new GroupBox();
            button1 = new Button();
            groupBox2 = new GroupBox();
            button2 = new Button();
            button4 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.Location = new Point(6, 51);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(185, 23);
            loginButton.TabIndex = 0;
            loginButton.Text = "Войти";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += button1_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(6, 22);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(185, 23);
            textBoxName.TabIndex = 1;
            textBoxName.TextChanged += textBoxName_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(loginButton);
            groupBox1.Controls.Add(textBoxName);
            groupBox1.Location = new Point(9, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(197, 82);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Введите имя для тестирования";
            // 
            // button1
            // 
            button1.Location = new Point(9, 22);
            button1.Name = "button1";
            button1.Size = new Size(185, 23);
            button1.TabIndex = 4;
            button1.Text = "Результаты тестирования";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Location = new Point(9, 99);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(197, 85);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Меню";
            // 
            // button2
            // 
            button2.Location = new Point(9, 51);
            button2.Name = "button2";
            button2.Size = new Size(185, 23);
            button2.TabIndex = 5;
            button2.Text = "Редактировать вопросы";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(9, 190);
            button4.Name = "button4";
            button4.Size = new Size(197, 48);
            button4.TabIndex = 6;
            button4.Text = "Выход";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(215, 247);
            Controls.Add(button4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Вход";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button loginButton;
        private TextBox textBoxName;
        private GroupBox groupBox1;
        private Button button1;
        private GroupBox groupBox2;
        private Button button2;
        private Button button4;
    }
}
