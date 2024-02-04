using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DelegateBasicExample
{
    public class Log
    {
        private delegate void LogDel(string text);
       
        public Log()
        {
            
            var logDelTextToScreen = new LogDel(LogTextToScreen);
            
            logDelTextToScreen += LogTextToFile;
            
            LogText(logDelTextToScreen);
        }

        private static void LogText(LogDel logDel)
        {
            Console.WriteLine("Please enter your name: ");
            
            var name = Console.ReadLine();

            logDel(name);
        }
        private void LogTextToScreen(string text)
        {

            Console.WriteLine($"{DateTime.Now}: {text}");

        }

        private void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {

                sw.WriteLine($"{DateTime.Now}: {text}");
            
            }
        }
    }
}
