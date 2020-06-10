using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MusicHelper
{
    public partial class MusicHelper : Form
    {
        Timer timer;
                
        string selectedSongName;

        AudioPlayer audioPlayer = new AudioPlayer();

        Theme theme = new Theme();

        bool smallInterface = true;
               
        public MusicHelper()
        {
            InitializeComponent();

            theme.ApplyTheme(this, Theme.Themes.SmallTheme);
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
            ChangeMusicValueOutput();
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
                Play();           
            else            
                Stop();            
        }

        private void loudTrackBar_Scroll(object sender, EventArgs e)
        {
            audioPlayer.AudioFileReader.Volume = loudTrackBar.Value;
        }

        private void musicValue_Scroll(object sender, EventArgs e)
        {            
            audioPlayer.ChangeScrollBarValue(musicValue.Value);
            UpdateListeningProgress();         
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

            UpdateListeningProgress();
        }

        private void ChangeMusicValueOutput()
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
                UpdateListeningProgress();
            }
            else
            {
                CheckForCurrentSong();
                leftTrackCount.Value = audioPlayer.SongsLeft;
                SetCurrentItem();
            }            
        }

        private void CheckForCurrentSong()
        {
            audioPlayer.CheckIfSameTrack(musicListBox.SelectedIndex);
            musicValue.Value = 0;
        }
        
        private void nextTrack_Click(object sender, EventArgs e)
        {
            Stop();
            audioPlayer.NextTrack();
            SetCurrentItem();
        }

        private void previousTrack_Click(object sender, EventArgs e)
        {
            Stop();
            audioPlayer.PastTrack();
            SetCurrentItem();            
        }

        private void SetCurrentItem()
        {
            Stop(); 
            musicListBox.SelectedIndex = audioPlayer.Index;
            musicValue.Value = 0;
            Play();
        }

        private void randomTrack_CheckedChanged(object sender, EventArgs e)
        {
            if (randomTrack.Checked)
                audioPlayer.IsRandom = true;
            else
                audioPlayer.IsRandom = false;

            musicListBox.Items.Clear();
            
            SetTracksList();
        }
 
        private void SetTracksList()
        {
            List<Song> currentList = audioPlayer.SetTracksList();
            foreach (var item in currentList)
                musicListBox.Items.Add(item.Name);
        }

        private void UpdateListeningProgress()
        {
            currentMomentLable.Text = audioPlayer.UpdateCurrentListeningTime(musicValue.Value).ToString("mm:ss"); 

            maxLengthLabel.Text = audioPlayer.UpdateMaxListeningTime(musicValue.Maximum).ToString("mm:ss");
        }

        private void leftTrackCount_ValueChanged(object sender, EventArgs e)
        {
            audioPlayer.SongsLeft = (int)leftTrackCount.Value;
        }

        private void infinitiMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (infinitiMusic.Checked)            
                audioPlayer.IsInfiniti = true;
            else
                audioPlayer.IsInfiniti = false;
        }

        private void ChangeInterface_Click(object sender, EventArgs e)
        {
            if (!smallInterface) 
            { 
                theme.ApplyTheme(this, Theme.Themes.SmallTheme);
                smallInterface = true; 
            }
            else 
            {
                theme.ApplyTheme(this, Theme.Themes.BigTheme);
                smallInterface = false;
            }
        }       
    }
}