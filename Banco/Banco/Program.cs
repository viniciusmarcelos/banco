using System;
using MyLibrary;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();

            Console.ReadKey();
        }
        public static void MainMenu()
        {
            string[] startMenu = new string[] { "Clientes", "Contas", "Operações", "Sair" };
            MenuLib.PrintMenu(startMenu, "SISTEMA DO BANCO");
            string startMenuChoice = MenuLib.ReadOption(startMenu,"Digite o número correspondente à opção desejada:");
            switch (startMenuChoice)
            {
                case "Clientes":
                    ClientsMenu();
                    break;
                case "Contas":
                    break;
                case "Operações":
                    break;
                case "Sair":
                    break;
                default:
                    break;
            }
        }
        public static void ClientsMenu()
        {
            string[] clientsMenu = new string[] { "Adicionar novo cliente", "Remover um cliente" , "Retornar ao menu principal"};
            MenuLib.PrintMenu(clientsMenu, "MENU DE CLIENTES");
            string clientsMenuChoice = MenuLib.ReadOption(clientsMenu);
            switch (clientsMenuChoice)
            {
                case "Adicionar novo cliente":
                    MainMenu();
                    break;
                case "Remover um cliente":
                    break;
                case "Retornar ao menu principal":
                    break;
                default:
                    break;
            }
        }
    }
}
