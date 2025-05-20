public class Mecanismo : Tablero //Mecanismo hereda todo lo del clase tablero 
{
    //Atributos
    private Tablero tableroJ1; //Se crea tableroJ1 que representan los tableros del J1 se ponen en private para que el valor no cambie
    private Tablero tableroJ2; //Se crea tableroJ2 que representan los tableros del J2 se ponen en private para que el valor no cambie
    public int contadorTurnos = 1;
    public int puntosJ1 =0; //Cantidad de puntos del J1
    public int puntosJ2 =0;//Cantidad de puntos del J2
    public int partesDeBarcosJ1 =9; //Representa la cantidad de aciertos que tienen que hacer para terminar el juego antes, si llega a 0 se acaba el juego
    public int partesDeBarcosJ2 =9;
    public bool rendirseJ1 = false; //Da la opción para rendirse
    public bool rendirseJ2 = false;
    public string coordenadasjugador1 ; //Aquí ingresarán las coordenadas de ataque
    public string coordenadasjugador2 ;
    public int submarinoJ1 =2; //Es la cantidad de partes del submarino
    public int fragataJ1 =3; //Es la cantidad de partes de la fragata
    public int destructorJ1 =4; //Es la cantidad de partes del destructor
    public int submarinoJ2 =2; 
    public int fragataJ2 =3; 
    public int destructorJ2 =4;  
    private HashSet<string> registroCoordenadasJ1 = new HashSet<string>(); //El hashset funciona como un almacen de datos, aqui se depositan todas las coordenas ingresadas del J1 para que no se repitan y se ponen en private para que el valor que no se repita
    private HashSet<string> registroCoordenadasJ2 = new HashSet<string>();//El hashset funciona como un almacen de datos, aqui se depositan todas las coordenas ingresadas del J2 para que no se repitan y se ponen en private para que el valor que no se repita

    public Mecanismo(Tablero tableroJ1, Tablero tableroJ2) : base(tableroJ1.confirmaciónBarcosJ1, tableroJ2.confirmaciónBarcosJ2) //Los objetos creados son en base a los creados en la clase base que es tablero
    {
        this.tableroJ1 = tableroJ1;
        this.tableroJ2 = tableroJ2;
        this.coordenadasjugador1 = string.Empty; 
        this.coordenadasjugador2 = string.Empty; 
    }

    public void Ataque(string jugador1, string jugador2)// Utiliza los nombres de los jugadores como parametros
    {
        Console.WriteLine("Bueno, ya comenzó lo bueno, la batalla ha llegado, presiona enter para desplegar tus tableros "+jugador1);
        Console.ReadLine();

        while (rendirseJ1 == false && contadorTurnos < 16 && partesDeBarcosJ1 > 0 && partesDeBarcosJ2>0 && rendirseJ2==false) //Valida si se rinden, terminan los turnos y que no hayan terminado de destruir los barcos
        {
            // Mostrar el tablero naval del jugador 1
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tablero Naval de " + jugador1);
            Console.WriteLine(" 1 2 3 4 5 6");
            for (int filas = 0; filas < tableroJ1.tableroNavalJugador1.GetLength(0); filas++)
            {
                Console.Write(letrasFilas[filas] + " ");
                for (int columnas = 0; columnas < tableroJ1.tableroNavalJugador1.GetLength(1); columnas++)
                {
                    switch (tableroJ1.tableroNavalJugador1[filas, columnas])
                    {
                        case "S":
                            Console.ForegroundColor = ConsoleColor.DarkMagenta; // Submarino
                            break;
                        case "F":
                            Console.ForegroundColor = ConsoleColor.Green; // Fragata
                            break;
                        case "D":
                            Console.ForegroundColor = ConsoleColor.DarkRed; // Destructor
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Blue; // Agua
                            break;
                    }
                    Console.Write(tableroJ1.tableroNavalJugador1[filas, columnas] + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }

            // Mostrar el tablero de ataque del jugador 1
            Console.WriteLine("Tablero Ataque de " + jugador1);
            Console.WriteLine(" 1 2 3 4 5 6");
            for (int filas = 0; filas < tableroJ1.tableroAtaqueJugador1.GetLength(0); filas++)
            {
                Console.Write(letrasFilas[filas] + " ");
                for (int columnas = 0; columnas < tableroJ1.tableroAtaqueJugador1.GetLength(1); columnas++)
                {
                    Console.Write(tableroJ1.tableroAtaqueJugador1[filas, columnas] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Turno numero "+contadorTurnos); //Le muestra sus turnos
            bool decisionJ1Confirmada = false;
            while(!decisionJ1Confirmada)//Verifica que si el jugador quiere atacar o rendirse
            {
            Console.WriteLine("Que quieres hacer jugador? (ATACAR/RENDIRSE)");
            string decisionJ1 = Console.ReadLine()?.ToUpper().Trim() ?? "";
            if(decisionJ1=="RENDIRSE")//Verifica que el jugador haya ingresado una respuesta valida
            {
                rendirseJ1 = true; 
                Console.WriteLine("Nooooooo, aún se podía ganar :c, pero respeto tu decisión, a la otra será");
                Console.WriteLine("Presiona enter para seguir");
                Console.ReadLine();
                return; // Regresa al main para pasar a los resultados
            }else if(decisionJ1=="ATACAR")//Si decide atacar saldrá del bucle
            {
                Console.WriteLine("ESA ES LA ACTITUD, CON TODO PUES");
                Console.WriteLine("Presiona enter para seguir");
                Console.ReadLine();
                decisionJ1Confirmada = true;
            }else if(string.IsNullOrWhiteSpace(decisionJ1))
            {
                Console.WriteLine("Ingresa una respuesta válida");
                Console.WriteLine("Presiona enter para volver a intentarlo");
                Console.ReadLine();
            }else
            {
                Console.WriteLine("Ingresa una respuesta válida");
                Console.WriteLine("Presiona enter para volver a intentarlo");
                Console.ReadLine(); 
            }
            }
            Console.WriteLine("Tienes "+puntosJ1+" pts");
            Console.WriteLine("Bueno ahora que puedes visualizar tus tablero podemos llevar acabo un ataque en contra de "+jugador2);
            bool confirmacionCoordenasJ1 = false;
            while(!confirmacionCoordenasJ1)//Verifica las coordenas del jugador
            {
            Console.WriteLine("Comandante "+jugador1+" por favor ingrese las coordenadas de ataque en un formatos de A-1, o sea primero una letra de la A-F y un numero del 1-6");
            Console.WriteLine("No vayas a ingresar coordenadas repetidas eh, que te estoy vigilando");
            coordenadasjugador1 = Console.ReadLine() ?.ToUpper().Trim() ??""; //Lee las coordenadas ingresadas
            if (string.IsNullOrWhiteSpace(coordenadasjugador1))//Verifica que no se nullo
            {
            Console.WriteLine("Error al registrar la coordenada, presione enter para hacerlo nuevamente");
            Console.ReadLine();
            continue;//Hace que pase validación por validación
            }else if(registroCoordenadasJ1.Contains(coordenadasjugador1))//Verifica que no se repita
            {
            Console.WriteLine("Error al registrar la coordenada, presione enter para hacerlo nuevamente");
            Console.ReadLine();
            continue;
            }else if(!System.Text.RegularExpressions.Regex.IsMatch(coordenadasjugador1, "^[A-F]-[1-6]$"))//Se crea un formato de escritura para que solo acepte por ejemplo F-5
            {
            Console.WriteLine("Error al registrar la coordenada, presione enter para hacerlo nuevamente");
            Console.ReadLine();
            continue;
            }
            // Ahora sí, conversión segura
            char columnaTemporalJ1 = coordenadasjugador1[0]; //Extrae el carácter de la coordenada ingresada por el jugador todo de forma temporal porque luego se recorre correctamente la matriz
            int filaTemporalJ1 = columnaTemporalJ1 - 'A'; //Convierte el carácter en número, por orden alfabetico, tipo A es 1, B es 2 y así, todo de forma temporal porque luego se recorre correctamente la matriz
            int coordenadaTemporalMatrizJ1 = int.Parse(coordenadasjugador1[2].ToString())-1; //Al valor número de la coordenada se le resta 1 porque así se puede recorrer la matriz correctamente, todo de forma temporal porque luego se recorre correctamente la matriz
            if(filaTemporalJ1<0||filaTemporalJ1>=6||coordenadaTemporalMatrizJ1<0||coordenadaTemporalMatrizJ1>=6) //Verifica que la coordenada no se salga del rango de la matriz
            {
                Console.WriteLine("Error al registrar la coordenada, presione enter para hacerlo nuevamente");
                Console.ReadLine();
                continue;
            }
            registroCoordenadasJ1.Add(coordenadasjugador1);
            confirmacionCoordenasJ1 = true;
            Console.WriteLine("Ataque realizado correctamente");
            }
            char columnaJ1 = coordenadasjugador1[0];//Extrae el carácter de la coordenada ingresada por el jugador
            int filaJ1 = columnaJ1 - 'A';//Convierte el carácter en número, por orden alfabetico, tipo A es 1, B es 2 y así
            int coordenadaMatrizJ1 = int.Parse(coordenadasjugador1[2].ToString())-1;//Al valor número de la coordenada se le resta 1 porque así se puede recorrer la matriz correctamente
            string lugarAtaqueJ1 = tableroJ2.tableroNavalJugador2[filaJ1,coordenadaMatrizJ1]; //Hace la coordenada tipo string porque así se puede almacenar en el hashset
            if(lugarAtaqueJ1=="S" || lugarAtaqueJ1 == "F" || lugarAtaqueJ1 == "D") //Verifica si hubo impacto en algún barco
            {
                tableroJ2.tableroNavalJugador2[filaJ1,coordenadaMatrizJ1]="X"; //Si hubo impacto en el tablero del jugador contrario marcará una X de que le dio a un barco
                Console.WriteLine("Wowwwwwwwwwwwwwwww, sigue asi, le diste al barco :D");
                tableroJ1.tableroAtaqueJugador1[filaJ1,coordenadaMatrizJ1] = "O";//Si hubo impacto marcará con un círculo en su tablero de ataque
                if(lugarAtaqueJ1=="S") //Verifica si le dio a un submarino
                {
                    submarinoJ1-=1;//Le quita una parte al submarino
                    if(submarinoJ1==0) //Si el destruye todas las partes del submarino le dará 2 puntos al jugador y le restará 2 puntos a las partes del barco del j2
                    {
                        Console.WriteLine("Felicidades ganaste 2 puntos por destruir el Submarino enemigo");
                        Console.WriteLine("Presiona enter para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        partesDeBarcosJ2-=2;
                        puntosJ1+=2;
                    }
                }else if(lugarAtaqueJ1=="F") //Verifica si hubo impacto en una fragata
                {
                    fragataJ1-=1;//Le quita una parte a la fragata
                    if(fragataJ1==0) //Si el destruye todas las partes de la fragata le dará 3 puntos y le restará 3 puntos a las partes de la fragata
                    {
                        Console.WriteLine("Felicidades ganaste 3 puntos por destruir la fragata enemiga");
                        Console.WriteLine("Presiona enter para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        partesDeBarcosJ2-=3;
                        puntosJ1+=3;
                    }
                }else if(lugarAtaqueJ1=="D")//Verifica si hubo impacto en un destructor
                {
                    destructorJ1 -=1;//Le quita una parte al destructor
                    if(destructorJ1==0)//Si el destruye todas las partes del destructor le dará 4 puntos y le restará 4 puntos a las partes de la fragata
                    {
                        Console.WriteLine("Felicidades ganaste 4 puntos por destruir el destructor enemigo");
                        Console.WriteLine("Presiona enter para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        partesDeBarcosJ2-=4;
                        puntosJ1+=4;
                    }  
                }
                 }else //Si no hubo impacto
                {
                    tableroJ1.tableroAtaqueJugador1[filaJ1,coordenadaMatrizJ1] = "X"; //Marcara en el tablero de ataque como que ya intentó ahí pero no acertó
                    tableroJ2.tableroNavalJugador2[filaJ1,coordenadaMatrizJ1] = "O"; //Marcara en el tablero del jugador 2 que lo atacaron ahí pero le dió al agua
                    Console.WriteLine("Ojo, ojo, se viene se viene, y el disparo le dio al......, agua JAJAJA, a la otra sera");
                    Console.WriteLine("Presiona enter para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
            Console.WriteLine("Tienes "+puntosJ1+" pts"); //Le muestra los puntos luego del ataque
            Console.WriteLine("Presiona enter para continuar con el turno de "+jugador2);//Pasa al siguiente turno
            Console.ReadLine();
            Console.Clear();//Hace que el jugador 2 no vea las cosas del j1
            Console.WriteLine("Es hora del contraataque, presiona enter para desplegar tus tableros "+jugador2);//Se repite lo mismo con el jugador 2, ya que es el mismo procedimiento
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tablero Naval de " + jugador2);
            Console.WriteLine(" 1 2 3 4 5 6");
            for (int filas = 0; filas < tableroJ2.tableroNavalJugador2.GetLength(0); filas++)
            {
                Console.Write(letrasFilas[filas] + " ");
                for (int columnas = 0; columnas < tableroJ2.tableroNavalJugador2.GetLength(1); columnas++)
                {
                    switch (tableroJ2.tableroNavalJugador2[filas, columnas])
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
                    Console.Write(tableroJ2.tableroNavalJugador2[filas, columnas] + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Tablero Ataque de " + jugador2);
            Console.WriteLine(" 1 2 3 4 5 6");
            for (int filas = 0; filas < tableroJ2.tableroAtaqueJugador2.GetLength(0); filas++)
            {
                Console.Write(letrasFilas[filas] + " ");
                for (int columnas = 0; columnas < tableroJ2.tableroAtaqueJugador2.GetLength(1); columnas++)
                {
                    Console.Write(tableroJ2.tableroAtaqueJugador2[filas, columnas] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Turno numero "+contadorTurnos);
            bool decisionJ2Confirmada = false;
            while (!decisionJ2Confirmada)
            {
                Console.WriteLine("Que quieres hacer jugador? (ATACAR/RENDIRSE)");
                string decisionJ2 = Console.ReadLine()?.ToUpper().Trim() ?? "";
                if (decisionJ2 == "RENDIRSE")
                {
                    rendirseJ2 = true;
                    Console.WriteLine("Nooooooo, aún se podía ganar :c, pero respeto tu decisión, a la otra será");
                    Console.WriteLine("Presiona enter para seguir");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
                else if (decisionJ2 == "ATACAR")
                {
                    Console.WriteLine("ESA ES LA ACTITUD, CON TODO PUES");
                    Console.WriteLine("Presiona enter para seguir");
                    Console.ReadLine();
                    decisionJ2Confirmada = true;
                }
                else if (string.IsNullOrWhiteSpace(decisionJ2))
                {
                    Console.WriteLine("Ingresa una respuesta válida");
                    Console.WriteLine("Presiona enter para volver a intentarlo");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Ingresa una respuesta válida");
                    Console.WriteLine("Presiona enter para volver a intentarlo");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("Tienes "+puntosJ2+" pts");
            Console.WriteLine("Bueno ahora que puede visualizar tus tablero podemos llevar acabo un ataque en contra de "+jugador1);
            bool confirmacionCoordenasJ2 = false;
            while(!confirmacionCoordenasJ2)
            {
            Console.WriteLine("Comandante "+jugador2+", por favor ingrese las coordenadas de ataque en un formatos de A-1, o sea primero una letra de la A-F y un numero del 1-6");
            Console.WriteLine("No ingrese coordenadas repetidas");
            coordenadasjugador2 = Console.ReadLine() ?.ToUpper().Trim() ??"";
            if (string.IsNullOrWhiteSpace(coordenadasjugador2))
            {
            Console.WriteLine("Error al registrar la coordenada, presione enter para hacerlo nuevamente");
            Console.ReadLine();
            continue;
            }else if(registroCoordenadasJ2.Contains(coordenadasjugador2))
            {
            Console.WriteLine("Error al registrar la coordenada, presione enter para hacerlo nuevamente");
            Console.ReadLine();
            continue;
            }else if(!System.Text.RegularExpressions.Regex.IsMatch(coordenadasjugador2, "^[A-F]-[1-6]$"))
            {
            Console.WriteLine("Error al registrar la coordenada, presione enter para hacerlo nuevamente");
            Console.ReadLine();
            continue;
            }
            char columnaTemporalJ2 = coordenadasjugador2[0];
            int filaTemporalJ2 = columnaTemporalJ2 - 'A';
            int coordenadaTemporalMatrizJ2 = int.Parse(coordenadasjugador2[2].ToString())-1;
            if(filaTemporalJ2<0||filaTemporalJ2>=6||coordenadaTemporalMatrizJ2<0||coordenadaTemporalMatrizJ2>=6)
            {
                Console.WriteLine("Error al registrar la coordenada, presione enter para hacerlo nuevamente");
                Console.ReadLine();
                continue;
            }
            registroCoordenadasJ2.Add(coordenadasjugador2);
            confirmacionCoordenasJ2 = true;
            Console.WriteLine("Ataque realizado correctamente");
            }
            char columnaJ2= coordenadasjugador2[0];
            int filaJ2 = columnaJ2 - 'A';
            int coordenadaMatrizJ2 = int.Parse(coordenadasjugador2[2].ToString())-1;
            string lugarAtaqueJ2 = tableroJ1.tableroNavalJugador1[filaJ2,coordenadaMatrizJ2];
            if(lugarAtaqueJ2=="S" || lugarAtaqueJ2 == "F" || lugarAtaqueJ2 == "D")
            {
                tableroJ1.tableroNavalJugador1[filaJ2,coordenadaMatrizJ2]="X";
                Console.WriteLine("Wowwwwwwwwwwwwwwww, sigue asi, le diste al barco :D");
                tableroJ2.tableroAtaqueJugador2[filaJ2,coordenadaMatrizJ2] = "O";
                partesDeBarcosJ1-=1;
              if(lugarAtaqueJ2=="S")
                {
                    submarinoJ2-=1;
                    if(submarinoJ2==0)
                    {
                        Console.WriteLine("Felicidades ganaste 2 puntos por destruir el Submarino enemigo");
                        Console.WriteLine("Presiona enter para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        partesDeBarcosJ1-=2;
                        puntosJ2+=2;
                    }
                }else if(lugarAtaqueJ2=="F")
                {
                    fragataJ2-=1;
                    if(fragataJ2==0)
                    {
                        Console.WriteLine("Felicidades ganaste 3 puntos por destruir la fragata enemiga");
                        Console.WriteLine("Presiona enter para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        partesDeBarcosJ1-=3;
                        puntosJ2+=3;
                    }
                }else if(lugarAtaqueJ2=="D")
                {
                    destructorJ2 -= 1;
                    if(destructorJ2==0)
                    {
                        Console.WriteLine("Felicidades ganaste 4 puntos por destruir el destructor enemigo");
                        Console.WriteLine("Presiona enter para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        partesDeBarcosJ1-=4;
                        puntosJ2+=4;
                    }  
                }   
            }else
            {
                tableroJ2.tableroAtaqueJugador2[filaJ2,coordenadaMatrizJ2] = "X";
                tableroJ1.tableroNavalJugador1[filaJ2,coordenadaMatrizJ2] = "O";
                Console.WriteLine("Ojo, ojo, se viene se viene, y el disparo le dio al......, agua JAJAJA, a la otra sera");
                Console.WriteLine("Presiona enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("Tienes "+puntosJ2+" pts");
            Console.WriteLine("Presiona enter para continuar al siguiente turno"); //Se repite el bucle hasta que termine el juego por alguna razón
            Console.ReadLine();
            Console.Clear();
            contadorTurnos++;//Suma un turno para que cuando lleguen a 15 termine el juego            
        }
    }
    public void Resultados(string jugador1, string jugador2)//Se usan los nombres de los jugadores como parámetros 
    {
       Console.WriteLine("Gracias por jugar a ambos, se les aprecia");
       Console.WriteLine("Ahora vamos a ver quien es el ganador");
       if(rendirseJ1==true)//Verifica si el que se rindió fue el jugador 1 para que el jugador 2 sea el ganador
        {
            Console.WriteLine("Como "+jugador1+" se rindió, el ganador es "+jugador2+". Felicidades! "+jugador2);
            Console.WriteLine("Presiona enter para terminar el juego");
            Console.ReadLine();
            return;//Regresa al main para agradecer por jugar
        }else if(rendirseJ2==true)//Verifica si el que se rindió fue el jugador 2 para que el jugador 1 sea el ganador
        {
            Console.WriteLine("Como "+jugador2+" se rindió, el ganador es "+jugador1+". Felicidades! "+jugador1);
            Console.WriteLine("Presiona enter para terminar el juego");
            Console.ReadLine();
            return;//Regresa al main para agradecer por jugar
        }
        if(rendirseJ1==false && rendirseJ2==false) //Si ninguno se rindió verifica otras condiciones       
        {
            Console.WriteLine("Es hora de contar los puntos para saber quien es el ganador");
            if(puntosJ1>puntosJ2)//Da como ganador al jugador 1 por tener más puntos
            {
                Console.WriteLine("EL GANADOR ESSSSSSS"+jugador1+" FELICIDADES!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Presiona enter para terminar el juego");
                Console.ReadLine();
                return;//Regresa al main para agradecer por jugar
            }else if(puntosJ1<puntosJ2)//Da como ganador al jugador 2 por tener más puntos
            {
                Console.WriteLine("EL GANADOR ESSSSSSS"+jugador2+" FELICIDADES!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Presiona enter para terminar el juego");
                Console.ReadLine();
                return;//Regresa al main para agradecer por jugar
            }else if(puntosJ1==puntosJ2)//Declara un empate entre ambos jugadores
            {
                Console.WriteLine("EL GANADOR ESSSSSSS...... empate?");
                Console.WriteLine("No crei que fuera posible eso pero bueno, supongo que ambos son igual de buenos jeje, igual felicidades a ambos por su esfuerzo :D");
                Console.WriteLine("Presiona enter para terminar el juego");
                Console.ReadLine();
                return;//Regresa al main para agradecer por jugar
            }
        }
    }
}