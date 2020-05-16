namespace MusicHelper
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
            this.openButton = new System.Windows.Forms.Button();
            this.musicBar = new System.Windows.Forms.ProgressBar();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.loudTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.loudTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(640, 417);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open File";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // musicBar
            // 
            this.musicBar.Location = new System.Drawing.Point(234, 386);
            this.musicBar.Name = "musicBar";
            this.musicBar.Size = new System.Drawing.Size(250, 25);
            this.musicBar.TabIndex = 1;
            this.musicBar.Click += new System.EventHandler(this.musicBar_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(361, 415);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(28, 25);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "▶";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(327, 415);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(28, 25);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "┃┃";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // loudTrackBar
            // 
            this.loudTrackBar.Location = new System.Drawing.Point(12, 386);
            this.loudTrackBar.Maximum = 100;
            this.loudTrackBar.Name = "loudTrackBar";
            this.loudTrackBar.Size = new System.Drawing.Size(204, 45);
            this.loudTrackBar.TabIndex = 4;
            this.loudTrackBar.Scroll += new System.EventHandler(this.loudTrackBar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 450);
            this.Controls.Add(this.loudTrackBar);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.musicBar);
            this.Controls.Add(this.openButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.loudTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.ProgressBar musicBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TrackBar loudTrackBar;
    }
}

