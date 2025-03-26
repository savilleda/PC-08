namespace JuegoDeAventura
{
    class Program
    {
        // Variables globales
        static string idJugador;
        static string aventureros;
        static string mapa;
        static int vida;
        static int ataque;
        static string menu = ""; // Inicializamos con un valor predeterminado
        static int enemigosDerrotados = 0;
        static Random cofre = new Random();

        static void Main()
        {
            IniciarAventura();
            Console.Clear();

            while (menu != "rendirse") // Continuar mientras el jugador no se rinda
            {
                SeleccionMapa();
                MenuJuego();

                if (menu == "rendirse")
                {
                    Console.WriteLine("Gracias por jugar. ¡Hasta la próxima!");
                    break;
                }
            }
        }

        static int IniciarAventura()
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
            idJugador = Console.ReadLine()??"";
            Console.WriteLine($"¡Bien! mucho gusto {idJugador}. Vaya nombre eh.");
            Console.ReadLine();
            Console.WriteLine("Ahora tienes que elegir que tipo de poderes quieres, este será un regalito de tu humilde servidor.");
            Console.WriteLine("\n (1) Mago: 100 puntos de vida y 20 puntos de ataque.");
            Console.WriteLine("\n (2) Caballero: 70 puntos de vida y 30 puntos de ataque.");
            Console.WriteLine("\n (3) Arquera: 85 puntos de vida y 25 puntos de ataque.");

            while (true)
            {
                string opcion = Console.ReadLine() ?? "";
                if (int.TryParse(opcion, out int aventurero))
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

                        default:
                            Console.WriteLine("Elige una opción válida (1, 2 o 3).");
                            continue;
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

        static string SeleccionMapa()
        {
            Console.WriteLine($"Ahora eres el/la {aventureros} {idJugador}");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("¡Muy bien! verás, este camino se divide en otros tres caminos, deberás superarlos.");
            Console.WriteLine("Cuando ganes tres batallas encontrarás el camino de regreso y habrás ganado.\nAdemás, después de cada combate tendrás la opción de abrir un cofre, tu decides si lo tomas o lo dejas...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Por último, considera que cada camino tiene sus propias características. Bien, ahora te los muestro: ");
            Console.ReadLine();
            Console.WriteLine("\n\n===== CAMINOS A ESCOGER ===== ");
            Console.WriteLine("(1) Bosque oscuro (Se pueden hallar tesoros sorprendentes o caer en trampas)");
            Console.WriteLine("(2) Cueva sombría (Posibilidad de encontrar enemigos sigilosos. En este mapa los enemigos golpean primero)");
            Console.WriteLine("(3) Camino de piedra (Es menos peligroso, pero con escasos recursos. Los cofres tienen un 25% de probabilidad de estar vacíos.)");

            while (true)
            {
                string opcionMapa = Console.ReadLine() ?? "";
                if (int.TryParse(opcionMapa, out int mapaSeleccion))
                {
                    switch (mapaSeleccion)
                    {
                        case 1:
                            mapa = "Bosque oscuro.";
                            break;

                        case 2:
                            mapa = "Cueva Sombría.";
                            break;

                        case 3:
                            mapa = "Camino de piedra.";
                            break;

                        default:
                            Console.WriteLine("Elige una opción válida (1, 2 o 3).");
                            continue;
                    }
                    return mapa;
                }
                else
                {
                    Console.WriteLine($"Elige un mapa. No te preocupes {idJugador}, confía en tu grandioso Gandalf el Gris, todo estará bien.");
                }
            }
        }

        static string MenuJuego()
        {
            while (vida > 0 && enemigosDerrotados < 3)
            {
                Console.WriteLine("\t\t\t===MENU PRINCIPAL DEL AVENTURERO===");
                Console.WriteLine($"El camino que elegiste fue: {mapa}");
                Console.WriteLine($"Tu tienes los poderes de un/a {aventureros}");
                Console.WriteLine($"Tus puntos de vida son: {vida}");
                Console.WriteLine($"Tu poder de ataque es de: {ataque}");
                Console.WriteLine($"Has derrotado a: {enemigosDerrotados}");
                Console.WriteLine("\n\n¿Qué deseas hacer?");
                Console.WriteLine("\n (1) Continuar la aventura.");
                Console.WriteLine("\n (2) Rendirte.");
                string decisionContinuacion = Console.ReadLine() ?? "";
                if (int.TryParse(decisionContinuacion, out int decision))
                {
                    switch (decision)
                    {
                        case 1:
                            Console.WriteLine("¡Vamos a la batalla!");
                            menu = "continuar";
                            break;

                        case 2:
                            Console.WriteLine("No me cabe duda del gran aventurero que eres... pero será a la próxima.");
                            Console.WriteLine("¡GAME OVER!");
                            menu = "rendirse";
                            return menu;
                    }
                }
                else
                {
                    Console.WriteLine("Elige una opción válida.");
                }
            }

            return menu;
        }
    }
}