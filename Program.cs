using System;
using System.Collections.Generic;

namespace ExercicioFixacacao
{
    internal class Program
    {
        enum Opcoes { Adicionar = 1, AtualizarStatus, ExibirTarefas, SairDoPrograma = 0 };
        enum Status { A_Fazer = 1, Em_Progresso, Concluido };

        static void Main(string[] args)
        {
            List<string> tarefas = new List<string>();
            List<string> status = new List<string>();
            Opcoes opcao;

            Console.WriteLine("== GERENCIADOR DE TAREFAS ==\n");

            do
            {
                opcao = selecionarOpcao();

                switch (opcao)
                {
                    case Opcoes.Adicionar:
                        adicionarTarefa(tarefas, status);
                        break;
                    case Opcoes.AtualizarStatus:
                        atualizarStatus(tarefas, status);
                        break;
                    case Opcoes.ExibirTarefas:
                        exibirTarefas(tarefas, status);
                        break;
                    case Opcoes.SairDoPrograma:
                        Console.WriteLine("\nObrigado por utilizar nossos serviços!");
                        Console.WriteLine("Saindo do programa...");
                        break;
                }

            } while (opcao != Opcoes.SairDoPrograma);
        }

        static Opcoes selecionarOpcao()
        {
            int index = -1;

            do
            {
                try
                {
                    Console.WriteLine("\n== MENU ==");
                    Console.WriteLine("\n[ 1 ] Adicionar Tarefa\n[ 2 ] Atualizar Status de uma Tarefa\n[ 3 ] Exibir Tarefas\n[ 0 ] Sair do Programa\n");
                    Console.Write("Selecione o número da opção desejada: ");
                    index = int.Parse(Console.ReadLine());

                    if (index > 3 || index < 0)
                    {
                        mensagemErro();
                    }
                }
                catch (FormatException)
                {
                    mensagemErro();
                }
            } while (index > 3 || index < 0);

            Opcoes opcaoSelecionada = (Opcoes)index;
            return opcaoSelecionada;
        }

        static void adicionarTarefa(List<string> tarefas, List<string> status)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("== ADICIONAR TAREFAS ==\n");
            Console.Write("Digite a tarefa ([ -1 ] Para retornar ao menu principal): ");
            string tarefa = Console.ReadLine();
            if (tarefa == "-1")
            {
                return;
            }
            tarefas.Add(tarefa);
            status.Add("A fazer");
            Console.WriteLine("========================================================");
        }

        static void atualizarStatus(List<string> tarefas, List<string> status)
        {
            if (tarefas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n== ERRO: POR FAVOR, ADICIONE UMA TAREFA PARA HABILITAR A ATUALIZAÇÃO DE TAREFAS ==\n");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("========================================================");
            Console.WriteLine("== ATUALIZAR TAREFAS ==");
            exibirTarefas(tarefas, status);

            int index = -1;

            do
            {
                try
                {
                    Console.Write("\nEscolha o número da tarefa que deseja atualizar o status ([ -1 ] Para retornar ao menu principal): ");
                    index = int.Parse(Console.ReadLine()) - 1;

                    if (index == -2)
                        return;
                    else if (index < -1 || index >= status.Count)
                        mensagemErro();
                }
                catch (FormatException)
                {
                    mensagemErro();
                    index = -2;
                }
            } while (index < -1 || index >= status.Count);

            Console.Write($"\nTarefa selecionada: {tarefas[index]}\n");

            int statusTarefaInt = -1;

            do
            {
                try
                {
                    Console.Write("\n[ 1 ] A Fazer\n[ 2 ] Em Progresso\n[ 3 ] Concluída\n\nEscolha o número de uma das três opções ([ -1 ] Para retornar ao menu principal): ");
                    statusTarefaInt = int.Parse(Console.ReadLine());

                    if (statusTarefaInt == -1)
                        return;
                    else if (statusTarefaInt < 1 || statusTarefaInt > 3)
                        mensagemErro();
                }
                catch (FormatException)
                {
                    mensagemErro();
                    index = -2;
                }
            } while (statusTarefaInt < 1 || statusTarefaInt > 3);

            Status statusTarefaSelecionada = (Status)statusTarefaInt;

            switch (statusTarefaSelecionada)
            {
                case Status.A_Fazer:
                    status[index] = "A Fazer";
                    break;
                case Status.Em_Progresso:
                    status[index] = "Em Progresso";
                    break;
                case Status.Concluido:
                    status[index] = "Concluída";
                    break;
            }

            Console.WriteLine("\nStatus atualizado com sucesso!\n");
            Console.WriteLine("========================================================");
        }

        static void exibirTarefas(List<string> tarefas, List<string> status)
        {
            if (tarefas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n== ERRO: POR FAVOR, ADICIONE UMA TAREFA PARA HABILITAR A EXIBIÇÃO DA LISTA ==\n");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("== LISTA DE TAREFAS ==\n");
                for (int cont = 0; cont < tarefas.Count; cont++)
                {
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine($"[ {cont + 1} ] -- Tarefa: {tarefas[cont]}\n      -- Status: {status[cont]}");
                    Console.WriteLine("--------------------------------------------------------");
                }
                Console.WriteLine("========================================================");
            }
        }

        static void mensagemErro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n== ERRO: POR FAVOR, DIGITE UMA OPÇÃO VÁLIDA ==");
            Console.ResetColor();
        }
    }
}