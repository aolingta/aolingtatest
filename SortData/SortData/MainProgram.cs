using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortData
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Console.Write("cmd as:filesort 1.txt 2.txt 3.txt 4.txt 5.txt 6.txt output.txt");
            Console.Write("\r\n");
            
            bool isinput = true;
            string[] filelist = new string[1];
            while (isinput)
            {
                string str = Console.ReadLine();
                filelist = str.Split(' ');
                int size = filelist.Length;
                if (string.Compare(filelist[0], "filesort") != 0 || size < 3)
                {
                    Console.Write("wrong input！\r\n");
                }
                else {
                    isinput = false;
                }
            }
            int filenum = 0;
            string path = "F:\\wooduan\\";
            string infile = "F:\\wooduan\\test\\";
            string outfile = "F:\\wooduan\\test\\a";
            for (int i = 1; i < filelist.Length - 1; i++)
            {
                string inputPath = path + filelist[i];
                if (File.Exists(inputPath))
                {
                    FileStream file = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
                    long blocknum = file.Length / (1024 * 1024) + 1;
                    CutSortFile(inputPath, (int)blocknum, filenum, infile);
                    filenum += (int)blocknum;
                }
            }
            string outpath = path + "output.txt";
            do{
                if (filenum == 2) {
                    outfile = outpath;
                }
                MergeSort.MergeSortFunction(infile, outfile, filenum);
                string temp = infile;
                infile = outfile;
                outfile = temp;
                filenum = filenum / 2 + filenum % 2;
            }while(filenum > 1);
        }
        private static void CutSortFile(string fromFile,int n,int appendnum,string path)
        {
            FileStream fileToCopy = new FileStream(fromFile, FileMode.Open, FileAccess.Read);
            for (int i = 0; i < n;i++)
            {
                int sname = appendnum + i;
                string path1 = path + sname + ".txt";
                FileStream copyToFile = new FileStream(path1, FileMode.Append, FileAccess.Write);
                int length = (int)(fileToCopy.Length / n);
                string[] list = BlockReadFile(fileToCopy, length);
                //QuickSort.QuickSortFunction(list, 0, list.Length - 1);
                Array.Sort(list);
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < list.Length; j++) {
                    sb.Append(list[j]);
                    sb.Append("\r\n");
                }
                copyToFile.Write(System.Text.Encoding.Default.GetBytes(sb.ToString()), 0, sb.Length);
                copyToFile.Flush();
                copyToFile.Close();
            }
            fileToCopy.Close();
        }
        public static string[] BlockReadFile(FileStream File, int length)
        {
            byte[] buffer = new byte[length];
            File.Read(buffer, 0, length);
            File.Flush();
            string txt = System.Text.Encoding.Default.GetString(buffer);
            if (txt.Length > 10)
            {
                string end = txt.Substring(txt.Length - 10);
                string[] sp = end.Split('\r', '\n');
                txt = txt.Substring(0, txt.Length - sp[sp.Length - 1].Length);
                File.Position -= sp[sp.Length - 1].Length;
            }
            string[] list = txt.Split('\r', '\n').Where(t => t.Trim() != "").ToArray();
            return list;
        }
    }
}
