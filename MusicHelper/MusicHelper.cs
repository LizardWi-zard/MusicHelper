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

        DateTime songLength = new DateTime();
        DateTime currentMoment = new DateTime();

        AudioPlayer audioPlayer = new AudioPlayer();

        bool smallInterface = true;
               
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

        private void UpdateListeningTime()
        {
            currentMoment = new DateTime(2020, 5, 22, musicValue.Value / 6000, musicValue.Value / 60, musicValue.Value % 60);
            currentMomentLable.Text = currentMoment.ToString("mm:ss");

            songLength = new DateTime(2020, 5, 22, musicValue.Maximum / 6000, musicValue.Maximum / 60, musicValue.Maximum % 60);
            maxLengthLabel.Text = songLength.ToString("mm:ss");
        }

        private void ChangeInterface_Click(object sender, EventArgs e)
        {
            if (!smallInterface)
                SetSmallInterface();
            else
                SetBigInterface();
        }

        void SetSmallInterface()
        {
            smallInterface = true;

            this.MinimumSize = new Size(250, 385);
            this.MaximumSize = new Size(250, 385);
            this.Size = new Size(250, 385);

            openButton.Size = new Size(97, 23);
            openButton.Location = new Point(125, 311);

            musicListBox.Size = new Size(210, 121);
            musicListBox.Location = new Point(12, 184);

            musicValue.Size = new Size(210, 45);
            musicValue.Location = new Point(12, 67);

            startButton.Size = new Size(68, 25);
            startButton.Location = new Point(83, 12);

            previousTrack.Size = new Size(65, 25);
            previousTrack.Location = new Point(12, 12);

            nextTrack.Size = new Size(65, 25);
            nextTrack.Location = new Point(157, 12);

            leftTrackCount.Size = new Size(65, 20);
            leftTrackCount.Location = new Point(12, 43);

            infinitiMusic.Size = new Size(50, 17);
            infinitiMusic.Location = new Point(81, 44);

            randomTrack.Size = new Size(85, 17);
            randomTrack.Location = new Point(137, 44);

            currentMomentLable.Size = new Size(34, 13);
            currentMomentLable.Location = new Point(97, 99);

            label1.Size = new Size(34, 13);
            label1.Location = new Point(12, 99);

            maxLengthLabel.Size = new Size(34, 13);
            maxLengthLabel.Location = new Point(188, 99);

            loudTrackBar.Size = new Size(210, 45);
            loudTrackBar.Location = new Point(12, 133);
        }

        void SetBigInterface()
        {
            smallInterface = false;

            this.MinimumSize = new Size(750, 500);
            this.MaximumSize = new Size(750, 500);
            this.Size = new Size(750, 500);

            openButton.Size = new Size(75, 45);
            openButton.Location = new Point(647, 404);

            musicListBox.Size = new Size(113, 329);
            musicListBox.Location = new Point(609, 12);

            musicValue.Size = new Size(710, 45);
            musicValue.Location = new Point(12, 353);

            startButton.Size = new Size(28, 25);
            startButton.Location = new Point(365, 424);

            previousTrack.Size = new Size(28, 25);
            previousTrack.Location = new Point(331, 424);

            nextTrack.Size = new Size(28, 25);
            nextTrack.Location = new Point(399, 424);

            leftTrackCount.Size = new Size(42, 20);
            leftTrackCount.Location = new Point(283, 428);

            infinitiMusic.Size = new Size(32, 17);
            infinitiMusic.Location = new Point(433, 429);

            randomTrack.Size = new Size(85, 17);
            randomTrack.Location = new Point(472, 429);

            currentMomentLable.Size = new Size(34, 13);
            currentMomentLable.Location = new Point(362, 401);

            label1.Size = new Size(34, 13);
            label1.Location = new Point(12, 385);

            maxLengthLabel.Size = new Size(34, 13);
            maxLengthLabel.Location = new Point(686, 385);

            loudTrackBar.Size = new Size(204, 45);
            loudTrackBar.Location = new Point(12, 404);
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
    }
}