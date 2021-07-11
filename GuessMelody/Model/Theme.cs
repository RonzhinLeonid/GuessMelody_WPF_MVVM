using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMelody.Model
{
    public class Theme
    {
        private string _name;
        private string _path;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        public string Path => _path;

        public Theme()
        {
        }

        public Theme(string path)
        {
            _path = path;
            _name = new DirectoryInfo(path).Name;
        }
    }
}