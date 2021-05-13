using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    class TelaPrincipal
    {
        private ControladorAmigo controladorAmigo;
        private ControladorEmprestimo controladorEmprestimo;
        private ControladorRevista controladorRevista;
        private ControladorCaixa controladorCaixa;
        private TelaAmigo telaAmigo;
        private TelaCaixa telaCaixa;
        private TelaEmprestimo telaEmprestimo;
        private TelaRevista telaRevista;

        public TelaPrincipal(ControladorAmigo ctlrAmigo,
            TelaRevista tlRevista, TelaEmprestimo tlEmprestimo,
            TelaAmigo tlAmigo, TelaCaixa tlCaixa,
            ControladorEmprestimo ctlrEmprestimo,
            ControladorRevista ctrlRevista, ControladorCaixa ctrlCaixa)
        {
            controladorCaixa = ctrlCaixa;
            controladorRevista = ctrlRevista;
            controladorEmprestimo = ctlrEmprestimo;
            controladorAmigo = ctlrAmigo;
            telaRevista = tlRevista;
            telaAmigo = tlAmigo;
            telaCaixa = tlCaixa;
            telaEmprestimo = tlEmprestimo;
        }
        
        public TelaBase ObterOpcao()
        {
            string opcao;
            TelaBase telaSelecionada = null;
            do
            {
                Console.Clear();

                Console.WriteLine("Digite 1 para o Cadastro de Revista");
                Console.WriteLine("Digite 2 para o Cadastro de Caixa");
                Console.WriteLine("Digite 3 para o Cadastro de Amigos");
                Console.WriteLine("Digite 4 para o controle de Emprestimos");

                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao == "1")
                    telaSelecionada = new TelaRevista(controladorRevista, controladorCaixa, telaCaixa);

                else if (opcao == "2")
                    telaSelecionada = new TelaCaixa(controladorCaixa);

                else if (opcao == "3")
                    telaSelecionada = new TelaAmigo(controladorAmigo);

                else if (opcao == "4")
                {
                    telaSelecionada = new TelaEmprestimo(controladorEmprestimo, telaRevista, telaAmigo);
                }
                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;
            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }


        private bool OpcaoInvalida(string opcao)    
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "S" && opcao != "s")
            {
                Console.WriteLine("Opção inválida");
                Console.ReadLine();
                return true;
            }
            else
                return false;
        }


    }
}
