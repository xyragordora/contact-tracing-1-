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

namespace contact_tracing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string userName = textBox_UserName.Text;
            string pw = textBox_pass.Text;

            if (userName == "admin" && pw == "123")
            {
                MessageBox.Show("Log-In Successful!");
                tabControl1.TabPages.Add(tabPage3);
                tabControl1.SelectTab("tabPage3");

            }
            else { MessageBox.Show("Invalid Credentials, Please Try Again"); }
        }

        private void buttonGetForm_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.SelectTab("tabPage2");
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.SelectTab("tabPage1");
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                string Date = (comboBoxMm.SelectedItem.ToString() + " " + comboBoxDd.SelectedItem.ToString() + " " + textBoxYy.Text);
                string Name = textBoxName.Text;
                string Age = textBoxAge.Text;
                string Bday = (comboBoxMbday.SelectedItem + "" + comboBoxDbday.SelectedItem + "," + textBoxYbday.Text);
                string Sex = comboBoxSex.SelectedItem.ToString();
                string CivilStat = textBoxCivil.Text;
                string Nationality = textBoxNation.Text;
                string Religion = textBoxRel.Text;
                string BirthPlace = textBoxBplace.Text;
                string Homeadd = textBoxHomeadd.Text;
                string PhoneNo = textBoxPhone.Text;
                string Email = textBoxEmail.Text;

                if ((textBoxName.Text == "") || (textBoxAge.Text == "") || (Bday == "") || (Sex == "") || (textBoxPhone.Text == "") || (textBoxBplace.Text == "") || (textBoxHomeadd.Text == "") ||
                    ((checkBoxN1.Checked == false) && (checkBoxY1.Checked == false)) || ((checkBoxN2.Checked == false) && (checkBoxY2.Checked == false)) ||
                     ((checkBoxN3.Checked == false) && (checkBoxY3.Checked == false)) || ((checkBoxN4.Checked == false) && (checkBoxY4.Checked == false)) ||
                      ((checkBoxN5.Checked == false) && (checkBoxY5.Checked == false) && (checkBoxUnknown.Checked == false)) || ((checkBoxN6.Checked == false) && (checkBoxY6.Checked == false)))
                {
                    MessageBox.Show("Complete the form");
                }
                else
                {
                    StreamWriter Xy = new StreamWriter(@"C:\Users\chris\OneDrive\Desktop\PROGRAMS\New folder\" + Date + ".txt", true);


                    Xy.Write("Date Today: " + comboBoxMm.SelectedItem.ToString() + " " + comboBoxDd.SelectedItem.ToString() + " " + textBoxYy.Text);
                    Xy.Write("Log-in Time: " + labelt.Text);

                    Xy.WriteLine();
                    Xy.Write("DEMOGRAPHIC PROFILE:");
                    Xy.WriteLine();
                    Xy.Write(labelName.Text + " " + textBoxName.Text); //NAME
                    Xy.WriteLine(labelAge.Text + " " + textBoxAge.Text); //AGE

                    //ComboBox Birthday
                    string MonthB = comboBoxMbday.SelectedItem.ToString();
                    string DateB = comboBoxDbday.SelectedItem.ToString();
                    Xy.WriteLine(labelBday.Text + " " + MonthB + " " + DateB + "," + textBoxYbday.Text);

                    //ComboBox Sex
                    string Sex1 = comboBoxSex.SelectedItem.ToString();
                    Xy.WriteLine(labelSex.Text + " " + Sex1);

                    Xy.WriteLine(labelCivil.Text + " " + textBoxCivil.Text); //CIVIL STAT
                    Xy.WriteLine(labelNation.Text + " " + textBoxNation.Text); //NATIONALITY
                    Xy.WriteLine(labelRel.Text + " " + textBoxRel.Text); //RELIGION
                    Xy.WriteLine(labelBplace.Text + " " + textBoxBplace.Text); //BIRTH PLACE
                    Xy.WriteLine(labelHomeadd.Text + " " + textBoxHomeadd.Text); //HOME ADDRESS
                    Xy.WriteLine(labelPhone.Text + " " + textBoxPhone.Text); //PHONE NO.
                    Xy.WriteLine(labelEmail.Text + " " + textBoxEmail.Text); //EMAIL

                    Xy.WriteLine();
                    Xy.WriteLine("NATURE OF EXPOSURE: ");
                    Xy.WriteLine();
                    Xy.WriteLine("Travel History:");

                    //OUTSIDE COUNTRY
                    if (checkBoxY1.Checked)
                    {

                        Xy.WriteLine(labelOutside1.Text + "" + checkBoxY1.Text);
                        Xy.WriteLine(labelifY1.Text + " " + textBoxifY1.Text);

                        string M1 = comboBoxMo1.SelectedItem.ToString();
                        string D1 = comboBoxDa1.SelectedItem.ToString();
                        Xy.WriteLine(labeldt1.Text + " " + M1 + " " + D1 + "," + textBoxYear1.Text);

                    }
                    else if (checkBoxN1.Checked)
                    {
                        Xy.WriteLine(labelOutside1.Text + "" + checkBoxN1.Text);



                    }
                    else
                    {

                    }

                    //WITHIN COUNTRY
                    Xy.WriteLine();
                    if (checkBoxY2.Checked)
                    {

                        Xy.WriteLine(labelWithin1.Text + "" + checkBoxY2.Text);
                        Xy.WriteLine(labelifY2.Text + " " + textBoxifY2.Text);

                        string M2 = comboBoxMo2.SelectedItem.ToString();
                        string D2 = comboBoxDa2.SelectedItem.ToString();
                        Xy.WriteLine(labeldt2.Text + " " + M2 + " " + D2 + "," + textBoxYear2.Text);
                    }
                    else if (checkBoxN2.Checked)
                    {

                        Xy.WriteLine(labelWithin1.Text + "" + checkBoxN2.Text);
                    }
                    else
                    {

                    }


                    //SOCIAL EVENTS
                    Xy.WriteLine();
                    if (checkBoxY3.Checked)
                    {

                        Xy.WriteLine(labelSocial1.Text + "" + checkBoxY3.Text);

                        Xy.WriteLine(labelifY3.Text + " " + textBoxifY3.Text);
                        string M3 = comboBoxMo3.SelectedItem.ToString();
                        string D3 = comboBoxDa3.SelectedItem.ToString();
                        Xy.WriteLine(labeldt3.Text + " " + M3 + " " + D3 + "," + textBoxYear3.Text);
                    }
                    else if (checkBoxN3.Checked)
                    {

                        Xy.WriteLine(labelSocial1.Text + "" + checkBoxN3.Text);
                    }
                    else
                    {

                    }




                    Xy.WriteLine();
                    Xy.WriteLine("Exposure History:");

                    //CONTACT COVID PATIENT
                    if (checkBoxY4.Checked)
                    {

                        Xy.WriteLine(labelCon1.Text + "" + checkBoxY4.Text);
                    }
                    else if (checkBoxN4.Checked)
                    {

                        Xy.WriteLine(labelCon1.Text + "" + checkBoxN4.Text);
                    }
                    else
                    {

                    }

                    //EXPOSED COVID VARIANT 
                    if (checkBoxY5.Checked)
                    {

                        Xy.WriteLine(labelExp1.Text + "" + checkBoxY5.Text);
                    }
                    else if (checkBoxN5.Checked)
                    {

                        Xy.WriteLine(labelExp1.Text + "" + checkBoxN5.Text);
                    }
                    else if (checkBoxUnknown.Checked)
                    {

                        Xy.WriteLine(labelExp1.Text + "" + checkBoxUnknown.Text);
                    }
                    else
                    {

                    }

                    //SYMPTOMATIC
                    Xy.WriteLine();
                    if (checkBoxY6.Checked)
                    {

                        Xy.WriteLine(labelSymp1.Text + "" + checkBoxY6.Text);

                        string M4 = comboBoxMo4.SelectedItem.ToString();
                        string D4 = comboBoxDa4.SelectedItem.ToString();
                        Xy.WriteLine(labeldt4.Text + " " + M4 + " " + D4 + "," + textBoxYear4.Text);
                    }
                    else if (checkBoxN6.Checked)
                    {

                        Xy.WriteLine(labelSymp1.Text + "" + checkBoxN6.Text);
                    }
                    else
                    {

                    }

                    MessageBox.Show("File Saved");
                }
            }
            catch

            {
                try
                {
                    string Date = (comboBoxMm.SelectedItem.ToString() + " " + comboBoxDd.SelectedItem.ToString() + " " + textBoxYy.Text);
                    StreamReader readCont = new StreamReader(@"C:\Users\chris\OneDrive\Desktop\PROGRAMS\New folder\" + Date + ".txt");
                    listBox1.Items.Add(readCont.ReadLine());
                    readCont.Close();
                }
                catch
                {
                }
            }
        }

        private void buttonfilter_Click(object sender, EventArgs e)
        {
            string searchDate = textBoxDate.Text;

            string fileName = (@"C: \Users\chris\OneDrive\Desktop\PROGRAMS\New folder\" + searchDate + ".txt");
            try
            {
                if (searchDate == "")
                {
                    MessageBox.Show("Input date");
                }
                else if (System.IO.File.Exists(fileName) == true)
                {
                    StreamReader filterInfo = new StreamReader(@"C:\Users\chris\OneDrive\Desktop\PROGRAMS\New folder\" + searchDate + ".txt", true);
                    listBox2.Items.Add(filterInfo.ReadLine());
                }
                else
                {
                    MessageBox.Show("No record");
                }
            }
            catch
            {
                MessageBox.Show("Error. Please try again.");
            }
        }

        private void buttondisplay_Click(object sender, EventArgs e)
        {
            string filterDate = textBoxDate.Text;
            StreamReader readInfo = new StreamReader(@"C:\Users\chris\OneDrive\Desktop\PROGRAMS\New folder\" + filterDate + ".txt");
            while (!readInfo.EndOfStream)
            { 
            
                string line = readInfo.ReadToEnd();
                
            }
        }
    }
    
}
    

