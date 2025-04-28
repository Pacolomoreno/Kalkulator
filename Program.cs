using System.Collections.Generic;
using System.Globalization;

namespace Kalkulator;

class Program
{
    static void Main(string[] args)
    {
        var K = new Calculator();
        K.ReadOperation();
        K.ReadNumbers();
        K.Compute();

    }
}

public class Calculator
{
    private double Resultado;
    private string? Opera = "+";
    private List<double>? Numbers = new List<double> { };
    public void Suma(double sum1, double sum2)
    {
        Resultado = sum1 + sum2;
    }

    public void Resta(double sum1, double sum2)
    {
        Resultado = sum1 - sum2;
    }

    public void Multiplica(double sum1, double sum2)
    {
        Resultado = sum1 * sum2;
    }

    public void Divide(double sum1, double sum2)
    {
        Resultado = sum1 / sum2;
    }


    public void ReadOperation()
    {
        Boolean ValidInput = false;
        List<string> ValidOpps = new List<string> { "+", "-", "*", "/" };

        // INPUT VALID OPERATION LOOP
        while (!ValidInput)
        {
            Console.Clear();
            Console.WriteLine("Wich operation are you interested in: [ + ] [ - ] [ * ] [ / ]");
            Opera = Console.ReadLine();
            if (ValidOpps.Contains(Opera)) { ValidInput = true; }
            Console.WriteLine($"Operation will be {Opera}");
        }
    }
    public void ReadNumbers()
    {
        Boolean ValidInput = false;
        List<string> ValidChars = new List<string>
         { "0", "1", "2" , "3", "4", "5" , "6", "7", "8" , "9", "-", ",", " "};
        string? input = "";

        // INPUT VALID NUMBERS LOOP
        while (!ValidInput)
        {
            Console.Clear();
            Console.WriteLine("Enter the numbers to operate separated by spaces [ ]");
            input = Console.ReadLine();
            if (input.Length > 0)
            {
                ValidInput = true;
                for (int i = 0; i < input.Length; i++)
                {
                    if (!(ValidChars.Contains(input[i].ToString())))
                    {
                        ValidInput = false;
                        break;
                    }
                }
            }
        }

        Numbers.Clear();
        string[] TempNumbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);  // Split in a array of strings 
        for (int i = 0; i < TempNumbers.Length; i++)
        {
            Numbers.Add(double.Parse(TempNumbers[i])); //parse strings to numbers and add to numbers list
        }
    }

    public void Compute()
    {

        switch (Opera)
        {
            case "+":
                Console.WriteLine($"This will be the Addition of the given values");
                Resultado = 0;
                Console.Write($"{Resultado}");
                foreach (var sumando in Numbers)
                {
                    Console.Write($"+{sumando}");
                    Suma(Resultado, sumando);
                }
                break;
            case "-":
                Console.WriteLine($"This will be the Substraction of the given values");
                Resultado = Numbers.First();
                Numbers.RemoveAt(0);
                Console.Write($"{Resultado}");
                while (Numbers.Any())
                {
                    var substractor = Numbers.First();
                    Numbers.RemoveAt(0);
                    Console.Write($"-{substractor}");
                    Resta(Resultado, substractor);
                }
                break;
            case "*":
                Console.WriteLine($"This will be the Product of the given values");
                Resultado = 1;
                Console.Write($"{Resultado}");
                foreach (var multiplier in Numbers)
                {
                    Console.Write($"*{multiplier}");
                    Multiplica(Resultado, multiplier);
                }
                break;
            case "/":
                Console.WriteLine($"This will be the Division of the given values");
                Resultado = Numbers.First();
                Numbers.RemoveAt(0);
                Console.Write($"{Resultado}");
                while (Numbers.Any())
                {
                    var divisor = Numbers.First();
                    Numbers.RemoveAt(0);
                    Console.Write($"/{divisor}");
                    Divide(Resultado, divisor);
                }
                break;
            default:
                break;
        }
        Console.Write($" = {Resultado}");
    }


}