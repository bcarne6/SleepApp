using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace SleepApp
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Runs Background worker so that ui is responsive.
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }        
        
        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                if(checkBox1.Checked)
                {
                    var userDate = dateTimePicker1.Text;
                    var userTime = dateTimePicker2.Text;
                    DateTime dt = DateTime.Now;
                    string formattedDate = dt.DayOfWeek.ToString() + ", " + dt.ToString("MMMM") + " " + dt.Day + ", " + dt.Year;
                    string formattedTime = DateTime.Now.ToString("hh:mm tt");
                    if ((userDate == formattedDate) && (userTime == formattedTime))
                    {
                        Application.SetSuspendState(PowerState.Suspend, true, true);
                        MessageBox.Show("Program slept successfully");
                        Application.Exit();
                    }
                }                        
            }                   
        }
    }
}
