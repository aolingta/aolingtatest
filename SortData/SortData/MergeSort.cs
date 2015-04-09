using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortData
{
    class MergeSort
    {
        //归并排序
        public static void MergeSortFunction(string inPath, string outPath, int filenum)
        {
            int outfilenum = 0;
            for (int i = 0; i < filenum; i++)
            {
                string subpathone = inPath + i + ".txt";
                string subpathout = outPath + outfilenum + ".txt";
                outfilenum++;
                FileStream fileone = new FileStream(subpathone, FileMode.Open, FileAccess.Read);
                FileStream fileout = new FileStream(subpathout, FileMode.Append, FileAccess.Write);
                StringBuilder outsb = new StringBuilder();
                if (++i < filenum)
                {
                    string subpathtwo = inPath + i + ".txt";
                    FileStream filetwo = new FileStream(subpathtwo, FileMode.Open, FileAccess.Read);
                    int lengthone = (int)fileone.Length;
                    int lengthtwo = (int)filetwo.Length;
                    List<string> s1 = new List<string>(MainProgram.BlockReadFile(fileone, 1024));
                    List<string> s2 = new List<string>(MainProgram.BlockReadFile(filetwo, 1024));
                    do
                    {
                        if (string.Compare(s1[0], s2[0]) < 0)
                        {
                            outsb.Append(s1[0]);
                            outsb.Append("\r\n");
                            s1.RemoveAt(0);
                        }
                        else
                        {
                            outsb.Append(s2[0]);
                            outsb.Append("\r\n");
                            s2.RemoveAt(0);
                        }
                        if (s1.Count == 0)
                        {
                            if ((fileone.Length - fileone.Position) > 1024)
                            {
                                s1.AddRange(MainProgram.BlockReadFile(fileone, 1024));
                            }
                            else if ((fileone.Length - fileone.Position) > 0)
                            {
                                s1.AddRange(MainProgram.BlockReadFile(fileone, (int)(fileone.Length - fileone.Position)));
                            }
                        }
                        if (s2.Count == 0)
                        {
                            if ((filetwo.Length - filetwo.Position) > 1024)
                            {
                                s2.AddRange(MainProgram.BlockReadFile(filetwo, 1024));
                            }
                            else if ((filetwo.Length - filetwo.Position) > 0)
                            {
                                s2.AddRange(MainProgram.BlockReadFile(filetwo, (int)(filetwo.Length - filetwo.Position)));
                            }
                        }
                        if (s1.Count == 0)
                        {
                            while (s2.Count != 0)
                            {
                                outsb.Append(s2[0]);
                                outsb.Append("\r\n");
                                s2.RemoveAt(0);
                                if (s2.Count == 0)
                                {
                                    if ((filetwo.Length - filetwo.Position) > 1024)
                                    {
                                        s2.AddRange(MainProgram.BlockReadFile(filetwo, 1024));
                                    }
                                    else if ((filetwo.Length - filetwo.Position) > 0)
                                    {
                                        s2.AddRange(MainProgram.BlockReadFile(filetwo, (int)(filetwo.Length - filetwo.Position)));
                                    }
                                }
                                if (outsb.Length > 2048)
                                {
                                    fileout.Write(System.Text.Encoding.Default.GetBytes(outsb.ToString()), 0, outsb.Length);
                                    fileout.Flush();
                                    outsb.Clear();
                                }
                            }
                        }
                        if (s2.Count == 0)
                        {
                            while (s1.Count != 0)
                            {
                                outsb.Append(s1[0]);
                                outsb.Append("\r\n");
                                s1.RemoveAt(0);
                                if (s1.Count == 0)
                                {
                                    if ((fileone.Length - fileone.Position) > 1024)
                                    {
                                        s1.AddRange(MainProgram.BlockReadFile(fileone, 1024));
                                    }
                                    else if ((fileone.Length - fileone.Position) > 0)
                                    {
                                        s1.AddRange(MainProgram.BlockReadFile(fileone, (int)(fileone.Length - fileone.Position)));
                                    }
                                }
                                if (outsb.Length > 2048)
                                {
                                    fileout.Write(System.Text.Encoding.Default.GetBytes(outsb.ToString()), 0, outsb.Length);
                                    fileout.Flush();
                                    outsb.Clear();
                                }
                            }
                        }
                        if (outsb.Length > 2048)
                        {
                            fileout.Write(System.Text.Encoding.Default.GetBytes(outsb.ToString()), 0, outsb.Length);
                            fileout.Flush();
                            outsb.Clear();
                        }
                    } while (s1.Count != 0 && s2.Count != 0);
                    if (outsb.Length > 0)
                    {
                        fileout.Write(System.Text.Encoding.Default.GetBytes(outsb.ToString()), 0, outsb.Length);
                        fileout.Flush();
                        fileout.Close();
                        outsb.Clear();
                    }
                    fileone.Close();
                    filetwo.Close();
                    File.Delete(subpathone);
                    File.Delete(subpathtwo);
                }
                else
                {
                    List<string> s1 = new List<string>(MainProgram.BlockReadFile(fileone, 1024));
                    while (s1.Count != 0)
                    {
                        outsb.Append(s1[0]);
                        outsb.Append("\r\n");
                        s1.RemoveAt(0);
                        if (s1.Count == 0)
                        {
                            if ((fileone.Length - fileone.Position) > 1024)
                            {
                                s1.AddRange(MainProgram.BlockReadFile(fileone, 1024));
                            }
                            else if ((fileone.Length - fileone.Position) > 0)
                            {
                                s1.AddRange(MainProgram.BlockReadFile(fileone, (int)(fileone.Length - fileone.Position)));
                            }
                        }
                        if (outsb.Length > 2048)
                        {
                            fileout.Write(System.Text.Encoding.Default.GetBytes(outsb.ToString()), 0, outsb.Length);
                            fileout.Flush();
                            outsb.Clear();
                        }
                    }
                    if (outsb.Length > 0)
                    {
                        fileout.Write(System.Text.Encoding.Default.GetBytes(outsb.ToString()), 0, outsb.Length);
                        fileout.Flush();
                        fileout.Close();
                        outsb.Clear();
                    }
                    fileone.Close();
                    File.Delete(subpathone);
                }
        }
        }
    }
}
