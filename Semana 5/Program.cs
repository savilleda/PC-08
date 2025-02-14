using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http.Headers;

namespace Actividad2semana5_SebastianVilleda
{
    class Actividad2semana5
    {
        static void Main(string[] args)
        {  
            double a = 0;
            double b = 0;
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
        if (a>b)
    {      
        Console.WriteLine("El valor de a es "+a+" y el valor de b es "+b);
        Console.WriteLine("El valor de verdad es verdadero");
    }
    else if (a==b)
    {
        Console.WriteLine("El valor de a es "+a+" y el valor de b es "+b);
        Console.WriteLine("A y B son iguales");
    }
    else if (a<b)
    {
        Console.WriteLine("El valor de a es "+a+" y el valor de b es "+b);
        Console.WriteLine("El valor de verdad de a es falso");
    }
}
        }
    }