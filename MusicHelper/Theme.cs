using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHelper
{
    class Theme
    {
        public enum Themes
        {
            SmallTheme,
            BigTheme
        }

        ThemeOptions GetTheme(Themes themes)
        {
            switch (themes)
            {
                case Themes.BigTheme:
                    return new BigTheme();

                case Themes.SmallTheme:
                    return new SmallTheme();

                default:
                    return null;

            }
        }

        public void ApplyTheme(MusicHelper musicHelper, Themes themeName)
        {
            ThemeOptions theme = GetTheme(themeName);

            musicHelper.MinimumSize = theme.WindowMinSize;
            musicHelper.MaximumSize = theme.WindowMaxSize;

            musicHelper.openButton.Size = theme.OpenButtonSize;
            musicHelper.openButton.Location = theme.OpenButtonLocation;

            musicHelper.musicListBox.Size = theme.musicListBoxSize;
            musicHelper.musicListBox.Location = theme.musicListBoxLocation;

            musicHelper.musicValue.Size = theme.MusicValueSize;
            musicHelper.musicValue.Location = theme.MusicValueLocation;

            musicHelper.startButton.Size = theme.StartButtonSize;
            musicHelper.startButton.Location = theme.StartButtonLocation;

            musicHelper.previousTrack.Size = theme.PreviousTrackSize;
            musicHelper.previousTrack.Location = theme.PreviousTrackLocation;

            musicHelper.nextTrack.Size = theme.NextTrackSize;
            musicHelper.nextTrack.Location = theme.NextTrackLocation;

            musicHelper.leftTrackCount.Size = theme.LeftTrackCountSize;
            musicHelper.leftTrackCount.Location = theme.LeftTrackCountLocation;

            musicHelper.infinitiMusic.Size = theme.InfinitiMusicSize;
            musicHelper.infinitiMusic.Location = theme.InfinitiMusicLocation;

            musicHelper.randomTrack.Size = theme.RandomTrackSize;
            musicHelper.randomTrack.Location = theme.RandomTrackLocation;

            musicHelper.currentMomentLable.Size = theme.CurrentMomentLableSize;
            musicHelper.currentMomentLable.Location = theme.CurrentMomentLableLocation;

            musicHelper.label1.Size = theme.Label1Size;
            musicHelper.label1.Location = theme.Label1Location;

            musicHelper.maxLengthLabel.Size = theme.MaxLengthLabelSize;
            musicHelper.maxLengthLabel.Location = theme.MaxLengthLabelLocation;

            musicHelper.loudTrackBar.Size = theme.LoudTrackBarSize;
            musicHelper.loudTrackBar.Location = theme.LoudTrackBarLocation;
        }

        class SmallTheme : ThemeOptions
        {           
            Size WindowMinSize { get; set; } = new Size(250, 385);

            Size WindowMaxSize { get; set; } = new Size(250, 385);


            Size OpenButtonSize { get; set; } = new Size(97, 23);

            Point OpenButtonLocation { get; set; } = new Point(125, 311);


            Size musicListBoxSize { get; set; } = new Size(210, 121);

            Point musicListBoxLocation { get; set; } = new Point(12, 184);


            Size MusicValueSize { get; set; } = new Size(210, 45);

            Point MusicValueLocation { get; set; } = new Point(12, 67);


            Size StartButtonSize { get; set; } = new Size(68, 25);

            Point StartButtonLocation { get; set; } = new Point(83, 12);


            Size PreviousTrackSize { get; set; } = new Size(65, 25);

            Point PreviousTrackLocation { get; set; } = new Point(12, 12);


            Size NextTrackSize { get; set; } = new Size(65, 25);

            Point NextTrackLocation { get; set; } = new Point(157, 12);


            Size LeftTrackCountSize { get; set; } = new Size(65, 20);

            Point LeftTrackCountLocation { get; set; } = new Point(12, 43);


            Size InfinitiMusicSize { get; set; } = new Size(50, 17);

            Point InfinitiMusicLocation { get; set; } = new Point(81, 44);


            Size RandomTrackSize { get; set; } = new Size(85, 17);

            Point RandomTrackLocation { get; set; } = new Point(137, 44);


            Size CurrentMomentLableSize { get; set; } = new Size(34, 13);

            Point CurrentMomentLableLocation { get; set; } = new Point(97, 99);


            Size Label1Size { get; set; } = new Size(34, 13);

            Point Label1Location { get; set; } = new Point(12, 99);


            Size MaxLengthLabelSize { get; set; } = new Size(34, 13);

            Point MaxLengthLabelLocation { get; set; } = new Point(188, 99);


            Size LoudTrackBarSize { get; set; } = new Size(210, 45);

            Point LoudTrackBarLocation { get; set; } = new Point(12, 133);
        }



        class BigTheme : ThemeOptions
        {
            public Size WindowMinSize { get; set; } = new Size(750, 500);

            public Size WindowMaxSize { get; set; } = new Size(750, 500);


            public Size OpenButtonSize { get; set; } = new Size(75, 45);

            public Point OpenButtonLocation { get; set; } = new Point(647, 404);


            public Size musicListBoxSize { get; set; } = new Size(113, 329);

            public Point musicListBoxLocation { get; set; } = new Point(609, 12);


            public Size MusicValueSize { get; set; } = new Size(710, 45);

            public Point MusicValueLocation { get; set; } = new Point(12, 353);


            public Size StartButtonSize { get; set; } = new Size(28, 25);

            public Point StartButtonLocation { get; set; } = new Point(365, 424);


            public Size PreviousTrackSize { get; set; } = new Size(28, 25);

            public Point PreviousTrackLocation { get; set; } = new Point(331, 424);


            public Size NextTrackSize { get; set; } = new Size(28, 25);

            public Point NextTrackLocation { get; set; } = new Point(399, 424);


            public Size LeftTrackCountSize { get; set; } = new Size(42, 20);

            public Point LeftTrackCountLocation { get; set; } = new Point(283, 428);


            public Size InfinitiMusicSize { get; set; } = new Size(32, 17);

            public Point InfinitiMusicLocation { get; set; } = new Point(433, 429);


            public Size RandomTrackSize { get; set; } = new Size(85, 17);

            public Point RandomTrackLocation { get; set; } = new Point(472, 429);


            public Size CurrentMomentLableSize { get; set; } = new Size(34, 13);

            public Point CurrentMomentLableLocation { get; set; } = new Point(362, 401);


            public Size Label1Size { get; set; } = new Size(34, 13);

            public Point Label1Location { get; set; } = new Point(12, 385);


            public Size MaxLengthLabelSize { get; set; } = new Size(34, 13);

            public Point MaxLengthLabelLocation { get; set; } = new Point(686, 385);

            public Size LoudTrackBarSize { get; set; } = new Size(204, 45);

            public Point LoudTrackBarLocation { get; set; } = new Point(12, 404);
        }

       
        abstract class ThemeOptions
        {
          public  Size WindowMinSize { get; set; }

            public Size WindowMaxSize { get; set; }

            public Size OpenButtonSize { get; set; }

            public Point OpenButtonLocation { get; set; }


            public Size musicListBoxSize { get; set; }

            public Point musicListBoxLocation { get; set; }


            public Size MusicValueSize { get; set; }

            public Point MusicValueLocation { get; set; }


            public Size StartButtonSize { get; set; }

            public Point StartButtonLocation { get; set; }


            public Size PreviousTrackSize { get; set; }

            public Point PreviousTrackLocation { get; set; }


            public Size NextTrackSize { get; set; }

            public Point NextTrackLocation { get; set; }


            public Size LeftTrackCountSize { get; set; }

            public Point LeftTrackCountLocation { get; set; }


            public Size InfinitiMusicSize { get; set; }

            public Point InfinitiMusicLocation { get; set; }


            public Size RandomTrackSize { get; set; }

            public Point RandomTrackLocation { get; set; }


            public Size CurrentMomentLableSize { get; set; }

            public Point CurrentMomentLableLocation { get; set; }


            public Size Label1Size { get; set; }

            public Point Label1Location { get; set; }


            public Size MaxLengthLabelSize { get; set; }

            public Point MaxLengthLabelLocation { get; set; }


            public Size LoudTrackBarSize { get; set; }

            public Point LoudTrackBarLocation { get; set; }
        }
    }
}
