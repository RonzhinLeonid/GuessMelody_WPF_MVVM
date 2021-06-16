using GuessMelody.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GuessMelody.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        int _scorePlayer1 = 0;
        int _scorePlayer2 = 0;
        int _scorePlayer3 = 0;
        int _scorePlayer4 = 0;

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

        public ICommand OpenSetting
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Test");
                    Settings settings = new Settings();
                    settings.ShowDialog();
                }, (p) => true);
            }
        }
        public ICommand LeftClickCommandPl1
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Test++");
                    ScorePlayer1++;
                }, (p) => true);
            }
        }
        public ICommand RightClickCommandPl1
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Test--");
                    ScorePlayer1--;
                }, (p) => true);
            }
        }
        public ICommand LeftClickCommandPl2
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Test++");
                    ScorePlayer2++;
                }, (p) => true);
            }
        }
        public ICommand RightClickCommandPl2
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Test--");
                    ScorePlayer2--;
                }, (p) => true);
            }
        }
        public ICommand LeftClickCommandPl3
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Test++");
                    ScorePlayer3++;
                }, (p) => true);
            }
        }
        public ICommand RightClickCommandPl3
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Test--");
                    ScorePlayer3--;
                }, (p) => true);
            }
        }
        public ICommand LeftClickCommandPl4
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Test++");
                    ScorePlayer4++;
                }, (p) => true);
            }
        }
        public ICommand RightClickCommandPl4
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Test--");
                    ScorePlayer4--;
                }, (p) => true);
            }
        }
    }
}
