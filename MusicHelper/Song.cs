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
        FileInfo songFileInfo;
        
        public int Lenght => (int)songFileInfo.Length;

        public string Path => songFileInfo.FullName;

        public string Name => songFileInfo.Name;

        public Song(string songPath) 
        {
            songFileInfo = new FileInfo(songPath);        
        }          
        
    }
}
