using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cit265_Bennett_I_A6
{
    
    public partial class Form1 : Form
    {
        public List<TaskItem> listOfTask = new List<TaskItem>();
        public Form1()
        {
             
            InitializeComponent();
            //Is this the start of the function?
            //If so open the file and load the list
            //If no file found, create list from scratch
           

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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Quit program
            //Save list to file
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
