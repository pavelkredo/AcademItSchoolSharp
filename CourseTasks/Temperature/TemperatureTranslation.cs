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
            introducedScale.Items.AddRange(installs);
            derivableScale.Items.AddRange(installs);
        }

        private void boxForTemperature_TextChanged(object sender, EventArgs e)
        {
            notDigitError.Visible = false;

            double.TryParse(boxForTemperature.Text, out originalTemperature);
        }

        private void boxForTemperature_Enter(object sender, EventArgs e)
        {
            if (originalTemperature != 0)
            {
                boxForTemperature.Text = originalTemperature.ToString();
            }
            else
            {
                boxForTemperature.Text = null;
            }
        }

        private void boxForTemperature_Leave(object sender, EventArgs e)
        {
            if (boxForTemperature.Text == "")
            {
                boxForTemperature.Text = "введите температуру";
            }
        }

        private void boxForTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isHandled = true;
            char character = e.KeyChar;

            if (!(char.IsDigit(character)))
            {
                notDigitError.Visible = true;
            }

            if (char.IsDigit(character) || (!boxForTemperature.Text.Contains(character.ToString()) && character == '.') || character == (char)Keys.Back)
            {
                isHandled = false;
            }

            e.Handled = isHandled;
        }

        private void introducedScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            originalScale = introducedScale.Text;
        }

        private void derivableScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            finalScale = derivableScale.Text;
        }

        private void translationButton_Click(object sender, EventArgs e)
        {
            if (boxForTemperature.Text == "введите температуру")
            {
                notEnteredError.Visible = true;
                return;
            }

            if (originalScale == null || finalScale == null)
            {
                notSelectedError.Visible = true;
                return;
            }

            CalculateTemperature();
            resultBox.Text = finalTemperature.ToString();
        }

        private void translationButton_Leave(object sender, EventArgs e)
        {
            notSelectedError.Visible = false;
            notEnteredError.Visible = false;
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
    }
}