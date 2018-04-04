namespace Temperature
{
    partial class TemperatureTranslation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemperatureTranslation));
            this.resultBox = new System.Windows.Forms.TextBox();
            this.derivableScale = new System.Windows.Forms.ComboBox();
            this.translationButton = new System.Windows.Forms.Button();
            this.notDigitError = new System.Windows.Forms.Label();
            this.boxForTemperature = new System.Windows.Forms.TextBox();
            this.introducedScale = new System.Windows.Forms.ComboBox();
            this.notSelectedError = new System.Windows.Forms.Label();
            this.notEnteredError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.SystemColors.Window;
            this.resultBox.Location = new System.Drawing.Point(128, 306);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(220, 20);
            this.resultBox.TabIndex = 2;
            this.resultBox.TabStop = false;
            this.resultBox.Text = "результат";
            this.resultBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // derivableScale
            // 
            this.derivableScale.AccessibleDescription = "";
            this.derivableScale.AccessibleName = "";
            this.derivableScale.FormattingEnabled = true;
            this.derivableScale.ItemHeight = 13;
            this.derivableScale.Location = new System.Drawing.Point(128, 177);
            this.derivableScale.Name = "derivableScale";
            this.derivableScale.Size = new System.Drawing.Size(220, 21);
            this.derivableScale.TabIndex = 4;
            this.derivableScale.TabStop = false;
            this.derivableScale.Text = "выберите в какую шкалу переводить";
            this.derivableScale.SelectedIndexChanged += new System.EventHandler(this.derivableScale_SelectedIndexChanged);
            // 
            // translationButton
            // 
            this.translationButton.Location = new System.Drawing.Point(128, 225);
            this.translationButton.Name = "translationButton";
            this.translationButton.Size = new System.Drawing.Size(220, 63);
            this.translationButton.TabIndex = 5;
            this.translationButton.TabStop = false;
            this.translationButton.Text = "ПЕРЕВЕСТИ";
            this.translationButton.UseVisualStyleBackColor = true;
            this.translationButton.Click += new System.EventHandler(this.translationButton_Click);
            this.translationButton.Leave += new System.EventHandler(this.translationButton_Leave);
            // 
            // notDigitError
            // 
            this.notDigitError.AutoSize = true;
            this.notDigitError.BackColor = System.Drawing.Color.Transparent;
            this.notDigitError.ForeColor = System.Drawing.Color.DarkRed;
            this.notDigitError.Location = new System.Drawing.Point(119, 110);
            this.notDigitError.Name = "notDigitError";
            this.notDigitError.Size = new System.Drawing.Size(238, 26);
            this.notDigitError.TabIndex = 6;
            this.notDigitError.Text = "вводить нужно число\r\n(для вещественных чисел используйте точку)";
            this.notDigitError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.notDigitError.Visible = false;
            // 
            // boxForTemperature
            // 
            this.boxForTemperature.AccessibleDescription = "";
            this.boxForTemperature.BackColor = System.Drawing.SystemColors.Window;
            this.boxForTemperature.Location = new System.Drawing.Point(128, 88);
            this.boxForTemperature.Name = "boxForTemperature";
            this.boxForTemperature.Size = new System.Drawing.Size(220, 20);
            this.boxForTemperature.TabIndex = 1;
            this.boxForTemperature.TabStop = false;
            this.boxForTemperature.Text = "введите температуру";
            this.boxForTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxForTemperature.TextChanged += new System.EventHandler(this.boxForTemperature_TextChanged);
            this.boxForTemperature.Enter += new System.EventHandler(this.boxForTemperature_Enter);
            this.boxForTemperature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxForTemperature_KeyPress);
            this.boxForTemperature.Leave += new System.EventHandler(this.boxForTemperature_Leave);
            // 
            // introducedScale
            // 
            this.introducedScale.AccessibleDescription = "";
            this.introducedScale.AccessibleName = "";
            this.introducedScale.FormattingEnabled = true;
            this.introducedScale.Location = new System.Drawing.Point(128, 150);
            this.introducedScale.Name = "introducedScale";
            this.introducedScale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.introducedScale.Size = new System.Drawing.Size(220, 21);
            this.introducedScale.TabIndex = 3;
            this.introducedScale.TabStop = false;
            this.introducedScale.Text = "выберите переводимую шкалу";
            this.introducedScale.SelectedIndexChanged += new System.EventHandler(this.introducedScale_SelectedIndexChanged);
            // 
            // notSelectedError
            // 
            this.notSelectedError.AutoSize = true;
            this.notSelectedError.BackColor = System.Drawing.Color.Transparent;
            this.notSelectedError.ForeColor = System.Drawing.Color.DarkRed;
            this.notSelectedError.Location = new System.Drawing.Point(142, 289);
            this.notSelectedError.Name = "notSelectedError";
            this.notSelectedError.Size = new System.Drawing.Size(193, 13);
            this.notSelectedError.TabIndex = 7;
            this.notSelectedError.Text = "нужно выбрать шкалы для перевода";
            this.notSelectedError.Visible = false;
            // 
            // notEnteredError
            // 
            this.notEnteredError.AutoSize = true;
            this.notEnteredError.BackColor = System.Drawing.Color.Transparent;
            this.notEnteredError.ForeColor = System.Drawing.Color.DarkRed;
            this.notEnteredError.Location = new System.Drawing.Point(170, 110);
            this.notEnteredError.Name = "notEnteredError";
            this.notEnteredError.Size = new System.Drawing.Size(136, 13);
            this.notEnteredError.TabIndex = 8;
            this.notEnteredError.Text = "вы не ввели температуру";
            this.notEnteredError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.notEnteredError.Visible = false;
            // 
            // TemperatureTranslation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(476, 394);
            this.Controls.Add(this.notEnteredError);
            this.Controls.Add(this.notSelectedError);
            this.Controls.Add(this.introducedScale);
            this.Controls.Add(this.boxForTemperature);
            this.Controls.Add(this.notDigitError);
            this.Controls.Add(this.translationButton);
            this.Controls.Add(this.derivableScale);
            this.Controls.Add(this.resultBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TemperatureTranslation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перевод температуры";
            this.Load += new System.EventHandler(this.TemperatureTranslation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.ComboBox derivableScale;
        private System.Windows.Forms.Button translationButton;
        private System.Windows.Forms.Label notDigitError;
        private System.Windows.Forms.TextBox boxForTemperature;
        private System.Windows.Forms.ComboBox introducedScale;
        private System.Windows.Forms.Label notSelectedError;
        private System.Windows.Forms.Label notEnteredError;
    }
}

