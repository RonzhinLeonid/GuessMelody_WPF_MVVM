using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMelody.Model
{
    internal class GameGuessMelody
    {
        private int _scorePlayer1 = 0;
        private int _scorePlayer2 = 0;
        private int _scorePlayer3 = 0;
        private int _scorePlayer4 = 0;
        private static List<Theme> _musicThemes;
        private static Theme _theme = new Theme() { Name = "Тема не задана" };
        private static List<string> _listMusic = new List<string>();
        private Random rnd = new Random();
        public int ScorePlayer1
        {
            get => _scorePlayer1;
            set
            {
                _scorePlayer1 = value;
            }
        }

        public int ScorePlayer2
        {
            get => _scorePlayer2;
            set
            {
                _scorePlayer2 = value;
            }
        }

        public int ScorePlayer3
        {
            get => _scorePlayer3;
            set
            {
                _scorePlayer3 = value;
            }
        }

        public int ScorePlayer4
        {
            get => _scorePlayer4;
            set
            {
                _scorePlayer4 = value;
            }
        }

        public Theme Theme
        {
            get => _theme;
            set
            {
                _theme = value;
            }
        }

        public List<Theme> MusicThemes
        {
            get => _musicThemes;
            set
            {
                _musicThemes = value;
            }
        }
        public List<string> ListMusic
        {
            get => _listMusic;
            set
            {
                _listMusic = value;
            }
        }

        public void GetListMusic()
        {
            if (Directory.Exists(_theme.Path))
                _listMusic = Directory.GetFiles(_theme.Path, "*.mp3").ToList();
        }

        public string GetMusic(bool randomMusic)
        {
            string rez;
            if (randomMusic)
            {
                int index = rnd.Next(_listMusic.Count);
                rez = _listMusic[index];
                _listMusic.RemoveAt(index);
                return rez;
            }
            else
            {
                rez = _listMusic[0];
                _listMusic.Remove(rez);
                return rez;
            }
        }
    }
}