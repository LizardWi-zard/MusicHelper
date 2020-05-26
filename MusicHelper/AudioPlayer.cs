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
        public List<FileInfo> AddedMusic { get; }

        //public bool IsPlaying { set; get; }

        public bool IsRandom { set; get; }

        public bool IsInfiniti { set; get; }

        public int SongsLeft { set; get; }

        public AudioPlayer()
        {
             
        }        

        public void AddTrack(FileInfo song)
        {
            AddedMusic.Add(song);
        }

        public void Play()
        {

        }

        public void Pause()
        {

        }

        public void PastTrack()
        {

        }

        public void NextTrack()
        {

        }



    }
}
