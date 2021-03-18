using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV
{
    public partial class Form1 : Form
    {


        string name;
        public List<string> language = new List<string>();

        private string ReturnGender()
        {
            string changeInGender;
            if (Malerbtn.Checked == true)
            {
                changeInGender = Malerbtn.Text;
                return changeInGender;
            }
            if (Femalerbtn.Checked == true)
            {
                changeInGender = Femalerbtn.Text;
                return changeInGender;
            }
            try
            {
                throw new InvalidCastException();
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox1.DisplayMember = "Name";
        }

        private void Malerbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Femalerbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ADDButton_Click(object sender, EventArgs e)
        {
            if (NameTextbox.Text != "")
            {
                if (EnglishBox.Checked) language.Add(EnglishBox.Text);
                else if (RussianBox.Checked) language.Add(RussianBox.Text);
                else if (TurkishBox.Checked) language.Add(TurkishBox.Text);
                else if (OtherBox.Checked) language.Add(OtherBox.Text);
                if (EnglishBox.Checked == false) language.Remove(EnglishBox.Text);
                if (RussianBox.Checked == false) language.Remove(RussianBox.Text);
                if (TurkishBox.Checked == false) language.Remove(TurkishBox.Text);
                if (OtherBox.Checked == false) language.Remove(OtherBox.Text);
                name = NameTextbox.Text;
                listBox1.Items.Add(new User
                {
                    Name = NameTextbox.Text,
                    Surname = SurnameTextbox.Text,
                    Email = EmailTextbox.Text,
                    PhoneNum = PhoneTextbox.Text,
                    Gender = ReturnGender(),
                    Language = language,
                    Skills = SkillsTextbox.Text,
                    Birthday = dateTimePicker1.Value
                });
                NameTextbox.Text = string.Empty;
                SurnameTextbox.Text = string.Empty;
                EmailTextbox.Text = string.Empty;
                PhoneTextbox.Text = string.Empty;
                SkillsTextbox.Text = string.Empty;

            }
            else
            {
                MessageBox.Show("Writw your name!");
            }
        }

        private void SAVEButton_Click(object sender, EventArgs e)
        {
            if (listBox1.Text != "")
            {
                JsonReadWrite.JsonSerialize(name, listBox1.SelectedItem as User);
                NameTextbox.Text = string.Empty;
                SurnameTextbox.Text = string.Empty;
                EmailTextbox.Text = string.Empty;
                PhoneTextbox.Text = string.Empty;
                SkillsTextbox.Text = string.Empty;
                Malerbtn.Checked = false;
                Femalerbtn.Checked = false;
                EnglishBox.Checked = false;
                RussianBox.Checked = false;
                TurkishBox.Checked = false;
                OtherBox.Checked = false;

            }
            else
            {
                MessageBox.Show("Fill in your list!");

            }
        }

        private void LOADButton_Click(object sender, EventArgs e)
        {
            if (listBox1.Text != "")
            {
                var obj = listBox1.SelectedItem as User;
                var selectedUser = JsonReadWrite.JsonDeserialize((obj)?.Name);
                var gendercheck = ReturnGender();
                try
                {
                    NameTextbox.Text = selectedUser.Name;
                    SurnameTextbox.Text = selectedUser.Surname;
                    EmailTextbox.Text = selectedUser.Email;
                    PhoneTextbox.Text = selectedUser.PhoneNum;
                    SkillsTextbox.Text = selectedUser.Skills;
                    if (gendercheck == Malerbtn.Text)
                    {
                        Malerbtn.Checked = true;
                    }
                    if (gendercheck == Femalerbtn.Text)
                    {
                        Femalerbtn.Checked = true;
                    }
                    foreach(var item in language)
                    {
                        if (item == EnglishBox.Text) EnglishBox.Checked = true;
                        if (item == RussianBox.Text) RussianBox.Checked = true;
                        if (item == TurkishBox.Text) TurkishBox.Checked = true;
                        if (item == OtherBox.Text) OtherBox.Checked = true;
                    }
                }
                catch(Exception ex)
                {
                   MessageBox.Show(ex.Message);
                }
            }
                else
                {
                    MessageBox.Show("There is nothing to load!");
                }
        }

        private void REMOVEButton_Click(object sender, EventArgs e)
        {
            if (listBox1.Text != "")
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("There is nothing to remove");
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.Yellow;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.button2.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.BackColor = Color.Yellow;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            this.button3.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.button3.BackColor = Color.Yellow;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            this.button4.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.button4.BackColor = Color.Yellow;
        }
    }
}
