using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MusicHelper
{
    public partial class Form1 : Form
    {
        Timer secondTimer;
        IWavePlayer waveOutDevice = new WaveOut();
        AudioFileReader audioFileReader;
        List<FileInfo> addedMusic = new List<FileInfo>();
        bool isPlaing = false;
        FileInfo openedFile;

        public Form1()
        {
            InitializeComponent();

            foreach (var path in addedMusic)
            {
                musicListBox.Items.Add(path.FullName);
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            stopSimpleSound();
          

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "mp3 files (*.mp3)|*.mp3";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    openedFile = new FileInfo(openFileDialog.FileName);

                    addedMusic.Add(openedFile);
                    audioFileReader = new AudioFileReader(openedFile.FullName);
                    musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
                    musicListBox.Items.Add(openedFile.Name);
                }
            }

            musicValue.Value = 1;
        }
        private void playSimpleSound()
        {
            //musicValue.Value = Convert.ToInt32(audioFileReader.Position);
            //ChangeMusicValuseOutput(); //TODO убрать комментарий чтобы работало
            waveOutDevice.Init(audioFileReader);
            isPlaing = true;
            startButton.Text = "┃┃";
            waveOutDevice.Play();
        }
        private void stopSimpleSound()
        {
            startButton.Text = "▶";
            isPlaing = false;
            //secondTimer.Stop(); //TODO проблема при открытии трека
            waveOutDevice.Stop();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!isPlaing && audioFileReader != null)
            {
                playSimpleSound();                
            }
            else
            {
                stopSimpleSound();                
            }
        }

        private void loudTrackBar_Scroll(object sender, EventArgs e)
        {
            audioFileReader.Volume = loudTrackBar.Value;
        }

        private void musicValue_Scroll(object sender, EventArgs e)
        {
            //stopSimpleSound();
            audioFileReader.Position = 0;
            audioFileReader.Skip(musicValue.Value);
            //playSimpleSound();
        }

        private void musicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            stopSimpleSound();
            string selectedSongName = musicListBox.SelectedItem.ToString(); 

            var songFileInfo = addedMusic.Where(x => x.Name == selectedSongName).FirstOrDefault();

            if (songFileInfo != null)
            {
                audioFileReader = new AudioFileReader(songFileInfo.FullName);
                musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            }
        }
        private void ChangeMusicValuseOutput()
        {
            {
                SetTimer();
            }
       
            void SetTimer()
            {
                secondTimer = new Timer(1000);
                secondTimer.Elapsed += OnTimedEvent;
                secondTimer.AutoReset = true;
                secondTimer.Enabled = true;
            }
       
            void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                musicValue.Value = musicValue.Value+1; //TODO вот тут проблема вылазит про потоки
            }
        }
    }
}