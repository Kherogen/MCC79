using DatabaseConnection.Controllers;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DatabaseConnection
{
    public class Program 
    {

        public static void Main(string[] args)
        {
            MenuController menuController = new MenuController();

            menuController.MainMenu();
        }
       /* {*/

            /*connection = new SqlConnection(connectionString);
            //GetAll
            List<Regions> regions = reg.GetAllRegions();
            foreach (Regions region in regions)
            {
                Console.WriteLine("Id : " + region.Id + ", Name " + region.Name);
            }

            Console.WriteLine("INPUT DATA : ");
*//*
            string InputRegion = Console.ReadLine();
            InsertToRegion(InputRegion);

            regions = GetAllRegions();
            foreach (var region in regions)
            {
                Console.WriteLine("Id : " + region.Id + ", Name " + region.Name);
            }*//*

            Console.WriteLine("INSERT");
            Console.Write("Masukkan Nama Region :");
            string name = Console.ReadLine();
            int isInsertSuccessfull = reg.InsertToRegion(name);
            if (isInsertSuccessfull > 0)
            {
                Console.WriteLine("Data Berhasil Ditambahkan !");
            }
            else
            {
                Console.WriteLine("Data Gagal Ditambahkan");
            }*/
            //Getby id : Region
            //Update : Region
            //Delete : Region
            
            //GetAllCountry : Countries
            //InsertCountry : Countries
            //Getby Id : Countries
            //Update : Countries
            //Delete : COuntries

            //Tabel Sisanya GetAll

            /*  try
              {
                  connection.Open();
                  Console.WriteLine("Connected!");
                  connection.Close();
              }
              catch (Exception ex)
              {
                  Console.WriteLine("Connection Faile!");
              }*/
        }
        //Method GetAll
       
    }
/*    
}*/



