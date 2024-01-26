  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaLaDog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operacao = 0;

            while (operacao != 9)
            {
                Console.WriteLine("Bem vindo ao sistema LaLaDOG");

                Console.WriteLine("1 - Calculo de medicação");
                Console.WriteLine("2 - Calculo de custo do banho");
                Console.WriteLine("3 - Calculo de disponibilidade de ração");
                Console.WriteLine("9 - Sair");

                // Espera o usuário digitar a operação
                int.TryParse(Console.ReadLine(), out  operacao);

                if (operacao == 9)
                {
                    // Limpa todas as mensagens do console.
                    Console.Clear();

                    Console.WriteLine("Obrigado por utilizar nosso sistema.");
                    Console.WriteLine("Tenha um bom dia!");

                    // Aguarda 2 segundos para dar tempo de leitura
                    Thread.Sleep(2000);

                    // Fecha o programa.
                    Environment.Exit(0);
                }

                if (operacao == 1)
                {
                    // Limpa todas as mensagens do console.
                    Console.Clear();

                    Console.WriteLine("Vamos realizar o calculo de medicação do pet");

                    decimal peso = (decimal) SolicitaInformacao("Qual o peso do animal?", "decimal");
                    decimal dose_kg = (decimal) SolicitaInformacao("Qual a dose por kg do medicamento?", "decimal");

                    decimal dose = peso * dose_kg;

                    Console.WriteLine($"A dose total do medicamento deve ser de {dose}");

                    // Espera o usuário sair da operação
                    Console.ReadKey();

                    // Limpa a tela
                    Console.Clear();
                }

                else if (operacao == 2)
                {
                    // Limpa todas as mensagens do console.
                    Console.Clear();

                    Console.WriteLine("Vamos realizar o calculo de custo para o banho!");

                    string porte = (string)SolicitaInformacao("Qual o porte do seu pet (p,m,g)?", "string");

                    string cuidados_extras = (string)SolicitaInformacao("Deseja adicionar cuidados extras (s,n)?", "string");

                    bool parasitas = false;
                    bool aparar = false;
                    bool shampoo = false;

                    if (cuidados_extras == "s")
                    {
                        int cuidado_extra = 0;

                        while (cuidado_extra != 4)
                        {
                            Console.WriteLine("Quais cuidados deseja?");
                            Console.WriteLine($"[{(parasitas ? "x" : " ")}] 1 - Remover parasitas");
                            Console.WriteLine($"[{(aparar ? "x" : " ")}] 2 - Aparar pelos");
                            Console.WriteLine($"[{(shampoo ? "x" : " ")}] 3 - Usar shampoo premium");
                            Console.WriteLine("Digite 4 para parar de adicionar");

                            cuidado_extra = (int)SolicitaInformacao("", "int");

                            // Alterna o valor dos serviços extras
                            if (cuidado_extra == 1)
                                parasitas = !parasitas;
                            if (cuidado_extra == 2)
                                aparar = !aparar;
                            if (cuidado_extra == 3)
                                shampoo = !shampoo;

                            Console.Clear();
                        }
                    }

                    decimal valor_total = 0;

                    if (porte == "p")
                        valor_total += 80;
                    else if (porte == "m")
                        valor_total += 100;
                    else if (porte == "g")
                        valor_total += 120;

                    // Teste ternário para somar os valores extras
                    valor_total += parasitas ? 20 : 0;
                    valor_total += aparar ? 20 : 0;
                    valor_total += shampoo ? 20 : 0;

                    Console.WriteLine($"O valor total do banho é de {valor_total}");

                    // Espera o usuário sair da operação
                    Console.ReadKey();

                    // Limpa a tela
                    Console.Clear();
                }

                else if (operacao == 3)
                {
                    // Limpa todas as mensagens do console.
                    Console.Clear();

                    Console.WriteLine("Vamos realizar o calculo de ração disponível!");

                    decimal racao_disponivel = (decimal)SolicitaInformacao("Quanto de ração está disponível em kg?", "decimal");
                    int quantidade_pets = (int)SolicitaInformacao("Qual a quantidade de pets no Local?", "int");
                    int dias = (int)SolicitaInformacao("Quantos dias os pets irão ficar?", "int");

                    decimal custo_total = (quantidade_pets * 0.1m) * dias;

                    if (racao_disponivel >= custo_total)
                    {
                        Console.WriteLine("Você possui ração suficente para todos os dias");
                    } 
                    else
                    {
                        Console.WriteLine($"É melhor comprar ração, vai faltar {custo_total - racao_disponivel} kg de ração");
                    }

                    // Espera o usuário sair da operação
                    Console.ReadKey();

                    // Limpa a tela
                    Console.Clear();
                }
            }
        }

        //
        // Resumo:
        //     Função que mostra uma mensagem e retorna um valor informado pelo console
        //
        // Parâmetros:
        //   mensagem:
        //     A mensagem a ser mostrada
        //
        //   tipo:
        //     O tipo de retorno (decimal, int, string)
        //
        static object SolicitaInformacao(string mensagem, string tipo)
        {
            decimal valor_decimal;
            int valor_inteiro;

            // Verifica se a mensagem tem mais de 0 caracteres
            if (mensagem.Length > 0)
                Console.WriteLine(mensagem);

            if (tipo == "string")
                return Console.ReadLine();
            else if (tipo == "decimal")
            {
                decimal.TryParse(Console.ReadLine(), out valor_decimal);
                return valor_decimal;
            }
            else if (tipo == "int")
            {
                int.TryParse(Console.ReadLine(), out valor_inteiro);
                return valor_inteiro;
            }

            return "";
        }
    }
}
