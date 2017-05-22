using System;
using System.Collections.Generic;
using System.Text;

namespace PostDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            string jsonStr = @"{""team_id"":""123123123"",""itinerary_id"":""123123123""}";
           string result =  Team.SynsChina(jsonStr);
            Console.Write(result);

        }
    }
}
