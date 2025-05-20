public class Promedio:Estudiante
{
    public void MostrarPromedio()
    {
        Console.Clear();
        Console.WriteLine("En este espacio podra ver el promedio de notas del grupo");
        int sumaDeNotas =0;
        for(int i = 0; i< NotasAlumnos.GetLength(0); i++)
        {
            for(int x=0; x<NotasAlumnos.GetLength(1); x++)
            {
                sumaDeNotas+=NotasAlumnos[i,x];
            }
        }
        int numeroNotas = NotasAlumnos.GetLength(0)*NotasAlumnos.GetLength(1);
        double promedio = sumaDeNotas/numeroNotas;
        Console.WriteLine("El promedio de grupo es: "+promedio);
        Console.WriteLine("");
        Console.WriteLine("Presione enter para volver al menu principal");
        Console.ReadLine();
        Console.Clear();
    }
}