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
        //3 seperate lists are created to hold the initial list and the sorted list
        public BindingList<TaskItem> listOfTask = new BindingList<TaskItem>();
        public BindingList<TaskItem> NameSorted = new BindingList<TaskItem>();
        public BindingList<TaskItem> DateSorted = new BindingList<TaskItem>();

        //File access variables
        private StreamWriter fileWriter;
        private StreamReader fileReader;
        public string fileName = "TestFile.txt";

        //Sorted variables
        public bool nameSortedInv = true;
        public bool dateSortedInv = true;

        public Form1()
        {
            //Thanks to: https://stackoverflow.com/questions/2675067/binding-listbox-to-listobject for this function call
            listOfTask = new BindingList<TaskItem>();

            InitializeComponent();
            
            //Establish connection to the list
            listBox1.DataSource = null;
            listBox1.DataSource = listOfTask;
            
            //Try catch block for getting a previously saved file
            try
            {
                //Attempts to open the file, if this fails the program opens a new file
                FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);

                fileReader = new StreamReader(input);

                //Starts a while loop that reads in the items in the file, the textbook's section on read in from file was very handy
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

                //This has to be done otherwise file access becomes difficult-impossible
                fileReader.Close();

                //Sets the file writer to append. When the program adds a task it will add items on new lines beneath content
                fileWriter = new StreamWriter(fileName, append: true);
            }
            catch(IOException)
            {
                //If the file doesn't exist, will create a new file
                var output = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fileWriter = new StreamWriter(output);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Clears the name list to rebuild it
            NameSorted.Clear();
            //Sort by linq name
            //If else statement checks to see the order, when clicked will invert the sort
            //The Foreach look readds the items to the list
            //Since the predicted list size of this program is very small, this function call is perfectly acceptable performance wise.
            if (nameSortedInv)
            {
                var nameSorted = from task in listOfTask orderby task.ItemName select task;
                foreach(var t in nameSorted)
                {
                    Console.WriteLine(t.ItemName);
                    NameSorted.Add(t);
                }
                nameSortedInv = false;
            }
            else
            {
                var nameSorted = from task in listOfTask orderby task.ItemName descending select task;
                foreach (var t in nameSorted)
                {
                    Console.WriteLine(t.ItemName);
                    NameSorted.Add(t);
                }
                nameSortedInv = true;
            }

            //Ensuring a total refresh of the listBox data
            listBox1.DataSource = null;
            listBox1.DataSource = NameSorted;
            listBox1.Refresh();

        }

        //Exactly the same as the name sort button
        private void button3_Click(object sender, EventArgs e)
        {
            //Sort by linq date

            DateSorted.Clear();
            
            if (dateSortedInv)
            {
                var dateSorted = from task in listOfTask orderby task.ItemDate select task;
                foreach (var t in dateSorted)
                {
                    Console.WriteLine(t.ItemDate);
                    DateSorted.Add(t);
                }
                dateSortedInv = false;
            }
            else
            {
                var dateSorted = from task in listOfTask orderby task.ItemDate descending select task;
                foreach (var t in dateSorted)
                {
                    Console.WriteLine(t.ItemDate);
                    DateSorted.Add(t);
                }
                dateSortedInv = true;
            }

            listBox1.DataSource = null;
            listBox1.DataSource = DateSorted;
            listBox1.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Through the next few lines the program creates a new task, pulls the data from the relevant sources, 
            //then adds that to the list of tasks and refreshes the listbox
            TaskItem newItem;
            newItem = new TaskItem();
            newItem.ItemName = textBox1.Text;
            newItem.ItemDate = dateTimePicker1.Value;
            Console.WriteLine(newItem.ItemName + " : " + newItem.ItemDate);
            string outputText = newItem.ItemName + " : " + newItem.ItemDate;
            label1.Text = outputText;

            listOfTask.Add(newItem);
            listBox1.Refresh();

            //Debug code that would have displayed the current task seperately, deprecated fully now but the debug code is left intact as a reference
            //label1.Text = (listOfTask[listOfTask.Count -1].ItemName + " " + listOfTask[listOfTask.Count -1].ItemDate);
            //label2.Text = listBox1.DataBindings.ToString();
            
            //Reset the boxes of Task name and date picker
            textBox1.ResetText();
            dateTimePicker1.ResetText();
 
            //After everything else is done we write the new task to the file
            fileWriter.WriteLine($"{listOfTask[listOfTask.Count - 1].ItemName},{listOfTask[listOfTask.Count - 1].ItemDate}");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Quit program
            //Save list to file

          
            //Close the file system
            fileWriter.Close();

            //Quits program, nice and simple
            Application.Exit();
        }
    

        private void button5_Click(object sender, EventArgs e)
        {
            //Removes a selected item from list
            listOfTask.RemoveAt(listBox1.SelectedIndex);

            //Closes the previous file writer and opens a new one in truncate mode
            //This then creates essentially a new file for us to work with.
            //Again since the size of the data we are expected to be working with is not large this kind of function is easy and quick.
            fileWriter.Close();
            var output = new FileStream(fileName, FileMode.Truncate, FileAccess.ReadWrite);
            fileWriter = new StreamWriter(output);
            for(int i = 0; i < listOfTask.Count; i++)
            {
                fileWriter.WriteLine($"{listOfTask[i].ItemName},{listOfTask[i].ItemDate}");
            }
            fileWriter.Close();

            //After recreating the file we reopen the file writer as an append file writer, allowing for additive saving.
            fileWriter = new StreamWriter(fileName, append: true);

            listBox1.Refresh();
            
        }

        
    }
}
