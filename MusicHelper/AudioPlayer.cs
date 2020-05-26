using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHelper
{
    class AudioPlayer
    {
        public List<Song> AddedMusic { set; get; }

        public bool IsPlaying { set; get; }

        public bool IsRandom { set; get; }

        public bool IsInfiniti { set; get; }

        public int SongsLeft { set; get; }

        public IWavePlayer WaveOutDevice { set; get; }

        public AudioFileReader AudioFileReader { set; get; }

            


        public AudioPlayer()
        {
            // MusicHelper interFace = new MusicHelper();

            AddedMusic = new List<Song>();
            IsPlaying = false;
            WaveOutDevice = new WaveOut();
        }        

        public void AddTrack(Song song)
        {
            AddedMusic.Add(song);
        }

        public void Play()
        {
            WaveOutDevice.Init(AudioFileReader);
            IsPlaying = true;
            WaveOutDevice.Play();
            
        }

        public void Pause()
        {
            WaveOutDevice.Init(AudioFileReader);
            IsPlaying = false;
            WaveOutDevice.Stop();
        }

        public void PastTrack()
        {

        }

        public void NextTrack()
        {

        }



    }
}
