using System.Runtime.CompilerServices;

namespace Semana_18;

public class Program
{
    static void Main(string[] args)
    {
        Estudiante estudiantes = new Estudiante ();
        Console.WriteLine("En este programa podra observar las notas de 10 estudiantes, también podrá ver sus notas aprobadas, las no aprobadas y el promedio del grupo");
        Console.WriteLine("Comenzemos ingresando los nombres y notas de los estuidantes");
        Console.WriteLine("Presione enter para ingresarlos");
        Console.ReadLine();
        Console.Clear();
        estudiantes.NombresYNotas();
        Console.WriteLine("Como ya ingresaste los valores es hora de ver las otras opciones del programa, presiona el numero que dice cada opcion para ingresar a ella");
        NotasAprobadas notasAprobadas = new NotasAprobadas();
        Promedio promedio = new Promedio();
        bool finalizarPrograma = false;
        while(finalizarPrograma==false)
        {
        try{
            Console.WriteLine("Opciones: ");
            Console.WriteLine("1 - Mostrar notas y estudiantes");
            Console.WriteLine("2 - Notas aprobadas por estudiante y notas no aprobadas");
            Console.WriteLine("3 - Promedio de notas");
            Console.WriteLine("4 - Salir del programa");
            int decisicion = Convert.ToInt16(Console.ReadLine());
            switch(decisicion)
            {
                case 1:
                    estudiantes.MostrarNotas();
                break;
                case 2:
                    notasAprobadas.NotasAprobadasYNoAprobadas();
                break;
                case 3:
                    promedio.MostrarPromedio();
                break;
                case 4:
                    Console.WriteLine("Gracias por utilizar el programa, vuelva pronto :D");
                    finalizarPrograma = true;
                break;
                default:
                Console.WriteLine("Error, comando no válido");
                Console.WriteLine("Presione enter para volver a intentar");
                Console.ReadLine();
                Console.Clear();
                break;
            }   
            }catch(FormatException)
            {
              Console.WriteLine("Error, comando no válido");
              Console.WriteLine("Presione enter para volver a intentar");
              Console.ReadLine();
              Console.Clear();  
            }
        }
    }
}
