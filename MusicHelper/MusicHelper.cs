﻿using NAudio.Wave;
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
        
        FileInfo openedFile;
        
        bool isPlaying = false;
        string selectedSongName;

        DateTime songLength = new DateTime();
        DateTime currentMoment = new DateTime();
        
        List<FileInfo> addedMusic = new List<FileInfo>();
        List<FileInfo> backUpList = new List<FileInfo>();
        List<FileInfo> randomTrackList = new List<FileInfo>();

        AudioPlayer audioPlayer = new AudioPlayer();
        
        public MusicHelper()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {

            //audioPlayer.Pause();

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

                    // audioFileReader = new AudioFileReader();
                    //openedFile = new FileInfo(openFileDialog.FileName);
                    //audioFileReader = new AudioFileReader(openedFile.FullName);
                    //musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
                    //musicListBox.Items.Add(openedFile.Name);
                }
            }
            musicValue.Value = 0;
        }
        
        private void PlaySimpleSound()
        {
           // ChangeMusicValuseOutput();
           // audioPlayer.WaveOutDevice.Init(audioFileReader);
           // isPlaying = true;
           // startButton.Text = "┃┃";
           // waveOutDevice.Play();
        }
    
        private void StopSimpleSound()
        {
            //startButton.Text = "▶";
            //if (isPlaying)
            //    timer.Stop();
            //isPlaying = false;
            //waveOutDevice.Stop();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!audioPlayer.IsPlaying && audioPlayer.AudioFileReader != null)
            {
                ChangeMusicValuseOutput();
                audioPlayer.Play();
                startButton.Text = "┃┃";

                //PlaySimpleSound();
            }
            else
            {
                if(audioPlayer.IsPlaying)
                  timer.Stop();
                audioPlayer.Pause();
                startButton.Text = "▶";


                //StopSimpleSound();
            }
        }

        private void loudTrackBar_Scroll(object sender, EventArgs e)
        {
            audioPlayer.AudioFileReader.Volume = loudTrackBar.Value;
        }

        private void musicValue_Scroll(object sender, EventArgs e)
        {
            audioPlayer.Pause();
            audioPlayer.AudioFileReader.Position = 0;
            audioPlayer.AudioFileReader.Skip(musicValue.Value);
            UpdateListeningTime();
            audioPlayer.Play();
        }

        private void musicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            audioPlayer.Pause();
            musicValue.Value = 0;
            selectedSongName = musicListBox.SelectedItem.ToString();

            var songFileInfo = audioPlayer.AddedMusic.Where(x => x.Name == selectedSongName).FirstOrDefault();

            if (songFileInfo != null)
            {
             //   audioPlayer.AudioFileReader = new AudioFileReader(songFileInfo.Name);
             //   musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
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
                audioPlayer.Play();
            } 
            else if (leftTrackCount.Value>0)
            {
                SetSameTrack();
                leftTrackCount.Value--;
                audioPlayer.Play();
            }
            else
            {
                audioPlayer.FindTrack(true);
            }
        }

        private void SetSameTrack()
        {
            audioPlayer.Pause();
            int SongIndex = musicListBox.SelectedIndex;
            //audioFileReader = new AudioFileReader(addedMusic[SongIndex].FullName);
            musicValue.Maximum = (int)audioFileReader.TotalTime.TotalSeconds;
            musicValue.Value = 0;
        }
       
        private void nextTrack_Click(object sender, EventArgs e)
        {
            audioPlayer.Pause();
            audioPlayer.NextTrack();
           
        }

        private void previousTrack_Click(object sender, EventArgs e)
        {
            audioPlayer.Pause();
            audioPlayer.PastTrack();
           
        }

        /*
        private void FindTrack(bool nextTrack)
        {
            audioPlayer.Pause();

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

            audioPlayer.Play();
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
        */

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