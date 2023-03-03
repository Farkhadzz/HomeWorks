using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryService;

namespace MenuService
{
    internal static class Menu
    {
        static Menu() { }

        public static void StartMenu()
        {
            Console.Clear();


            int choice = 0;
            int tmpIndx = 0;
            Dictionary MainDictionary = new();


            Console.WriteLine("~-- MENU --~\n" +
                "1 - CREATE DICTIONARY\n" +
                "2 - EDIT DICTIONARY\n" +
                "3 - SHOW DICTIONARY\n" +
                "4 - SEARCH WORD\n" +
                "5 - SAVE TO FILE DICTIONARY\n" +
                "6 - SAVE TO FILE WORD\n" +
                "7 - EXIT\n" +
                "PRESS ON NUMBER : \n"
                );
            ConsoleKeyInfo UserInput = Console.ReadKey();


            if (char.IsDigit(UserInput.KeyChar))
            {
                choice = Convert.ToInt32(UserInput.KeyChar.ToString());
            }
            else
            {
                Console.WriteLine("error");
                Menu.StartMenu();
            }


            switch (choice)
            {
                case 1:
                    MainDictionary.CreateDictionary();
                    Menu.StartMenu();
                    break;

                case 2:
                    if (MainDictionary == null)
                    {
                        Console.WriteLine("YOU CANNOT EDIT EMPTY DICTIONARY");
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.editDictionary();
                        Menu.StartMenu();
                    }
                    break;

                case 3:
                    if (MainDictionary == null)
                    {
                        Console.WriteLine("CANNOT PRINT NULL DICTIONARY");
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {

                        MainDictionary.editDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.PrintDictionary();
                        Menu.StartMenu();
                    }
                    break;

                case 4:
                    if (MainDictionary == null)
                    {
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {
                        MainDictionary.editDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.find();
                        Menu.StartMenu();
                    }
                    break;

                case 5:
                    if (MainDictionary == null)
                    {
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {
                        MainDictionary.editDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.save();
                        Menu.StartMenu();
                    }
                    break;

                case 6:
                    if (MainDictionary == null)
                    {
                        Console.WriteLine("CANNOT SAVE WORD FROM NULL DICTIONARY");
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {
                        MainDictionary.editDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        Console.Write("ENTER INDEX OF WORD : ");
                        tmpIndx = Convert.ToInt32(Console.ReadLine());

                        MainDictionary.translationPairs[tmpIndx - 1].SaveWord();
                        Menu.StartMenu();
                    }
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("ERROR");
                    Menu.StartMenu();
                    break;
            }
        }
    }
}
}
