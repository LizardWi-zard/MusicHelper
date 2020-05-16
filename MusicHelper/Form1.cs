using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form1()
        {
            InitializeComponent();

         
        }

        private void openButton_Click(object sender, EventArgs e)
        {

            audioFileReader = new AudioFileReader(@"C:\Users\EG\Downloads\trak1.mp3");
        }
        private void playSimpleSound()
        {
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
        }
        private void stopSimpleSound()
        {
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Stop();
        }

        private void musicBar_Click(object sender, EventArgs e)
        {
            // musicBar.Value 
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopSimpleSound();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            playSimpleSound();
        }

        private void loudTrackBar_Scroll(object sender, EventArgs e)
        {

        }
    }
}
