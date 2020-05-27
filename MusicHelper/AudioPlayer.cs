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

        int index;

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
            index = AddedMusic.Count() - 1;
        }

        public void Play()
        {
            WaveOutDevice.Init(AudioFileReader);
            IsPlaying = true;
            WaveOutDevice.Play();
            
        }

        public void Pause()
        {
            WaveOutDevice.Stop();           
            IsPlaying = false;
        }

        public void NextTrack()
        {
          
            FindTrack(true);
         
        }
        
        public void PastTrack()
        {
          
            FindTrack(false);
           
        }

        public void FindTrack(bool nextTrack)
        {
            

            if (nextTrack)
            {
                if (index + 1 > AddedMusic.Count() - 1)
                {
                    index = 0;
                }
                else
                    index++;

                SetCurrenTrack();
            }
            else
            {
                if (index - 1 < 0)
                {
                    index = AddedMusic.Count() - 1;
                }
                else
                    index--;

                SetCurrenTrack();
            }
            Play();
        }

        private void SetCurrenTrack()
        {
            AudioFileReader = new AudioFileReader(AddedMusic[index].Path);
            //WaveOutDevice.Init(AudioFileReader);
            
        }



    }
}
