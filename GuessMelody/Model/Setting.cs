using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuessMelody.Model
{

    public class Setting
    {
        public string FolderWithMusic { get; set; }
        public int TimeToAnswer { get; set; }
        public int TimeToMusic { get; set; }
        public int PointsForAnswer { get; set; }
        public bool RandomMusic { get; set; }

        public void WriteToXML(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Setting));
            try
            {
                serializer.Serialize(new System.IO.StreamWriter(filename), this);
            }
            catch(Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }

        public Setting ReadFromXML(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Setting));
            try
            {
                return (Setting)serializer.Deserialize(new System.IO.StreamReader(filename));
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc);
                return null;
            }

        }
    }
}
