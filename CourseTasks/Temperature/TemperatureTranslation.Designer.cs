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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.SystemColors.Window;
            this.resultBox.Location = new System.Drawing.Point(48, 302);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(220, 20);
            this.resultBox.TabIndex = 2;
            this.resultBox.TabStop = false;
            this.resultBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // derivableScale
            // 
            this.derivableScale.AccessibleDescription = "";
            this.derivableScale.AccessibleName = "";
            this.derivableScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.derivableScale.FormattingEnabled = true;
            this.derivableScale.ItemHeight = 13;
            this.derivableScale.Location = new System.Drawing.Point(48, 162);
            this.derivableScale.Name = "derivableScale";
            this.derivableScale.Size = new System.Drawing.Size(220, 21);
            this.derivableScale.TabIndex = 4;
            this.derivableScale.TabStop = false;
            this.derivableScale.SelectedIndexChanged += new System.EventHandler(this.DerivableScale_SelectedIndexChanged);
            // 
            // translationButton
            // 
            this.translationButton.Location = new System.Drawing.Point(48, 206);
            this.translationButton.Name = "translationButton";
            this.translationButton.Size = new System.Drawing.Size(220, 63);
            this.translationButton.TabIndex = 5;
            this.translationButton.TabStop = false;
            this.translationButton.Text = "ПЕРЕВЕСТИ";
            this.translationButton.UseVisualStyleBackColor = true;
            this.translationButton.Click += new System.EventHandler(this.TranslationButton_Click);
            this.translationButton.Leave += new System.EventHandler(this.TranslationButton_Leave);
            // 
            // notDigitError
            // 
            this.notDigitError.AutoSize = true;
            this.notDigitError.BackColor = System.Drawing.Color.Transparent;
            this.notDigitError.ForeColor = System.Drawing.Color.DarkRed;
            this.notDigitError.Location = new System.Drawing.Point(39, 75);
            this.notDigitError.Name = "notDigitError";
            this.notDigitError.Size = new System.Drawing.Size(238, 26);
            this.notDigitError.TabIndex = 6;
            this.notDigitError.Text = "Вводить нужно число\r\n(для вещественных чисел используйте точку)";
            this.notDigitError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.notDigitError.Visible = false;
            // 
            // boxForTemperature
            // 
            this.boxForTemperature.AccessibleDescription = "";
            this.boxForTemperature.BackColor = System.Drawing.SystemColors.Window;
            this.boxForTemperature.Location = new System.Drawing.Point(48, 53);
            this.boxForTemperature.Name = "boxForTemperature";
            this.boxForTemperature.Size = new System.Drawing.Size(220, 20);
            this.boxForTemperature.TabIndex = 1;
            this.boxForTemperature.TabStop = false;
            this.boxForTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.boxForTemperature.TextChanged += new System.EventHandler(this.BoxForTemperature_TextChanged);
            this.boxForTemperature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BoxForTemperature_KeyPress);
            // 
            // introducedScale
            // 
            this.introducedScale.AccessibleDescription = "";
            this.introducedScale.AccessibleName = "";
            this.introducedScale.BackColor = System.Drawing.SystemColors.Window;
            this.introducedScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.introducedScale.FormattingEnabled = true;
            this.introducedScale.Location = new System.Drawing.Point(48, 121);
            this.introducedScale.Name = "introducedScale";
            this.introducedScale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.introducedScale.Size = new System.Drawing.Size(220, 21);
            this.introducedScale.TabIndex = 3;
            this.introducedScale.TabStop = false;
            this.introducedScale.SelectedIndexChanged += new System.EventHandler(this.IntroducedScale_SelectedIndexChanged);
            // 
            // notSelectedError
            // 
            this.notSelectedError.AutoSize = true;
            this.notSelectedError.BackColor = System.Drawing.Color.Transparent;
            this.notSelectedError.ForeColor = System.Drawing.Color.DarkRed;
            this.notSelectedError.Location = new System.Drawing.Point(62, 270);
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
            this.notEnteredError.Location = new System.Drawing.Point(90, 75);
            this.notEnteredError.Name = "notEnteredError";
            this.notEnteredError.Size = new System.Drawing.Size(137, 13);
            this.notEnteredError.TabIndex = 8;
            this.notEnteredError.Text = "Вы не ввели температуру";
            this.notEnteredError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.notEnteredError.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(95, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Вводимая температура";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(76, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Шкала, из которой переводить";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(79, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Шкала, в которую переводить";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(129, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Результат";
            // 
            // TemperatureTranslation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(317, 342);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.notEnteredError);
            this.Controls.Add(this.notSelectedError);
            this.Controls.Add(this.introducedScale);
            this.Controls.Add(this.boxForTemperature);
            this.Controls.Add(this.notDigitError);
            this.Controls.Add(this.translationButton);
            this.Controls.Add(this.derivableScale);
            this.Controls.Add(this.resultBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.Label notSelectedError;
        private System.Windows.Forms.Label notEnteredError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox introducedScale;
    }
}

