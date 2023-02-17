using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Тесты
{
    public partial class Form1 : Form
    {
        static int Count()
        {
            StreamReader sr = File.OpenText("test.txt");
            int count = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                count++;
            }
            count = count / 6;
            return count;
        }
        
        int count;
        static int[] random(int count)
        {
            Random rnd = new Random();
            int[] mas = new int[count];
            for (int j = 0; j < count; j++)
            {
                int num = rnd.Next(0, count);
                num--;
                if (Array.IndexOf(mas, num) == -1) mas[j] = num;
                else j--;
            }
            return mas;
        }
        
        string[,] questions = new string[Count(), 6];
        int curr_numb = 0;
        int answer = 0;
        string otv;
        public Form1()
        {
            InitializeComponent();
          
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] mas = random(count);
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
            {
                MessageBox.Show("Выберите хотя бы 1 вариант ответа", "Проблемка");
            }
            else
            {
                if (curr_numb < count - 1)
                    if (questions[mas[curr_numb]+1 , 5] != "*") pictureBox1.Image = Image.FromFile($"{curr_numb + 1}.png");
                    else pictureBox1.Image = null;
                //if (radioButton1.Checked)
                //{
                //    if (radioButton1.Text == questions[curr_numb, 4])
                //    {
                //        answer++;
                //    }
                //}
                //if (radioButton2.Checked)
                //{
                //    if (radioButton2.Text == questions[curr_numb, 4])
                //    {
                //        answer++;
                //    }
                //}
                //if (radioButton3.Checked)
                //{
                //    if (radioButton3.Text == questions[curr_numb, 4])
                //    {
                //        answer++;
                //    }
                //}
                if (checkBox1.Checked)
                {
                    otv += checkBox1.Text;
                    //if (checkBox1.Text == questions[curr_numb, 4])
                    //{
                    //    answer++;
                    //}
                }
                if (checkBox2.Checked)
                {
                    otv += checkBox2.Text;
                    //if (checkBox2.Text == questions[curr_numb, 4])
                    //{
                    //    answer++;
                    //}
                }
                if (checkBox3.Checked)
                {
                    otv += checkBox3.Text;
                    //if (checkBox3.Text == questions[curr_numb, 4])
                    //{
                    //    answer++;
                    //}
                }

                {
                    if (otv == questions[mas[curr_numb], 4]) answer++;
                    otv = "";
                    if (curr_numb < count - 1)
                    {
                        this.Text = "Вопрос " + (curr_numb + 2);
                        curr_numb++;
                        label1.Text = questions[mas[curr_numb], 0];
                        //radioButton1.Text = questions[curr_numb, 1];
                        //radioButton2.Text = questions[curr_numb, 2];
                        //radioButton3.Text = questions[curr_numb, 3];
                        checkBox1.Text = questions[mas[curr_numb], 1];
                        checkBox2.Text = questions[mas[curr_numb], 2];
                        checkBox3.Text = questions[mas[curr_numb], 3];
                    }
                    else
                    {
                        button1.Enabled = false;
                        if (curr_numb + 1 == answer) MessageBox.Show($"Поздравляю, вы ответили на все вопросы верно", "Результат");
                        else if (answer == 0) MessageBox.Show($"Очень плохо, у вас нет правильных ответов", "Результат");
                        else
                            MessageBox.Show($"Вы ответили правильно на {answer} из {curr_numb + 1} вопросов", "Результат");
                    }
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            StreamReader sr = File.OpenText("test.txt");
            count = Count();
            int[] mas = random(count);
            int i = 0;
            while (!sr.EndOfStream)
            {
                for (int j = 0; j < 6; j++)
                {
                    questions[i, j] = sr.ReadLine();


                }
                i++;
            }
            sr.Close();

            this.Text = "Вопрос " + (curr_numb + 1);
            label1.Text = questions[mas[curr_numb], 0];
            checkBox1.Text = questions[mas[curr_numb], 1];
            checkBox2.Text = questions[mas[curr_numb], 2];
            checkBox3.Text = questions[mas[curr_numb], 3];
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
