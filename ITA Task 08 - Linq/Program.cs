using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITA_Task_08___Linq
{
   
    class Program
    {
        static void Main(string[] args)
        {
            CustomDataTable createTable = new CustomDataTable();
            createTable.CreateDT();
       }
    }

    class CustomDataTable
    {
        public Random r = new Random();

        public void AddNewRow(DataTable table, string[] names)
        {
            for (int i = 0; i < 10; i++)
            {
                DataRow newRow = table.NewRow();
                newRow["Id"] = i;
                newRow["Name"] = i + "_" + names[i];
                newRow["Price"] = (float)r.Next(1, 100) / r.Next(1, 100);
                table.Rows.Add(newRow);

            }    
        }
        public void CreateDT()
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Name"));
            table.Columns.Add(new DataColumn("Price", typeof(float)));

            string[] names = {"Dima","Vanyz","Kolyan","Anton","Maks","Oleg","Volodya","Misha","Sasha","Roma"};
            AddNewRow(table,names);
           

         
            Console.WriteLine("\n");
           var task1 = table.AsEnumerable().Where(x => (int)x["Id"] > 3).ToList();
           var task2 = table.AsEnumerable().Where(x => (int)x["Id"] > 4).Select(x => x["Price"]).ToArray();
           var  task3 = table.AsEnumerable().OrderBy(x => (float)x["Price"]).ToList();
           var task4 = table.AsEnumerable().Select(x => new { IdField = x["Id"], NameField = x["Name"], PriceField = x["Price"] }).ToList();
           var task5 = table.AsEnumerable().Where(x => (int)x["Id"] > 2 && (int)x["Id"] < 8).OrderByDescending(x => (float)x["Price"]).ToArray();



           foreach (DataRow row in table.Rows)
           {
               foreach (DataColumn column in table.Columns)
                   Console.WriteLine("{0}:{1} ", column.ColumnName, row[column]);

           }

            Console.ReadKey();
        }
    }
}
