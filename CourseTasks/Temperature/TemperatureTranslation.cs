using System;
using System.Drawing;
using System.Windows.Forms;

namespace Temperature
{
    public partial class TemperatureTranslation : Form
    {
        private double originalTemperature;
        private double finalTemperature;
        private string originalScale;
        private string finalScale;

        public TemperatureTranslation()
        {
            InitializeComponent();
        }

        private void TemperatureTranslation_Load(object sender, EventArgs e)
        {
            string[] installs = new string[] { "цельсия", "фаренгейта", "кельвина" };
            comboBox1.Items.AddRange(installs);
            comboBox2.Items.AddRange(installs);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;

            double.TryParse(textBox1.Text, out originalTemperature);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            originalScale = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            finalScale = comboBox2.Text;
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
            if (originalScale == "цельсия" && finalScale == "фаренгейта")
            {
                finalTemperature = originalTemperature * 1.8 + 32;
            }
            else if (originalScale == "цельсия" && finalScale == "кельвина")
            {
                finalTemperature = originalTemperature + 273.15;
            }
            else if (originalScale == "фаренгейта" && finalScale == "цельсия")
            {
                finalTemperature = (originalTemperature - 32) / 1.8;
            }
            else if (originalScale == "фаренгейта" && finalScale == "кельвина")
            {
                finalTemperature = (originalTemperature - 32) / 1.8 + 273.15;
            }
            else if (originalScale == "кельвина" && finalScale == "цельсия")
            {
                finalTemperature = originalTemperature - 273.15;
            }
            else if (originalScale == "кельвина" && finalScale == "фаренгейта")
            {
                finalTemperature = 1.8 * (originalTemperature - 273.15) + 32;
            }
            else
            {
                finalTemperature = originalTemperature;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "введите температуру";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isHandled = true;
            char character = e.KeyChar;

            if (!(char.IsDigit(character)))
            {
                label1.Visible = true;
            }

            if (char.IsDigit(character) || (!textBox1.Text.Contains(character.ToString()) && character == '.') || character == (char)Keys.Back)
            {
                isHandled = false;
            }

            e.Handled = isHandled;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
