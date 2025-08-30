using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        int counter = 0;
        Double[] X = new Double[10];
       Double temp = 1;
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("V<--V");
            comboBox1.Items.Add("V<--V+1");
            comboBox1.Items.Add("V<--V-1");
            comboBox1.Items.Add("IF V!=0 GO TO L");

            comboBox2.Items.Add("None");
            comboBox2.Items.Add("A");
            comboBox2.Items.Add("B");
            comboBox2.Items.Add("C");
            comboBox2.Items.Add("D");
            comboBox2.Items.Add("E");

            comboBox3.Items.Add("y");
            comboBox3.Items.Add("x");
            comboBox3.Items.Add("z");

            comboBox4.Items.Add("A");
            comboBox4.Items.Add("B");
            comboBox4.Items.Add("C");
            comboBox4.Items.Add("D");
            comboBox4.Items.Add("E");

            comboBox4.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
            label5.Visible = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = my_fuctions.GetParings(Int32.Parse(textBox1.Text)); 
            richTextBox2.Text = my_fuctions.GetCodes(Int32.Parse(textBox1.Text)); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "IF V!=0 GO TO L")
            {
                comboBox4.Visible = true;
                textBox4.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
            }
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
           

            //if(comboBox1.Text!="" && comboBox2.Text!="" && comboBox3.Text!="" && comboBox4.Text!="" && textBox2.Text!="" && textBox3.Text!="")
            //{
                int ans = 0;
                string s2 = comboBox1.SelectedItem.ToString();
                if (s2 == "V<--V")
                {
                    ans = 0;
                }
                else if (s2 == "V<--V+1")
                {
                    ans = 1;
                }
                else if (s2 == "V<--V-1")
                {
                    ans = 2;
                }
                else if (s2 == "IF V!=0 GO TO L")
                {

                    ans = (my_fuctions.get_label_f_form(comboBox4.SelectedItem.ToString(), Int32.Parse(textBox4.Text))) + 2;


                }
                else if (s2 == "")
                {
                    MessageBox.Show("select a instruction plz!");
                }

                int instruction_number = ans;
                int variable_number = my_fuctions.get_variable_f_form(comboBox3.SelectedItem.ToString(), textBox3.Text);
                int label_number = my_fuctions.get_label_f_form(comboBox2.SelectedItem.ToString(), Int32.Parse(textBox2.Text));

                richTextBox3.Text += my_fuctions.GetCode2(label_number, instruction_number, variable_number) + "\n";
                ///richTextBox2.Text = "< " + label_number + " , < " + instruction_number + " , " + (variable_number-1) + " >>\n";
                Double[] X = new Double[10];
            //int[] X = new int[10];
                variable_number = variable_number - 1;
                X[counter] = my_fuctions.Pairing3(label_number, instruction_number, variable_number);
                counter++;

                temp = temp * my_fuctions.Godel_Number2(X);

                if (checkBox1.Checked)
                {

                    Double s3 = (temp - 1);
                    if (s3 >= 0)
                    {
                        label8.Text = s3.ToString();
                    }
                    else
                    {
                        MessageBox.Show("The Digit is too large!!");
                    }

                }
                comboBox4.Visible = false;
                textBox4.Visible = false;
                label4.Visible = false;
                label5.Visible = false;

            //}
            //else
            //{
            //    MessageBox.Show("plz fill all text boxes!");
            //}
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
    }
