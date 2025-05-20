public class Tablero
{
    public string[,] tableroNavalJugador1 { get; protected set; } = new string[6, 6];//Crea una matriz 6x6 y el es protected para que solo las clases heredadas lo puedan editar 
    public string[,] tableroNavalJugador2 { get; protected set; } = new string[6, 6];//Crea una matriz 6x6 y el es protected para que solo las clases heredadas lo puedan editar 
    public string[,] tableroAtaqueJugador1 { get; protected set; } = new string[6, 6];//Crea una matriz 6x6 y el es protected para que solo las clases heredadas lo puedan editar 
    public string[,] tableroAtaqueJugador2 { get; protected set; } = new string[6, 6];//Crea una matriz 6x6 y el es protected para que solo las clases heredadas lo puedan editar 
    public char[] letrasFilas = { 'A', 'B', 'C', 'D', 'E', 'F' }; //Es una arreglo unidimensional tipo char para desplegar las letras en el tablero como lo requiere el enunciado del proyecto
    public string confirmaciónBarcosJ1 { get; set; } //Confirmación de los barcos del j1
    public string confirmaciónBarcosJ2 { get; set; } //Confirmación de los barcos del j2

    public Tablero(string confirmaciónBarcosJ1, string confirmaciónBarcosJ2) //Crea los objetos confirmaciónBarcosJ1 y confirmaciónBarcosJ2
    {
        this.confirmaciónBarcosJ1 = confirmaciónBarcosJ1;
        this.confirmaciónBarcosJ2 = confirmaciónBarcosJ2;
    }

    public void GeneracionDeTableroNavalJ1(string jugador1, string confirmaciónBarcosJ1) //Aquí se genera el tablero naval del j1 y utiliza los parametros de confirmación del j1 y su id
    {
        Console.WriteLine("Bienvenido " + jugador1 + " aqui se generaran tus barcos, si no estas conforme con el resultado puedes decir que no para volver a generarlo aleatoriamente");
        Console.WriteLine("Presiona enter para continuar");
        Console.ReadLine();
        Console.Clear();
        do// El do permite que siempre se rellene la matriz con agua y que se generen los barcos aunque sea una vez
        {
            for (int columnas = 0; columnas < tableroNavalJugador1.GetLength(0); columnas++)
            {
                for (int filas = 0; filas < tableroNavalJugador1.GetLength(1); filas++)//Se rellena cada espacio de la matriz con agua, columna por columna y fila por fila
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    tableroNavalJugador1[columnas, filas] = "■";
                }
            }
            Random numeroRandom = new Random();//Con este random se generan las posiciones y filas en donde irán los barcos
            bool submarinoColocado = false;
            while (!submarinoColocado)//Aquí se generan los submarinos y estos solo pueden estar posicionados horizontalmente
            {
                int columna = numeroRandom.Next(0, 6); //Puede ocupar todos los espacios de las columnas 
                int fila = numeroRandom.Next(0, 5);//No puede ocupar todos los espacios de las filas, ya que si se genera en la posición 6 no podrá generar uno de más y ocurrira un eror de límite en la matriz
                if (tableroNavalJugador1[columna, fila] == "■" && tableroNavalJugador1[columna, fila + 1] == "■")//Detecta si hay agua para ver si se pueden ubicar las 2 partes del submarino
                {
                    tableroNavalJugador1[columna, fila] = "S"; //En las posiciones de las filas y columnas que se generaron con el random se colocará una S
                    tableroNavalJugador1[columna, fila + 1] = "S"; //Lo mismo en esta posición
                    submarinoColocado = true;//Cuando se hayan generado correctamente se acaba el ciclo que hace que se generen
                }
            }
            bool fragataColocada = false;
            while (!fragataColocada)//Aquí se generan las fragatas y estas solo pueden estar verticalmente
            {
                int columna = numeroRandom.Next(0, 4);//No puede ocupar todas las columnas ya que si se genera luego de la posición 4 por ejemplo en la 5 va a ocurrir un error porque supero los límetes del rango de la matriz
                int fila = numeroRandom.Next(0, 6);//Puede ocupar todas las filas
                if (tableroNavalJugador1[columna, fila] == "■" && tableroNavalJugador1[columna + 1, fila] == "■" && tableroNavalJugador1[columna + 2, fila] == "■")//Detecta si hay agua para ver si se pueden ubicar las 3 partes de la fragata
                {
                    tableroNavalJugador1[columna, fila] = "F"; //En las posiciones de las filas y columnas que se generaron con el random se colocará una F
                    tableroNavalJugador1[columna + 1, fila] = "F";//Lo mismo en las otras 2 posiciones
                    tableroNavalJugador1[columna + 2, fila] = "F";
                    fragataColocada = true;//Cuando se hayan generado correctamente se acaba el ciclo que hace que se generen
                }
            }
            bool destructorColocado = false;
            while (!destructorColocado)//En esta parte se generan los destructores los cuáles pueden estar ubicados de manera horizontal o vertical
            {
                bool posiconDestructorHoV = numeroRandom.Next(0, 2) == 0;//Para decir en que posición se usara, se utiliza un random el cuál genera un número entre 0 y 1, si es 0 el valor es true y el barco se genera de manera horizontal y si es 1 de manera vertical
                if (posiconDestructorHoV)//Verifica el valor, si fue 0 significa que tiene un valor de true y si fue 1 un valor de false
                {
                    int columna = numeroRandom.Next(0, 6);//Como el destructor está acostado puede utilizar todas las columnas
                    int fila = numeroRandom.Next(0, 3);//No se puede generar en la posición 3 ya que ocupa 4 espacios y eso provocaría un error en el límite de la matriz
                    if (tableroNavalJugador1[columna, fila] == "■" && tableroNavalJugador1[columna, fila + 1] == "■" && tableroNavalJugador1[columna, fila + 2] == "■" && tableroNavalJugador1[columna, fila + 3] == "■")//Detecta si hay agua para ver si se pueden ubicar las 4 partes del destructor
                    {
                        tableroNavalJugador1[columna, fila] = "D";  //En las posiciones de las filas y columnas que se generaron con el random se colocará una D
                        tableroNavalJugador1[columna, fila + 1] = "D";//Lo mismo ocurre en las otras 3 posiciones
                        tableroNavalJugador1[columna, fila + 2] = "D";
                        tableroNavalJugador1[columna, fila + 3] = "D";
                        destructorColocado = true;//Cuando se hayan generado correctamente se acaba el ciclo que hace que se generen
                    }
                }
                else
                {
                    int columna = numeroRandom.Next(0, 3);//No puede ocupar todas las columnas ya que si se genera luego de la posición 2 por ejemplo en la 5 va a ocurrir un error porque supero los límetes del rango de la matriz
                    int fila = numeroRandom.Next(0, 6);//Como solo utiliza una fila, no importa en que fila se genere 
                    if (tableroNavalJugador1[columna, fila] == "■" && tableroNavalJugador1[columna + 1, fila] == "■" && tableroNavalJugador1[columna + 2, fila] == "■" && tableroNavalJugador1[columna + 3, fila] == "■")
                    {
                        tableroNavalJugador1[columna, fila] = "D";//En las posiciones de las filas y columnas que se generaron con el random se colocará una D
                        tableroNavalJugador1[columna + 1, fila] = "D";//Lo mismo ocurre en las otras 3 posiciones
                        tableroNavalJugador1[columna + 2, fila] = "D";
                        tableroNavalJugador1[columna + 3, fila] = "D";
                        destructorColocado = true;//Cuando se hayan generado correctamente se acaba el ciclo que hace que se generen
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tablero Naval de " + jugador1); //Le muestra el tablero naval al jugador 1
            Console.WriteLine(" 1  2  3  4  5  6");
            for (int columnas = 0; columnas < tableroNavalJugador1.GetLength(0); columnas++)
            {
                Console.Write(letrasFilas[columnas] + " "); //Escribe el arreglo de char con las letrar al inicio, ya que así queda como lo muestra el tablero del requerimiento
                for (int filas = 0; filas < tableroNavalJugador1.GetLength(1); filas++)
                {
                    switch (tableroNavalJugador1[columnas, filas])
                    {
                        case "S":
                            Console.ForegroundColor = ConsoleColor.DarkMagenta; // Por cada S del submarino se le asigna un color magenta oscuro
                            break;
                        case "F":
                            Console.ForegroundColor = ConsoleColor.Green; // Por cada F de la fragata se le asigna un color verde
                            break;
                        case "D":
                            Console.ForegroundColor = ConsoleColor.DarkRed; // Por cada D del destructor se le asigna un color rojo oscuro
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Blue; //Si no se detecta ninguna letra o sea los cuadraditos, serán de color azul del agua
                            break;
                    }
                    Console.Write(tableroNavalJugador1[columnas, filas] + " "); //Deja espacio entre cada letra y cuadrito
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                Console.ResetColor();
            }
            Console.WriteLine("Te parecen bien el tablero así como esta? (SI/NO)"); //Corrobora que el jugador escriba si o no para saber que opina del tablero generado, si no está de acuerdo lo vuelve a generar y si lo está deja ese
            confirmaciónBarcosJ1 = Console.ReadLine()?.ToUpper().Trim() ?? "";
            bool respuestaJ1 = false;
            while (!respuestaJ1)//Verifica que el jugador solo escriba si o no
            {
                if (confirmaciónBarcosJ1 == "SI" || confirmaciónBarcosJ1 == "NO")
                {
                    respuestaJ1 = true;
                }
                else
                {
                    Console.WriteLine("Escriba solo SI O NO"); 
                    confirmaciónBarcosJ1 = Console.ReadLine()?.ToUpper().Trim() ?? "";
                }
            }
        } while (confirmaciónBarcosJ1 != "SI"); //Si el jugador esta de acuerdo con su tablero se deja de generar el tablero naval y le deja con el que esta de acuerdo
    }
    public void GeneracionDeTableroAtaqueJ1(string jugador1) //Genera su tablero de ataque
    {
        Console.WriteLine("A continuación se generará tu tablero de ataque, presiona enter para ver tu tablero de ataque");
        Console.ReadLine();
        for (int columnas = 0; columnas < tableroAtaqueJugador1.GetLength(0); columnas++)
        {
            for (int filas = 0; filas < tableroAtaqueJugador1.GetLength(1); filas++)
            {
                tableroAtaqueJugador1[columnas, filas] = "~"; //Escribe fila por fila en cada columna ese simbolo que representa el agua ya que no ha realizo ataques
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Tablero Ataque de " + jugador1); //Le muestra su tablero de ataque al jugador 2
        Console.WriteLine(" 1 2 3 4 5 6");
        for (int columnas = 0; columnas < tableroAtaqueJugador1.GetLength(0); columnas++)
        {
            Console.Write(letrasFilas[columnas] + " ");
            for (int filas = 0; filas < tableroAtaqueJugador1.GetLength(1); filas++)
            {
                Console.Write(tableroAtaqueJugador1[columnas, filas] + " ");
            }
            Console.WriteLine();
        }
    }
    //Todo el proceso de arriba vuelve a ocurrir pero con el jugador 2
    public void GeneracionDeTableroNavalJ2(string jugador2, string confirmaciónBarcosJ2)
    {
        Console.WriteLine("Bienvenido " + jugador2 + " aquí se generarán tus barcos, si no estás conforme con el resultado puedes decir que no para volver a generarlo aleatoriamente");
        Console.WriteLine("Presiona enter para continuar");
        Console.ReadLine();
        Console.Clear();
        do
        {
            for (int columnas = 0; columnas < tableroNavalJugador2.GetLength(0); columnas++)
            {
                for (int filas = 0; filas < tableroNavalJugador2.GetLength(1); filas++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    tableroNavalJugador2[columnas, filas] = "■";
                }
            }

            Random numeroRandom = new Random();
            bool submarinoColocado = false;
            while (!submarinoColocado)
            {
                int columna = numeroRandom.Next(0, 6);
                int fila = numeroRandom.Next(0, 5);
                if (tableroNavalJugador2[columna, fila] == "■" && tableroNavalJugador2[columna, fila + 1] == "■")
                {
                    tableroNavalJugador2[columna, fila] = "S";
                    tableroNavalJugador2[columna, fila + 1] = "S";
                    submarinoColocado = true;
                }
            }

            bool fragataColocada = false;
            while (!fragataColocada)
            {
                int columna = numeroRandom.Next(0, 4);
                int fila = numeroRandom.Next(0, 6);
                if (tableroNavalJugador2[columna, fila] == "■" && tableroNavalJugador2[columna + 1, fila] == "■" && tableroNavalJugador2[columna + 2, fila] == "■")
                {
                    tableroNavalJugador2[columna, fila] = "F";
                    tableroNavalJugador2[columna + 1, fila] = "F";
                    tableroNavalJugador2[columna + 2, fila] = "F";
                    fragataColocada = true;
                }
            }

            bool destructorColocado = false;
            while (!destructorColocado)
            {
                bool posiconDestructorHoV = numeroRandom.Next(0, 2) == 0;
                if (posiconDestructorHoV)
                {
                    int columna = numeroRandom.Next(0, 6);
                    int fila = numeroRandom.Next(0, 3);
                    if (tableroNavalJugador2[columna, fila] == "■" && tableroNavalJugador2[columna, fila + 1] == "■" && tableroNavalJugador2[columna, fila + 2] == "■" && tableroNavalJugador2[columna, fila + 3] == "■")
                    {
                        tableroNavalJugador2[columna, fila] = "D";
                        tableroNavalJugador2[columna, fila + 1] = "D";
                        tableroNavalJugador2[columna, fila + 2] = "D";
                        tableroNavalJugador2[columna, fila + 3] = "D";
                        destructorColocado = true;
                    }
                }
                else
                {
                    int columna = numeroRandom.Next(0, 3);
                    int fila = numeroRandom.Next(0, 6);
                    if (tableroNavalJugador2[columna, fila] == "■" && tableroNavalJugador2[columna + 1, fila] == "■" && tableroNavalJugador2[columna + 2, fila] == "■" && tableroNavalJugador2[columna + 3, fila] == "■")
                    {
                        tableroNavalJugador2[columna, fila] = "D";
                        tableroNavalJugador2[columna + 1, fila] = "D";
                        tableroNavalJugador2[columna + 2, fila] = "D";
                        tableroNavalJugador2[columna + 3, fila] = "D";
                        destructorColocado = true;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tablero Naval de " + jugador2);
            Console.WriteLine(" 1 2 3 4 5 6");
            for (int columnas = 0; columnas < tableroNavalJugador2.GetLength(0); columnas++)
            {
                Console.Write(letrasFilas[columnas] + " ");
                for (int filas = 0; filas < tableroNavalJugador2.GetLength(1); filas++)
                {
                    switch (tableroNavalJugador2[columnas, filas])
                    {
                        case "S":
                            Console.ForegroundColor = ConsoleColor.DarkMagenta; 
                            break;
                        case "F":
                            Console.ForegroundColor = ConsoleColor.Green; 
                            break;
                        case "D":
                            Console.ForegroundColor = ConsoleColor.DarkRed; 
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Blue; 
                            break;
                    }
                    Console.Write(tableroNavalJugador2[columnas, filas] + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                Console.ResetColor();
            }

            Console.WriteLine("Te parecen bien el tablero así como esta? (SI/NO)");
            confirmaciónBarcosJ2 = Console.ReadLine()?.ToUpper().Trim() ?? "";
            bool respuestaJ2 = false;
            while (!respuestaJ2)
            {
                if (confirmaciónBarcosJ2 == "SI" || confirmaciónBarcosJ2 == "NO")
                {
                    respuestaJ2 = true;
                }
                else
                {
                    Console.WriteLine("Escriba solo SI O NO"); 
                    confirmaciónBarcosJ2 = Console.ReadLine()?.ToUpper().Trim() ?? "";
                }
            }

        } while (confirmaciónBarcosJ2 != "SI");
    }

    public void GeneracionDeTableroAtaqueJ2(string jugador2)
    {
        Console.WriteLine("A continuación se generará tu tablero de ataque, presiona enter para ver tu tablero de ataque");
        Console.ReadLine();
        for (int columnas = 0; columnas < tableroAtaqueJugador2.GetLength(0); columnas++)
        {
            for (int filas = 0; filas < tableroAtaqueJugador2.GetLength(1); filas++)
            {
                tableroAtaqueJugador2[columnas, filas] = "~"; 
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Tablero Ataque de " + jugador2);
        Console.WriteLine("  1 2 3 4 5 6");

        for (int columnas = 0; columnas < tableroAtaqueJugador2.GetLength(0); columnas++)
        {
            Console.Write(letrasFilas[columnas] + " ");
            for (int filas = 0; filas < tableroAtaqueJugador2.GetLength(1); filas++)
            {
                Console.Write(tableroAtaqueJugador2[columnas, filas] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Presiona enter para continuar");
        Console.ReadLine();
    }
}