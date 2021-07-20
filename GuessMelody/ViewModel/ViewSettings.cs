using GuessMelody.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Win32;
using System.Windows;


namespace GuessMelody.ViewModel
{
    class ViewSettings : INotifyPropertyChanged
    {
        //Setting Setting { get; set; } = new Setting();

        public ViewSettings()
        {
            //Setting.ReadFromXML("setting.xml");
        }

        string _folderWithMusic;
        int _timeToAnswer;
        int _timeToMusic;
        int _pointsForAnswer;
        bool _randomMusic;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string FolderWithMusic
        {
            get => _folderWithMusic;
            set
            {
                _folderWithMusic = value;
                OnPropertyChanged("FolderWithMusic");
            }
        }
        public int TimeToAnswer
        {
            get => _timeToAnswer;
            set
            {
                _timeToAnswer = value;
                OnPropertyChanged("TimeToAnswer");
            }
        }
        public int TimeToMusic
        {
            get => _timeToMusic;
            set
            {
                _timeToMusic = value;
                OnPropertyChanged("TimeToMusic");
            }
        }
        public int PointsForAnswer
        {
            get => _pointsForAnswer;
            set
            {
                _pointsForAnswer = value;
                OnPropertyChanged("PointsForAnswer");
            }
        }
        public bool RandomMusic
        {
            get => _randomMusic;
            set
            {
                _randomMusic = value;
                OnPropertyChanged("RandomMusic");
            }
        }

        /// <summary>
        /// Принять настройки
        /// </summary>
        public ICommand OkSettings
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Ok Settings");
                    var temp = p as Window;
                    temp.DialogResult = true;
                    temp.Close();
                    //Setting.WriteToXML("setting.xml");
                    
                }, (p) => true);
            }
        }
        /// <summary>
        /// Отменить настройки
        /// </summary>
        public ICommand CanselSettings
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Close Settings");
                    var temp = p as Window;
                    temp.DialogResult = false;
                    temp.Close();
                }, (p) => true);
            }
        }
        /// <summary>
        /// Выбор папки с музыкой
        /// </summary>
        public ICommand SelectFolder
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Select Settings");
                    var selectFoler = new System.Windows.Forms.FolderBrowserDialog();
                    selectFoler.SelectedPath = _folderWithMusic;
                    selectFoler.ShowNewFolderButton = false;

                    if (selectFoler.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        FolderWithMusic = selectFoler.SelectedPath;
                    }
                }, (p) => true);
            }
        }
        /// <summary>
        /// Сохранить настройки в файл
        /// </summary>
        public ICommand SaveSettings
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Save Settings");
                    Setting setting = new Setting { FolderWithMusic = _folderWithMusic, 
                                                TimeToAnswer = _timeToAnswer,  
                                                TimeToMusic = _timeToMusic, 
                                                PointsForAnswer = _pointsForAnswer, 
                                                RandomMusic = _randomMusic };
                    Settigs.SaveSetting(setting);
                }, (p) => true);
            }
        }
        /// <summary>
        /// Загрузить настройки из файла
        /// </summary>
        public ICommand LoadSettings
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Load Settings");

                    var setting =  Settigs.LoadSetting();
                    if (setting != null)
                    {
                        FolderWithMusic = setting.FolderWithMusic;
                        TimeToAnswer = setting.TimeToAnswer;
                        TimeToMusic = setting.TimeToMusic;
                        PointsForAnswer = setting.PointsForAnswer;
                        RandomMusic = setting.RandomMusic;
                    }
                }, (p) => true);
            }
        }
    }
}
