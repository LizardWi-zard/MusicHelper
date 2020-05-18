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
        List<FileInfo> addedMusic = new List<FileInfo>();
        bool isPlaing = false;
        FileInfo openedFile;

        public Form1()
        {
            InitializeComponent();

            // musicValue.Maximum = Convert.ToInt32(audioFileReader.Length);
            foreach (var path in addedMusic)
            {
                musicListBox.Items.Add(path.FullName);
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
                    openedFile =  new FileInfo(openFileDialog.FileName);

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }


            addedMusic.Add(openedFile);
            audioFileReader = new AudioFileReader(openedFile.FullName); // это сразу же музыку проигрывает
            musicListBox.Items.Add(openedFile.Name);
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



        private void musicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            stopSimpleSound();
            startButton.Text = "▶";
            isPlaing = false;
            string selectedPath = musicListBox.SelectedItem.ToString(); // вот тут ломается
            audioFileReader = new AudioFileReader(selectedPath); // вот тут ломается
        }
    }
}
