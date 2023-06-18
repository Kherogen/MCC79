using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Views
{
    public class LocationsView
    {
        public void Result(int id, string street, string post, string city, string state, string CountryId)
        {
            Console.WriteLine($"||ID : {id} || Street : {street} || POST : {post} || CITY : {city} || STATE : {state} || Country ID : {CountryId}");

        }
    }
}
