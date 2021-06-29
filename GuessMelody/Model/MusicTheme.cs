using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GuessMelody.Model
{
    static class MusicTheme
    {
        public static Random rnd = new Random();
        /// <summary>
        /// Сканирование папки
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public static string[] GetMusicThemes(string folder)
        {
            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Указанной папки не существует", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
            else
            {
                var subFolder = Directory.GetDirectories(folder);
                if (subFolder.Length == 0)
                {
                    MessageBox.Show("В указанной папке нет подпапок", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                    return null;
                }
                else return subFolder;
            }
        }
        /// <summary>
        /// Выбор случайной темы
        /// </summary>
        /// <param name="musicThemes"></param>
        /// <returns></returns>
        public static string ChoosingRandomTheme(string[] musicThemes)
        {
            if (musicThemes != null)
                return musicThemes[rnd.Next(musicThemes.Length)];
            else 
                return null;
        }
        /// <summary>
        /// Выбор темы
        /// </summary>
        /// <param name="musicThemes"></param>
        /// <returns></returns>
        public static string ChoosingTheme(string[] musicThemes)
        {
            if (musicThemes != null)
                return musicThemes[rnd.Next(musicThemes.Length)];
            else
                return null;
        }
    }
}
