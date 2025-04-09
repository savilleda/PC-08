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
                //En esta parte el jugador selecciona el mapa en el que jugará, cada mapa tiene una condición diferente
                opcionMapa = Console.ReadLine() ?? "";
                if (int.TryParse(opcionMapa, out int mapaSeleccion))
                {
                    switch (mapaSeleccion)
                    {
                        //El mapa que escogió es el bosque oscuro y podrá caer en trampas
                        case 1:
                            opcionMapa = "Bosque oscuro";
                            break;
                        //El mapa que escogió es la cueva sombría y los enemigos atacan primero
                        case 2:
                            opcionMapa = "Cueva Sombría";
                            break;
                        //El mapa que escogió es el camino de piedra y los cofres pueden estar vacíos pero tiene probabilidad de un loot especial
                        case 3:
                            opcionMapa = "Camino de piedra";
                            break;
                        //Si no selecciona ninguno de los 3 marcará un error y lo hará regresar para volver a seleccionar mapa
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
            //Este while se ejecuta mientras los enemigos derrotados sean menores a 3, de lo contrario lo va a dirijir
            while (saludPuntos > 0 && enemigosAbatidos < 3)
            {
                //El jugador realiza su decisión, en base a lo que escoga se desplegará un menú
                string decisionContinuacion = Console.ReadLine() ?? "";
                if (int.TryParse(decisionContinuacion, out int decision) && (decision == 1 || decision == 2))
                {
                    //Este switch evaluá la desción del usuario
                    switch (decision)
                    {
                        //Si el jugador presiona 1, el juego continuara y se desplegará el menú de combate
                        case 1:
                            Console.WriteLine("¡Vamos a la batalla!");
                            Console.ReadLine();
                            menu = "continuar";
                            return menu;
                        //Si el jugador presiona 2 el juego terminará automáticante
                        case 2:
                            Console.WriteLine("");
                            Console.WriteLine("No me cabe duda del gran aventurero que eres... pero será a la próxima.");
                            Console.WriteLine("¡GAME OVER!");
                            menu = "rendirse";
                            return menu;
                    }
                }
                //Si el jugador no presiona 1 o 2 se le dará la oportunidad de volver a escribir un número, hasta que sea una de las opciones
                else
                {
                    Console.WriteLine("Por favor, elige una opción válida (1 o 2).");
                }
            }
            return menu;
        }
        //Este método determina los enemigos que habrán por combate, asignando un atributo único para cada monstruo
        static void SeleccionEnemigos ()
        {
            //Cuando la cantidad de enemigos derrotados sea 0, se la asignará el nombre de bandido, 20 de vida, un daño de 1-5 
            //Y una probabilidad de spawn de bandidos de 1-3
            if (enemigosAbatidos == 0)
            {
                CombateDelAventurero("Bandido", 20, random.Next(1,6), random.Next(1,4));
            }//Cuando haya ganado el primer combate aparecerá un monstruo, el cual tendrá 25 de vida, un daño de 5-11 y pueden aparecer de 1-2 monstruos
            else if (enemigosAbatidos == 1)
            {
                CombateDelAventurero("Monstruo", 25, random.Next(5,11), random.Next(1,3));
            }//Cuando haya ganado el segundo combate aparecerá el jefe final, el cual tendrá 70 de vida, un daño de 10-21 y aparecerá solo 1 jefe final por partida
            else if (enemigosAbatidos == 2)
            {
                CombateDelAventurero("Jefe Final", 70, random.Next(10,21), random.Next(1,2));
            }
        }
            //Este método realiza el combate por turnos 
            static void CombateDelAventurero(string oponente, int puntosDeVidaOponente, int fuerzaDeAtaqueOponente, int cantidadOponentes)
                {
                    //Se le da la bienvenida al campo de batalla al jugador, además se le muestra en pantalla el enemigo a vencer y sus atributos 
                    Console.WriteLine("Me gusta tu actitud, es hora de luchar así que a darle con todo");
                    Console.WriteLine($"¡Cuidado! Un enemigo se acerca, es un {oponente} con {puntosDeVidaOponente} puntos de vida y {fuerzaDeAtaqueOponente} puntos de ataque.");
                    Console.ReadLine();
                    //Si llegan a spawnear más de 1 enemigo en los primeros 2 combates, estos se le anuncian al jugador para que decida que hacer
                    if (cantidadOponentes > 1)
                    {
                        Console.WriteLine($"\n¡Vaya! parece ser que vienen en grupo aventurero, son {cantidadOponentes} {oponente}s");
                    }//Conociendo sus rivales el jugador decide si atacar huir, está opción la tiene durante cada turno que dure el combate
                    Console.WriteLine($"\nSabiendo quién/es es/son tu/s oponente/s, ¿Qué decides?\nGandalf el Gris confía en ti, ¡CON TODO, SE QUE TU PUEDES {idJugador} !");
                    Console.ReadLine();
                        while (saludPuntos > 0 && puntosDeVidaOponente > 0)
                        {
                            //Si el jugador decide atacar se desplegará la interfaz de combate y si se rinde regresará al menú principal y se le quitarán 10 pts de vida
                            Console.WriteLine($"(1) Atacar al {oponente}.");
                            Console.WriteLine($"(2) ¡HUIR! (-10 puntos de vida).");
                            string destinoCombate = Console.ReadLine() ?? "";
                            if (destinoCombate == "1")
                            {//Cuando el mapa es la cueva sombría los enemigos atacan primero, por lo que el enemigo golpea al enemigo primero y muestra una interacción especial
                            //Si el enemigo no llega a morir se repeti está instrucción para el contrataque del enemigo
                            if (opcionMapa == "Cueva Sombría") 
                            {
                                saludPuntos -= fuerzaDeAtaqueOponente * cantidadOponentes;
                                Console.WriteLine($"[Cueva Sombría] Es turno del {oponente} de atacar:");
                                Console.WriteLine($"- Recibes {fuerzaDeAtaqueOponente * cantidadOponentes} de daño");
                                Console.WriteLine($"- Vida restante: {saludPuntos}");
                                Console.ReadLine();
                            }//En esta parte se muestra el ataque del jugador al oponente, la vida del oponente depende de la cantidad de enemigos que hayan
                            puntosDeVidaOponente = puntosDeVidaOponente*cantidadOponentes;
                            //Si hay más de un oponente el daño que hará el jugador será igual a la cantidad de oponentes que hay ya que ataca ambos por igual y al mismo tiempo
                            puntosDeVidaOponente -= ataquePuntos * cantidadOponentes;
                            Console.WriteLine($"Atacas a los {oponente}s:");
                            Console.WriteLine($"- Infliges {ataquePuntos * cantidadOponentes} de daño");
                            Console.WriteLine($"- Vida enemiga restante: {puntosDeVidaOponente}");
                            Console.ReadLine();
                            //Luego se muestra el contrataque del enemigo, siempre y cuando sea el primer y tercer mapa, si no regresa a la instrucción anterior
                            if (opcionMapa != "Cueva Sombría" && puntosDeVidaOponente>0) 
                            {
                                saludPuntos -= fuerzaDeAtaqueOponente * cantidadOponentes;
                                Console.WriteLine($"Los {oponente}s contraatacan:");
                                Console.WriteLine($"- Recibes {fuerzaDeAtaqueOponente * cantidadOponentes} de daño");
                                Console.WriteLine($"- Vida restante: {saludPuntos}");
                                Console.ReadLine();
                            }//Si la salud del enemigo es 0 o menor, se mostrará un menú indicando que lo derroto y el contador de enemigos derrotados aumentará en uno
                            if (puntosDeVidaOponente <= 0)
                            {
                                enemigosAbatidos++;
                                Console.WriteLine($"¡Has derrotado a los {oponente}s!"+"; Ahorra llevas "+enemigosAbatidos+" enemigos abatidos");
                                CofreDelTesoro();
                            }//Si la salud del jugador llega a 0 o menor, mostrará un mensaje de que murió y perderá automáticamente
                            else if (saludPuntos <= 0)
                            {
                                Console.WriteLine($"¡Has sido derrotado por los {oponente}s!");
                                menu = "rendirse";
                                return;
                            }
                            }//Si el jugador decide huir se le quitarán 10 puntos de vida y regresará al menú principal
                    else if (destinoCombate == "2")
                    {
                        Console.WriteLine($"\nGandalf te entiende {idJugador}, a mí también me daría miedo. \nSin embargo, toda decisión tiene sus consecuencias, sales feliz y contento pero con 10 puntos menos de vida.");
                        saludPuntos -= 10;
                        return;
                    }//Si el jugador no selecciona una opción que no es 1 o 2, se le dará la opción de seleccionar otra vez un número, esto ocurrirá hasta que seleccione una de las 2 opciones
                    else
                    {
                        Console.WriteLine("Elige una opción válida (1 o 2).");
                    }
                     
                    }
                }//Este método enseña el funcionamiento de los cofres
            static void CofreDelTesoro()
                {
                    //Si el enemigo ya derrotó al jefe final no tendrá la opción de abrir cofres
                    if(enemigosAbatidos==3)return;
                    //Se le dará la bienvenida a la interfaz de cofres, en esta decidirá si abrirlos o no
                    Console.WriteLine("Lo prometido es deuda grandioso aventurero, ¡un cofre del tesoro!");
                    Console.WriteLine("Grandalf ama los cofres del tesoro, pero es tu decisión abrirlo o no.");
                    Console.WriteLine("¿Deseas abrirlo? ((1)si / (2)no)");
                    while (true)
                    {
                    string decisionCofre = Console.ReadLine() ?? "";
                    //Si el mapa es el bosque oscuro, le podrán tocar 14 puntos de vida en la poción, 12 de daño, podrá caer en una trampa, la cual le quitará 10 de vida
                    //O le pueden quitar 5 de vida, todo esto funciona con un random, ya que cada loot tiene una probabilidad del 25%, además en este mapa las cosas que le pueden tocar están potenciadas
                    if (decisionCofre == "1" && opcionMapa=="Bosque oscuro")
                    {
                        int tesoro = random.Next(1, 5);
                        switch (tesoro)
                        {
                            case 1:
                            saludPuntos += 14;
                            if(saludPuntos>=saludDefinida)
                            {
                            Console.WriteLine("Epaaaaa aventurero, con que haciendo trampa eh, no puedes tener más vida que al inicio del juego, actualmente tienes "+ saludPuntos+" pts de vida");
                            saludPuntos = saludPuntos-(saludPuntos-saludDefinida);
                            Console.WriteLine("Correjido, al viejo Gandalf no se le escapa nada eh, ahora tienes "+saludPuntos+" pts de vida");
                            }else if(saludPuntos<saludDefinida){
                            Console.WriteLine($" Menos mal que tu fiel amigo Gandalf rezó por ti...\nHas ganado 14 puntos de vida. Un regalito de los dioses de la aventura.");
                            }
                            break;

                            case 2:
                            ataquePuntos += 12;
                            Console.WriteLine($"¡Increíble! Has encontrado un arma mágica...\nHas ganado 12 puntos de ataque. ¡Tus enemigos temblarán ante ti!");
                            break;

                            case 3:
                            saludPuntos -= 5;
                            Console.WriteLine($"Hay días en los que amanecemos con el pie derecho...Gandalf cree que hoy no es tu día. Ahora tienen 5 puntos de vida menos.");
                            break;

                            case 4:
                            saludPuntos -= 10;
                            Console.WriteLine("Vamos aventurero te llevare al cofre, aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa *se cae*");
                            Console.WriteLine("Cuidado aventurero no pises ahi porque hay una trampa *cae en la trampa tambien*, perdon aventurero no me fije en la trampa");
                            Console.WriteLine("2 cosas, una buena y una mala, la buena fue que podemos seguir con la aventura y la mala es que rompimos el cofre al caer  y pierdes 10 pts de vida jeje");
                            break;
                        }
                     return;
                     //Si el mapa es la cueva sombría, tiene solo 3 posibles recompenzas, curarse 10 de vida, un aumento de 7 puntos de daño o le podrán quitar 5 de vida
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
                            Console.WriteLine($"Hay días en los que amanecemos con el pie derecho...Gandalf cree que hoy no es tu día. Ahora tienen 5 puntos de vida menos.");
                            break;
                        }
                         return;
                         //En el camino de piedra el aventurero tiene un 25% de caer en una trampa, las demás cosas que le pueden tocar son: curarse 10 de vida, un aumento de 7 puntos de daño o le podrán quitar 5 de vida
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
                            Console.WriteLine($"Hay días en los que amanecemos con el pie derecho...Gandalf cree que hoy no es tu día. Ahora tienen 5 puntos de vida menos.");
                            break;

                            case 4:
                            Console.WriteLine("Mira aventurero, encontramos el cofreo, abrelo para ver que contiene");
                            Console.ReadLine();
                            Console.WriteLine("UPSSS......JAJAJA perdón aventurero pero el cofre está vacío, pero no te preocupes, ¡la aventura sigue!");
                            break;
                        }
                         return;
                         //Si el jugador presiona 2, es porque no quiere abrir ningún cofre, esto aplica para los 3 mapas
                    }else if(decisionCofre== "2")
                    {
                     Console.WriteLine("Con que estamos confiados aventurero, me gusta esa actitud, solo espero que no te arrepientas luego");
                     break;
                    }//Si el jugador no presiona 1 o 2, se le dará la opción de volver a intentarlo, hasta que seleccione una opción válida 
                    else
                    {
                        Console.WriteLine("Elige una opción válida (1 o 2)");   
                    }
                }
                }    
        }
    }
}