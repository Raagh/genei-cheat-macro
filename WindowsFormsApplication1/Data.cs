using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApplication1
{
    static class Data
    {
       static public bool valuesSET = false;


       static public Config LoadFile(string path)
       {
           Config configNew = new Config();
           string s;
           if (File.Exists(path))
           {
               using (StreamReader sr = new StreamReader(File.OpenRead(path)))
               {
                   int Rows = 0;
                   while ((s = sr.ReadLine()) != null)
                   {
                       if (Rows <3 )
                       {
                           Rows++;
                           continue;
                       }
                       else
                       {
                           configNew = Data.SplitDataFile(s);
                       }
                   }
               }
           }
           return configNew;
       
       }

       private static Config SplitDataFile(string s)
       {
           string[] split = s.Split(new Char[] { ';' });
           Config configNew = new Config();

           configNew.timerInterval = int.Parse(split[0]);
           configNew.extra = (split[1]);
           return configNew;
       }
    }
}
