using System;
using ArrayLibrary;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }
        public static void MainMenu()
        {
            string[] startMenu = new string[] { "Clientes", "Contas", "Operações", "Sair" };
            MenuLib.PrintMenu(startMenu, "SISTEMA DO BANCO");
            string mainMenuChoice = MenuLib.ReadOption(startMenu, 
                "Digite o número correspondente à opção desejada:");
            switch (mainMenuChoice)
            {
                case "Clientes":
                    ClientsMenu();
                    break;
                case "Contas":
                    AccountsMenu();
                    break;
                case "Operações":
                    OperationsMenu();
                    break;
                case "Sair":
                    break;
            }
        }
        public static void ClientsMenu()
        {
            string[] clientsMenu = new string[] { "Adicionar novo cliente",
                "Alterar dados de um cliente existente", "Remover um cliente",
                "Consultar informações de um cliente", "Retornar ao menu principal" };
            MenuLib.PrintMenu(clientsMenu, "MENU DE CLIENTES");
            string clientsMenuChoice = MenuLib.ReadOption(clientsMenu);
            switch (clientsMenuChoice)
            {
                case "Adicionar novo cliente":
                    break;
                case "Alterar dados de um cliente existente":
                    break;
                case "Remover um cliente":
                    break;
                case "Consultar informações de um cliente":
                    break;
                case "Retornar ao menu principal":
                    MainMenu();
                    break;
            }
        }
        public static void AccountsMenu()
        {
            //cpf imput to go to specific client's accounts
            string[] accountsMenu = new string[] { "Criar uma nova conta", "Remover uma conta",
                "Consultar contas do cliente", "Retornar ao menu principal" };
            MenuLib.PrintMenu(accountsMenu, "MENU DE CONTAS");
            string accountsMenuChoice = MenuLib.ReadOption(accountsMenu);
            switch (accountsMenuChoice)
            {
                case "Criar uma nova conta":
                    break;
                case "Remover uma conta":
                    break;
                case "Consultar contas do cliente":
                    break;
                case "Retornar ao menu principal":
                    MainMenu();
                    break;
            }
        }
        public static void OperationsMenu()
        {
            //account number imput to go to specific account
            string[] operationsMenu = new string[] { "Depósito", "Saque",
                "Retornar ao menu principal" };
            MenuLib.PrintMenu(operationsMenu, "MENU DE OPERAÇÕES");
            string operationsMenuChoice = MenuLib.ReadOption(operationsMenu);
            switch (operationsMenuChoice)
            {
                case "Depósito":
                    break;
                case "Saque":
                    break;
                case "Retornar ao menu principal":
                    MainMenu();
                    break;
            }
        }
        public static string[,] AddNewClient(string[,] array)
        {
            if ((array.GetLength(0) == 1) && (array[0, 0] == "")) //first insertion
            {
               
            }
            return array;
        }        
    }
}
