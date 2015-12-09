using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Small_World_Phenomenon___Algorithm__
{
    class Program
    {
        public class movie_data
        {
            public string movie_name;
            public List <string> actors;
            public movie_data()  //constructor
            {
                actors = new List<string>();
            }
        }
        static void Main(string[] args)
        {
            FileStream F = new FileStream("movies1.txt", FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(F);
            string line=null;
            while(SR.Peek() != -1)
            {
                movie_data my_movie = new movie_data();
                line= SR.ReadLine();
                string[] line_splited = line.Split('/');
                my_movie.movie_name = line_splited[0];
                foreach (string item in line_splited )
                {
                    my_movie.actors.Add(item);
                }
                my_movie.actors.RemoveAt(0);
                //Console.WriteLine(my_movie.movie_name);
                //foreach (string item in my_movie.actors)
                //{
                //    Console.WriteLine(item);
                //}
                //uncomment above to test 
                //your turn xD
            }
            
            SR.Close();
            
        }
    }
}
