using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GuessMelody.ViewModel
{
    class ViewSelectTheme
    {
        static List<string> _musicThemes;
        static string _theme;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public List<string> MusicThemes
        {
            get => _musicThemes;
            set
            {
                _musicThemes = value;
                OnPropertyChanged("MusicThemes");
            }
        }
        public string Themes
        {
            get => _theme;
            set
            {
                _theme = value;
                OnPropertyChanged("Themes");
            }
        }


        /// <summary>
        /// Принять настройки
        /// </summary>
        public ICommand OkSelectTheme
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Ok SelectTheme");
                    var temp = p as Window;
                    temp.DialogResult = true;
                    temp.Close();
                }, (p) => true);
            }
        }
        /// <summary>
        /// Отменить настройки
        /// </summary>
        public ICommand CanselSelectTheme
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Close SelectTheme");
                    var temp = p as Window;
                    temp.DialogResult = false;
                    temp.Close();
                }, (p) => true);
            }
        }
    }
}
