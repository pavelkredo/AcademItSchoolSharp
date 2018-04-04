using System;
using System.Drawing;
using System.Windows.Forms;

namespace Temperature
{
    public partial class TemperatureTranslation : Form
    {
        private double originalTemperature;
        private double finalTemperature;
        private int originalScale;
        private int finalScale;

        public TemperatureTranslation()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Contains("введите температуру"))
            {
                textBox1.Text = null;
            }

            label1.Visible = false;
            string str = textBox1.Text;

            if (!double.TryParse(str, out originalTemperature))
            {
                label1.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            CalculateTemperature();
            textBox2.Text = finalTemperature.ToString();
        }

        private void CalculateTemperature()
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            string[] installs = new string[] { "цельсия", "фаренгейта", "кельвина" };
            comboBox1.Items.AddRange(installs);
        }
    }
}
