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
         public class queries
         {
             public string actor1, actor2;
         }
        static void Main(string[] args)
        {
            FileStream movies_file = new FileStream("movies1.txt", FileMode.Open, FileAccess.Read);
            StreamReader movies_SR = new StreamReader(movies_file);
            string line=null;
            while(movies_SR.Peek() != -1)
            {
                movie_data my_movie = new movie_data();
                line= movies_SR.ReadLine();
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
            movies_SR.Close();

            FileStream queries_file = new FileStream("queries1.txt", FileMode.Open, FileAccess.Read);
            StreamReader queries_SR = new StreamReader(queries_file);
            string actors=null;
            while (queries_SR.Peek() != -1)
            {
                queries my_querie = new queries();
                actors = queries_SR.ReadLine();
                string[] actors_splited = actors.Split('/');
                my_querie.actor1 = actors_splited[0];
                my_querie.actor2 = actors_splited[1];
            }
            queries_SR.Close();
        }
    }
}
