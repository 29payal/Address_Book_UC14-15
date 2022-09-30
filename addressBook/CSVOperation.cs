using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBook
{
    public class CSVOperation
    {
            public static void CsvSerialize()
            {
                Console.WriteLine("WelCome to Address Book ");
                Person s = new Person();

                string csvFilePath = @"C:\Users\DELL\Desktop\RFP\Address_Book_UC14-15\addressBook\CSVData.csv";

                List<Person> Persons = new List<Person>()
            {
                new Person(){FirstName=" Payal", LastName = "  Sharma ," ,Address=" 12 Streets ," ,ZipCode=987654 , City= " Pune ,", State= " Maharashtra ,", Email= " sgsh@gmail.com ,"  , PhoneNumber = 9876543210},
             //   new Person(){FName="Joe",LName="doe",Address="Us",ZipCode=987654}
            };

                StreamWriter sw = new StreamWriter(csvFilePath);
                CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture);

                cw.WriteRecords<Person>(Persons);
                sw.Close();
                Console.WriteLine("Closed");
            }

            public static void CsvDeserialize()
            {
            string csvFilePath = @"C:\Users\DELL\Desktop\RFP\Address_Book_UC14-15\addressBook\CSVData.csv";

            string CopyFilepath = @"C:\Users\DELL\Desktop\RFP\Address_Book_UC14-15\addressBook\CopyCSVData.csv";

            string jsonFilePath = @"C:\Users\DELL\Desktop\RFP\Address_Book_UC14-15\addressBook\JsonData.json";
            StreamReader swReader = new StreamReader(csvFilePath);

            CsvReader csvReader = new CsvReader(swReader, CultureInfo.InvariantCulture);

            List<Person> Persons1 = csvReader.GetRecords<Person>().ToList();

            foreach (Person Person in Persons1)
            {
                Console.WriteLine(Person);
            }

            //csv to another csv

            using(var writer=new StreamWriter(CopyFilepath))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords<Person>(Persons1);
            }

            //Csv to json
            
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter stream = new StreamWriter(jsonFilePath))
            using (JsonWriter jsonWriter = new JsonTextWriter(stream))
            {
                serializer.Serialize(jsonWriter, Persons1);
            }

        }
    }


    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }    
        public string State { get; set; }   
        public int ZipCode { get; set; }
        public string Email { get; set; }   
        public double PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{FirstName}  {LastName}  {Address}  {City}  {State}  {ZipCode},  {Email}  {PhoneNumber} ";
        }
    }
}
