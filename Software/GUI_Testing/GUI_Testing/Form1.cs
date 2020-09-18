using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Xml;

namespace GUI_Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            comboBox1.DataSource = SerialPort.GetPortNames();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort6.IsOpen) {// Neu nhu object SerialPort1 chua dc mo thi...
                serialPort6.Open(); // Mo cong Serial
               // serialPort6.PortName = comboBox1.Text; // Cong Serial = cong COM ma minh chon
            }
            if (serialPort6.IsOpen)
                label3.Text = "Connected";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort6.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort6.Write("1"); // gui byte 1 den cong Serial
            label3.Text = "Led turning on";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
                //timer1.Start();
                serialPort6.Write("0"); // gui byte 0 den cong Serial
                label3.Text = "Led turning off";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
           // comboBox1.DataSource = SerialPort.GetPortNames();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            comboBox1.DataSource = SerialPort.GetPortNames();
            if (!serialPort6.IsOpen)
            {
                button1.Text = ("Connect");
                label3.Text = "Nothing is connected";
                label3.ForeColor = Color.Red;
            }
            //Nếu Timer được làm mới, Cổng serialPort1 chưa được mở thì thay đổi Text trong button1, 
            //label3… đổi màu text label3 thành màu đỏ 
            if (serialPort6.IsOpen)
            {
                label3.Text = "Connecting";
                label3.ForeColor = Color.Green;
                //serialPort6.Write("0");

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s;
            if (label3.Text == "Connecting")
            {
                s = textBox1.Text;
                serialPort6.Write(s);
            }
        }
    }
}
