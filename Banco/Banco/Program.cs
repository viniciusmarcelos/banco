using System;
using ArrayLibrary;
using MenuLibrary;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] clientsArray = new string[,] {{"01604075678","vinicius marcelos andrade","02/09/1987" },
                {"06157184698","cássia marcelos andrade","12/05/1983" },
                {"27352820663","carlos alberto andrade","27/04/1957" },
                {"07386199651","mariana marcelos andrade","25/09/1985" },
                {"93186894620","lucelia maria alves","22/11/1974" }};
            decimal[,] accountsArray = new decimal[,] { { 01604075678, 666, 1000000 },
            { 01604075678, 667, 100.12M },{ 27352820663, 668, 350.65M },
            { 01604075678, 669, 250000.12M },{ 01604075678, 670, 20000.03M },
            { 27352820663, 671, 885000 },{ 93186894620, 672, 123000 },
            { 0, 673, 0},{01604075678,674,0 } };
            MainMenu(clientsArray, accountsArray);
        }
        public static void MainMenu(string[,] clientsArray, decimal[,] accountsArray)
        {
            string[] mainMenuOptions = new string[] { "Clientes", "Contas", "Operações", "Sair" };
            MenuLib.PrintMenu(mainMenuOptions, "SISTEMA DO BANCO");
            string mainMenuChoice = MenuLib.ReadOption(mainMenuOptions,
                "Digite o número correspondente à opção desejada:");
            switch (mainMenuChoice)
            {
                case "Clientes":
                    ClientsMenu(clientsArray, accountsArray);
                    break;
                case "Contas":
                    AccountsMenu(clientsArray, accountsArray);
                    break;
                case "Operações":
                    OperationsMenu(clientsArray, accountsArray);
                    break;
                case "Sair":
                    break;
            }
        }
        public static void ClientsMenu(string[,] clientsArray, decimal[,] accountsArray)
        {
            string[] clientsMenuOptions = new string[] { "Adicionar novo cliente",
                "Alterar dados de um cliente existente", "Remover um cliente",
                "Consultar informações de um cliente", "Retornar ao menu principal" };
            MenuLib.PrintMenu(clientsMenuOptions, "MENU DE CLIENTES");
            string clientsMenuChoice = MenuLib.ReadOption(clientsMenuOptions);
            switch (clientsMenuChoice)
            {
                case "Adicionar novo cliente":
                    clientsArray = ClientsLib.AddNewClient(clientsArray);
                    break;
                case "Alterar dados de um cliente existente":
                    clientsArray = ClientsLib.EditClient(clientsArray);
                    break;
                case "Remover um cliente":
                    clientsArray = ClientsLib.RemoveClient(clientsArray);
                    break;
                case "Consultar informações de um cliente":
                    ClientsLib.ConsultClient(clientsArray);
                    break;
                case "Retornar ao menu principal":
                    break;
            }
            MainMenu(clientsArray, accountsArray);
        }
        public static void AccountsMenu(string[,] clientsArray, decimal[,] accountsArray)
        {
            MenuLib.PrintSubmenu("ACESSO AO MENU DE CONTAS");
            int clientPosition = Verifications.ReadCPF(clientsArray, "Digite o CPF do cliente:");
            if (clientPosition != -1)
            {
                decimal.TryParse(clientsArray[clientPosition, 0], out decimal clientCPF);
                string[] accountsMenuOptions = new string[] { "Criar uma nova conta", "Remover uma conta",
                "Consultar contas do cliente", "Retornar ao menu principal" };
                MenuLib.PrintMenu(accountsMenuOptions, "MENU DE CONTAS");
                MenuLib.PrintMessage("Acessando as contas de:\n");
                ClientsLib.PrintClientNameAndCPF(clientsArray, clientPosition);
                Console.WriteLine();
                string accountsMenuChoice = MenuLib.ReadOption(accountsMenuOptions);
                switch (accountsMenuChoice)
                {
                    case "Criar uma nova conta":
                        accountsArray = AccountsLib.AddNewAccount(accountsArray, clientCPF);
                        break;
                    case "Remover uma conta":
                        accountsArray = AccountsLib.RemoveAccount(accountsArray, clientCPF);
                        break;
                    case "Consultar contas do cliente":
                        AccountsLib.ConsultAccounts(accountsArray, clientCPF);
                        break;
                    case "Retornar ao menu principal":
                        break;
                }
            }
            MainMenu(clientsArray, accountsArray);
        }
        public static void OperationsMenu(string[,] clientsArray, decimal[,] accountsArray)
        {
            MenuLib.PrintSubmenu("ACESSO AO MENU DE OPERAÇÕES");
            int accountIndex = Verifications.ReadAccount(accountsArray, "Digite a conta na qual deseja realizar a operação:");
            if (!MenuLib.ConfirmationMenu("A conta está correta?", "Sim", "Não, voltar para menu principal"))
            {
                MainMenu(clientsArray, accountsArray);
            }
            string[] operationsMenu = new string[] { "Depósito", "Saque",
                "Retornar ao menu principal" };
            MenuLib.PrintMenu(operationsMenu, "MENU DE OPERAÇÕES");
            string operationsMenuChoice = MenuLib.ReadOption(operationsMenu);
            switch (operationsMenuChoice)
            {
                case "Depósito":
                    decimal creditValue = MenuLib.ReadMoneyValue("Entre com o valor a ser depositado na conta:");
                    if (MenuLib.ConfirmationMenu("Confirma a operação?"))
                    {
                        accountsArray[accountIndex, 2] += creditValue;
                        MenuLib.PrintMessage("Operação realizada com sucesso!\n");
                        AccountsLib.PrintAccount(accountsArray, accountIndex);
                        MenuLib.PrintMessage("Digite qualquer tecla para retornar ao menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        MenuLib.PrintMessage("Operação cancelada pelo usuário.\n" +
                            "Digite qualquer tecla para retornar ao menu.");
                        Console.ReadKey();
                    }
                    break;
                case "Saque":
                    decimal debitValue = MenuLib.ReadMoneyValue("Entre com o valor a ser debitado da conta:");
                    if (!Verifications.IsThereEnougthCredit(accountsArray[accountIndex, 2], debitValue))
                    {
                        MenuLib.PrintMessage("Saldo insuficiente.\n\n" +
                            "Pressione qualquer tecla para retornar ao menu.");
                        Console.ReadKey();
                        break;
                    }
                    if (MenuLib.ConfirmationMenu("Confirma a operação?"))
                    {
                        accountsArray[accountIndex, 2] -= debitValue;
                        MenuLib.PrintMessage("Operação realizada com sucesso!\n\n" +
                            "Saldo atualizado:\n");
                        AccountsLib.PrintBalance(accountsArray, accountIndex);
                        MenuLib.PrintMessage("Digite qualquer tecla para retornar ao menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        MenuLib.PrintMessage("Operação cancelada pelo usuário.\n\n" +
                            "Digite qualquer tecla para retornar ao menu.");
                        Console.ReadKey();
                    }
                    break;
                case "Retornar ao menu principal":
                    MainMenu(clientsArray, accountsArray);
                    break;
            }
            MainMenu(clientsArray, accountsArray);
        }
    }
}
