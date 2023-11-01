using System.Net;
using System.Text;

namespace _030203
{
    internal class Program
    {
        public static bool meetingSymbol(string t)
        {
            if (t.Contains("<h2>") || t.Contains("<h3>"))
            {
                return true;
            }
            return false;
        }
        public static bool meeting2Symbol(string t)
        {
            if (t.Contains("</h2>") || t.Contains("</h3>"))
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            WebRequest request = WebRequest.Create("https://mortein43.github.io/ukrtrade/pages/card_parafin.html");
            WebResponse response = request.GetResponse();
            string result = "";
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string currentLine = "";
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        if (meetingSymbol(currentLine) || meeting2Symbol(currentLine))
                        {
                            result += "\n" + currentLine + "\n";
                        }
                    }
                    reader.Close();
                }
                stream.Close();
            }
            string newresult = result.Replace(" ", "");
            Console.WriteLine(newresult.ToString());
            
            

        }
    }
}