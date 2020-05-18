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
using System.Windows.Forms;

namespace MusicHelper
{
    public partial class Form1 : Form
    {
        IWavePlayer waveOutDevice = new WaveOut();
        AudioFileReader audioFileReader;
        List<string> musicPath = new List<string>();
        bool isPlaing = false;

        public Form1()
        {
            InitializeComponent();

            // musicValue.Maximum = Convert.ToInt32(audioFileReader.Length);
            foreach (var path in musicPath)
            {
                musicList.Items.Add(path);
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "mp3 files (*.mp3)|*.mp3";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            musicPath.Add(filePath);
            audioFileReader = new AudioFileReader(filePath);
            musicList.Items.Add(filePath);
        }
        private void playSimpleSound()
        {            
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
        }
        private void stopSimpleSound()
        {
         //   waveOutDevice.Init(audioFileReader);
            waveOutDevice.Stop();
        }

        private void musicBar_Click(object sender, EventArgs e)
        {
            
            // musicBar.Value 
        }

        private void startButton_Click(object sender, EventArgs e)
        { 
            if (!isPlaing && audioFileReader != null)
            {
                playSimpleSound();
                startButton.Text = "┃┃";
                isPlaing = true;
            } 
            else
            {
                stopSimpleSound();
                startButton.Text = "▶";
                isPlaing = false;
            }
        }

        private void loudTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void musicValue_Scroll(object sender, EventArgs e)
        {

        }

        private void musicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            stopSimpleSound();
            startButton.Text = "▶";
            string selectedPath = musicList.SelectedItem.ToString();
            audioFileReader = new AudioFileReader(selectedPath);
        }
    }
}
