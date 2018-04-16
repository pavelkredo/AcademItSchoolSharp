using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Temperature.Scales;
using Temperature.Temperature;

namespace Temperature
{
    public partial class TemperatureTranslation : Form
    {
        private double originalTemperature;
        private string originalScale;
        private string finalScale;
        private IScale originalScaleObject;
        private IScale finalScaleObject;
        private readonly List<IScale> scales = new List<IScale> { new Celsius(), new Fahrenheit(), new Kelvin() };

        public TemperatureTranslation()
        {
            InitializeComponent();
        }

        private void TemperatureTranslation_Load(object sender, EventArgs e)
        {
            foreach (var item in scales)
            {
                introducedScale.Items.Add(item.Name);
                derivableScale.Items.Add(item.Name);
            }
        }

        private void BoxForTemperature_TextChanged(object sender, EventArgs e)
        {
            notDigitError.Visible = false;

            double.TryParse(boxForTemperature.Text, out originalTemperature);
        }

        private void BoxForTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            var isHandled = true;
            var character = e.KeyChar;

            if (!char.IsDigit(character))
            {
                notDigitError.Visible = true;
            }

            if (char.IsDigit(character) || (!boxForTemperature.Text.Contains(character.ToString()) && character == '.') || character == (char)Keys.Back)
            {
                isHandled = false;
            }

            e.Handled = isHandled;
        }

        private void IntroducedScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            originalScale = introducedScale.Text;
        }

        private void DerivableScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            finalScale = derivableScale.Text;
        }

        private void TranslationButton_Click(object sender, EventArgs e)
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

            foreach (IScale item in scales)
            {
                if (originalScale.Equals(item.Name))
                {
                    originalScaleObject = item;
                }

                if (finalScale.Equals(item.Name))
                {
                    finalScaleObject = item;
                }
            }

            TemperatureConvertion converter = new TemperatureConvertion();
            resultBox.Text = converter.ConvertTemperature(originalTemperature, originalScaleObject, finalScaleObject).ToString();
        }

        private void TranslationButton_Leave(object sender, EventArgs e)
        {
            notSelectedError.Visible = false;
            notEnteredError.Visible = false;
        }
    }
}