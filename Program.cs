using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu = 0;
            do
            {
                Menu();
            } while (menu != 1);
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("What you want to do?");
            Console.WriteLine("1- Open file");
            Console.WriteLine("2- Creat new file");
            Console.WriteLine("3- Delete to file");
            Console.WriteLine("0- Exit");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                    System.Environment.Exit(0); break;
                case 1:
                    Open(); break;
                case 2:
                    ToEdit(); break;
                case 3:
                    Delete(); break;
                default:
                    Console.WriteLine("Invalid"); break;
            }

            static void Open()
            {
                Console.Clear();
                Console.WriteLine("Path the file");
                string path = Console.ReadLine();
                using (var file = new StreamReader(path))
                {
                    string text = file.ReadToEnd();
                    Console.WriteLine(text);
                }
                Console.WriteLine("");
                Console.ReadLine();
            }

            static void ToEdit()
            {
                Console.Clear();
                Console.WriteLine(" Write your text (Press ESC to exit)");
                Console.WriteLine("-------------------------------");
                string text = "";

                do
                {
                    text += Console.ReadLine();
                    text += Environment.NewLine;
                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);

                Save(text);
            }

            static void Delete()
            {
                Console.Clear();
                Console.Write("Path to delete the file");
                Console.WriteLine("");
                var path = Console.ReadLine();

                File.Delete(path);

            }

            static void Save(string text)
            {
                Console.WriteLine(" Path to save the file?");
                var path = Console.ReadLine();

                using (var file = new StreamWriter(path))
                {
                    file.Write(text);
                }
                Console.WriteLine($"file {path} saved successfully");
                Console.ReadLine();
                Menu();
            }

        }
    }

}
