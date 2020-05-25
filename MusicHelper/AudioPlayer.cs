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

        public List<FileInfo> BackUpList { set; get; }

        public List<FileInfo> RandomTrackList { set; get; }

        public bool IsPlaying { set; get; }

        public bool IsRandom { set; get; }

        public bool IsInfiniti { set; get; }

        public int SongsLeft { set; get; }

        public AudioPlayer(List<FileInfo> music)
        {
             
        }
        
        public void FindNextSong()
        {

        }

        public void AddTrack(FileInfo song)
        {
            //AddedMusic.Add(song);
        }

        public void PlaySong(bool isPlaying)
        {

        }

        public void StopSong(bool isPlaying)
        {

        }

        public void CreateRandomList()
        {
            
        }


    }
}
