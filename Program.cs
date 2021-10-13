using System;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu() 
        {
            Console.Clear();
            Console.WriteLine("Tempo:");
            Console.WriteLine("h - hora");
            Console.WriteLine("m - minuto");
            Console.WriteLine("s - segundo");
            Console.WriteLine("Quanto tempo deseja contar?");
            Console.WriteLine("Exemplo de formato:");
            Console.WriteLine("1h 10m 40s => 1 hora, 10 minutos e 40 segundos");

            string data = Console.ReadLine().ToLower();
            
            int posH = 0, posM = 0, posS = 0;
            int tamH = 0, tamM = 0, tamS = 0;

            for (int i = 0; i < data.Length; i++) {
                char caractere = data[i];
                if (caractere == 'h') {posH = i; tamH = posH - 0;}
                if (caractere == 'm') {posM = i; tamM = posM - (posH + 2);}
                if (caractere == 's') {posS = i; tamS = posS - (posM + 2);}
            }

            int hora = 0, minuto = 0, segundo = 0;

            if(posH > 0) hora = int.Parse(data.Substring(0, tamH));
            if(posM > 0) minuto = int.Parse(data.Substring(posH+2, tamM));
            if(posS > 0) segundo = int.Parse(data.Substring(posM+2, tamS));

            int tempo = segundo + 60*minuto + 360*hora;

            Start(tempo);

            Console.WriteLine($"{hora}h {minuto}m {segundo}s");
        }

        static void Start(int time) 
        {
            int currentTime = 0;
            int timeS = 0, timeM = 0, timeH = 0;

            while (currentTime != time) 
            {
                Console.Clear();
                currentTime++;
                if (timeS == 60) {timeS = 0; timeM++;}
                if (timeM == 60) {timeM = 0; timeH++;}

                Console.WriteLine(timeH + ":" + timeM + ":" + timeS);

                Thread.Sleep(1000); //dormir 1 segundo
                
                timeS++;
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finalizado!");
            Thread.Sleep(5000);
        }
    }
}
