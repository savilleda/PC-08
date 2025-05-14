using System.Security.Cryptography.X509Certificates;

public class Estudiante
{
    public static string[] NombresAlumnos = new string[10];
    public static int[,] NotasAlumnos = new int[10, 10];
    public string Alumnos {get; set;}
    public int Notas{get; set;}

    public Estudiante()
    {
        this.Alumnos = Alumnos ?? "";
        this.Notas = Notas;
    }

    public void NombresYNotas()
    {
        for(int i=0; i<NombresAlumnos.Length; i++)
        {
            bool nombrePermitido = false;
            do{
            Console.WriteLine("Hola estudiante numero "+(i+1));
            Console.WriteLine("Por favor ingresa tu nombre para poder registrarlo");
           this.Alumnos = Console.ReadLine() ??"";
           if(string.IsNullOrWhiteSpace(this.Alumnos))
           {
            Console.WriteLine("Error al registrar el nombre, presione enter para hacerlo nuevamente");
            Console.ReadLine();
            Console.Clear();
           }else{
            NombresAlumnos[i]= this.Alumnos;
            nombrePermitido =true;
           }
            }while(nombrePermitido==false);
            for(int x=0; x<NotasAlumnos.GetLength(1); x++)
            {
                bool notaPermitida = false;
                while (notaPermitida==false)
                {
                    try{
                    Console.WriteLine("Ahora ingresa las notas por favor, las notas deben ser en un rango de 0-100");
                    Console.WriteLine("Ingresa la nota numero "+(x+1));
                    this.Notas = Convert.ToInt32(Console.ReadLine());
                    if(this.Notas >= 0 && this.Notas<=100)
                    {
                        NotasAlumnos[i,x] = this.Notas;
                        notaPermitida = true;
                    }else
                    {
                        Console.WriteLine("Vuelva a ingresar la nota nuevamente");
                        Console.WriteLine("Presione enter para volver a intentar");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    }catch(FormatException){
                        Console.WriteLine("Vuelva a ingresar la nota nuevamente");
                        Console.WriteLine("Presione enter para volver a intentar");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }
        }
        Console.WriteLine("Nombres y notas registradas correctamente");
    }

    public void MostrarNotas()
    {
        Console.Clear();
        Console.WriteLine("Bienvenido, en este lugar podrás ver todas las notas y todos los nombres");
        for(int i=0; i<NombresAlumnos.Length; i++)
        {
            Console.WriteLine("El alumno numero "+(i+1)+" es: "+NombresAlumnos[i]);
            for(int x=0; x<NotasAlumnos.GetLength(1);x++)
            {
                Console.WriteLine("La nota numero "+(x+1)+" del alumno "+NombresAlumnos[i]+" es "+NotasAlumnos[i,x]);
            }
            Console.WriteLine("Para ver las del siguiente alumno presione enter");
            Console.ReadLine();
            Console.WriteLine("");
        }
        Console.WriteLine("Esas fueron las notas gracias por consultarlas");
        Console.WriteLine("Presione enter para volver al menu principal");
        Console.ReadLine();
        Console.Clear();
    }   
}