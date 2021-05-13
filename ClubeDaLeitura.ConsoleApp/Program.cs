using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Telas;

namespace ClubeDaLeitura.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ControladorAmigo controladorAmigo = new ControladorAmigo(100);
            ControladorCaixa controladorCaixa = new ControladorCaixa(100);
            ControladorRevista controladorRevista = new ControladorRevista(100, controladorCaixa);
            ControladorEmprestimo controladorEmprestimo = new ControladorEmprestimo(100, controladorRevista, controladorAmigo);


            TelaAmigo telaAmigo = new TelaAmigo(controladorAmigo);
            TelaCaixa telaCaixa = new TelaCaixa(controladorCaixa);
            TelaRevista telaRevista = new TelaRevista(controladorRevista, controladorCaixa, telaCaixa);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(controladorEmprestimo, telaRevista, telaAmigo);

            TelaPrincipal telaPrincipal = new TelaPrincipal(
                controladorAmigo, telaRevista, telaEmprestimo, telaAmigo, telaCaixa, controladorEmprestimo, controladorRevista, controladorCaixa);

            while (true)
            {
                TelaBase telaSelecionada = telaPrincipal.ObterOpcao();

                if (telaSelecionada == null)
                    break;

                Console.Clear();

                string opcao = telaSelecionada.ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (((telaSelecionada is ICadastravel)))
                {
                    if (opcao == "1")
                        telaSelecionada.InserirRegistro();

                    else if (opcao == "2")
                    {
                        telaSelecionada.VisualizarRegistro();
                        Console.ReadLine();
                    }

                    else if (opcao == "3")
                    {
                        telaSelecionada.EditarRegistro();
                    }

                    else if (opcao == "4")
                        telaSelecionada.ExcluirRegistro();
                }
                else if ((!(telaSelecionada is ICadastravel)))
                {
                    telaEmprestimo = (TelaEmprestimo)telaSelecionada;

                    if (opcao == "1")
                        telaEmprestimo.RealizarEmprestimo();

                    else if (opcao == "2")
                    telaEmprestimo.RegistrarDevolucao();

                    else if (opcao == "3")
                    {
                        telaEmprestimo.TelaVisualizarEmprestimos(out opcao);
                             if (opcao == "1")
                            telaEmprestimo.VisualizarEmprestimosAbertos();
                        else if (opcao == "2")
                            telaEmprestimo.VisualizarEmprestimosPorMes();
                    }
                }
                Console.Clear();
            }
        }
    }
}
