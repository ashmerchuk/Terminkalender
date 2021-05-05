using System;
using System.Windows.Forms;
using System.Timers;
using System.Drawing;

namespace Terminkalender
{
    public partial class Form1 : Form
    {
        public ListViewItem Selected { get; private set; }

        private void addEvent_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(dateTimePicker1.Value.Date.ToString("dd/MM/yyyy"));
            lvi.SubItems.Add(dateTimePicker2.Value.ToString("HH/mm/ss"));
            lvi.SubItems.Add(textBox.Text);
            listView1.Items.Add(lvi);
            textBox.Text = "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (DateTime.Now.ToString("dd/MM/yyyy") == listView1.Items[i].SubItems[0].Text &&
                    DateTime.Now.ToString("HH/mm/ss") == listView1.Items[i].SubItems[1].Text)
                {
                    listView1.Items[i].BackColor = Color.Red;
/*                    if (WindowState == FormWindowState.Minimized)
                    {
                        this.Show(listView1.Items[i].SubItems[1]);
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(1000);
                    }*/
                    Console.Beep(300, 100);
                    Console.Beep(450, 100);
                    Console.Beep(600, 100);
                    MessageBox.Show(listView1.Items[i].SubItems[2].Text);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bitte kontaktieren Sie mich bei eventuellen Fragen: and.shmerchuk@gmail.com");
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void setCurrenltyTime_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].Remove();
            }
        }

        

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
                
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Text = "Tetminkalender";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }
    }
}