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

namespace Cit265_Bennett_I_A6
{
    
    public partial class Form1 : Form
    {
        public BindingList<TaskItem> listOfTask = new BindingList<TaskItem>();

        private StreamWriter fileWriter;
        private StreamReader fileReader;

        public string fileName = "TestFile.txt";

        public bool newFile = true;
        public Form1()
        {
            //Thanks to: https://stackoverflow.com/questions/2675067/binding-listbox-to-listobject for this function call
            
            listOfTask = new BindingList<TaskItem>();
            InitializeComponent();
            //Is this the start of the function?
            //If so open the file and load the list
            //If no file found, create list from scratch
            //listBox1.DisplayMember = "GetValue";
            //listBox1.ValueMember = "ItemDate";
            listBox1.DataSource = null;
            listBox1.DataSource = listOfTask;
            //listBox1.MultiColumn = true;
            //var output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                fileReader = new StreamReader(input);

                var inputTask = fileReader.ReadLine();
                while(inputTask != null)
                {
                    string[] inputStrings = inputTask.Split(',');
                    TaskItem inputItem = new TaskItem();
                    inputItem.ItemName = inputStrings[0];
                    inputItem.ItemDate = DateTime.Parse(inputStrings[1]);
                    listOfTask.Add(inputItem);
                    inputTask = fileReader.ReadLine();
                }


                var output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                fileWriter = new StreamWriter(output);
            }
            catch(IOException)
            {
                var output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                fileWriter = new StreamWriter(output);
                
                

            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Sort by linq name
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Sort by linq date
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Need to create a struct that contains a date and string
            //Clear date and text boxes upon submit

            TaskItem newItem;
            newItem = new TaskItem();
            newItem.ItemName = textBox1.Text;
            newItem.ItemDate = dateTimePicker1.Value;
            Console.WriteLine(newItem.ItemName + " : " + newItem.ItemDate);
            string outputText = newItem.ItemName + " : " + newItem.ItemDate;
            label1.Text = outputText;

            listOfTask.Add(newItem);
            label1.Text = (listOfTask[listOfTask.Count -1].ItemName + " " + listOfTask[listOfTask.Count -1].ItemDate);
            listBox1.Refresh();
            label2.Text = listBox1.DataBindings.ToString();
            //listBox1.Items.Add(newItem);

            
            fileWriter.WriteLine($"{listOfTask[listOfTask.Count - 1].ItemName},{listOfTask[listOfTask.Count - 1].ItemDate}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Quit program
            //Save list to file

            //var output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            //fileWriter = new StreamWriter(output);
            
            //Close the file system
            fileWriter.Close();

            //Quits program, nice and simple
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            //Should return a DateTime Struct
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Should give a string for the title
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Remove selected item from list
        }
    }
}
