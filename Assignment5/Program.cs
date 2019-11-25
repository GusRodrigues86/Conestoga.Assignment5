/* Assignment 5
*
* Revision History
*      Gustavo Bonifacio Rodrigues, 2019.11.23: Created
*/
using Assignment5.Model;
using Assignment5.Service;
using Assignment5.View;
using System;
using System.Threading;
using static Assignment5.Resources.AppConfiguration;
using static Assignment5.View.Presenter;

namespace Assignment5
{

    class Program
    {
        static void Main(string[] args) => RunApp();

        private static void RunApp()
        {
            DefaultApp();

            // start the library
            Console.WriteLine("Loading the library...");
            LibraryService library = new LibraryService();
            Thread.Sleep(500);
            Console.WriteLine("Loading the librarian...");
            Thread.Sleep(500);
            Console.WriteLine("Loading the coffee...");
            Thread.Sleep(2000);
            Console.Clear();
            Welcome(library);
            Console.WriteLine();
            CreateBook(library);
            Console.WriteLine();
            SearchBook(library);
            Console.WriteLine();
            SearchByAuthor(library);
            Console.WriteLine();
            SearchByTitle(library);
            Console.WriteLine();
            EditAnBook(library);

        }
    }
}
