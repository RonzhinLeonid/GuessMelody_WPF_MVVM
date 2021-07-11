using GuessMelody.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GuessMelody.ViewModel
{
    public class ViewSelectTheme
    {
        private static List<Theme> _musicThemes;
        private static Theme _theme;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<Theme> MusicThemes
        {
            get => _musicThemes;
            set
            {
                _musicThemes = value;
                OnPropertyChanged("MusicThemes");
            }
        }

        public Theme Themes
        {
            get => _theme;
            set
            {
                _theme = value;
                OnPropertyChanged("Themes");
            }
        }

        /// <summary>
        /// Отменить настройки
        /// </summary>
        public ICommand OkSelectTheme
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Double Click");
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