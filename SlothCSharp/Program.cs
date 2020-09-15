using System;
using System.IO;
using System.Threading;

namespace SlothCSharp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2){
                Console.WriteLine("Usage: SlothCSharp filename time(ms,s,m,h; e.g. 30ms for 30 milliseconds)");
            }else{
                byte[] bytes = File.ReadAllBytes(args[0]);
                string timeString = args[1];
                string timeType;
                int time;

                if (timeString.Contains("ms"))
                {
                    timeType = "ms";
                    timeString = timeString.Replace("ms", "");
                }else if (timeString.Contains("s"))
                {
                    timeType = "s";
                    timeString = timeString.Replace("s", "");
                }
                else if (timeString.Contains("m"))
                {
                    timeType = "m";
                    timeString = timeString.Replace("m", "");
                }
                else if (timeString.Contains("h"))
                {
                    timeType = "h";
                    timeString = timeString.Replace("h", "");
                }
                else
                {
                    Console.WriteLine("Invalid time input.");
                    return;
                }

                time = int.Parse(timeString);

                int index = 0;

                while (index < bytes.Length)
                {
                    Console.Write((char)bytes[index]);
                    index++;
                    switch (timeType)
                    {
                        case "ms":
                        Thread.Sleep(TimeSpan.FromMilliseconds(time));
                        break;
                        case "s":
                        Thread.Sleep(TimeSpan.FromSeconds(time));
                        break;
                        case "m":
                        Thread.Sleep(TimeSpan.FromMinutes(time));
                        break;
                        case "h":
                        Thread.Sleep(TimeSpan.FromHours(time));
                        break;
                    }
                }
            }
        }
    }
}
