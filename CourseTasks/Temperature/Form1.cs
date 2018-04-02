using System;
using System.Windows.Forms;

namespace Temperature
{
    public partial class Form1 : Form
    {
        double originalTemperature;
        double finalTemperature;
        int originalScale;
        int finalScale;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            string str = textBox1.Text;

            if (!double.TryParse(str, out originalTemperature))
            {
                label1.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            originalScale = comboBox1.SelectedIndex;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            finalScale = comboBox2.SelectedIndex;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (originalScale == 0 && finalScale == 1)
            {
                finalTemperature = originalTemperature * 1.8 + 32;
            }
            else if (originalScale == 0 && finalScale == 2)
            {
                finalTemperature = originalTemperature + 273.15;
            }
            else if (originalScale == 1 && finalScale == 0)
            {
                finalTemperature = (originalTemperature - 32) / 1.8;
            }
            else if (originalScale == 1 && finalScale == 2)
            {
                finalTemperature = (originalTemperature - 32) / 1.8 + 273.15;
            }
            else if (originalScale == 2 && finalScale == 0)
            {
                finalTemperature = originalTemperature - 273.15;
            }
            else if (originalScale == 2 && finalScale == 1)
            {
                finalTemperature = 1.8 * (originalTemperature - 273.15) + 32;
            }
            else
            {
                finalTemperature = originalTemperature;
            }

            textBox2.Text = finalTemperature.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
