using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cw060624
{
    public partial class Form1 : Form
    {
        public class Person
        {
            public string Name { get; set; }
            public byte Age { get; set; }
            public string Surname { get; set; }
            public int Balance { get; set; }

            public Person(string name, byte age, string surname, int balance)
            {
                Name = name;
                Age = age;
                Surname = surname;
                Balance = balance;
            }

            public override string ToString()
            {
                return $"{Name} {Surname} ({Age} years old) - Balance: ${Balance}";
            }
        }
        public class Data
        {
            public List<Person> list = new List<Person>();

            public void AddPerson(string name, byte age, string surname, int balance)
            {
                list.Add(new Person(name, age, surname, balance));
            }

            public void DelPerson(string name, byte age, string surname, int balance)
            {
                list.RemoveAll(p => p.Name == name && p.Age == age && p.Surname == surname && p.Balance == balance);
            }
        }
        Data data;
        public Form1()
        {
            InitializeComponent();
            data = new Data();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox2.Text;
                string surname = textBox3.Text;
                byte age = byte.Parse(textBox4.Text);
                int balance = int.Parse(textBox5.Text);

                data.AddPerson(name, age, surname, balance);
                UpdateListBox();
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchName = textBox1.Text.ToLower();
            listBox1.Items.Clear();
            foreach (var person in data.list)
            {
                if (person.Name.ToLower().Contains(searchName))
                {
                    listBox1.Items.Add(person);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var person = (Person)listBox1.SelectedItem;
                data.DelPerson(person.Name, person.Age, person.Surname, person.Balance);
                UpdateListBox();
            }
            else
            {
                MessageBox.Show("Select a person to delete.");
            }
        }
        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (var person in data.list)
            {
                listBox1.Items.Add(person);
            }
        }
        private void ClearTextBoxes()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
