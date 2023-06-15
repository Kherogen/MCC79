using System.Security.Cryptography;
using System.Threading.Channels;
using System.Threading.Tasks;
using System;

namespace Latihan1;
public class Program
{
    /*pada method menu saya menggunakan while looping dengan paramater boolean bernilai true selama memilih menu 1 dan 2
     lalu boolean bernilai false pada pilihan ke 3 untuk keluar aplikasi 
     dan juga switch untuk memamnggil method berisi function*/
    static void Menu()
    {
        Console.WriteLine("===========================================================");
        Console.WriteLine("".PadRight(20) + "Menu Ganjil Genap".PadRight(30));
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine("1. Cek Ganjil Genap ");
        Console.WriteLine("2. Print Ganjil / Genap (dengan limit)");
        Console.WriteLine("3. Exit"); ;
        Console.WriteLine("-----------------------------------------------------------");

        Console.Write("Pilihan: ");
        string input_pilihan = Console.ReadLine();
        int pilihan;

        if (!int.TryParse(input_pilihan, out pilihan))
        {
            Console.WriteLine("Input Pilihan Tidak Valid. Harap Masukkan Bilangan Bulat.");
            Thread.Sleep(2000);
            Console.Clear();
            Menu();
        }
        {
            bool ulang = true;
            while (ulang == true)
            {
                switch (pilihan)
                {
                    case 1:
                        Console.Write("Masukan Bilangan Yang Ingin Dicek : ");

                        string input_number = Console.ReadLine();
                        int number;

                        if (!int.TryParse(input_number, out number))
                        {
                            Console.WriteLine("Input Pilihan Tidak Valid. Harap Masukkan Bilangan Bulat.");
                            Thread.Sleep(2000);
                            Console.Clear();
                            Menu();
                        }
                        Console.WriteLine(EvenOddCheck(number));
                        Thread.Sleep(2000);
                        Console.Clear();
                        Menu();
                        break;
                    case 2:
                        Console.Write("Pilih (Ganjil/Genap) : ");
                        string even_or_odd = Console.ReadLine().Trim();
                        Console.Write("Masukan limit : ");
                        string input_limit = Console.ReadLine();
                        int limit;

                        if (!int.TryParse(input_limit, out limit))
                        {
                            Console.WriteLine("Input Pilihan Tidak Valid. Harap Masukkan Bilangan Bulat.");
                            Thread.Sleep(2000);
                            Console.Clear();
                            Menu();
                        }
                        PrintEvenOdd(limit, even_or_odd);
                        break;
                    case 3:
                        ulang = false;
                        Console.Clear();
                        Console.WriteLine("Terima Kasih");
                        Thread.Sleep(2000);
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Input Pilihan Tidak Valid!!!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Menu();
                        break;
                }
            }
        }

    }
    /*Pada method ini saya menggunakan if else decission dan menampung nilai atau inputan limit kedalam List 
     * foreach looping digunakan untuk menghitung angka ganjil/genap berdasarkan limit yang ditentukan
     * dengan melakukan increment += 2 jika bilangan ganjil maka increment dimulai dari 1 lalu di increment +2 sesuai limit
     * jika bilangan genap maka increment dimulai dari 2 dan di increment +2 sesuai limit */
    static void PrintEvenOdd(int limit, string choice)

    {
        if (limit <= 0)
        {
            Console.WriteLine("Print bilangan 1 - " + limit);
            Console.WriteLine("Input Limit Tidak Valid!!!");

        }

        List<int> numberList = new List<int>();

        if (choice.ToLower() == "ganjil")
        {
            for (int i = 1; i <= limit; i += 2)
            {
                numberList.Add(i);
            }

            Console.WriteLine("Print bilangan 1 - " + limit);

            foreach (int i in numberList)
            {
                Console.Write(", " + i);
            }
            Thread.Sleep(2000);
            Console.Clear();
            Menu();
        }
        else if (choice.ToLower() == "genap")
        {
            for (int i = 2; i <= limit; i += 2)
            {
                numberList.Add(i);
            }

            Console.WriteLine("Print bilangan 1 - " + limit);

            foreach (int i in numberList)
            {
                Console.Write(", " + i);
            }
            Thread.Sleep(2000);
            Console.Clear();
            Menu();
        }
        else
        {
            Console.WriteLine("Invalid input (silahkan pilih Ganjil atau Genap)!");
            Thread.Sleep(2000);
            Console.Clear();
            Menu();
        }
    }
    /*Pada method ini saya menggunakan if else function dimana return valuenya berupa string dan
     * menggunakan modulus untuk pengecekkan ganjil atau genap */
    static string EvenOddCheck(int input)
    {
        if (input % 2 == 0)
        {
            return "Genap";
        }
        if (input % 2 == 1)
        {
            return "Ganjil";
        }
        else
        {
            return "Bilangan Tidak Valid";
        }

    }

    private static void Main(string[] args)

    {
        Menu();

    }

}