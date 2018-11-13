using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cit265_Bennett_I_A6
{
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
