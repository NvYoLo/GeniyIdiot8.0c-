﻿using System.Text;

namespace GeniyIdiotConsoleApp
{

    public class FileProvider
    {
        public static void Append(string fileName, string value)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(value);
            }
        }
        public static void AppendNewFile(string fileName, List<string> strings)
        {
            File.WriteAllLines(fileName, strings);
        }
        public static string GetValue(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                var value = reader.ReadToEnd();
                return value;
            }

        }
        public static bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }
    }

}
