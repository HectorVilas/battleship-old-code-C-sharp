using System;

namespace BatallaNaval
{
    //tipo de casillas
    enum casilla
        {
            Libre,
            Barco,
            Atacado,
            Hundido,
        };

    class Program
    {


        //función para dibujar tablero
        static void verTablero(casilla[,] tab, int h, int v, bool oculto=false)
        {
            if(oculto==true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write("╔");
            for (int i = 0; i < h; i++)
            {
                Console.Write("══");
            }
            Console.WriteLine("═╗");
            for (int i = 0; i < v; i++)
            {
                Console.Write("║");
                for (int j = 0; j < h; j++)
                {
                    switch(tab[j,i])
                    {
                        case casilla.Libre:
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("^");
                            break;
                        case casilla.Barco:
                            if(oculto==true)
                            {
                                Console.Write(" ");
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("^");
                            }else{
                                Console.Write(" ");
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("B");
                            }
                            break;
                        case casilla.Atacado:
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("X");
                            break;
                        case casilla.Hundido:
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("#");
                            break;
                        default:
                            Console.Write(" ");
                            Console.Write("?");
                            break;
                    }
                }
            if(oculto==true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
                Console.Write(" ║\n");
            }

            Console.Write("╚");
            for (int i = 0; i < h; i++)
            {
                Console.Write("══");
            }
            Console.WriteLine("═╝");

            Console.ResetColor();

        }
        
        //funcion para comprobar que entrada sea número
        static int entrada()
        {
            int size=0;
            bool funciona=false;

            do
            {
                try
                {
                    size=int.Parse(Console.ReadLine());
                    funciona=true;
                }
                catch
                {
                    funciona=false;
                }
            }

            while(funciona==false || size <= 2 || size > 20);
            return size;
        }

        //función para comprobar ataque en rango y que sea número
        static int ataqueJ(int size)
        {
            int convertido;
            bool funciona=false;
            do
            {
                string texto = Console.ReadLine();
                try
                {
                    convertido = int.Parse(texto);
                    funciona = true;
                }
                catch
                {
                    funciona = false;
                    convertido = 9999;
                }
            }
            while(funciona == false || convertido > size || convertido <= 0);

            return convertido;
        }

        static void menu()
        {
            Console.ResetColor();
            Console.WriteLine(@"  ___   _ _____ _   _    _      _     _  _   ___   ___   _    
 | _ ) /_|_   _/_\ | |  | |    /_\   | \| | /_\ \ / /_\ | |   
 | _ \/ _ \| |/ _ \| |__| |__ / _ \  | .` |/ _ \ V / _ \| |__ 
 |___/_/ \_|_/_/ \_|____|____/_/ \_\ |_|\_/_/ \_\_/_/ \_|____|
");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"
                                  )___(
                           _______/__/_
                  ___     /===========|   ___
 ____       __   [\\\]___/____________|__[///]   __
 \   \_____[\\]__/___________________________\__[//]___
  \40A                                                 |
   \                                                  /");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
");
            Console.ResetColor();
        }

        static void Main()
        {
            Console.Title = "Batalla Naval";
            //tamaño consola
            Console.WindowHeight = 45;
            Console.WindowWidth = 65;

            //declarando variables
            int turnos;
            int atacarH;
            int atacarV;
            int barcosJ;
            int barcosPC;
            
            menu();

            Console.Beep(200,100);Console.Beep(210,100);Console.Beep(220,100);Console.Beep(230,100);
            Console.Beep(240,100);Console.Beep(250,100);Console.Beep(260,100);Console.Beep(270,100);
            Console.Beep(280,100);Console.Beep(40,100);Console.Beep(240,100);Console.Beep(40,100);Console.Beep(280,100);
            
            //asignando tamaño de tablero
            Console.Write("Tamaño de tablero en horizontal: ");
            int horiz=entrada();
            Console.Write("Tamaño de tablero en vertical: ");
            int vert=entrada();

            //creando y rellenando tableros
            casilla [,] tableroPC = new casilla[horiz,vert];
            casilla [,] tableroJ = new casilla[horiz,vert];
                        for (int i = 0; i < vert; i++)
            {
                for (int j = 0; j < horiz; j++)
                {
                    tableroPC[j,i]=casilla.Libre;
                    tableroJ[j,i]=casilla.Libre;
                };
            }

          
            //creando IA
            Random rng = new Random();
            int iaH = rng.Next(0,horiz);
            int iaV = rng.Next(0,vert);  

            
            barcosJ=(horiz+vert)/3;
            barcosPC=(horiz+vert)/3;

            for (int i = 0; i < barcosJ; i++)
            {
                
                int h;
                int v;
                
                do
                {
                    h = rng.Next(0,horiz);
                    v = rng.Next(0,vert);
                    
                }
                while(tableroJ[h,v] == casilla.Barco);
                {
                    tableroJ[h,v]=casilla.Barco;
                }

                do
                {
                    h = rng.Next(0,horiz);
                    v = rng.Next(0,vert);
                    
                }
                while(tableroPC[h,v] == casilla.Barco);
                {
                    tableroPC[h,v]=casilla.Barco;
                }
            }



            //calculando total de turnos
            turnos=horiz*vert;
            


            //iniciando juego
            while(barcosJ > 0 && barcosPC > 0)
            {

                //turno jugador
                do
                {
                    Console.Clear();
                    menu();
                    Console.WriteLine("Turnos restantes: {0}", turnos);
                    Console.WriteLine("Barcos jugador: {0}\nBarcos PC: {1}",barcosJ,barcosPC);//-------------
                    verTablero(tableroPC, horiz, vert, true);
                    verTablero(tableroJ, horiz, vert);

                    Console.Write("\nAtaque H: ");
                    atacarH=ataqueJ(horiz);
                    Console.Write("Ataque V: ");
                    atacarV=ataqueJ(vert);
                }
                while(tableroPC[atacarH-1,atacarV-1] != casilla.Libre && tableroPC[atacarH-1,atacarV-1] != casilla.Barco);
                {
                    switch(tableroPC[(atacarH-1),(atacarV-1)])
                    {
                        case casilla.Barco:
                            tableroPC[(atacarH-1),(atacarV-1)]= casilla.Hundido;
                            barcosPC--;
                            int duracion=80;
                            Console.Beep(400,duracion);Console.Beep(410,duracion);Console.Beep(420,duracion);
                            Console.Beep(430,duracion);Console.Beep(440,duracion);Console.Beep(450,duracion);
                            Console.Beep(460,duracion);Console.Beep(470,duracion);
                            break;
                        case casilla.Libre:
                            tableroPC[(atacarH-1),(atacarV-1)]= casilla.Atacado;
                            break;
                    }
                }


                //turno pc
                do
                {
                    iaH = rng.Next(0,horiz);
                    iaV = rng.Next(0,vert);
                    
                }
                while(tableroJ[iaH,iaV]!=casilla.Libre && tableroJ[iaH,iaV]!=casilla.Barco);
                {
                    //tableroJ[iaH,iaV]=casilla.Atacado;
                    switch(tableroJ[iaH,iaV])
                    {
                        case casilla.Libre:
                            tableroJ[iaH,iaV]=casilla.Atacado;
                            break;
                        case casilla.Barco:
                            tableroJ[iaH,iaV]=casilla.Hundido;
                            barcosJ--;
                            int duracion=100;
                            Console.Beep(470,duracion);Console.Beep(460,duracion);Console.Beep(450,duracion);Console.Beep(440,duracion);
                            Console.Beep(430,duracion);Console.Beep(420,duracion);Console.Beep(410,duracion);Console.Beep(400,duracion);
                            break;
                    }
                };
                turnos--;
            };

            //fin del juego, pantalla final
            Console.Clear();
            menu();
            Console.WriteLine("Turnos restantes: {0}", turnos);
            Console.WriteLine("Barcos jugador: {0}\nBarcos PC: {1}",barcosJ,barcosPC);
            verTablero(tableroPC, horiz, vert);
            verTablero(tableroJ, horiz, vert);
            Console.Write("Fin del juego. Gana ");
            if(barcosPC==0)
            {
                Console.Write("el jugador.");
            }
            else
            {
                Console.Write("PC.");
            }

            Console.Beep(300,1000);Console.Beep(330,900);Console.Beep(300,500);Console.Beep(330,400);
            Console.Beep(300,500);Console.Beep(300,100);Console.Beep(450,1700);Console.Beep(400,400);
            Console.Beep(370,400);Console.Beep(350,1700);Console.Beep(40,300);Console.Beep(450,700);
            Console.Beep(430,1500);Console.Beep(40,1000);

            //Console.ReadKey();
            
        }
    }
}