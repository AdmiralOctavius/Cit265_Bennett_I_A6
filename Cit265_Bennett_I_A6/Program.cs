/*
 * Name: Isaac Bennett
 * Class: CIT265
 * Assignment: A6
 * Professor: Davide Mauro
 * 
 * Notes: Massive thanks to Philip Taylor for helping with many smaller features of my program. In particular the hotkeys portion of the assignment and the ToString override.
 * An apology to Prof. Mauro for turning this in late, I've been not well and have been struggling with all of my classes.
 * 
 * A question: In my program I set the FileWriter to be open through the entire program. In reality I wasn't sure how much processing power-
 * -it takes to open a new file writer and close one constantly so I decided to keep this open. 
 * Is this bad design?
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cit265_Bennett_I_A6
{

    //Custom class to hold items for the task manager
    //Built with properties and private variables
    //The overriden tostring function allows for an easier time displaying data in the ListBox on the form
    public class TaskItem
    {
        private string itemName;
        private DateTime itemDate;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
            
        public DateTime ItemDate
        {
            get { return itemDate; }
            set { itemDate = value; }
        }
        
        public override string ToString()
        {
            string value;
            value = ItemName + " " + itemDate.ToShortDateString();
            return value;
        }
    }


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        
        [STAThread]
        static void Main()
        { 
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
