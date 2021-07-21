using GuessMelody.Model;
using GuessMelody.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GuessMelody.ViewModel
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private GameGuessMelody gameGuessMelody = new GameGuessMelody();
        private Settigs settigs = new Settigs();
        private MediaPlayer player = new MediaPlayer();
        private DispatcherTimer timerSecond = new DispatcherTimer();

        private bool statusButton = true;
        private int leftSeconds = 0;
        private int numberMelody = 0;

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
            get => gameGuessMelody.ScorePlayer1;
            set
            {
                gameGuessMelody.ScorePlayer1 = value;
                OnPropertyChanged("ScorePlayer1");
            }
        }

        public int ScorePlayer2
        {
            get => gameGuessMelody.ScorePlayer2;
            set
            {
                gameGuessMelody.ScorePlayer2 = value;
                OnPropertyChanged("ScorePlayer2");
            }
        }

        public int ScorePlayer3
        {
            get => gameGuessMelody.ScorePlayer3;
            set
            {
                gameGuessMelody.ScorePlayer3 = value;
                OnPropertyChanged("ScorePlayer3");
            }
        }

        public int ScorePlayer4
        {
            get => gameGuessMelody.ScorePlayer4;
            set
            {
                gameGuessMelody.ScorePlayer4 = value;
                OnPropertyChanged("ScorePlayer4");
            }
        }
        public int LeftSeconds
        {
            get => leftSeconds;
            set
            {
                leftSeconds = value;
                OnPropertyChanged("LeftSeconds");
            }
        }
        public int NumberMelody
        {
            get => numberMelody;
            set
            {
                numberMelody = value;
                OnPropertyChanged("NumberMelody");
            }
        }

        public Theme Theme
        {
            get => gameGuessMelody.Theme;
            set
            {
                gameGuessMelody.Theme = value;
                OnPropertyChanged("Theme");
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
                    var settings = new Settings();
                    settings.viewSettings.FolderWithMusic = settigs.FolderWithMusic;
                    settings.viewSettings.TimeToAnswer = settigs.TimeToAnswer;
                    settings.viewSettings.TimeToMusic = settigs.TimeToMusic;
                    settings.viewSettings.PointsForAnswer = settigs.PointsForAnswer;
                    settings.viewSettings.RandomMusic = settigs.RandomMusic;

                    if (settings.ShowDialog() == true)
                    {
                        settigs.FolderWithMusic = settings.viewSettings.FolderWithMusic;
                        settigs.TimeToAnswer = settings.viewSettings.TimeToAnswer;
                        settigs.TimeToMusic = settings.viewSettings.TimeToMusic;
                        settigs.PointsForAnswer = settings.viewSettings.PointsForAnswer;
                        settigs.RandomMusic = settings.viewSettings.RandomMusic;
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
                    temp.Text = (score + settigs.PointsForAnswer).ToString();
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
                    if (score >= settigs.PointsForAnswer)
                        temp.Text = (score - settigs.PointsForAnswer).ToString();
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
                    gameGuessMelody.MusicThemes = MusicTheme.GetMusicThemes(settigs.FolderWithMusic);
                }, (p) => true);
            }
        }

        /// <summary>
        /// Случайный выбор темы
        /// </summary>
        public ICommand ChoosingRandomTheme
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Выбор случайной темы");
                    Theme = MusicTheme.ChoosingRandomTheme(gameGuessMelody.MusicThemes);
                    gameGuessMelody.GetListMusic();
                }, (p) => gameGuessMelody.MusicThemes != null);
            }
        }

        /// <summary>
        /// Случайный темы
        /// </summary>
        public ICommand ChoosingTheme
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Выбор темы");

                    ViewSelectTheme dataSelectTheme = new ViewSelectTheme()
                    {
                        MusicThemes = gameGuessMelody.MusicThemes,
                        Themes = new Theme() { Name = gameGuessMelody.Theme.Name, Path = gameGuessMelody.Theme.Path }
                    };
                    var selectTheme = new SelectTheme();
                    selectTheme.DataContext = dataSelectTheme;
                    if (selectTheme.ShowDialog() == true)
                    {
                        Theme = selectTheme.viewSelectTheme.Themes;
                        gameGuessMelody.GetListMusic();
                    }
                }, (p) => gameGuessMelody.MusicThemes != null);
            }
        }
        public ICommand PlayMusic
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Пуск музыки");

                    ++NumberMelody;

                    LeftSeconds = settigs.TimeToMusic;

                    var temp = p as Button;
                    temp.Content = "Пауза";
                    statusButton = !statusButton;

                    player.Open(new Uri(gameGuessMelody.GetMusic(settigs.RandomMusic), UriKind.Relative));

                    timerSecond.Interval = new TimeSpan(0, 0, 1);
                    timerSecond.Tick += new EventHandler(OnTimerTickSecond);

                    player.Play();
                    timerSecond.Start();

                }, (p) => gameGuessMelody.ListMusic.Any() && statusButton);
            }
        }
        public ICommand PauseMusic
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Пауза музыки");
                    var temp = p as Button;
                    if (temp.Content.ToString() == "Пауза")
                    {
                        player.Pause();
                        timerSecond.Stop();
                        temp.Content = "Возобновить";
                    }
                    else
                    {
                        player.Play();
                        timerSecond.Start();
                        temp.Content = "Пауза";
                    }
                }, (p) => !statusButton);
            }
        }

        private void OnTimerTickSecond(object sender, EventArgs e)
        {
            if (LeftSeconds == 0)
            {
                player.Stop();
                timerSecond.Stop();
                statusButton = !statusButton;
                timerSecond.Tick -= new EventHandler(OnTimerTickSecond);
                MessageBox.Show("Время истекло");
            }
            else
                --LeftSeconds;
        }
    }
}