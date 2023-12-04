using caixaSaqueConsole.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixaSaqueConsole
{
    class Program
    {
        static List<Nota> notaDisponiveis = new List<Nota>();


        static void Main(string[] args)
        {
            setaQuantidades();

            string entrada = "-1";
            int valorSaque = 0;
            
            Console.WriteLine("-----------------");
            Console.WriteLine("Saque");
            Console.WriteLine("-----------------");

            Console.WriteLine("Digite o valor do seu saque ou 0 para sair");                        


            while (!int.Parse(entrada).Equals(0))
            {
                entrada = Console.ReadLine();

                if (int.TryParse(entrada, out valorSaque))
                {
                    if (valorSaque > 0)
                    {
                        if ((valorSaque % 10) == 0)
                        {
                            entrada = saque(valorSaque).ToString();
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido. Apenas multiplos 10");
                        }
                    }
                }            
                else
                {
                    Console.WriteLine("Valor invalido. Tente novamente ou digite 0 para sair");
                    entrada = "-1";
                }
            }

            Console.WriteLine("Fim da operação! Obrigado!");
            Console.Read();
        }

        static int saque(int valor)
        {
            if (valor > SomaValorCaixa())
            {
                Console.WriteLine("Saldo em caixa insuficiente para este saque");
            }
            else
            {
                StringBuilder saidaNotas = new StringBuilder();

                foreach(var nota in notaDisponiveis)                
                {
                    if (nota.QuantNota == 0) continue;

                    int quantidade = valor / nota.ValorNota;
                    int quantidadeNecessaria = quantidade;

                    if (quantidade > nota.QuantNota)
                    {
                        quantidade = nota.QuantNota;
                    }

                    nota.QuantNota -= quantidade;


                    if (quantidade > 0)
                    {
                        saidaNotas.Append($"{quantidade} cedulas(s) de {nota.ValorNota} - Total: {nota.ValorNota * quantidade} ");
                        saidaNotas.Append(Environment.NewLine);

                        valor = valor - (nota.ValorNota * quantidade);

                        if (quantidadeNecessaria == quantidade) valor = (valor % nota.ValorNota);
                    }                                       
                }
                

                Console.WriteLine(saidaNotas);               
            }

            return 0;
        }

        static void setaQuantidades()
        {
            //Total disponivel 4000

            notaDisponiveis.Add(new Nota { ValorNota = 100, QuantNota = 10 });
            notaDisponiveis.Add(new Nota { ValorNota = 50, QuantNota = 20 });
            notaDisponiveis.Add(new Nota { ValorNota = 20, QuantNota = 50 });
            notaDisponiveis.Add(new Nota { ValorNota = 10, QuantNota = 100 });
            
        }

        static int SomaValorCaixa()
        {
            int soma = 0;

            foreach (var item in notaDisponiveis)
            {
                soma += (item.ValorNota * item.QuantNota);
            }

            return soma;

        }
    }
}
