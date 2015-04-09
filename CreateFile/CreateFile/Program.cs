using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "F:\\wooduan\\1.txt";
            makefile(1000,path);
        }
        public static void makefile(int size,string path)
        {

            Random ra = new Random();
            int num = 0;
            StringBuilder a = new StringBuilder();
            int i = 0;
            while(i<size*1024*1024){
                FileStream toFile = new FileStream(path, FileMode.Append, FileAccess.Write);
                num = 0;
                a.Clear();
                do
                {
                    int length = ra.Next(1, 10);
                    string str = makestring(length, ra);
                    a.Append(str);
                    a.Append("\r\n");
                    num += length + 2;

                } while (num < 1 * 1024 * 1024 && num < size * 1024 * 1024);
                i += num;
                //int a = sizeof();
                string dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                byte[] aa = System.Text.Encoding.Default.GetBytes(a.ToString());
                toFile.Write(aa, 0, aa.Length);
                toFile.Flush();
                toFile.Close();
            }
            
        }
        public static string makestring(int length,Random r)
        {
            StringBuilder str = new StringBuilder("",length);
            string strall = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&*()_+";
            //Random r = new Random();
            for (int i = 0; i < length; i++){
                str.Append(strall[r.Next(0, 75)]);
            }
            return str.ToString();
        }
    }
}
