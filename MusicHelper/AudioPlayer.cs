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

        public int Index { set; get; }
        
        public List<Song> RandomTrackList { set; get; }

        public AudioPlayer()
        {
            AddedMusic = new List<Song>();
            IsPlaying = false;
            WaveOutDevice = new WaveOut();
            RandomTrackList = new List<Song>();
        }        

        public void AddTrack(Song song)
        {
            AddedMusic.Add(song);
            Index = AddedMusic.Count() - 1;
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
                if (Index + 1 > AddedMusic.Count() - 1)
                    Index = 0;
                else
                    Index++;

                SetTrack();
            }
            else
            {
                if (Index - 1 < 0)
                    Index = AddedMusic.Count() - 1;
                else
                    Index--;

                SetTrack();
            }
        }

        public void ChangeScrollBarValue(int skipTime)
        {
            Pause();
            AudioFileReader.Position = 0;
            AudioFileReader.Skip(skipTime);            
            Play();
        }
        
        public List<Song> CreateRandomTracksList()
        {
            List<Song> backUpList = new List<Song>();

            backUpList.AddRange(AddedMusic);

            RandomTrackList.Clear();

            for (int i = 0; i < AddedMusic.Count; i++)
            {
                int index = new Random().Next(0, backUpList.Count);
                RandomTrackList.Add(backUpList[index]);
                backUpList.RemoveAt(index);
            }

            return RandomTrackList;
        }

        public List<Song> SetTracksList()
        {
            if (IsRandom)
                return CreateRandomTracksList();
            else
                return AddedMusic;            
        }

        public void CheckIfSameTrack(int index)
        {
            Index = index;

            if (IsInfiniti)
                SetTrack();
            else if (SongsLeft > 0)
            {
                SetTrack();
                SongsLeft--;
            }
            else            
                FindTrack(true);            
        }

        public void SetTrack()
        {              
            AudioFileReader = new AudioFileReader(AddedMusic[Index].Path);            
        }
    }
}
