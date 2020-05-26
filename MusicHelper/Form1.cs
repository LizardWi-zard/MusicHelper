using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MusicHelper
{
    public partial class MusicHelper : Form
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
        List<FileInfo> backUpList = new List<FileInfo>();
        List<FileInfo> randomTrackList = new List<FileInfo>();
        public MusicHelper()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            
            StopSimpleSound();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "mp3 files (*.mp3)|*.mp3";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Song song = new Song(openFileDialog.FileName);
                    openedFile = new FileInfo(openFileDialog.FileName);

                    addedMusic.Add(openedFile);
                    audioFileReader = new AudioFileReader(openedFile.FullName);
                    musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
                    musicListBox.Items.Add(openedFile.Name);
                    musicListBox.SelectedIndex = addedMusic.Count() - 1;
                }
            }
            musicValue.Value = 0;
        }
        
        private void PlaySimpleSound()
        {
            ChangeMusicValuseOutput();
            waveOutDevice.Init(audioFileReader);
            isPlaing = true;
            startButton.Text = "┃┃";
            waveOutDevice.Play();
        }
    
        private void StopSimpleSound()
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
                PlaySimpleSound();
            }
            else
            {
                StopSimpleSound();
            }
        }

        private void loudTrackBar_Scroll(object sender, EventArgs e)
        {
            audioFileReader.Volume = loudTrackBar.Value;
        }

        private void musicValue_Scroll(object sender, EventArgs e)
        {
            StopSimpleSound();
            audioFileReader.Position = 0;
            audioFileReader.Skip(musicValue.Value);
            UpdateListeningTime();
            PlaySimpleSound();
        }

        private void musicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopSimpleSound();
            musicValue.Value = 0;
            selectedSongName = musicListBox.SelectedItem.ToString();

            var songFileInfo = addedMusic.Where(x => x.Name == selectedSongName).FirstOrDefault();

            if (songFileInfo != null)
            {
                audioFileReader = new AudioFileReader(songFileInfo.FullName);
                musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            }

            UpdateListeningTime();
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
                UpdateListeningTime();
            }
            else if (infinitiMusic.Checked)
            {
                SetSameTrack();
                PlaySimpleSound();
            } 
            else if (leftTrackCount.Value>0)
            {
                SetSameTrack();
                leftTrackCount.Value--;
                PlaySimpleSound();
            }
            else
            {
                FindTrack(true);
            }
        }

        private void SetSameTrack()
        {
            StopSimpleSound();
            int SongIndex = musicListBox.SelectedIndex;
            audioFileReader = new AudioFileReader(addedMusic[SongIndex].FullName);
            musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            musicValue.Value = 0;
        }
       
        private void nextTrack_Click(object sender, EventArgs e)
        {
            FindTrack(true);
        }

        private void previousTrack_Click(object sender, EventArgs e)
        {
            FindTrack(false);
        }

        private void FindTrack(bool nextTrack)
        {
            StopSimpleSound();

            if (nextTrack)
            {
                int nextSongIndex = CountNextIndex();

                SetCurrenTrack(nextSongIndex);
            } 
            else
            {
                int nextSongIndex = CountPastIndex();

                SetCurrenTrack(nextSongIndex);
            }

            leftTrackCount.Value = 0;
            UpdateListeningTime();

            PlaySimpleSound();
        }

        private void SetCurrenTrack(int nextSongIndex)
        {
            audioFileReader = new AudioFileReader(addedMusic[nextSongIndex].FullName);
            musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            musicValue.Value = 0;
            musicListBox.SelectedIndex = nextSongIndex;
        }

        private int CountNextIndex()
        {
            int firstSongIndex = 0;

            int nextSongIndex = musicListBox.SelectedIndex + 1;

            if (nextSongIndex > addedMusic.Count - 1)
                nextSongIndex = firstSongIndex;

            return nextSongIndex;
        }

        private int CountPastIndex()
        {
            int lastSongIndex = addedMusic.Count - 1;

            int nextSongIndex = musicListBox.SelectedIndex - 1;

            if (nextSongIndex < 0)
                nextSongIndex = lastSongIndex;

            return nextSongIndex;
        }

        private void randomTrack_CheckedChanged(object sender, EventArgs e)
        {
                musicListBox.Items.Clear();

            if (randomTrack.Checked)
            {
                backUpList.AddRange(addedMusic);


                CreateRandomTracksList();

                SetTracksList(randomTrackList);
            } 
            else
            {
              
                SetTracksList(addedMusic);
            }
        }

        private void CreateRandomTracksList()
        {
            for (int i = 0; i < addedMusic.Count; i++)
                randomTrackList.Clear();
            {
                int index = new Random().Next(0, backUpList.Count);
                randomTrackList.Add(backUpList[index]);
                backUpList.RemoveAt(index);
            }
        }
 
        private void SetTracksList(List<FileInfo> musicList)
        {  
            foreach (var item in musicList)
            {
                musicListBox.Items.Add(item.Name);
            }
        }

        private void UpdateListeningTime()
        {
            currentMoment = new DateTime(2020, 5, 22, musicValue.Value / 6000, musicValue.Value / 60, musicValue.Value % 60);
            currentMomentLable.Text = currentMoment.ToString("mm:ss");

            songLength = new DateTime(2020, 5, 22, musicValue.Maximum / 6000, musicValue.Maximum / 60, musicValue.Maximum % 60);
            maxLengthLabel.Text = songLength.ToString("mm:ss");
        }
    }
}