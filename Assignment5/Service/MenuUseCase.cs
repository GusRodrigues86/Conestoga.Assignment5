using Assignment5.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Service
{
    public static class MenuUseCase
    {
        public static int MainMenu(string input) =>
            Parser.ParseInputToMenu(input);

        public static int Search(string input) =>
            Parser.ParseInputToSearch(input);
    }
}
