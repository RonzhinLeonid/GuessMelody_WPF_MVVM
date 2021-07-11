using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GuessMelody.Model
{
    internal static class MusicTheme
    {
        public static Random rnd = new Random();

        /// <summary>
        /// Сканирование папки
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public static List<Theme> GetMusicThemes(string folder)
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
                else
                {
                    var listTheme = new List<Theme>();
                    foreach (var item in subFolder)
                    {
                        listTheme.Add(new Theme(item));
                    }

                    return listTheme;
                }
            }
        }

        /// <summary>
        /// Выбор случайной темы
        /// </summary>
        /// <param name="musicThemes"></param>
        /// <returns></returns>
        public static Theme ChoosingRandomTheme(List<Theme> musicThemes)
        {
            if (musicThemes != null)
                return musicThemes[rnd.Next(musicThemes.Count)];
            else
                return null;
        }
    }
}