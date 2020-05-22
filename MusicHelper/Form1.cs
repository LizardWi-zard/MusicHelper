using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MusicHelper
{
    public partial class form1 : Form
    {
        Timer timer;
        IWavePlayer waveOutDevice = new WaveOut();
        AudioFileReader audioFileReader;
        List<FileInfo> addedMusic = new List<FileInfo>();
        bool isPlaing = false;
        FileInfo openedFile;
        string selectedSongName;
        DateTime songLength = new DateTime();
        DateTime currentMoment = new DateTime();

        public form1()
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
            musicValue.Value = 0;
        }
        private void playSimpleSound()
        {
            ChangeMusicValuseOutput();
            waveOutDevice.Init(audioFileReader);
            isPlaing = true;
            startButton.Text = "┃┃";
            waveOutDevice.Play();
        }
        private void stopSimpleSound()
        {
            startButton.Text = "▶";
            if (isPlaing)
                timer.Stop();
            isPlaing = false;
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
            stopSimpleSound();
            audioFileReader.Position = 0;
            audioFileReader.Skip(musicValue.Value);
            LabelOptoins();
            playSimpleSound();
        }

        private void musicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            stopSimpleSound();
            musicValue.Value = 0;
            selectedSongName = musicListBox.SelectedItem.ToString();

            var songFileInfo = addedMusic.Where(x => x.Name == selectedSongName).FirstOrDefault();

            if (songFileInfo != null)
            {
                audioFileReader = new AudioFileReader(songFileInfo.FullName);
                musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            }

            LabelOptoins();
        }

        private void ChangeMusicValuseOutput()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += UpdateListeningProgress;
            timer.Start();
        }

        private void UpdateListeningProgress(Object sender, EventArgs args)
        {
            if (musicValue.Value < musicValue.Maximum)
            {
                musicValue.Value++;
                LabelOptoins();
            }
            else if (infinitiMusic.Checked)
            {
                SetSameTrack();
                playSimpleSound();
            } 
            else if (leftTrackCount.Value>0)
            {
                SetSameTrack();
                leftTrackCount.Value--;
                playSimpleSound();
            }
            else
            {
                stopSimpleSound();

                findTrack(true);
                LabelOptoins();

                playSimpleSound();
            }
        }

        private void nextTrack_Click(object sender, EventArgs e)
        {
            stopSimpleSound();

            findTrack(true);
            LabelOptoins();

            playSimpleSound();
        }

        private void previousTrack_Click(object sender, EventArgs e)
        {
            stopSimpleSound();

            findTrack(false);
            LabelOptoins();

            playSimpleSound();
        }

        private void findTrack(bool nextTrack)
        {
            if (nextTrack)
            {
                int firstSongIndex = 0;

                int nextSongIndex = musicListBox.SelectedIndex + 1;

                if (nextSongIndex > addedMusic.Count - 1)
                    nextSongIndex = firstSongIndex;

                ChangeMusic(nextSongIndex);
            } 
            else
            {
                int lastSongIndex = addedMusic.Count - 1;

                int nextSongIndex = musicListBox.SelectedIndex - 1;

                if (nextSongIndex < 0)
                    nextSongIndex = lastSongIndex;

                ChangeMusic(nextSongIndex);
            }

            leftTrackCount.Value = 0;
            LabelOptoins();
        }

        private void SetSameTrack()
        {
            stopSimpleSound();
            int SongIndex = musicListBox.SelectedIndex;
            audioFileReader = new AudioFileReader(addedMusic[SongIndex].FullName);
            musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            musicValue.Value = 0;
        }

        private void ChangeMusic(int nextSongIndex)
        {
            audioFileReader = new AudioFileReader(addedMusic[nextSongIndex].FullName);
            musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            musicValue.Value = 0;
            musicListBox.SelectedIndex = nextSongIndex;
        }

        private void infinitiMusic_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maxLengthLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void randomTrack_CheckedChanged(object sender, EventArgs e)
        {
            if (randomTrack.Checked)
            {
                musicListBox.Items.Clear();

                List<FileInfo> randomTrack = new List<FileInfo>();
                List<FileInfo> backUpList = new List<FileInfo>();

                foreach (var item in addedMusic)
                {
                    backUpList.Add(item);
                }

                for (int i = 0; i < addedMusic.Count; i++)
                {
                    int b = new Random().Next(0, backUpList.Count);
                    randomTrack.Add(backUpList[b]);
                    backUpList.RemoveAt(b);
                }

                foreach (var item in randomTrack)
                {
                    musicListBox.Items.Add(item.Name);
                }
            } 
            else
            {
                musicListBox.Items.Clear();

                foreach (var item in addedMusic)
                {
                    musicListBox.Items.Add(item.Name);
                }
            }
        }
        private void LabelOptoins()
        {
            currentMoment = new DateTime(2020, 5, 22, musicValue.Value / 6000, musicValue.Value / 60, musicValue.Value % 60);
            currentMomentLable.Text = currentMoment.ToString("mm:ss");

            songLength = new DateTime(2020, 5, 22, musicValue.Maximum / 6000, musicValue.Maximum / 60, musicValue.Maximum % 60);
            maxLengthLabel.Text = songLength.ToString("mm:ss");
        }
    }
}