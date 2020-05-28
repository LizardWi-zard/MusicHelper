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
                
        string selectedSongName;

        DateTime songLength = new DateTime();
        DateTime currentMoment = new DateTime();

        AudioPlayer audioPlayer = new AudioPlayer();
               
        public MusicHelper()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            Stop();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "mp3 files (*.mp3)|*.mp3";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Song song = new Song(openFileDialog.FileName);

                    audioPlayer.AddTrack(song);
                    musicListBox.Items.Add(song.Name);
                    audioPlayer.AudioFileReader = new AudioFileReader(song.Path);
                    musicValue.Maximum = (int)audioPlayer.AudioFileReader.TotalTime.TotalSeconds;
                    musicListBox.SelectedIndex = audioPlayer.AddedMusic.Count() - 1;
                }
            }
            musicValue.Value = 0;
        }
        
        private void Play()
        {
            ChangeMusicValuseOutput();
            audioPlayer.Play();
            startButton.Text = "┃┃";
        }
    
        private void Stop()
        {
            if (audioPlayer.IsPlaying)
                timer.Stop();
            audioPlayer.Pause();
            startButton.Text = "▶";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!audioPlayer.IsPlaying && audioPlayer.AudioFileReader != null)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }

        private void loudTrackBar_Scroll(object sender, EventArgs e)
        {
            audioPlayer.AudioFileReader.Volume = loudTrackBar.Value;
        }

        private void musicValue_Scroll(object sender, EventArgs e)
        {            
            audioPlayer.ChangeScrollBarValue(musicValue.Value);
            UpdateListeningTime();         
        }

        private void musicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stop();
            musicValue.Value = 0;
            selectedSongName = musicListBox.SelectedItem.ToString();

            var songFileInfo = audioPlayer.AddedMusic.Where(x => x.Name == selectedSongName).FirstOrDefault();

            if (songFileInfo != null)
            {
                audioPlayer.AudioFileReader = new AudioFileReader(songFileInfo.Path);
                musicValue.Maximum = (int)audioPlayer.AudioFileReader.TotalTime.TotalSeconds;
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
            } 
            else if (leftTrackCount.Value>0)
            {
                SetSameTrack();
                leftTrackCount.Value--;
            }
            else
            {
                Stop();
                audioPlayer.FindTrack(true);
                SetCurrentItem();
                Play();
            }
        }

        private void SetSameTrack()
        {
            audioPlayer.SetSameTrack(musicListBox.SelectedIndex);
            SetCurrentItem();
        }
       
        private void nextTrack_Click(object sender, EventArgs e)
        {
            Stop();
            audioPlayer.NextTrack();
            SetCurrentItem();
            Play();
        }

        private void previousTrack_Click(object sender, EventArgs e)
        {
            Stop();
            audioPlayer.PastTrack();
            SetCurrentItem();
            Play();
        }

        private void SetCurrentItem()
        {
            musicListBox.SelectedIndex = audioPlayer.Index;
            musicValue.Value = 0;
        }

        private void randomTrack_CheckedChanged(object sender, EventArgs e)
        {
            musicListBox.Items.Clear();

            if (randomTrack.Checked)
            {
                audioPlayer.CreateRandomTracksList();
                SetTracksList(audioPlayer.RandomTrackList);
            } 
            else
            { 
                SetTracksList(audioPlayer.AddedMusic);
            }
        }
 
        private void SetTracksList(List<Song> musicList)
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