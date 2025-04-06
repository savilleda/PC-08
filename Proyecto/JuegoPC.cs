namespace JuegoDeAventura
{
    class Program
    {
        //Variables generales del programa
        public static string idJugador = "";
        public static string aventurero = "";
        public static string opcionMapa = "";
        public static int saludDefinida;
        public static int saludPuntos;
        public static int ataquePuntos;
        public static string menu = "continuar"; 
        public static int enemigosAbatidos = 0;
        public static Random random = new Random();

        //Método principal, esté método evalua si el juego termina o continua
        static void Main()
        {
            IniciarAventura();
            SeleccionMapa();
            //Mientras el jugador no se rinda la partida continuará 
            while (menu != "rendirse") 
            { 
                while (menu == "continuar" && enemigosAbatidos < 3)
                {
                    menu = MenuJuego(menu);

                    if (menu == "continuar")
                    {
                        SeleccionEnemigos();
                    }

                    if (menu == "rendirse")
                    {
                        //El juego terminará si el jugador se riende
                        Console.WriteLine("Gracias por jugar. ¡Hasta la próxima!");
                        break;
                    }
                }
            //Cuando el jugador haya superado los 3 combates el juego terminará y le dará un emovito mensaje
                if (enemigosAbatidos >= 3)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Wow! Eres increíble jugador eres toda una leyenda");
                    Console.WriteLine($"¡Felicidades {idJugador}! Has derrotado a todos los enemigos y has ganado la aventura.");
                    Console.WriteLine("Grandalf el Gris siempre creyó en ti. ¡Hasta la próxima!");
                    break;
                }
            }
        //Bienvenida al jugador, en este método se le da la bienvenida y también se le pondrá a escoger personaje
        static string IniciarAventura()
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
            Console.WriteLine("Mi nombre es.... eeeeeeee... Gandalf el Gris (o eso creo); pero bueno, eso no es importante.");
            Console.ReadLine();
            Console.Clear();
            Console.Write("Estas a punto de entrar en una aventura sin igual, veo en ti un aura poderosa, estoy seguro que estarás bien.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Ya mucho de mí, mejor dime, ¿cuál es tu nombre?");
            Console.WriteLine("Ingresa tu nombre a continuación: ");
            //Aquí se le solicita al jugador que nos indique como quiere ser llamado durante la aventura
            idJugador = Console.ReadLine()??"";
            Console.WriteLine($"¡Bien! mucho gusto {idJugador}. Vaya nombre eh.");
            Console.ReadLine();
            Console.WriteLine("Ahora tienes que elegir que tipo de poderes quieres, este será un regalito de tu humilde servidor.");
            //Se le mencionan al jugador los personajes que puede escoger y los atributos que los personajes poseen
            Console.WriteLine("\n (1) Mago: 100 puntos de vida y 20 puntos de ataque.");
            Console.WriteLine("\n (2) Caballero: 70 puntos de vida y 30 puntos de ataque.");
            Console.WriteLine("\n (3) Arquera: 85 puntos de vida y 25 puntos de ataque.");

            while (true)
            {
                //En esta parte se le da al jugador la opción de escoger que personaje quiere ser
                string opcion = Console.ReadLine() ?? "";
                if (int.TryParse(opcion, out int aventureroSeleccionado))
                {
                    switch (aventureroSeleccionado)
                    {
                        case 1:
                            aventurero = "Mago";
                            saludDefinida = 100;
                            saludPuntos = 100;
                            ataquePuntos = 20;
                            break;

                        case 2:
                            aventurero = "Caballero";
                            saludDefinida = 70;
                            saludPuntos = 70;
                            ataquePuntos = 30;
                            break;

                        case 3:
                            aventurero = "Arquera";
                            saludDefinida = 85;
                            saludPuntos = 85;
                            ataquePuntos = 25;
                            break;

                        default:
                            Console.WriteLine("Elige una opción válida (1, 2 o 3).");
                            continue;
                    }
                    return aventurero;
                }
                else
                {
                    //Si el jugador presiona un número que no es correcto será redireccionado aquí para que vuelva a elegir.
                    Console.WriteLine("Elige el tipo de poder que deseas.");
                    Console.WriteLine("Te aseguro que las opciones que te doy te llevarán a la victoria");
                }
            }
        }
        //En esté método el jugador seleccionará el mapa en el que desea jugar 
        static string SeleccionMapa()
        {   
            //Aquí ya se le da la bienvenida al jugador de acuerdo al nombre y personaje elegido
            Console.WriteLine($"Ahora eres el/la {aventurero} {idJugador}");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("¡Muy bien! verás, este camino se divide en otros tres caminos, deberás superarlos.");
            Console.WriteLine("Cuando ganes tres batallas encontrarás el camino de regreso y habrás ganado.\nAdemás, después de cada combate tendrás la opción de abrir un cofre, tu decides si lo tomas o lo dejas...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Por último, considera que cada camino tiene sus propias características. Bien, ahora te los muestro: ");
            Console.ReadLine();
            Console.WriteLine("\n\n===== CAMINOS A ESCOGER ===== ");
            //Se le menciona al jugador los 3 mapas que hay con sus respectivas condiciones y el número que debe presionar para escogerlos
            Console.WriteLine("(1) Bosque oscuro (Se pueden hallar tesoros sorprendentes o caer en trampas)");
            Console.WriteLine("(2) Cueva sombría (Posibilidad de encontrar enemigos sigilosos. En este mapa los enemigos golpean primero)");
            Console.WriteLine("(3) Camino de piedra (Es menos peligroso, pero con escasos recursos. Los cofres tienen un 25% de probabilidad de estar vacíos.)");

            while (true)
            {
                //En esta parte el jugador selecciona el mapa en el que jugará
                opcionMapa = Console.ReadLine() ?? "";
                if (int.TryParse(opcionMapa, out int mapaSeleccion))
                {
                    switch (mapaSeleccion)
                    {
                        case 1:
                            opcionMapa = "Bosque oscuro";
                            break;

                        case 2:
                            opcionMapa = "Cueva Sombría";
                            break;

                        case 3:
                            opcionMapa = "Camino de piedra";
                            break;

                        default:
                            Console.WriteLine("Elige una opción válida (1, 2 o 3).");
                            continue;
                    }
                    return opcionMapa;
                }
                else
                {
                    //Si el jugador presiona sin queres un número o una tecla que no es permitida tiene la opción de volver a intentar 
                    Console.WriteLine($"Elige un mapa. No te preocupes {idJugador}, confía en tu grandioso Gandalf el Gris, todo estará bien.");
                }
            }
        }
        //Esté método muestra el menú del juego, este aparecerá luego de escoger el personaje y el mapa
        static string MenuJuego(string menu)
        {
            //En esta parte se mostrará el camino escogido, los enemigoss que lleva derrotados el jugador, el mapa escogido
            //La vida que posee, la clase de personaje que escogió y su poder de ataque 
            Console.WriteLine("\t\t\t===MENU PRINCIPAL DEL AVENTURERO===");
            Console.WriteLine($"El camino que elegiste fue: {opcionMapa}");
            Console.WriteLine($"Tu tienes los poderes de un/a {aventurero}");
            Console.WriteLine($"Tus puntos de vida son: \t\t{saludPuntos}");
            Console.WriteLine($"Tu poder de ataque es de: \t\t{ataquePuntos}");
            Console.WriteLine($"Enemigos derrotados: \t\t\t{enemigosAbatidos}");
            Console.ReadLine();
            Console.WriteLine("\n\n¿Qué deseas hacer?");
            Console.ReadLine();
            //Se le muestran las opciones que tiene el jugador, si contínua el jugador entrará en un combate y si se rinde termina el juego
            Console.WriteLine("\n (1) Continuar la aventura.");
            Console.WriteLine("\n (2) Rendirte.");

            while (saludPuntos > 0 && enemigosAbatidos < 3)
            {
                //El jugador realiza su decisión, en base a lo que escoga se desplegará un menú
                string decisionContinuacion = Console.ReadLine() ?? "";
                if (int.TryParse(decisionContinuacion, out int decision) && (decision == 1 || decision == 2))
                {
                    switch (decision)
                    {
                        case 1:
                            Console.WriteLine("¡Vamos a la batalla!");
                            Console.ReadLine();
                            menu = "continuar";
                            return menu;
                        case 2:
                            Console.WriteLine("");
                            Console.WriteLine("No me cabe duda del gran aventurero que eres... pero será a la próxima.");
                            Console.WriteLine("¡GAME OVER!");
                            menu = "rendirse";
                            return menu;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, elige una opción válida (1 o 2).");
                }
            }
            return menu;
        }
        //En esté método se muestran los enemigos que habrán por combate
        static void SeleccionEnemigos ()
        {
            
            if (enemigosAbatidos == 0)
            {
                CombateDelAventurero("Bandido", 20, random.Next(1,6), random.Next(1,4));
            }
            else if (enemigosAbatidos == 1)
            {
                CombateDelAventurero("Monstruo", 25, random.Next(5,11), random.Next(1,3));
            }
            else if (enemigosAbatidos == 2)
            {
                CombateDelAventurero("Jefe Final", 70, random.Next(10,21), random.Next(1,2));
            }
            if (menu == "rendirse")
            {
                return;
            }
        }
        
            static void CombateDelAventurero(string oponente, int puntosDeVidaOponente, int fuerzaDeAtaqueOponente, int cantidadOponentes)
                {
                    Console.WriteLine("Me gusta tu actitud, es hora de luchar así que a darle con todo");
                    Console.WriteLine($"¡Cuidado! Un enemigo se acerca, es un {oponente} con {puntosDeVidaOponente} puntos de vida y {fuerzaDeAtaqueOponente} puntos de ataque.");
                    Console.ReadLine();
                    if (cantidadOponentes > 1)
                    {
                        Console.WriteLine($"\n¡Vaya! parece ser que vienen en grupo aventurero, son {cantidadOponentes} {oponente}s");
                    }
                    Console.WriteLine($"\nSabiendo quién/es es/son tu/s oponente/s, ¿Qué decides?\nGandalf el Gris confía en ti, ¡CON TODO, SE QUE TU PUEDES {idJugador} !");
                    Console.ReadLine();
                        while (saludPuntos > 0 && puntosDeVidaOponente > 0)
                        {
                            Console.WriteLine($"(1) Atacar al {oponente}.");
                            Console.WriteLine($"(2) ¡HUIR! (-10 puntos de vida).");
                            string destinoCombate = Console.ReadLine() ?? "";
                            if (destinoCombate == "1")
                            {
                            if (opcionMapa == "Cueva Sombría") 
                            {
                                saludPuntos -= fuerzaDeAtaqueOponente * cantidadOponentes;
                                Console.WriteLine($"[Cueva Sombría] Es turno del {oponente} de atacar:");
                                Console.WriteLine($"- Recibes {fuerzaDeAtaqueOponente * cantidadOponentes} de daño");
                                Console.WriteLine($"- Vida restante: {saludPuntos}");
                                Console.ReadLine();
                            }
                            puntosDeVidaOponente = puntosDeVidaOponente*cantidadOponentes;
                            puntosDeVidaOponente -= ataquePuntos * cantidadOponentes;
                            Console.WriteLine($"Atacas a los {oponente}s:");
                            Console.WriteLine($"- Infliges {ataquePuntos * cantidadOponentes} de daño");
                            Console.WriteLine($"- Vida enemiga restante: {puntosDeVidaOponente}");
                            Console.ReadLine();
                            if (opcionMapa != "Cueva Sombría" && puntosDeVidaOponente>0) 
                            {
                                saludPuntos -= fuerzaDeAtaqueOponente * cantidadOponentes;
                                Console.WriteLine($"Los {oponente}s contraatacan:");
                                Console.WriteLine($"- Recibes {fuerzaDeAtaqueOponente * cantidadOponentes} de daño");
                                Console.WriteLine($"- Vida restante: {saludPuntos}");
                                Console.ReadLine();
                            }
                            if (puntosDeVidaOponente <= 0)
                            {
                                enemigosAbatidos++;
                                Console.WriteLine($"¡Has derrotado a los {oponente}s!"+"; Ahorra llevas "+enemigosAbatidos+" enemigos abatidos");
                                CofreDelTesoro();
                            }
                            else if (saludPuntos <= 0)
                            {
                                Console.WriteLine($"¡Has sido derrotado por los {oponente}s!");
                                menu = "rendirse";
                                return;
                            }
                            }
                    else if (destinoCombate == "2")
                    {
                        Console.WriteLine($"\nGandalf te entiende {idJugador}, a mí también me daría miedo. \nSin embargo, toda decisión tiene sus consecuencias, sales feliz y contento pero con 10 puntos menos de vida.");
                        saludPuntos -= 10;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Elige una opción válida (1 o 2).");
                    }
                     
                    }
                }
            static void CofreDelTesoro()
                {
                    if(enemigosAbatidos==3)return;
                    Console.WriteLine("Lo prometido es deuda grandioso aventurero, ¡un cofre del tesoro!");
                    Console.WriteLine("Grandalf ama los cofres del tesoro, pero es tu decisión abrirlo o no.");
                    Console.WriteLine("¿Deseas abrirlo? ((1)si / (2)no)");
                    while (true)
                    {
                    string decisionCofre = Console.ReadLine() ?? "";
                    if (decisionCofre == "1" && opcionMapa=="Bosque oscuro")
                    {
                        int tesoro = random.Next(1, 5);
                        switch (tesoro)
                        {
                            case 1:
                            saludPuntos += 10;
                            if(saludPuntos>=saludDefinida)
                            {
                            Console.WriteLine("Epaaaaa aventurero, con que haciendo trampa eh, no puedes tener más vida que al inicio del juego, actualmente tienes "+ saludPuntos+" pts de vida");
                            saludPuntos = saludPuntos-(saludPuntos-saludDefinida);
                            Console.WriteLine("Correjido, al viejo Gandalf no se le escapa nada eh, ahora tienes "+saludPuntos+" pts de vida");
                            }else if(saludPuntos<saludDefinida){
                            Console.WriteLine($" Menos mal que tu fiel amigo Gandalf rezó por ti...\nHas ganado 10 puntos de vida. Un regalito de los dioses de la aventura.");
                            }
                            break;

                            case 2:
                            ataquePuntos += 7;
                            Console.WriteLine($"¡Increíble! Has encontrado un arma mágica...\nHas ganado 7 puntos de ataque. ¡Tus enemigos temblarán ante ti!");
                            break;

                            case 3:
                            saludPuntos -= 5;
                            Console.WriteLine($"Hay días en los que amanecemos con le pie derecho...Gandalf cree que hoy no es tu día. Ahors tienen 5 puntos de vida menos.");
                            break;

                            case 4:
                            saludPuntos -= 10;
                            Console.WriteLine("Vamos aventurero te llevare al cofre, aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa *se cae*");
                            Console.WriteLine("Cuidado aventurero no pises ahi porque hay una trampa *cae en la trampa tambien*, perdon aventurero no me fije en la trampa");
                            Console.WriteLine("2 cosas, una buena y una mala, la buena fue que podemos seguir con la aventura y la mala es que rompimos el cofre al caer  y pierdes 10 pts de vida jeje");
                            break;
                        }
                     return;
                    }else if(decisionCofre == "1" && opcionMapa=="Cueva Sombría")
                     {
                        int tesoro = random.Next(1, 4);
                        switch (tesoro)
                        {
                            case 1:
                            saludPuntos += 10;
                            if(saludPuntos>=saludDefinida)
                            {
                            Console.WriteLine("Epaaaaa aventurero, con que haciendo trampa eh, no puedes tener más vida que al inicio del juego, actualmente tienes"+ saludPuntos+" pts de vida");
                            saludPuntos = saludPuntos-(saludPuntos-saludDefinida);
                            Console.WriteLine("Correjido, al viejo Gandalf no se le escapa nada eh, ahora tienes "+saludPuntos+" pts de vida");
                            }else if(saludPuntos<saludDefinida){
                            Console.WriteLine($" Menos mal que tu fiel amigo Gandalf rezó por ti...\nHas ganado 10 puntos de vida. Un regalito de los dioses de la aventura.");
                            }
                            break;

                            case 2:
                            ataquePuntos += 7;
                            Console.WriteLine($"¡Increíble! Has encontrado un arma mágica...\nHas ganado 7 puntos de ataque. ¡Tus enemigos temblarán ante ti!");
                            break;

                            case 3:
                            saludPuntos -= 5;
                            Console.WriteLine($"Hay días en los que amanecemos con le pie derecho...Gandalf cree que hoy no es tu día. Ahors tienen 5 puntos de vida menos.");
                            break;
                        }
                         return;
                     }else if (decisionCofre == "1" && opcionMapa=="Camino de piedra")
                     {
                        int tesoro = random.Next(1, 4);
                        switch (tesoro)
                        {
                            case 1:
                            saludPuntos += 10;
                            if(saludPuntos>=saludDefinida)
                            {
                            Console.WriteLine("Epaaaaa aventurero, con que haciendo trampa eh, no puedes tener más vida que al inicio del juego, actualmente tienes"+ saludPuntos+" pts de vida");
                            saludPuntos = saludPuntos-(saludPuntos-saludDefinida);
                            Console.WriteLine("Correjido, al viejo Gandalf no se le escapa nada eh, ahora tienes "+saludPuntos+" pts de vida");
                            }else if(saludPuntos<saludDefinida){
                            Console.WriteLine($" Menos mal que tu fiel amigo Gandalf rezó por ti...\nHas ganado 10 puntos de vida. Un regalito de los dioses de la aventura.");
                            }
                            break;

                            case 2:
                            ataquePuntos += 7;
                            Console.WriteLine($"¡Increíble! Has encontrado un arma mágica...\nHas ganado 7 puntos de ataque. ¡Tus enemigos temblarán ante ti!");
                            break;

                            case 3:
                            saludPuntos -= 5;
                            Console.WriteLine($"Hay días en los que amanecemos con le pie derecho...Gandalf cree que hoy no es tu día. Ahors tienen 5 puntos de vida menos.");
                            break;

                            case 4:
                            Console.WriteLine("Mira aventurero, encontramos el cofreo, abrelo para ver que contiene");
                            Console.ReadLine();
                            Console.WriteLine("UPSSS......JAJAJA perdón aventurero pero el cofre esta vacío, pero no te preocupes, ¡la aventura sigue!");
                            break;
                        }
                         return;
                    }else if(decisionCofre== "2")
                    {
                     Console.WriteLine("Con que estamos confiados aventurero, me gusta esa actitud, solo espero que no te arrepientas luego");
                     break;
                    }
                    else
                    {
                        Console.WriteLine("Elige una opción válida (1 o 2)");   
                    }
                }
                }    
        }
    }
}