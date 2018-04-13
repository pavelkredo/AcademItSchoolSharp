using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Temperature.Scales;

namespace Temperature
{
    public partial class TemperatureTranslation : Form
    {
        private double originalTemperature;
        private double finalTemperature;
        private string originalScale;
        private string finalScale;
        private IScale originalScaleObject;
        private IScale finalScaleObject;
        List<IScale> scales = new List<IScale> { new Celsius(), new Kelvin(), new Fahrenheit() };

        public TemperatureTranslation()
        {
            InitializeComponent();
        }

        private void TemperatureTranslation_Load(object sender, EventArgs e)
        {
            foreach (IScale item in scales)
            {
                introducedScale.Items.Add(item.GetName());
                derivableScale.Items.Add(item.GetName());
            }
        }

        private void boxForTemperature_TextChanged(object sender, EventArgs e)
        {
            notDigitError.Visible = false;

            double.TryParse(boxForTemperature.Text, out originalTemperature);
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

            foreach(IScale item in scales)
            {
                if(originalScale.Equals(item.GetName()))
                {
                    originalScaleObject = item;
                }

                if(finalScale.Equals(item.GetName()))
                {
                    finalScaleObject = item;
                }
            }

            originalScaleObject.Value = originalTemperature;
            finalTemperature = originalScaleObject.GetFinalTemperature(finalScaleObject);
            resultBox.Text = finalTemperature.ToString();
        }

        private void translationButton_Leave(object sender, EventArgs e)
        {
            notSelectedError.Visible = false;
            notEnteredError.Visible = false;
        }
    }
}