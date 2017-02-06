using System;
using System.IO;
using System.Text.RegularExpressions;
using static System.Console;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            if(args.Length==0)
            {
                Write("Must specify source");
                return;
            }
            var src = args[0];
            var dest = args.Length>1 ? args[1] : src;
            var destIsDirectory = !Regex.IsMatch(dest, @"\.[^.]+$");
            var srcIsDirectory = Directory.Exists(src);

            if(!File.Exists(src) && !srcIsDirectory) 
            {
                Write("Source directory or file not found");
                return;
            }
            if(destIsDirectory && (dest[dest.Length - 1] == '.' || Regex.IsMatch(dest,"[<>=*?|]")))
            {
                Write("Invalid destination directory");
                return;
            }
            if(destIsDirectory && !Directory.Exists(dest))
            {
                try
                {
                    Directory.CreateDirectory(dest);
                }
                catch
                {
                    Write("Could not create destination directory");
                    return;
                } 
            }

            var startTime = DateTime.Now;
            try
            {
                if(srcIsDirectory)
                {
                    var files = Directory.EnumerateFiles(src, "*.js");
                    var index = 0;
                    foreach(var file in files)
                    {
                        var localDest = dest == src? file : dest;
                        var append = false;
                        if(destIsDirectory)
                        {
                            var fileName = new FileInfo(file).Name;
                            var path = dest[dest.Length-1] == Path.DirectorySeparatorChar ? dest.Substring(0, dest.Length-1) : dest;
                            localDest = $"{path}{Path.DirectorySeparatorChar}{fileName}";
                        }
                        else
                        {
                            append = index > 0;
                        }
                        ConvertFile(file, localDest, append);
                        index++;
                    }
                    WriteLine($"Converted {index} file(s)");
                }
                else
                {
                    ConvertFile(src, dest);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Write("ERR:Could not convert file or directory");
                Console.ResetColor();
                return;
            }
            
            var duration = DateTime.Now - startTime;
            WriteLine($"Finish converting total duration:{duration.TotalSeconds} s");
        }

        public static void ConvertFile(string src, string dest, bool append=false)
        {
            var content = File.ReadAllText(src);
            var startTime = DateTime.Now;
            
            WriteLine($"Start converting {src}");
            
            content = Regex.Replace(content, @" ?: ? function ?\(", "(");
            content = Regex.Replace(content, @"(?<!prototype\..+ ?= ?)function ?\((.*)\)","($1) =>");
            content = content.Replace("var ","let ");
            
            if(append)
            {
                File.AppendAllText(dest,Environment.NewLine + Environment.NewLine);
                File.AppendAllText(dest, content);
            }
            else
            {
                File.WriteAllText(dest, content);
            }
            
            var duration = DateTime.Now - startTime;
            WriteLine($"Finish converting {src}, duration:{duration.TotalSeconds} s");
        }
    }
}
