using System.Xml.Serialization;

namespace DentalProjectConstruction
{
    public class XMLFuncions
    {
        public static void SerializeToXML(Treatment data, string fileLocation, out Exception? exception)
        {
            FileStream fs = new FileStream(fileLocation, FileMode.Create, FileAccess.Write);
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(Treatment));
                sr.Serialize(fs, data);
                fs.Close();
                exception = null;
            }
            catch (Exception e)
            {
                fs.Close();
                exception = e;
            }
        }
        public static Treatment DeserializeFromXML(string fileLocation, out Exception? exception)
        {
            FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(Treatment));
                object result = sr.Deserialize(fs);
                fs.Close();
                exception = null;
                return (Treatment)result;
            }
            catch (Exception e)
            {
                fs.Close();
                exception = e;
                return null;
            }
        }
    }
}