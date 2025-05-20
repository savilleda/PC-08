namespace Proyecto;

class Program //Clase main
{
    static void Main(string[] args) //Aquí es donde se llaman a todas las clases y métodos
    {
        Console.WriteLine("======================Battleship=====================================");
        Console.WriteLine("======================Hecho por: Sebastian Villeda :D ==============================");
        Console.WriteLine("Presione enter para continuar");
        Console.ReadLine();
        Console.WriteLine("Bienvenido a battleship jugadores, para hacer esto más interesante deberán colocar un ID para poder llamarlos así");
        // Solicitar nombres de los jugadores
        Console.WriteLine("¿Cuál será tu nombre de usuario jugador 1?");
        string iDjugador1 = Console.ReadLine()?.Trim() ?? "";//El jugador 1 ingresará el nombre con el que quiere ser llamado
        bool confirmacionIDjugador1 = false;
        while (confirmacionIDjugador1==false)
        {

            if (string.IsNullOrWhiteSpace(iDjugador1))//Se verifica que el jugador 1 no ingrese nada, ya que lo fuerza a que escriba algo 
            {
                Console.WriteLine("Nombre no permitido, ingreselo de nuevo, presione enter para ingresarlo nuevamente");
                Console.ReadLine();
                Console.WriteLine("¿Cuál será tu nombre de usuario jugador 1?");
                iDjugador1 = Console.ReadLine()?.Trim() ?? "";
            }
            else
            {
                confirmacionIDjugador1 = true;
            }
        }
        Console.WriteLine("Es el nombre perfecto para un pirata, mucha suerte " + iDjugador1);
        Console.WriteLine("A ver si puedes superar ese user jugador 2, ahora es tu turno de ingresar tu nombre de usuario");
        Console.WriteLine("¿Cuál será tu nombre de usuario jugador 2?");
        string iDjugador2 = Console.ReadLine()?.Trim() ?? "";//Se le solicita al jugador 2 que ingrese un ID
        bool confirmacionIDjugador2 = false;
        while (confirmacionIDjugador2==false)
        {
            if (string.IsNullOrWhiteSpace(iDjugador2))//Se verifica que no presione enter 
            {
                Console.WriteLine("Nombre no permitido, ingreselo de nuevo, presione enter para ingresarlo nuevamente");
                Console.ReadLine();
                Console.WriteLine("¿Cuál será tu nombre de usuario jugador 2");
                iDjugador2 = Console.ReadLine()?.Trim() ?? "";
            }
            else if (iDjugador1 == iDjugador2) //Si el user es el mismo del jugador 1 hace que se lo vuelva a ingresar para que no hayan confusiones
            {
                Console.WriteLine("Nombre no permitido, ingreselo de nuevo, presione enter para ingresarlo nuevamente");
                Console.ReadLine();
                Console.WriteLine("¿Cuál será tu nombre de usuario jugador 2?");
                iDjugador2 = Console.ReadLine()?.Trim() ?? "";
            }
            else
            {
                confirmacionIDjugador2 = true;
            }
        }
        Console.WriteLine("Esooooo, buen ID " + iDjugador2);
        Console.WriteLine("Como ya tienen usuarios asignados, el jugador uno es " + iDjugador1 + " y el jugador es " + iDjugador2 + " ahora con todo eso aclarado");
        Console.WriteLine("Presionen enter para continuar y ver cómo funciona el juego");
        Console.ReadLine();
        Console.Clear();
        string decisionJugador1 = "NO";
        string decisionJugador2 = "NO";
        Jugador funcionamiento = new Jugador(iDjugador1, iDjugador2);
        funcionamiento.FuncionamientoJuego();//Se les muestran las reglas del juego a ambos jugadores para que tengan la idea de como funciona el programa
        Tablero tableroJ1 = new Tablero(iDjugador1, decisionJugador1);
        tableroJ1.GeneracionDeTableroNavalJ1(iDjugador1, decisionJugador1);//Genera el tablero naval del jugador uno y valida que este de acuerdo con el que se le asigno o se lo vuelve a generar
        tableroJ1.GeneracionDeTableroAtaqueJ1(iDjugador1);//Genera el tablero de ataque del jugador 1 y se lo muestra
        Console.WriteLine("Presione enter para que el jugador " + iDjugador2 + " vea sus tableros");
        Console.ReadLine();
        Console.Clear();
        Tablero tableroJ2 = new Tablero(iDjugador2, decisionJugador2);
        tableroJ2.GeneracionDeTableroNavalJ2(iDjugador2, decisionJugador2);//se repite el proceso con el jugador 2 sobre la generación de tableros
        tableroJ2.GeneracionDeTableroAtaqueJ2(iDjugador2);//Igual con el jugador 2, se le muestra su tablero de ataque
        Console.Clear();
        Console.WriteLine("Se viene una masacre!!!!!!!!!!!!!!!");
        Mecanismo mecanismo = new Mecanismo(tableroJ1, tableroJ2);
        mecanismo.Ataque(iDjugador1, iDjugador2);//Les muestra el juego y hace que empiece la partida
        mecanismo.Resultados(iDjugador1,iDjugador2);//Desplega los resultados obtenidos
        Console.WriteLine("Gracias por jugar");//Fin del programa y agradecimiento por jugar :D
    }
}
