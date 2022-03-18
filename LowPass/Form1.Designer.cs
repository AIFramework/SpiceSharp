namespace LowPass
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chartVisual1 = new AI.Charts.Control.ChartVisual();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.freqCut = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.order = new System.Windows.Forms.TextBox();
            this.C3l = new System.Windows.Forms.Label();
            this.C2l = new System.Windows.Forms.Label();
            this.nC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartVisual1
            // 
            this.chartVisual1.AutoScroll = true;
            this.chartVisual1.BackColor = System.Drawing.Color.White;
            this.chartVisual1.ChartName = "АЧХ";
            this.chartVisual1.ForeColor = System.Drawing.Color.Black;
            this.chartVisual1.IsContextMenu = true;
            this.chartVisual1.IsLogScale = false;
            this.chartVisual1.IsMoove = true;
            this.chartVisual1.IsScale = true;
            this.chartVisual1.IsShowXY = true;
            this.chartVisual1.LabelX = "Частота";
            this.chartVisual1.LabelY = "Коэф. передачи";
            this.chartVisual1.Location = new System.Drawing.Point(341, 1);
            this.chartVisual1.Name = "chartVisual1";
            this.chartVisual1.Size = new System.Drawing.Size(724, 339);
            this.chartVisual1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Частота среза:";
            // 
            // freqCut
            // 
            this.freqCut.Location = new System.Drawing.Point(90, 169);
            this.freqCut.Name = "freqCut";
            this.freqCut.Size = new System.Drawing.Size(110, 20);
            this.freqCut.TabIndex = 3;
            this.freqCut.Text = "10";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 47);
            this.button1.TabIndex = 4;
            this.button1.Text = "Анализ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Порядок:";
            // 
            // order
            // 
            this.order.Location = new System.Drawing.Point(90, 196);
            this.order.Name = "order";
            this.order.Size = new System.Drawing.Size(110, 20);
            this.order.TabIndex = 6;
            this.order.Text = "6";
            // 
            // C3l
            // 
            this.C3l.AutoSize = true;
            this.C3l.Location = new System.Drawing.Point(2, 244);
            this.C3l.Name = "C3l";
            this.C3l.Size = new System.Drawing.Size(20, 13);
            this.C3l.TabIndex = 7;
            this.C3l.Text = "С3";
            // 
            // C2l
            // 
            this.C2l.AutoSize = true;
            this.C2l.Location = new System.Drawing.Point(2, 268);
            this.C2l.Name = "C2l";
            this.C2l.Size = new System.Drawing.Size(20, 13);
            this.C2l.TabIndex = 8;
            this.C2l.Text = "С2";
            // 
            // nC
            // 
            this.nC.AutoSize = true;
            this.nC.Location = new System.Drawing.Point(2, 301);
            this.nC.Name = "nC";
            this.nC.Size = new System.Drawing.Size(90, 13);
            this.nC.TabIndex = 9;
            this.nC.Text = "Число каскадов";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 339);
            this.Controls.Add(this.nC);
            this.Controls.Add(this.C2l);
            this.Controls.Add(this.C3l);
            this.Controls.Add(this.order);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.freqCut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chartVisual1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Фильтр Баттервордта";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AI.Charts.Control.ChartVisual chartVisual1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox freqCut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox order;
        private System.Windows.Forms.Label C3l;
        private System.Windows.Forms.Label C2l;
        private System.Windows.Forms.Label nC;
    }
}

