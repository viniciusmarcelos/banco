﻿using System;
using ArrayLibrary;

namespace MenuLibrary
{
    public class MenuLib
    {
        ///prints a Menu, options are: 1, 2, 3 .. and the last is 0 - Exit
        public static void PrintMenu(string[] array, string headline)
        {
            Console.Clear();
            PrintAddingSpaces(headline);
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("{0} - {1}", i < (array.Length - 1) ? i + 1 : 0, array[i]);
            }
            Console.WriteLine();
        }
        ///Clears the screen and prints the imput headline
        public static void PrintSubmenu(string headline)
        {
            Console.Clear();
            PrintMessage(headline);
            Console.WriteLine();
        }
        ///prints options with no headline: 1, 2, 3 .. and the last is 0 - Exit
        public static void PrintOptions(string[] array)
        {
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("{0} - {1}", i < (array.Length - 1) ? i + 1 : 0, array[i]);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Two choices menu.Prints a message, prints options, returns true for the first one and false for the other.
        /// </summary>
        /// <param name="message">Question to be displayed.</param>
        /// <param name="choice1">The first choice.</param>
        /// <param name="choice2">The second choice.</param>
        /// <returns></returns>
        public static bool ConfirmationMenu(string message, string choice1, string choice2)
        {
            PrintMessage(message);
            Console.WriteLine("\nDigite 1 para <{0}> ou 2 para <{1}>:", choice1, choice2);
            while (true)
            {
                string imput = Console.ReadLine();
                if (imput == "1")
                {
                    return true;
                }
                else if (imput == "2")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Escolha inválida.\n" +
                        "Digite 1 para <{0}> ou 2 para <{1}>:", choice1, choice2);
                }
            }
        }
        /// <summary>
        /// Two choices menu.Prints a message, prints options, returns true for the first one and false for the other.
        /// </summary>
        /// <param name="message">Question to be displayed.</param>
        /// <returns></returns>
        public static bool ConfirmationMenu(string message)
        {
            return ConfirmationMenu(message, "Sim", "Não");
        }
        /// <summary>
        /// Two choices menu.Prints a message, prints options, returns true for the first one and false for the other.
        /// </summary>
        /// <returns></returns>
        public static bool ConfirmationMenu()
        {
            return ConfirmationMenu("Tem certeza?", "Sim", "Não");
        }
        ///prints the message
        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        ///prints a message then reads the option chosen, checks if it's valid, loops if not, returns the TEXT of the option
        public static string ReadOption(string[] options, string message)
        {
            while (true)
            {
                PrintMessage(message);
                string imput = Console.ReadLine();
                if (!int.TryParse(imput, out int chosenOption) || chosenOption < 0 || chosenOption > options.Length - 1)
                {
                    message = "Opção inválida. Digite uma opção válida:";
                }
                else
                {
                    string optionText = chosenOption == 0 ? options[options.Length - 1] : options[chosenOption - 1];
                    return optionText;
                }
            }
        }
        ///sends default message to ReadOption
        public static string ReadOption(string[] options)
        {
            return ReadOption(options, "Digite a opção desejada:");
        }
        public static double ReaddoubleValue(string message)
        {
            while (true)
            {
                PrintMessage(message);
                if (!double.TryParse(Console.ReadLine(), out double value))
                {
                    message = "Valor digitado inválido. Digite um valor válido:";
                }
                else
                {
                    return value;
                }
            }
        }
        /// prints a message then reads value and checks if it's a double, loops if not, returns the double
        public static double ReadMoneyValue(string message)
        {
            while (true)
            {
                PrintMessage(message);
                if (!double.TryParse(Console.ReadLine(), out double value) || !Verifications.TwoDecimalsCheck(value))
                {
                    message = "Valor digitado inválido. Digite um valor válido:";
                }
                else
                {
                    return value;
                }
            }
        }
        ///sends default message to ReadMoneyValue
        public static double ReadMoneyValue()
        {
            return ReadMoneyValue("Digite o valor:");
        }
        /// prints a message then reads value and returns the string
        public static string ReadStringValue(string message)
        {
            PrintMessage(message);
            return Console.ReadLine();
        }
        ///sends default message to ReadStringValue
        public static string ReadStringValue()
        {
            return ReadStringValue("Digite o valor:");
        }
        ///adds the correct sulfix to positions, as following: 0"", 1"st", 2"nd", 3"rd", 4"th", 5"th" ... and -1"not found"
        public static string ThAdder(int position)
        {
            switch (position)
            {
                case 0:
                    return "";
                case 1:
                    return "st";
                case 2:
                    return "nd";
                case 3:
                    return "rd";
                case -1:
                    return "(not found)";
                default:
                    return "th";
            }
        }
        ///P R I N T S  L I K E  T H I S
        public static void PrintAddingSpaces(string imput)
        {
            for (int i = 0; i < imput.Length; i++)
            {
                Console.Write("{0}{1}", imput[i], i < imput.Length - 1 ? " " : "\n");
            }
        }
    }
    public class ClientsLib
    {
        /// <summary>
        /// Adds a new client.
        /// </summary>
        /// <param name="clientsArray">The string[,] that contains the clients.</param>
        /// <returns>The string[,] with all clients it had plus the added one, or not, if the CPF already existed.</returns>
        public static string[,] AddNewClient(string[,] clientsArray)
        {
            MenuLib.PrintSubmenu("ADICIONANDO NOVO CLIENTE");
            int i = clientsArray.GetLength(0);
            clientsArray = ArrayLib.AddOneLength(clientsArray);
            if (ReadAndRecordCPF(clientsArray, i))
            {
                ReadAndRecordName(clientsArray, i);
                ReadAndRecordBirthDate(clientsArray, i);
                MenuLib.PrintMessage("Cliente adicionado com sucesso!\n" +
                    "Pressione qualquer tecla para retornar ao Menu.");
                Console.ReadKey();
                return clientsArray;
            }
            return clientsArray;
        }
        /// <summary>
        /// Edits the name or the birth date of a client by searching for it with the CPF.
        /// </summary>
        /// <param name="clientsArray"></param>
        /// <returns></returns>
        public static string[,] EditClient(string[,] clientsArray)
        {
            MenuLib.PrintSubmenu("EDITAR CLIENTE");
            int clientPosition = Verifications.ReadCPF(clientsArray, "Qual o CPF do cliente que deseja acessar?");
            if (clientPosition != -1)
            {
                string[] editMenu = new string[] { "Alterar o nome", "Alterar a data de nascimento", "Retornar ao menu principal" };
                MenuLib.PrintSubmenu("EDITAR CLIENTE");
                PrintClient(clientsArray, clientPosition, "Cliente a ser alterado:");
                MenuLib.PrintOptions(editMenu);
                string editMenuChoice = MenuLib.ReadOption(editMenu);
                switch (editMenuChoice)
                {
                    case "Alterar o nome":
                        ReadAndRecordName(clientsArray, clientPosition, "Digite o novo nome para o cliente:");
                        break;
                    case "Alterar a data de nascimento":
                        ReadAndRecordBirthDate(clientsArray, clientPosition, "Digite a nova data de nascimento:");
                        break;
                    case "Retornar ao menu principal":
                        return clientsArray;
                }
                Console.Clear();
                PrintClient(clientsArray, clientPosition, "Alteração bem sucedida!");
                MenuLib.PrintMessage("\nPressione ENTER para voltar ao menu principal:");
                Console.ReadKey();
            }
            return clientsArray;
        }
        /// <summary>
        /// Based on CPF input deletes a client.
        /// </summary>
        /// <param name="clientsArray"></param>
        /// <returns></returns>
        public static string[,] RemoveClient(string[,] clientsArray)
        {
            MenuLib.PrintSubmenu("REMOVER CLIENTE");
            int clientPosition = Verifications.ReadCPF(clientsArray, "Qual o CPF do cliente que deseja remover?");
            if (clientPosition != -1)
            {
                Console.Clear();
                PrintClient(clientsArray, clientPosition, "Cliente que será removido:");
                if (MenuLib.ConfirmationMenu("Tem certeza que deseja deletar o cliente?"))
                {
                    if (clientsArray.GetLength(0) - 1 != clientPosition)
                    {
                        clientsArray = ArrayLib.SwapLines(clientsArray, clientPosition, clientsArray.GetLength(0) - 1);
                    }
                    clientsArray = ArrayLib.RemoveLast(clientsArray);
                    MenuLib.PrintMessage("O cliente foi deletado. Pressione ENTER para retornar ao menu principal:");
                    Console.ReadKey();
                    return clientsArray;
                }
                MenuLib.PrintMessage("Operação cancelada.\n" +
                    "Pressione ENTER para retornar ao menu principal:");
                Console.ReadKey();
            }
            return clientsArray;
        }
        /// <summary>
        /// Consults a client and displays information
        /// </summary>
        /// <param name="clientsArray"></param>
        /// <returns></returns>
        public static void ConsultClient(string[,] clientsArray)
        {
            MenuLib.PrintSubmenu("CONSULTAR CLIENTE");
            int clientPosition = Verifications.ReadCPF(clientsArray, "Qual o CPF do cliente que deseja consultar?");
            if (clientPosition != -1)
            {
                Console.Clear();
                PrintClient(clientsArray, clientPosition, "Dados do cliente:");
                MenuLib.PrintMessage("Pressione qualquer tecla para retornar ao menu principal.");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Prints a message and then the client data.
        /// </summary>
        /// <param name="clientArray"></param>
        /// <param name="clientIndex"></param>
        /// <param name="message"></param>
        public static void PrintClient(string[,] clientArray, int clientIndex, string message)
        {
            MenuLib.PrintMessage(message);
            Console.WriteLine("\nNome: {0}\nCPF: {1}\nData de Nascimento: {2}",
                clientArray[clientIndex, 1], clientArray[clientIndex, 0], clientArray[clientIndex, 2]);
        }
        /// <summary>
        /// Prints the client data.
        /// </summary>
        /// <param name="clientArray"></param>
        /// <param name="clientIndex"></param>
        public static void PrintClient(string[,] clientArray, int clientIndex)
        {
            Console.WriteLine("\nNome: {0}\nCPF: {1}\nData de Nascimento: {2}",
                clientArray[clientIndex, 1], clientArray[clientIndex, 0], clientArray[clientIndex, 2]);
        }
        /// <summary>
        /// Prints the client's name and CPF.
        /// </summary>
        /// <param name="clientArray"></param>
        /// <param name="clientIndex"></param>
        public static void PrintClientNameAndCPF(string[,] clientArray, int clientIndex)
        {
            Console.WriteLine("{0} - CPF: {1}",
                clientArray[clientIndex, 1], clientArray[clientIndex, 0]);
        }
        /// <summary>
        /// Read and record the CPF of the position i client and returns true, or returns false if CPF already exists.
        /// </summary>
        /// <param name="clientsArray"></param>
        /// <param name="clientIndex"></param>
        /// <returns></returns>
        private static bool ReadAndRecordCPF(string[,] clientsArray, int clientIndex)
        {
            string message = "Digite o CPF do Cliente:";
            while (true)
            {
                string cpf = MenuLib.ReadStringValue(message);
                if (!Verifications.CPFAlreadyExists(clientsArray, cpf))  //validates CPF
                {
                    MenuLib.PrintMessage("CPF já cadastrado no nosso banco de dados.\n" +
                        "Pressione qualquer tecla para retornar ao Menu.");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    clientsArray[clientIndex, 0] = cpf;
                    return true;
                }
            }
        }
        /// <summary>
        /// Read and record the name of the position i client.
        /// </summary>
        /// <param name="clientsArray"></param>
        /// <param name="clientIndex"></param>
        /// <param name="message"></param>
        private static void ReadAndRecordName(string[,] clientsArray, int clientIndex, string message)
        {
            clientsArray[clientIndex, 1] = MenuLib.ReadStringValue(message);
        }
        /// <summary>
        /// sends default message to ReadAndRecordName
        /// </summary>
        /// <param name="clientsArray"></param>
        /// <param name="clientIndex"></param>
        private static void ReadAndRecordName(string[,] clientsArray, int clientIndex)
        {
            ReadAndRecordName(clientsArray, clientIndex, "Digite o nome do Cliente:");
        }
        /// <summary>
        /// read and record the birth date of the position i client
        /// </summary>
        /// <param name="clientsArray"></param>
        /// <param name="clientIndex"></param>
        /// <param name="message"></param>
        private static void ReadAndRecordBirthDate(string[,] clientsArray, int clientIndex, string message)
        {
            clientsArray[clientIndex, 2] = MenuLib.ReadStringValue(message);
        }
        /// <summary>
        /// sends default message to ReadAndRecordName
        /// </summary>
        /// <param name="clientsArray"></param>
        /// <param name="clientIndex"></param>
        private static void ReadAndRecordBirthDate(string[,] clientsArray, int clientIndex)
        {
            ReadAndRecordBirthDate(clientsArray, clientIndex, "Digite a data de nascimento do cliente:");
        }
    }
    public class AccountsLib
    {
        /// <summary>
        /// Adds a new account for the CPF input. Sets it's number to previous + 1 and balance to 50.
        /// </summary>
        /// <param name="accountsArray"></param>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static double[,] AddNewAccount(double[,] accountsArray, double cpf)
        {
            MenuLib.PrintSubmenu("CRIANDO NOVA CONTA");
            if (MenuLib.ConfirmationMenu("Tem certeza que deseja criar uma nova conta?", "Criar nova conta", "Cancelar"))
            {
                int newAccountPosition = accountsArray.GetLength(0);
                accountsArray = ArrayLib.AddOneLength(accountsArray);
                accountsArray[newAccountPosition, 0] = cpf;
                accountsArray[newAccountPosition, 1] = accountsArray[newAccountPosition - 1, 1] + 1;
                accountsArray[newAccountPosition, 2] = 50.00F;
                PrintAccount(accountsArray, newAccountPosition, "\nA conta foi criada com sucesso! Veja:");
                MenuLib.PrintMessage("Pressione qualquer tecla para retornar ao Menu.");
                Console.ReadKey();
            }
            return accountsArray;
        }
        /// <summary>
        /// Removes account from input cpf.
        /// </summary>
        /// <param name="accountsArray"></param>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static double[,] RemoveAccount(double[,] accountsArray, double cpf)
        {
            MenuLib.PrintSubmenu("REMOVER CONTA");
            int accountPosition = Verifications.ReadAccount(accountsArray, "Qual o número da conta a ser removida?");
            if (accountPosition != -1)
            {
                if (Verifications.IsAccountFromCPF(accountsArray, accountPosition, cpf))
                {
                    Console.Clear();
                    PrintAccount(accountsArray, accountPosition, "Conta que será removida:");
                    if (Verifications.IsAccountZeroed(accountsArray, accountPosition))
                    {
                        if (MenuLib.ConfirmationMenu("Tem certeza que deseja deletar a conta?"))
                        {
                            if (accountsArray.GetLength(0) - 1 != accountPosition)
                            {
                                accountsArray = ArrayLib.SwapLines(accountsArray, accountPosition, accountsArray.GetLength(0) - 1);
                            }
                            accountsArray = ArrayLib.RemoveLast(accountsArray);
                            MenuLib.PrintMessage("A conta foi deletada. Pressione ENTER para retornar ao menu principal:");
                            Console.ReadKey();
                            return accountsArray;
                        }
                        MenuLib.PrintMessage("Operação cancelada pelo usuário.\n" +
                            "Pressione ENTER para retornar ao menu principal:");
                        Console.ReadKey();
                    }
                    else
                    {
                        MenuLib.PrintMessage("A operação não pôde ser concluída pois há saldo na conta.\n" +
                        "Primeiramente deve ser feito o saque de todo o saldo da conta.\n" +
                        "Pressione ENTER para retornar ao menu principal:");
                        Console.ReadKey();
                    }
                }
                else
                {
                    MenuLib.PrintMessage("A operação não pôde ser concluída pois a conta não pertence a este CPF.\n" +
                    "Verifique o número da conta e do CPF digitados e tente novamente.\n" +
                    "Pressione ENTER para retornar ao menu principal:");
                    Console.ReadKey();
                }
            }
            return accountsArray;
        }
        /// <summary>
        /// Prints account number and balance.
        /// </summary>
        /// <param name="accountsArray"></param>
        /// <param name="accountIndex"></param>
        /// <param name="message"></param>
        public static void ConsultAccounts(double[,] accountsArray, double cpf)
        {
            MenuLib.PrintSubmenu("CONSULTANDO AS CONTAS");
            Console.WriteLine("Para o CPF informado ({0}), temos as seguintes contas:\n", cpf);
            double totalBalance = 0;
            for (int i = 0; i < accountsArray.GetLength(0); i++)
            {
                if (accountsArray[i, 0] == cpf)
                {
                    PrintAccount(accountsArray, i);
                    totalBalance += accountsArray[i, 2];
                }
            }
            Console.WriteLine("\nO balanço total do cliente é: R${0}\n" +
                "Digite qualquer tecla para retornar ao menu principal.", totalBalance);
            Console.ReadKey();
        }
        /// <summary>
        /// Prints a message and account number + account balance.
        /// </summary>
        /// <param name="accountsArray"></param>
        /// <param name="accountIndex"></param>
        /// <param name="message"></param>
        public static void PrintAccount(double[,] accountsArray, int accountIndex, string message)
        {
            MenuLib.PrintMessage(message);
            Console.WriteLine("\nNúmero da conta: {0}\nSaldo da conta: {1}",
                accountsArray[accountIndex, 1], accountsArray[accountIndex, 2]);
        }
        /// <summary>
        /// Prints account number + account balance.
        /// </summary>
        /// <param name="accountsArray"></param>
        /// <param name="accountIndex"></param>
        /// <param name="message"></param>
        public static void PrintAccount(double[,] accountsArray, int accountIndex)
        {
            Console.WriteLine("\nNúmero da conta: {0}\nSaldo da conta: {1}",
                accountsArray[accountIndex, 1], accountsArray[accountIndex, 2]);
        }
        /// <summary>
        /// Prints aaccount balance.
        /// </summary>
        /// <param name="accountsArray"></param>
        /// <param name="accountIndex"></param>
        /// <param name="message"></param>
        public static void PrintBalance(double[,] accountsArray, int accountIndex)
        {
            Console.WriteLine("Saldo da conta: {0}", accountsArray[accountIndex, 2]);
        }
    }
    public class Verifications
    {
        /// <summary>
        /// Displays a message than reads CPF input. 
        /// If it is found in the clienrsArray, returns the position,
        /// if not, keeps asking for another valid input, unless user types "" to leave.
        /// </summary>
        /// <param name="clientsArray"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int ReadCPF(string[,] clientsArray, string message)
        {
            string target = MenuLib.ReadStringValue(message);
            while (true)
            {
                int i = ArrayLib.Find_Ordinary(clientsArray, target, 0);
                if (i != -1)
                {
                    return i;
                }
                else
                {
                    target = MenuLib.ReadStringValue("O CPF digitado não foi encontrado.\n" +
                        "Digite um CPF válido ou tecle ENTER para voltar ao menu principal:");
                    if (target == "")
                    {
                        return -1;
                    }
                }
            }
        }
        /// <summary>
        /// Checks if account is zeroed in balance, returns true if it is.
        /// </summary>
        /// <param name="accountsArray"></param>
        /// <param name="accountIndex"></param>
        /// <returns></returns>
        public static bool IsAccountZeroed(double[,] accountsArray, int accountIndex)
        {
            return accountsArray[accountIndex, 2] == 0 ? true : false;
        }
        /// <summary>
        /// Checks if account belongs to the CPF input. True for yes.
        /// </summary>
        /// <param name="accountsArray"></param>
        /// <param name="accountIndex"></param>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool IsAccountFromCPF(double[,] accountsArray, int accountIndex, double cpf)
        {
            return accountsArray[accountIndex, 0] == cpf ? true : false;
        }
        /// <summary>
        /// Checks if there is enougth cash in the account for the withdrawn.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="debitValue"></param>
        /// <returns></returns>
        public static bool IsThereEnougthCredit(double balance, double debitValue)
        {
            return (balance -= debitValue) >= 0 ? true : false;
        }
        /// <summary>
        /// Reads account input, if found returns position on accountsArray, if not, keeps asking until 
        /// valid input or 0 for exit.
        /// </summary>
        /// <param name="accountsArray"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int ReadAccount(double[,] accountsArray, string message)
        {
            while (true)
            {
                double target = MenuLib.ReaddoubleValue(message);
                int accountPosition = ArrayLib.Find_Ordinary(accountsArray, target, 1);
                if (accountPosition != -1)
                {
                    return accountPosition;
                }
                else
                {
                    message = ("A conta digitada não foi encontrada.\n" +
                        "Digite uma conta válida ou entre com o valor 0 para voltar ao menu principal:");
                    target = MenuLib.ReaddoubleValue(message);
                    if (target == 0)
                    {
                        return -1;
                    }
                }
            }
        }
        /// <summary>
        /// Reads CPF input. If it is found in the clienrsArray, returns the position,
        /// if not, keeps asking for another valid input, unless user types "" to leave.
        /// </summary>
        /// <param name="clientsArray"></param>
        /// <returns></returns>
        public static int ReadCPF(string[,] clientsArray)
        {
            return ReadCPF(clientsArray, "Digite o CPF:");
        }
        /// <summary>
        /// Checks if CPF exists on the array. True if it does.
        /// </summary>
        /// <param name="clientsArray"></param>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool CPFAlreadyExists(string[,] clientsArray, string cpf)
        {
            if (ArrayLib.Find_Ordinary(clientsArray, cpf, 0) == -1)
            {
                return true;
            }
            else return false; //make it check according to https://www.geradorcpf.com/algoritmo_do_cpf.htm 
        }
        public static bool TwoDecimalsCheck(double value)
        {
            return true; //make check if there are no more than 2 decimal places
        }
        private static int[] DateToIntArray(string dateString)
        {
            int[] dateInt = new int[3];
            string dayString = dateString.Substring(0, 2);
            string monthString = dateString.Substring(3, 2);
            string yearString = dateString.Substring(6, 4);
            int.TryParse(dayString, out dateInt[0]);
            int.TryParse(monthString, out dateInt[1]);
            int.TryParse(yearString, out dateInt[2]);
            return dateInt;
        }
        /// <summary>
        /// If under 18 years old returns true, if not returns false
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static bool Underage(int age)
        {

            return (age >= 18 ? false : true);
        }
        /// <summary>
        /// If account ballance is negative returns true, if not returns false
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public static bool NegativeBalanceCheck(double balance)
        {
            return (balance >= 0 ? false : true);
        }
    }
}