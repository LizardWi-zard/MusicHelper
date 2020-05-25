using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHelper
{
    class Song
    {
        int songLenght;
        string songPath;
        string songName;

        public void GetSongStats(FileInfo newSong)
        {
            AudioFileReader audioFileReader = new AudioFileReader(newSong.FullName);

            //songLenght = (int)audioFileReader.TotalTime.TotalSeconds;

            songLenght = (int)newSong.Length;
            songPath = newSong.FullName;
            songName = newSong.Name;
        }
    }
}
