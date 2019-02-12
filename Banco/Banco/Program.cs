using System;
using ArrayLibrary;
using MenuLibrary;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] clients = new string[,] {{"01604075678","vinicius marcelos andrade","02/09/1987" },
                {"06157184698","cássia marcelos andrade","12/05/1983" },
                {"27352820663","carlos alberto andrade","27/04/1957" },
                {"07386199651","mariana marcelos andrade","25/09/1985" },
                {"93186894620","lucelia maria alves","22/11/1974" } };
            float[,] accounts = new float[,] { { 01604075678, 666, 1000000.00F },
            { 01604075678, 667, 100.12F },{ 27352820663, 668, 350.65F },
            { 01604075678, 669, 250000.12F },{ 01604075678, 666, 20000.03F },
            { 27352820663, 666, 885000.00F },{ 93186894620, 666, 123000.00F }};
            MainMenu(clients, accounts);
        }
        public static void MainMenu(string[,] clients , float[,] accounts)
        {
            string[] startMenu = new string[] { "Clientes", "Contas", "Operações", "Sair" };
            Menu.PrintMenu(startMenu, "SISTEMA DO BANCO");
            string mainMenuChoice = Menu.ReadOption(startMenu,
                "Digite o número correspondente à opção desejada:");
            switch (mainMenuChoice)
            {
                case "Clientes":
                    ClientsMenu(clients,accounts);
                    break;
                case "Contas":
                    AccountsMenu(clients, accounts);
                    break;
                case "Operações":
                    OperationsMenu(clients, accounts);
                    break;
                case "Sair":
                    break;
            }
        }
        public static void ClientsMenu (string[,] clients, float[,] accounts)
        {
            string[] clientsMenu = new string[] { "Adicionar novo cliente",
                "Alterar dados de um cliente existente", "Remover um cliente",
                "Consultar informações de um cliente", "Retornar ao menu principal" };
            Menu.PrintMenu(clientsMenu, "MENU DE CLIENTES");
            string clientsMenuChoice = Menu.ReadOption(clientsMenu);
            switch (clientsMenuChoice)
            {
                case "Adicionar novo cliente":
                    ArrayLib.PrintArray(clients);
                    Console.ReadKey();
                    break;
                case "Alterar dados de um cliente existente":
                    break;
                case "Remover um cliente":
                    break;
                case "Consultar informações de um cliente":
                    break;
                case "Retornar ao menu principal":
                    MainMenu(clients, accounts);
                    break;
            }
        }
        public static void AccountsMenu(string[,] clients, float[,] accounts)
        {
            //cpf imput to go to specific client's accounts
            string[] accountsMenu = new string[] { "Criar uma nova conta", "Remover uma conta",
                "Consultar contas do cliente", "Retornar ao menu principal" };
            Menu.PrintMenu(accountsMenu, "MENU DE CONTAS");
            string accountsMenuChoice = Menu.ReadOption(accountsMenu);
            switch (accountsMenuChoice)
            {
                case "Criar uma nova conta":
                    break;
                case "Remover uma conta":
                    break;
                case "Consultar contas do cliente":
                    break;
                case "Retornar ao menu principal":
                    MainMenu(clients, accounts);
                    break;
            }
        }
        public static void OperationsMenu(string[,] clients, float[,] accounts)
        {
            //account number imput to go to specific account
            string[] operationsMenu = new string[] { "Depósito", "Saque",
                "Retornar ao menu principal" };
            Menu.PrintMenu(operationsMenu, "MENU DE OPERAÇÕES");
            string operationsMenuChoice = Menu.ReadOption(operationsMenu);
            switch (operationsMenuChoice)
            {
                case "Depósito":
                    break;
                case "Saque":
                    break;
                case "Retornar ao menu principal":
                    MainMenu(clients,accounts);
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
