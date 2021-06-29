using GuessMelody.Model;
using GuessMelody.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GuessMelody.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        int _scorePlayer1 = 0;
        int _scorePlayer2 = 0;
        int _scorePlayer3 = 0;
        int _scorePlayer4 = 0;
        static string[] _musicThemes;
        static string _theme;

        //ViewSettings viewSettings { get; set; }

        string _folderWithMusic = @"E:\GeekBrains";
        int _timeToAnswer = 5;
        int _timeToMusic = 30;
        int _pointsForAnswer = 2;
        bool _randomMusic = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public int ScorePlayer1
        {
            get => _scorePlayer1;
            set
            {
                _scorePlayer1 = value;
                OnPropertyChanged("ScorePlayer1");
            }
        }
        public int ScorePlayer2
        {
            get => _scorePlayer2;
            set
            {
                _scorePlayer2 = value;
                OnPropertyChanged("ScorePlayer2");
            }
        }
        public int ScorePlayer3
        {
            get => _scorePlayer3;
            set
            {
                _scorePlayer3 = value;
                OnPropertyChanged("ScorePlayer3");
            }
        }
        public int ScorePlayer4
        {
            get => _scorePlayer4;
            set
            {
                _scorePlayer4 = value;
                OnPropertyChanged("ScorePlayer4");
            }
        }
        
        /// <summary>
        /// Открытие окна настроек
        /// </summary>
        public ICommand OpenSetting
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Test");
                    Settings settings = new Settings();
                    settings.viewSettings.FolderWithMusic = _folderWithMusic;
                    settings.viewSettings.TimeToAnswer = _timeToAnswer;
                    settings.viewSettings.TimeToMusic = _timeToMusic;
                    settings.viewSettings.PointsForAnswer = _pointsForAnswer;
                    settings.viewSettings.RandomMusic = _randomMusic;

                    if (settings.ShowDialog() == true)
                    {
                        _folderWithMusic = settings.viewSettings.FolderWithMusic;
                        _timeToAnswer = settings.viewSettings.TimeToAnswer;
                        _timeToMusic = settings.viewSettings.TimeToMusic;
                        _pointsForAnswer = settings.viewSettings.PointsForAnswer;
                        _randomMusic = settings.viewSettings.RandomMusic;
                    }
                }, (p) => true);
            }
        }
        /// <summary>
        /// Команда на увеличение счета игрока
        /// </summary>
        public ICommand LeftClickCommand
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine(p.ToString() + " Test++");
                    var temp = p as TextBlock;
                    var score = Convert.ToInt32(temp.Text);
                    temp.Text = (score + _pointsForAnswer).ToString();
                }, (p) => true);
            }
        }
        /// <summary>
        /// Команда на уменьшение счета игрока
        /// </summary>
        public ICommand RightClickCommand
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine(p.ToString() + " Test");
                    var temp = p as TextBlock;
                    var score = Convert.ToInt32(temp.Text);
                    if (score >= _pointsForAnswer)
                        temp.Text = (score - _pointsForAnswer).ToString();
                }, (p) => true);
            }
        }
        /// <summary>
        /// Обнуление очков игроков
        /// </summary>
        public ICommand ZeroScorePlayer
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Обнулить очки");
                    ScorePlayer1 = 0;
                    ScorePlayer2 = 0;
                    ScorePlayer3 = 0;
                    ScorePlayer4 = 0;
                }, (p) => true);
            }
        }
        /// <summary>
        /// Просканировать папку
        /// </summary>
        public ICommand ScanFolder
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Просканировать папку");
                    _musicThemes = MusicTheme.GetMusicThemes(_folderWithMusic);
                }, (p) => true);
            }
        }
        /// <summary>
        /// Случайный выбор тема
        /// </summary>
        public ICommand ChoosingRandomTheme
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Выбор случайной темы");
                    _theme = MusicTheme.ChoosingRandomTheme(_musicThemes);
                }, (p) => _musicThemes != null);
            }
        }
    }
}
