namespace MusicHelper
{
    partial class MusicHelper
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
            this.startButton = new System.Windows.Forms.Button();
            this.loudTrackBar = new System.Windows.Forms.TrackBar();
            this.musicValue = new System.Windows.Forms.TrackBar();
            this.musicListBox = new System.Windows.Forms.ListBox();
            this.previousTrack = new System.Windows.Forms.Button();
            this.nextTrack = new System.Windows.Forms.Button();
            this.infinitiMusic = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentMomentLable = new System.Windows.Forms.Label();
            this.randomTrack = new System.Windows.Forms.CheckBox();
            this.maxLengthLabel = new System.Windows.Forms.Label();
            this.leftTrackCount = new System.Windows.Forms.NumericUpDown();
            this.ChangeInterface = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loudTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTrackCount)).BeginInit();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(125, 311);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(97, 23);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Open File";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(83, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(68, 25);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "▶";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // loudTrackBar
            // 
            this.loudTrackBar.Location = new System.Drawing.Point(12, 133);
            this.loudTrackBar.Name = "loudTrackBar";
            this.loudTrackBar.Size = new System.Drawing.Size(210, 45);
            this.loudTrackBar.TabIndex = 4;
            this.loudTrackBar.Value = 1;
            this.loudTrackBar.Scroll += new System.EventHandler(this.loudTrackBar_Scroll);
            // 
            // musicValue
            // 
            this.musicValue.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.musicValue.Location = new System.Drawing.Point(12, 67);
            this.musicValue.Name = "musicValue";
            this.musicValue.Size = new System.Drawing.Size(210, 45);
            this.musicValue.TabIndex = 5;
            this.musicValue.Scroll += new System.EventHandler(this.musicValue_Scroll);
            // 
            // musicListBox
            // 
            this.musicListBox.FormattingEnabled = true;
            this.musicListBox.Location = new System.Drawing.Point(12, 184);
            this.musicListBox.Name = "musicListBox";
            this.musicListBox.Size = new System.Drawing.Size(210, 121);
            this.musicListBox.TabIndex = 7;
            this.musicListBox.SelectedIndexChanged += new System.EventHandler(this.musicListBox_SelectedIndexChanged);
            // 
            // previousTrack
            // 
            this.previousTrack.Location = new System.Drawing.Point(12, 12);
            this.previousTrack.Name = "previousTrack";
            this.previousTrack.Size = new System.Drawing.Size(65, 25);
            this.previousTrack.TabIndex = 9;
            this.previousTrack.Text = "|◄";
            this.previousTrack.UseVisualStyleBackColor = true;
            this.previousTrack.Click += new System.EventHandler(this.previousTrack_Click);
            // 
            // nextTrack
            // 
            this.nextTrack.Location = new System.Drawing.Point(157, 12);
            this.nextTrack.Name = "nextTrack";
            this.nextTrack.Size = new System.Drawing.Size(65, 25);
            this.nextTrack.TabIndex = 10;
            this.nextTrack.Text = "►|";
            this.nextTrack.UseVisualStyleBackColor = true;
            this.nextTrack.Click += new System.EventHandler(this.nextTrack_Click);
            // 
            // infinitiMusic
            // 
            this.infinitiMusic.AutoSize = true;
            this.infinitiMusic.Location = new System.Drawing.Point(81, 44);
            this.infinitiMusic.Name = "infinitiMusic";
            this.infinitiMusic.Size = new System.Drawing.Size(50, 17);
            this.infinitiMusic.TabIndex = 11;
            this.infinitiMusic.Text = "∞      ";
            this.infinitiMusic.UseVisualStyleBackColor = true;
            this.infinitiMusic.CheckedChanged += new System.EventHandler(this.infinitiMusic_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "00:00";
            // 
            // currentMomentLable
            // 
            this.currentMomentLable.AutoSize = true;
            this.currentMomentLable.Location = new System.Drawing.Point(97, 99);
            this.currentMomentLable.Name = "currentMomentLable";
            this.currentMomentLable.Size = new System.Drawing.Size(34, 13);
            this.currentMomentLable.TabIndex = 14;
            this.currentMomentLable.Text = "00:00";
            // 
            // randomTrack
            // 
            this.randomTrack.AutoSize = true;
            this.randomTrack.Location = new System.Drawing.Point(137, 44);
            this.randomTrack.Name = "randomTrack";
            this.randomTrack.Size = new System.Drawing.Size(85, 17);
            this.randomTrack.TabIndex = 15;
            this.randomTrack.Text = "mixed tracks";
            this.randomTrack.UseVisualStyleBackColor = true;
            this.randomTrack.CheckedChanged += new System.EventHandler(this.randomTrack_CheckedChanged);
            // 
            // maxLengthLabel
            // 
            this.maxLengthLabel.AutoSize = true;
            this.maxLengthLabel.Location = new System.Drawing.Point(188, 99);
            this.maxLengthLabel.Name = "maxLengthLabel";
            this.maxLengthLabel.Size = new System.Drawing.Size(34, 13);
            this.maxLengthLabel.TabIndex = 16;
            this.maxLengthLabel.Text = "00:00";
            // 
            // leftTrackCount
            // 
            this.leftTrackCount.Location = new System.Drawing.Point(12, 43);
            this.leftTrackCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.leftTrackCount.Name = "leftTrackCount";
            this.leftTrackCount.Size = new System.Drawing.Size(65, 20);
            this.leftTrackCount.TabIndex = 18;
            this.leftTrackCount.ValueChanged += new System.EventHandler(this.leftTrackCount_ValueChanged);
            // 
            // ChangeInterface
            // 
            this.ChangeInterface.Location = new System.Drawing.Point(12, 311);
            this.ChangeInterface.Name = "ChangeInterface";
            this.ChangeInterface.Size = new System.Drawing.Size(107, 23);
            this.ChangeInterface.TabIndex = 19;
            this.ChangeInterface.Text = "Change Interface";
            this.ChangeInterface.UseVisualStyleBackColor = true;
            this.ChangeInterface.Click += new System.EventHandler(this.ChangeInterface_Click);
            // 
            // MusicHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(235, 346);
            this.Controls.Add(this.ChangeInterface);
            this.Controls.Add(this.leftTrackCount);
            this.Controls.Add(this.maxLengthLabel);
            this.Controls.Add(this.randomTrack);
            this.Controls.Add(this.currentMomentLable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.infinitiMusic);
            this.Controls.Add(this.nextTrack);
            this.Controls.Add(this.previousTrack);
            this.Controls.Add(this.musicListBox);
            this.Controls.Add(this.musicValue);
            this.Controls.Add(this.loudTrackBar);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.openButton);
            this.MaximumSize = new System.Drawing.Size(750, 500);
            this.MinimumSize = new System.Drawing.Size(250, 385);
            this.Name = "MusicHelper";
            ((System.ComponentModel.ISupportInitialize)(this.loudTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTrackCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button openButton;
        internal System.Windows.Forms.Button startButton;
        internal System.Windows.Forms.TrackBar loudTrackBar;
        internal System.Windows.Forms.TrackBar musicValue;
        internal System.Windows.Forms.ListBox musicListBox;
        internal System.Windows.Forms.Button previousTrack;
        internal System.Windows.Forms.Button nextTrack;
        internal System.Windows.Forms.CheckBox infinitiMusic;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label currentMomentLable;
        internal System.Windows.Forms.CheckBox randomTrack;
        internal System.Windows.Forms.Label maxLengthLabel;
        internal System.Windows.Forms.NumericUpDown leftTrackCount;
        internal System.Windows.Forms.Button ChangeInterface;
    }
}

