public class NotasAprobadas : Estudiante
{
    public void NotasAprobadasYNoAprobadas()
    {
        Console.Clear();
        Console.WriteLine("En este espacio podra ver las notas aprobadas y no aprobadas por cada alumno");
        for(int i = 0; i< NombresAlumnos.Length; i++)
        {
            Console.WriteLine("Presione enter para ver las notas del estudiante numero "+(i+1));
            for(int x=0; x<NotasAlumnos.GetLength(1); x++)
            {
                if(NotasAlumnos[i,x]>=65)
                {
                    Console.WriteLine("El alumno "+NombresAlumnos[i]+" gano la clase numero "+(x+1)+" con una nota de "+NotasAlumnos[i,x]);
                }else
                {
                    Console.WriteLine("El alumno "+NombresAlumnos[i]+" perdio la clase numero "+(x+1)+" con una nota de "+NotasAlumnos[i,x]);
                }
            }
            Console.WriteLine("Para ver las del siguiente alumno presione enter");
            Console.ReadLine();
            Console.WriteLine("");  
        }
        Console.WriteLine("Presione enter para volver al menu principal");
        Console.ReadLine();
        Console.Clear();
    }
}