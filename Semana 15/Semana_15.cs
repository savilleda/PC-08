namespace Semana15_PC{
    //Sebastian Villeda Carné: 1032625
public class Estudiante //Clase Estudiante, la cual tiene instancia nombre, edad, carrera, carnet y nota admisión
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Carrera { get; set; }
    public string Carnet { get; set; }
    public int NotaAdmision { get; set; }                                                                                                                            
    public static void Main() //Este método main llama los otros métodos para mostrar el resumen de los datos del estudiante y si se puede matricular el estudiante o no
    {
        Estudiante objetoProgram = new Estudiante();
        Console.WriteLine("Presione enter para mostrar todos los datos");
        Console.ReadLine();
        objetoProgram.MostrarResumen(); //Esto muestra el método mostrar resumen con los datos de la clase y hace uso de las variables locales
        Console.WriteLine("Presione enter para ver si se puede matricular o no");
        Console.ReadLine();
        objetoProgram.PuedeMatricular(); //Esto muestre el método puede matricular e indica si el estudiante se puede matricular o no
    }
    Estudiante() // Es un constructor en el cual se utilizan las variables globales y se les da un valor
    {
        while(true)// Esto permite que si un valor no es ingresado correctamente, se tendrá que volver a intentar hasta conseguirlo 
        {
        try{//Busca errores como formatexcepcion
        Console.WriteLine("Ingrese su nombre: ");
        this.Nombre = Console.ReadLine() ?? "";
        Console.WriteLine("");
        Console.WriteLine("Ingrese su edad: ");
        this.Edad = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        Console.WriteLine("Ingrese su carrera: ");
        this.Carrera = Console.ReadLine() ?? "";
        Console.WriteLine("");
        Console.WriteLine("Ingrese su carnet: ");
        this.Carnet = Console.ReadLine() ?? "";
        int cantidadDeDigitos = this.Carnet.Length;
        while(cantidadDeDigitos !=9) //Si el número de carnet no tiene 9 dígitos hace que se tenga que ingresar nuevamente el valor
        {
            Console.WriteLine("Valor incorrecto, presione enter para ingresar el carnet nuevamente");
            Console.ReadLine();
            Console.WriteLine("Ingrese el valor nuevamente");
            this.Carnet = Console.ReadLine() ?? "";
            cantidadDeDigitos = this.Carnet.Length;
        }
        Console.WriteLine("");
        Console.WriteLine("Ingrese su nota de admisión: ");
        this.NotaAdmision = Convert.ToInt32(Console.ReadLine());
        while(this.NotaAdmision>100)//Si la nota de admision que colocó fue mayor a 100 tiene que colocar el valor nuevamente
        {
            Console.WriteLine("Valor incorrecto, presione enter para ingresarlo nuevamente");
            Console.ReadLine();
            Console.WriteLine("Ingrese el valor nuevamente");
            this.NotaAdmision = Convert.ToInt32(Console.ReadLine());
        }
        break;
        }catch(FormatException)
        {
            Console.WriteLine("Valor no permitido, por favor ingresarlo nuevamente y presione enter para continuar");
            Console.ReadLine();
            Console.Clear();    
        }
        }
    } 
    public void MostrarResumen()//Muestra los datos y las variables las llama haciendo uso del this, ya que el this permite utilizar los objetos
    {
        Console.WriteLine("Su nombre es: " + this.Nombre);
        Console.WriteLine("");
        Console.WriteLine("Su edad es: " + this.Edad);
        Console.WriteLine("");
        Console.WriteLine("Su carrera es: " + this.Carrera);
        Console.WriteLine("");
        Console.WriteLine("Su carnet es: " + this.Carnet);
        Console.WriteLine("");
        Console.WriteLine("Su nota de admisión fue de: " + this.NotaAdmision);
    }
    public void PuedeMatricular()//Muestra si se puede matricualar o no 
    {
        if(this.NotaAdmision >=75 && this.Carnet.EndsWith("2025"))
        {
            Console.WriteLine("Si cumple con las condiciones, por lo que puede matricularse");
        }else
        {
            Console.WriteLine("No cumple con las condiciones, por lo que no puede matricularse");
        }  
    }
}
}