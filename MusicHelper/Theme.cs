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
            public SmallTheme()
            {
                WindowMinSize = new Size(250, 385);
                WindowMaxSize = new Size(250, 385);

                OpenButtonSize = new Size(97, 23);
                OpenButtonLocation = new Point(125, 311);

                musicListBoxSize = new Size(210, 121);
                musicListBoxLocation = new Point(12, 184);

                MusicValueSize = new Size(210, 45);
                MusicValueLocation = new Point(12, 67);

                StartButtonSize = new Size(68, 25);
                StartButtonLocation = new Point(83, 12);

                PreviousTrackSize = new Size(65, 25);
                PreviousTrackLocation = new Point(12, 12);

                NextTrackSize = new Size(65, 25);
                NextTrackLocation = new Point(157, 12);

                LeftTrackCountSize = new Size(65, 20);

                LeftTrackCountLocation = new Point(12, 43);

                InfinitiMusicSize = new Size(50, 17);
                InfinitiMusicLocation = new Point(81, 44);

                RandomTrackSize = new Size(85, 17);
                RandomTrackLocation = new Point(137, 44);

                CurrentMomentLableSize = new Size(34, 13);
                CurrentMomentLableLocation = new Point(97, 99);

                Label1Size = new Size(34, 13);
                Label1Location = new Point(12, 99);

                MaxLengthLabelSize = new Size(34, 13);
                MaxLengthLabelLocation = new Point(188, 99);

                LoudTrackBarSize = new Size(210, 45);
                LoudTrackBarLocation = new Point(12, 133);
            }
        }



        class BigTheme : ThemeOptions
        {
            public BigTheme()
            {
                WindowMinSize = new Size(750, 500);
                WindowMaxSize  = new Size(750, 500);

                OpenButtonSize = new Size(75, 45);
                OpenButtonLocation  = new Point(647, 404);

                musicListBoxSize  = new Size(113, 329);
                musicListBoxLocation = new Point(609, 12);

                MusicValueSize  = new Size(710, 45);
                MusicValueLocation  = new Point(12, 353);

                StartButtonSize = new Size(28, 25);
                StartButtonLocation = new Point(365, 424);

                PreviousTrackSize  = new Size(28, 25);
                PreviousTrackLocation  = new Point(331, 424);

                NextTrackSize  = new Size(28, 25);
                NextTrackLocation = new Point(399, 424);

                LeftTrackCountSize = new Size(42, 20);
                LeftTrackCountLocation = new Point(283, 428);

                InfinitiMusicSize  = new Size(32, 17);
                InfinitiMusicLocation  = new Point(433, 429);

                RandomTrackSize= new Size(85, 17);
                RandomTrackLocation = new Point(472, 429);

                CurrentMomentLableSize  = new Size(34, 13);
                CurrentMomentLableLocation = new Point(362, 401);

                Label1Size = new Size(34, 13);
                Label1Location  = new Point(12, 385);

                MaxLengthLabelSize = new Size(34, 13);
                MaxLengthLabelLocation = new Point(686, 385);

                LoudTrackBarSize = new Size(204, 45);
                LoudTrackBarLocation = new Point(12, 404);
            }
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
