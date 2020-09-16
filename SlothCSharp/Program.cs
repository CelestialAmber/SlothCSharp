using System;
using System.IO;
using System.Threading;

namespace SlothCSharp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1){
                Console.WriteLine("Usage: SlothCSharp filename (custom time (ms/s/m/h), default is 10ms)");
            }else{
                byte[] bytes = File.ReadAllBytes(args[0]);
                TimeSpan time;

                if (args.Length == 2)
                {
                    string timeString = args[1];

                    if (timeString.Contains("ms"))
                    {
                        timeString = timeString.Replace("ms", "");
                        time = TimeSpan.FromMilliseconds(int.Parse(timeString));
                    }
                    else if (timeString.Contains("s"))
                    {
                        timeString = timeString.Replace("s", "");
                        time = TimeSpan.FromSeconds(int.Parse(timeString));
                    }
                    else if (timeString.Contains("m"))
                    {
                        timeString = timeString.Replace("m", "");
                        time = TimeSpan.FromMinutes(int.Parse(timeString));
                    }
                    else if (timeString.Contains("h"))
                    {
                        timeString = timeString.Replace("h", "");
                        time = TimeSpan.FromHours(int.Parse(timeString));
                    }
                    else
                    {
                        Console.WriteLine("Invalid time input.");
                        return;
                    }
                }
                else
                {
                    time = TimeSpan.FromMilliseconds(10);
                }

                int index = 0;

                while (index < bytes.Length)
                {
                    Console.Write((char)bytes[index]);
                    index++;
                    Thread.Sleep(time);
                }
            }
        }
    }
}
