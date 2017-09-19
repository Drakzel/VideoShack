using System;
using System.Collections.Generic;
using System.Text;
using VideoShackBLL;
using System.Linq;
using VideoShackBLL.BusinessObjects;

namespace VideoShack.Menu
{
    public class IntroMenu
    {
        string string1;
        int integer1;
        static BLLFacade BllFacade = new BLLFacade();


        public void Introduction ()
        {
            
            Console.WriteLine(
                "***************************************\n" +
                "**        Welcome to VideoShack      **\n" +
                "**                                   **\n" +
                "**               Press               **\n" +
                "**          1: Show videos.          **\n" +
                "**          2: Add.                  **\n" +
                "**          3: Delete.               **\n" +
                "**          4: Update.               **\n" +
                "**          5: Search.               **\n" +
                "**          6: Exit.                 **\n" +
                "**                                   **\n" +
                "***************************************");
            string1 = Console.ReadLine();

            if (int.TryParse(string1, out integer1))
            {
                integer1 = Convert.ToInt32(string1);
            }

            switch (integer1)
            {
                case 1:
                    Console.WriteLine("***************************************");
                    List<MovieBO> tempList = BllFacade.GetVideoService.RetrieveAllMovies();
                    foreach (var item in tempList)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    Console.WriteLine("***************************************");
                    break;
                case 2:
                    Console.WriteLine(
                        "***************************************\n" +
                        "**        Enter name of movie        **\n" +
                        "***************************************");
                    string name = Console.ReadLine();

                    Console.WriteLine(
                        "***************************************\n" +
                        "**        Enter genre of movie       **\n" +
                        "***************************************");
                    string genre = Console.ReadLine();

                    var movie = new MovieBO()
                    {
                        Name = name,
                        Genre = genre
                    };
                    movie = BllFacade.GetVideoService.Create(movie);
                    break;
                case 3:
                    Console.WriteLine(
                        "***************************************\n" +
                        "**     Enter the id of the movie     **\n" +
                        "**        you want to retrieve       **\n" +
                        "***************************************");
                    string stringId = Console.ReadLine();
                    if (int.TryParse(stringId, out int id))
                    {
                        id = Convert.ToInt32(stringId);
                    }

                    var movieFound = BllFacade.GetVideoService.RetrieveById(id);
                    if (movieFound != null)
                    {
                        Console.WriteLine(
                            "***************************************\n" +
                            " Are you sure you want to delete:\n" +
                            " Name: {0}\n" +
                            " Genre: {1}\n" +
                            " Id: {2}\n" +
                            "***************************************", movieFound.Name, movieFound.Genre, movieFound.Id);
                        Console.WriteLine(
                            "*************             *************\n" +
                            "**   YES   **             **    NO   **\n" +
                            "*************             *************");
                        string deleteValidation = Console.ReadLine();
                        if (deleteValidation.ToUpper() == "yes".ToUpper() || deleteValidation.ToUpper() == "y".ToUpper())
                        {
                            BllFacade.GetVideoService.DeleteMovie(id);
                            Console.WriteLine("Movie has been deleted");
                        }
                        else
                        {
                            Console.WriteLine("No changes was made, to the movie archieve.\n");
                        }
                    }
            break;
                case 4:
                    Console.WriteLine("Enter the id, of the movie you want:");
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out int idInput))
                    {
                        
                        MovieBO movieToUpdate = BllFacade.GetVideoService.RetrieveById(idInput);
                        if (movieToUpdate != null)
                        {
                            Console.WriteLine($"The selected movie is : {movieToUpdate.ToString()}");

                            Console.WriteLine(
                                "***************************************\n" +
                                "**       What would you like  the    **\n" +
                                "**       movie name changed into?    **\n" +
                                "***************************************");
                            string newName = Console.ReadLine();

                            Console.WriteLine(
                                "***************************************\n" +
                                "**       What would you like  the    **\n" +
                                "**       movie genre changed into?   **\n" +
                                "***************************************");
                            string newGenre = Console.ReadLine();
                            MovieBO updatedMovie = new MovieBO() { Id = movieToUpdate.Id };
                            if (newName != null || newName != "")
                            {
                                updatedMovie.Name = newName;
                            }
                            else { updatedMovie.Name = movieToUpdate.Name; }

                            if (newGenre != null || newGenre != "")
                            {
                                updatedMovie.Genre = newGenre;
                            }
                            else { updatedMovie.Genre = movieToUpdate.Genre; }

                            BllFacade.GetVideoService.Update(updatedMovie);
                        }
                        else
                        {
                            Console.WriteLine("Movie could not be found.");
                        }
                            
                    }
                    
                    else
                    {
                        Console.WriteLine("The movie was not found.");
                        Console.ReadLine();
                    }
                    break;
                case 5:
                    Console.WriteLine("SEARCH :");
                    string userSearch = Console.ReadLine();
                    List<MovieBO> retrievedList = BllFacade.GetVideoService.RetrieveByName(userSearch);
                    foreach (var item in retrievedList)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.Write("Press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
            Introduction();
        }
    }
}
