using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CSVOperation.CsvSerialize();
            CSVOperation.CsvDeserialize();
            Console.ReadLine();
        }
    }
}
