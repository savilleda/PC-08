using System; 

namespace JuegoDeAventura
{
    class Program
    {
        //Variables globales
        static string idJugador;
        static string aventureros; 
        static int mapa;
        static int vida; 
        static int ataque;
        static int enemigosDerrotados = 0;
        Random cofre = new Random();

        static void Main() 
        {
            IniciarAventura();
            Console.ReadLine();
            Console.Clear();
            while (true)
            {
                
                break;
            }
        } 

        //Método que ejecuta el inicio del juego.
        static int IniciarAventura ()
        {
            Console.WriteLine("\t\t\t===============================\t\t");
            Console.WriteLine("\t\t\t\tJUEGO DE AVENTURA\t\t\t\t");
            Console.WriteLine("\t\t\t===============================\t\t");
            Console.WriteLine("\n\t\tCreado por:\t Ing. Sebastian Villeda - 1032625\n\t\t\t\t Ing. Marco Donadio - 1076925");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("¿¡QUÉEEEEE!?..... Hola aventurero, vaya, hace tiempo que no venía nadie por estos rumbos.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Mi nombre es.... eeeeeeee... Gandalf el Gris (o eso creo); pero bueno, eso no es imporante.");
            Console.ReadLine();
            Console.Clear();
            Console.Write("Estas a punto de entrar en una aventura sin igual, veo en ti un aura poderosa, estoy seguro que estarás bien.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Ya mucho de mí, mejor dime, ¿cuál es tu nombre?");
            Console.WriteLine("Ingresa tu nombre a continuación: ");
            idJugador = Console.ReadLine();
            Console.WriteLine($"¡Bien! mucho gusto {idJugador}. Vaya nombre eh.");
            Console.ReadLine();
            Console.WriteLine("Ahora tienes que elegir que tipo de poderes quieres, este será un regalito de tu humilde servidor.");
            Console.WriteLine("\n (1) Mago: 100 puntos de vida y 20 puntos de ataque.");
            Console.WriteLine("\n (2) Caballero: 70 puntos de vida y 30 puntos de ataque.");
            Console.WriteLine("\n (3) Arquera: 85 puntos de vida y 25 puntos de ataque.");
        
            while (true)
            {
                string opcion=Console.ReadLine();
                if(int.TryParse(opcion, out int aventurero))
                {
                    switch (aventurero)
                    {
                        case 1: 
                        aventureros = "Mago";
                        vida = 100;
                        ataque = 20;
                        break; 

                        case 2: 
                        aventureros = "Caballero";
                        vida = 70; 
                        ataque = 30; 
                        break; 

                        case 3: 
                        aventureros = "Arquera";
                        vida = 85; 
                        ataque = 25;
                        break;


                    }
                    return aventurero;
                }

                else 
                {
                    Console.WriteLine("Elige el tipo de poder que deseas.");
                    Console.WriteLine("Te aseguro que las opciones que te doy te llevarán a la victoria");
                }
            } 
                
        }


    }
}