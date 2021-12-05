using System;
using System.Collections.Generic;
using System.IO;

namespace me.jamesharvey.advent.twentyone.Utilities
{
    public static class FileReader
    {
        public static List<string> ReadStringInputFromFile(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }
            List<string> inputValues = new List<string>();
            using (var reader = new StreamReader(fileName))
            {
                string item = reader.ReadLine();
                while (item != null)
                {
                    inputValues.Add(item);
                    item = reader.ReadLine();
                }
            }
            return inputValues;
        }

        public static List<int> ReadIntegerInputFromFile(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }
            List<int> inputValues = new List<int>();
            using (var reader = new StreamReader(fileName))
            {
                string item = reader.ReadLine();
                while (item != null)
                {
                    inputValues.Add(int.Parse(item));
                    item = reader.ReadLine();
                }
            }
            return inputValues;
        }
    }
}
