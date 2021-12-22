using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StartProgress
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            List<string> m_listPath = new List<string>(2);
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(System.Environment.CurrentDirectory + "\\config.txt");
            while ((line = file.ReadLine()) != null)
            {
                //string strPath = "\"" + line + "\"" ;
                m_listPath.Add(line);
                Console.WriteLine(line);
                
            }

            file.Close();

            for (int i = 0; i < m_listPath.Count; i++)
            {
                Process pro = StartProcess(m_listPath[i], "");
                pro.Start();
                //pro.WaitForExit();
                //pro.Close();
            }
            //Console.ReadLine();
            return;
        }

        public static Process StartProcess(string fileName, string args)
        {
            try
            {
                fileName = "\"" + fileName + "\"";
                //args = "\"" + args + "\"";
                Process myProcess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(fileName, args);
                //startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardInput = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo = startInfo;
                return myProcess;
            }
            catch (Exception ex)
            {
                Console.WriteLine("出错原因：" + ex.Message);
            }
            return null;
        }

    }
}
