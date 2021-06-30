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
    static class WorkWithSettigs
    {
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
