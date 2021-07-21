using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuessMelody.Model
{
    class Settigs
    {
        string _folderWithMusic = @"E:\Музыка";
        int _timeToAnswer = 5;
        int _timeToMusic = 30;
        int _pointsForAnswer = 2;
        bool _randomMusic = true;

        public string FolderWithMusic
        {
            get => _folderWithMusic;
            set
            {
                _folderWithMusic = value;
            }
        }
        public int TimeToAnswer
        {
            get => _timeToAnswer;
            set
            {
                _timeToAnswer = value;
            }
        }
        public int TimeToMusic
        {
            get => _timeToMusic;
            set
            {
                _timeToMusic = value;
            }
        }
        public int PointsForAnswer
        {
            get => _pointsForAnswer;
            set
            {
                _pointsForAnswer = value;
            }
        }
        public bool RandomMusic
        {
            get => _randomMusic;
            set
            {
                _randomMusic = value;
            }
        }
        /// <summary>
        /// Сохранение настроек в файл
        /// </summary>
        /// <param name="settings"></param>
        public static void SaveSetting (Setting settings)
        {
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
        }

        /// <summary>
        /// Загрузка настроек из файл
        /// </summary>
        /// <param name="settings"></param>
        public static Setting LoadSetting()
        {
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
                    return (Setting)formatter.Deserialize(fs);
                }
            }
            return null;
        }
    }
}
