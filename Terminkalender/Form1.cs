using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Terminkalender
{
    public partial class Form1 : Form
    {

        private TimeSpan timeLeft;
        System.Timers.Timer t;
        public ListViewItem Selected { get; private set; }

        public Form1()
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
         //   timer.addEvent_Click += Timer_addEvent_Click;
            InitializeComponent();
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void addEvent_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(dateTimePicker1.Value.Date.ToString("dd/MM/yyyy"));
            lvi.SubItems.Add(dateTimePicker2.Value.ToString("HH/mm/ss"));
            lvi.SubItems.Add(textBox.Text);
            listView1.Items.Add(lvi);
            textBox.Text ="";
            t.Start();
            DateTime currentTime = DateTime.Now;
          //  currentTime.ToString("dd/MM/yyyy");
            DateTime userDateTime = dateTimePicker1.Value;
            DateTime userJustTime = dateTimePicker2.Value;
            //    currentTime+
            t.Interval = 1000;

            timeLeft = new TimeSpan(userJustTime.Second - currentTime.Second);
            timer1.Start();

            
            if (currentTime.Second == userJustTime.Second)
                //&& currentTime.Minute >= userJustTime.Minute &&
                //currentTime.Second >= userJustTime.Second && currentTime.Day >= userDateTime.Day &&
                //currentTime.Month >= userDateTime.Month && currentTime.Year >= userDateTime.Year)
                
            
            {
                // timer.Stop();
                t.Interval = 1000;
                MessageBox.Show("Ring, ring...");
            }

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you have some questions about program, write me: and.shmerchuk@gmail.com");
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            string textMessage = Console.ReadLine();
        }

        public void setCurrenltyTime_Click(object sender, EventArgs e)
        {
           //  DateTime timenNow = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

          //  DateTime setTime = dateTimePicker2.Value;
          //  string zeitString = Convert.ToString(setTime);


        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
                
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems[0].Remove();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
        }
    }
}
