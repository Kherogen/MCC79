using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Views
{
    public class InputView
    {
        public int InputInt()
        {
            return int.Parse(Console.ReadLine());
        }
/*
        public string InputString()
        {
            return Console.ReadLine();
        }*/
    }
}
