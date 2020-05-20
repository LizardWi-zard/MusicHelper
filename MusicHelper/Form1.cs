﻿using NAudio.Wave;
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
            //musicValue.Value = Convert.ToInt32(audioFileReader.Position);
            
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
            currentMomentLable.Text = musicValue.Value.ToString();
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

            maxLengthLabel.Text = musicValue.Maximum.ToString();
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
                currentMomentLable.Text = musicValue.Value.ToString();
            }
            else if (infinitiMusic.Checked)
            {
                musicValue.Value = 0;
                playSimpleSound();
            }
            else
            {
                stopSimpleSound();

                findTrack(true);

                playSimpleSound();
            }
        }

        private void nextTrack_Click(object sender, EventArgs e)
        {
            stopSimpleSound();

            findTrack(true);
            
            playSimpleSound();
        }

        private void previousTrack_Click(object sender, EventArgs e)
        {
            stopSimpleSound();

            findTrack(false);
            
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
            currentMomentLable.Text = musicValue.Value.ToString();
            maxLengthLabel.Text = musicValue.Maximum.ToString();
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
    }
}