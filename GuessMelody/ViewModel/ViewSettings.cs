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

namespace GuessMelody.ViewModel
{
    class ViewSettings : INotifyPropertyChanged
    {
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

        public ICommand OkSettings
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Ok Settings");
                    p = true;
                }, (p) => true);
            }
        }
        public ICommand CanselSettings
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Close Settings");
                    p = true;
                }, (p) => true);
            }
        }

        public ICommand SaveSettings
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Save Settings");
                    Setting settings = new Setting { FolderWithMusic = _folderWithMusic, 
                                                TimeToAnswer = _timeToAnswer, 
                                                TimeToMusic = _timeToMusic, 
                                                PointsForAnswer = _pointsForAnswer, 
                                                RandomMusic = _randomMusic };
                    XmlSerializer formatter = new XmlSerializer(typeof(Setting));

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Save Files";
                    saveFileDialog.FileName = "Settings";
                    saveFileDialog.DefaultExt = "xml";
                    saveFileDialog.Filter = "XML files(.xml)|*.xml|all Files(*.*)|*.*";
                    saveFileDialog.InitialDirectory = @"C:\"; 
                    saveFileDialog.FilterIndex = 1;

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, settings);
                        }
                    }
                }, (p) => true);
            }
        }

        public ICommand LoadSettings
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    Debug.WriteLine("Load Settings");

                    OpenFileDialog loadFileDialog = new OpenFileDialog();
                    loadFileDialog.Title = "Load Files";
                    loadFileDialog.FileName = "Settings";
                    loadFileDialog.DefaultExt = "xml";
                    loadFileDialog.Filter = "XML files(.xml)|*.xml|all Files(*.*)|*.*";
                    loadFileDialog.InitialDirectory = @"C:\";
                    loadFileDialog.FilterIndex = 1;

                    if (loadFileDialog.ShowDialog() == true)
                    {
                        XmlSerializer formatter = new XmlSerializer(typeof(Setting));
                        using (FileStream fs = new FileStream(loadFileDialog.FileName, FileMode.OpenOrCreate))
                        {
                            Setting settings = (Setting)formatter.Deserialize(fs);

                            FolderWithMusic = settings.FolderWithMusic;
                            TimeToAnswer = settings.TimeToAnswer;
                            TimeToMusic = settings.TimeToMusic;
                            PointsForAnswer = settings.PointsForAnswer;
                            RandomMusic = settings.RandomMusic;
                        }
                    }
                }, (p) => true);
            }
        }
    }
}
