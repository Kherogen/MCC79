using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Views
{
    public class Handling
    {
        public void NotFound()
        {
            Console.WriteLine("DATA NOT FOUND !!!");
        }
        public void NotFoundByID(object id)
        {
            Console.WriteLine($"The ID {id} not Found.");
        }

        public void Success() 
        { Console.WriteLine("DATA BERSHASIL DIUBAH "); }
        public void NotSuccess()
        { Console.WriteLine("DATA GAGAL DIUBAH "); }

        public void WrongInput()
        {
            Console.WriteLine("INVALID INPUT !!!!");
        }

    }
}
