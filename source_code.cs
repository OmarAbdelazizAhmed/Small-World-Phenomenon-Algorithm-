using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
namespace Small_World_Phenomenon
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
         public static List<movie_data> all_movies = new List<movie_data>(); //list of all movies 
         static int indexing = 0; // for indexing the actors with code numbers
         public static HashSet<string> all_actors = new HashSet<string>(); //to remove the movie name from the input
         public static Dictionary<string, int> actors_incoding = new Dictionary<string, int>();// to index the actors name to numbers, easier access in the adjacency list
         public static Dictionary<int, string> reversed_incoding = new Dictionary<int, string>();// same as above but reversed
         public static List<Dictionary<string,int>> adj_list = new List<Dictionary<string, int>>(); // adjacency list; a vector of maps
        static void Main(string[] args)
        {
            FileStream movies_file = new FileStream("movies1.txt", FileMode.Open, FileAccess.Read); //accessing the input file
            StreamReader movies_SR = new StreamReader(movies_file); //stream reading the filestream
            string line=null;// to read line by line
            while(movies_SR.Peek() != -1)
            {
                movie_data my_movie = new movie_data(); //data container to fill movie data in
                line = movies_SR.ReadLine(); // read line by line
                string[] line_splited = line.Split('/'); // splitting when you find a backslash
                my_movie.movie_name = line_splited[0];//movie name will be put in the first index

                for (int i = 1; i < line_splited.Count(); i++) // i=1 because index 0 contains the movie name
                {
                    all_actors.Add(line_splited[i]); // adds the actor to a set of all actors
                    my_movie.actors.Add(line_splited[i]); // adds the actor to a set of all actors in the movie we're proccessing
                }

                all_movies.Add(my_movie); // adds the movie to a vector of all movies
            

            }
            movies_SR.Close();

            for (int i = 0; i < all_actors.Count(); i++)
                adj_list.Add(new Dictionary<string,int>()); //adding a map in each index in the adjacency list
            foreach (string item in all_actors)
            {
                    actors_incoding.Add(item, indexing); //giving each actor a code number
                    reversed_incoding.Add(indexing, item); // reverse indexing, will be needed later for representation
                    indexing++;
            }
            foreach (movie_data item in all_movies) //looping on each movie sepereately 
            { 
                for (int i=0; i<item.actors.Count(); i++){ //accessing each actor in that movie once as a primary index
                    for (int j = 0; j <item.actors.Count(); j++) // looping through the while array to mark and increase the graph weight
                    {
                        string temp = item.actors[i]; 
                        string temp2=item.actors[j];
                        if (item.actors[i] != item.actors[j]) // check if both comparirators are not on the same index
                        {
                            if (adj_list[actors_incoding[temp]].ContainsKey(temp2) == true) // if the key is already in this index's map
                            adj_list[actors_incoding[temp]][temp2]++;// increase it's weight by one

                            else  // if not
                            adj_list[actors_incoding[temp]].Add(temp2, 1); // add it to this index's map and increase the value by one
                            
                        }
                    
                    }
                }

            }

            for (int i = 0; i < adj_list.Count(); i++)
            {
                Console.Write(reversed_incoding[i]);
                Console.Write(" ===> ");
                foreach (KeyValuePair<string, int> item in adj_list[i])
                    Console.Write(item);
                Console.WriteLine();

            }
           //  the commented part is for adjacency list representation, uncomment to test 
           
            

            // the following part is for loading queries 
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
