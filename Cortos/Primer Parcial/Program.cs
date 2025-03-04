using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http.Headers;

namespace Parcial_SebastianVilleda
{
    class Parcial
    {
        static void Main(string[] args)
        {  
            double A = 0;
            double B = 0;
            double C = 0;
            A = double.Parse(Console.ReadLine());
            B = double.Parse(Console.ReadLine());
            C = double.Parse(Console.ReadLine());
            Console.WriteLine("El valor de A es "+A+" el valor de B es "+B+" y el valor de es "+C);
        if (A==0 && B==0 && C==0)
    {
        Console.WriteLine("Ingresar valores nuevamente");
    }
    else if (A==B)
    {
        Console.WriteLine("Ingresar valores nuevamente");
    }
        else if (A==C)
    {
        Console.WriteLine("Ingresar valores nuevamente");
    }
        else if (C==B)
    {
        Console.WriteLine("Ingresar valores nuevamente");
    }
        else if (A>B && B>C)
    {
        Console.WriteLine("El numero mas grande es A y el menor C");
    }
        else if (C>B && B>A)
    {
        Console.WriteLine("El numero mas grande es C y el menor A");
    }
        else if (B>A && B>C)
    {
        Console.WriteLine("El numero mas grande es B y el menor C");
    }
        else if (B>C && C>A)
    {
        Console.WriteLine("El numero mas grande es B y el menor A");
        
    }
        else if (A>C && C>B)
    {
        Console.WriteLine("El numero mas grande es A y el menor B");
    }
        else if (C>A && A>B)
    {
        Console.WriteLine("El numero mas grande es C y el menor B");
    }
        }
    }
}