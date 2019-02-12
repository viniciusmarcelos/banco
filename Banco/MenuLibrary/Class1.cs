using System;
using ArrayLibrary;

namespace MenuLibrary
{
    public class MenuLib
    {
        public static void PrintMenu(string[] array, string headline) //prints a Menu, options are: 1, 2, 3 .. and the last is 0 - Exit
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
        public static void PrintMessage(string message) //prints the message
        {
            Console.WriteLine(message);
        }
        public static string ReadOption(string[] options, string message) //prints a message then reads the option chosen, checks if it's valid, loops if not, returns the TEXT of the option
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
        public static string ReadOption(string[] options) //sends default message to ReadOption
        {
            return ReadOption(options, "Digite a opção desejada:");
        }
        public static double ReadMoneyValue(string message) // prints a message then reads value and checks if it's a double, loops if not, returns the double
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
        public static double ReadMoneyValue() //sends default message to ReadMoneyValue
        {
            return ReadMoneyValue("Digite o valor:");
        }
        public static string ReadStringValue(string message) // prints a message then reads value and returns the string
        {
            PrintMessage(message);
            return Console.ReadLine();
        }
        public static string ReadStringValue() //sends default message to ReadStringValue
        {
            return ReadStringValue("Digite o valor:");
        }
        public static string ThAdder(int position) //adds the correct sulfix to positions, as following: 0"", 1"st", 2"nd", 3"rd", 4"th", 5"th" ... and -1"not found"
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
        public static void PrintAddingSpaces(string imput) //P R I N T S  L I K E  T H I S
        {
            for (int i = 0; i < imput.Length; i++)
            {
                Console.Write("{0}{1}", imput[i], i < imput.Length - 1 ? " " : "\n");
            }
        }
        public class Clients
        {
            public static void CPFAdder(string[,] clients, int clientIndex) //adds the CPF of the position i
            {
                string message = "Digite o CPF do Cliente:";
                while (true)
                {
                    string cpf = ReadStringValue(message);
                    if (!Verifications.CPFCheck(clients, cpf))  //validates CPF
                    {
                        message = "CPF inválido. Digite no formato 000.000.000-00 :)";
                    }
                    else
                    {
                        clients[clientIndex, 0] = cpf;
                    }
                }
            }
            public static void NameAdder(string[,] clients, int clientIndex) //adds the CPF of the position i
            {
                clients[clientIndex, 0] = ReadStringValue("Digite o nome do Cliente:");
            }
            public static void BirthDateAdder(string[,] clients, int clientIndex) //adds the CPF of the position i
            {
                clients[clientIndex, 0] = ReadStringValue("Digite o nome do Cliente:");
            }
        }
    }
    public class Verifications
    {
        public static bool CPFCheck(string[,] clients, string cpf)
        {
            if (ArrayLib.Find_Ordinary(clients, cpf, 0) == -1)
            {
                return true;
            }
            else return false; //make it check according to https://www.geradorcpf.com/algoritmo_do_cpf.htm 
        }
        public static bool TwoDecimalsCheck(double value)
        {
            return true; //make check if there are not more than 2 decimal places
        }
        public static bool Underage(int age) //if under 18 years old returns true, if not returns false
        {
            return (age >= 18 ? false : true);
        }
        public static bool NegativeBalanceCheck(double balance) //if account ballance is negative returns true, if not returns false
        {
            return (balance >= 0 ? false : true);
        }
    }
}
