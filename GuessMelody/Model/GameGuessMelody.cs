using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMelody.Model
{
    class GameGuessMelody
    {
        int _scorePlayer1 = 0;
        int _scorePlayer2 = 0;
        int _scorePlayer3 = 0;
        int _scorePlayer4 = 0;
        static string[] _musicThemes;
        static string _theme = "Тема не выбрана";
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
        public string Theme
        {
            get => _theme;
            set
            {
                _theme = value;
            }
        }
        public string[] MusicThemes
        {
            get => _musicThemes;
            set
            {
                _musicThemes = value;
            }
        }
    }
}
