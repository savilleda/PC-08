
public class Jugador
{
  //Atributos
    public string jugador1 { get; set; }//Nombre del jugador 1
    public string jugador2 {get; set;}//Nombre del jugador 2

    public Jugador(string jugador1, string jugador2)//Constructor que inicializa los objetos jugador 1 y jugador 2
    {
        this.jugador1= jugador1;
        this.jugador2= jugador2;
    }
    public void FuncionamientoJuego()//En este método se desplegan las instrucciones del juego para que los jugadores lo entiendan perfectamente
    {
      Console.WriteLine("Bueno pues, capitan "+this.jugador1+" y capitan "+this.jugador2+". A continuación les mostrare el funcionamiento del juego");
      Console.WriteLine("Se les presentara un tablero naval y uno de ataque, el naval les mostrará 3 barcos, los cuales son: ");
      Console.WriteLine("1. Submarino y ocupa 2 casillas, su símbolo es una S de color magenta y da 2pts al rival tras ser derribado");
      Console.WriteLine("2. Fragata y ocupa 3 casillas, además su símbolo es una F de color verde y da 3pts al rival tras ser derribado");
      Console.WriteLine("3. Destructor y ocupa 4 casillas, además su símbolo es una D de color rojo oscuro y da 4pts al rival tras ser derribado");
      Console.WriteLine("En el tablero naval, se verán reflejados los ataques del rival, si le dio a tu barco sera reemplazado con una X y si le dio al agua con un O");
      Console.WriteLine("En el tablero ataque podrás ver las coordenadas donde has atacado, así podrás plantear una mejor estrategia");
      Console.WriteLine("A su vez en el tablero ataque hay 3 símbolos, el primero es ~, el cual representa el agua y donde no se ha probado tirar");
      Console.WriteLine("El segundo símbolo es la X y este indica que hubo un disparo fallido");
      Console.WriteLine("Y el último símbolo es el O el cual simboliza que le diste a uno de los barcos");
      Console.WriteLine("Bueno, esos es todo lo que tienen que saber de los barcos ahora les contaré sobre más cosas del juego");
      Console.WriteLine("La posición de los barcos de se genera de manera automática, quiere decir que ustedes no los ponen donde quieren, pero si no están conformes con la posición pueden decir que la genere de nuevo");
      Console.WriteLine("Para atacar tendrán que poner una coordenada de la A-F y del 1-6");
      Console.WriteLine("Bueno ahora que conocen como funciona el juego comenzemos");
      Console.WriteLine("Presionen enter para continuar");
      Console.ReadLine();
      Console.Clear();  
    }
}