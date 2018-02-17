using System;

namespace JogoVelha
{
    class Program
    {
        public static string jog1 = "jogador 1", jog2 = "jogador 2", oponente = "";

        static void Main(string[] args)
        {
            //jogador 1
            int vitoriaj1=0, vitoriaj2=0, total=0;
            int contador = 0, escolha =0;
            bool vitoria = false;
            string[] matrizjogo = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };


            Console.WriteLine("Digite o nome do" + jog1);
            jog1 = Console.ReadLine();
            //jogador 2
            do
            {
                Console.WriteLine("Qual oponente " + jog1 + " enfrentará?\nH=Humano,\nC = Computador");
                oponente = Console.ReadLine();
                if (oponente.ToUpper() == "H" || oponente.ToUpper() == "HUMANO")
                {
                    Console.WriteLine("Digite o nome do" + jog2);
                    jog2 = Console.ReadLine();
                }
                else if (oponente.ToUpper() == "C" || oponente.ToUpper() == "COMPUTADOR")
                {
                    jog2 = "Computador";
                }
                else {
                    oponente = "incorreto";
                }
            } while (oponente == "incorreto");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            //tabuleiro
            mostrarTabuleiro(matrizjogo);
            contador = 1;
            do
            {
                if (contador % 2 != 0)
                {
                    Console.WriteLine("\n" + jog1 + ", escolha uma posição");
                    escolha = int.Parse(Console.ReadLine());
                    if (escolha <1||escolha>9) {
                        Console.WriteLine("Opcao Invalida!");
                    }
                    else{
                        MarcaEscolha(matrizjogo, escolha, jog1);
                        Console.Clear();
                        mostrarTabuleiro(matrizjogo);
                        vitoria = VerificaVitoria():
                    }
                }
                else {


                    Console.WriteLine("\n" + jog2 + ", escolha uma posição");
                    escolha = int.Parse(Console.ReadLine());

                    if (escolha < 1 || escolha > 9)
                    {
                        Console.WriteLine("Opcao Invalida!");
                    }
                    else
                    {
                        MarcaEscolha(matrizjogo, escolha, jog2);
                        Console.Clear();
                        mostrarTabuleiro(matrizjogo);


                    }

                }
                contador++;



            } while (vitoria == false);


            Console.ReadKey();

        }
        public static void mostrarTabuleiro(string[] matrizjogo) {
            int contador = 0;
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("\t" + matrizjogo[contador] + "|");
                    contador++;
                }
            }

        }
        public static string[] MarcaEscolha(string[] matrizjogo, int escolha, string jogador) {
            string marcacao = "X";
            if (jogador == jog2)
                marcacao = "O";
            if (matrizjogo[escolha - 1] == "X" || matrizjogo[escolha - 1] == "O")
            {
                Console.WriteLine("Ja escolhido!");
                System.Threading.Thread.Sleep(700);
                return matrizjogo;
            }
            else {
                matrizjogo[escolha - 1] = marcacao;
            }
            return matrizjogo;



        }
        public static bool VerificaVitoria(string[] matrizjogo) {

            int contador = 0;
            for (int i = 0; i < 3; i++)
            {


                for (int j = 0; j < 3; j++)
                {
                    if (matrizjogo[contador] == matrizjogo[contador + 3] && matrizjogo[contador + 6] == matrizjogo[contador])
                        return true;
                    if (matrizjogo[contador] == matrizjogo[contador + 1] && matrizjogo[contador] == matrizjogo[contador + 2])
                        return true;
                }
            }
            return true;
        }

    }
}
