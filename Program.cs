﻿//Program.cs
//O programa executa um cronômetro em tempo real
//O usuário insere o tempo final e o cronômetro inicia

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

            string time = Console.ReadLine().ToLower(); //tempo string
            
            CalcularTempo(time);
        }

        static void CalcularTempo(string time) 
        {
            int posH = 0, posM = 0, posS = 0; //posição de h, m e s na string
            int tamH = 0, tamM = 0, tamS = 0; //tamanho hora, minuto e segundo

            //obter posições e tamanho da hora, minuto e segundo
            for (int i = 0; i < time.Length; i++) 
            {
                char caractere = time[i];
                if (caractere == 'h') {posH = i; tamH = posH - 0;}
                if (caractere == 'm') {posM = i; tamM = posM - (posH + 2);}
                if (caractere == 's') {posS = i; tamS = posS - (posM + 2);}
            }


            //tranformar partes da string pra inteiro, extraindo cada unidades de tempo
            int hora = 0, minuto = 0, segundo = 0;

            if(posH > 0) hora = int.Parse(time.Substring(0, tamH));
            if(posM > 0) minuto = int.Parse(time.Substring(posH+2, tamM));
            if(posS > 0) segundo = int.Parse(time.Substring(posM+2, tamS));

            int tempo = segundo + 60*minuto + 360*hora;

            Start(tempo);
        }

        static void Start(int time) //time = tempo total em segundos
        {
            int currentTime = 0;                 //tempo percorrido em segundos. 
            int timeS = 0, timeM = 0, timeH = 0; //tempo em segundo, minuto e hora

            //enquanto o tempo percorrido for diferente do tempo inserido + 1 segundo, pois vai iniciar em zero
            while (currentTime != (time + 1)) 
            {
                Console.Clear();
                currentTime++;

                if (timeS == 60) {timeS = 0; timeM++;} //60 segundos = 1 minuto
                if (timeM == 60) {timeM = 0; timeH++;} //60 minutos = 1 hora

                Console.WriteLine(timeH + ":" + timeM + ":" + timeS);

                Thread.Sleep(1000); //espera 1 segundo

                timeS++;
                
            } 

            Thread.Sleep(1000);
            Console.WriteLine("Stopwatch finalizado!");
            Thread.Sleep(5000);
        }
    }
}
