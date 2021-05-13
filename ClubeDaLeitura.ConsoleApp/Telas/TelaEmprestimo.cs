using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaEmprestimo : TelaBase
    {
        private ControladorEmprestimo controladorEmprestimo;
        private TelaRevista telaRevista;
        private TelaAmigo telaAmigo;
        public TelaEmprestimo(ControladorEmprestimo controlador, TelaRevista telaR, TelaAmigo telaA) : base ("Controle de empréstimo")
        {
            controladorEmprestimo = controlador;
            telaRevista = telaR;
            telaAmigo = telaA;
        }

        public void RealizarEmprestimo()
        {
            GravarEmprestimo(0);
        }

        internal void TelaVisualizarEmprestimos(out string opcao)
        {
            Console.WriteLine("Digite 1 para visualizar os emprestimos em aberto");
            Console.WriteLine("Digite 2 para visualizar os emprestimos por mês");

            Console.WriteLine("Digite S para sair");

            opcao = Console.ReadLine();
        }
        override public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para fazer um emprestimo");
            Console.WriteLine("Digite 2 para registrar uma devolução");
            Console.WriteLine("Digite 3 para visualizar emprestimos");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void VisualizarEmprestimosAbertos()
        {
            ConfigurarTela("Visualizando emprestimos abertos...");

            Emprestimo[] emprestimo = controladorEmprestimo.SelecionarTodosEmprestimos();

            if (emprestimo.Length == 0)
            {
                Console.WriteLine("Nenhum emprestimo cadastrado");
                Console.ReadLine();
                return;
            }

            int contador = 0;

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].estaAtivo)
                    contador++;
            }

            if (contador == 0)
            {
                Console.WriteLine("Nenhum emprestimo ativo");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Existe {contador} emprestimo(s) ativos.");
            Console.WriteLine();

            string configuracaColunasTabela = "{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].estaAtivo)
                    Console.WriteLine(configuracaColunasTabela,
                       emprestimo[i].id, emprestimo[i].revistinha.id, emprestimo[i].amiguinho.id, emprestimo[i].dataEmprestimo.ToString(),
                       emprestimo[i].dataDevolucao.ToString());
            }
            Console.ReadLine();
        }

        public void VisualizarEmprestimosPorMes()
        {
            ConfigurarTela("Visualizando emprestimos no mês...");

            Console.Write("Digite o número do mês que deseja visualizar ");
            int mes = Convert.ToInt32(Console.ReadLine());

            Emprestimo[] emprestimo = controladorEmprestimo.SelecionarTodosEmprestimos();

            if (emprestimo.Length == 0)
            {
                Console.WriteLine("Nenhum emprestimo cadastrado");
                Console.ReadLine();
                return;
            }

            int contador = 0;

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].dataEmprestimo.Month == mes)
                {
                    contador++;
                }
            }

            if (contador == 0)
            {
                Console.WriteLine("Nenhum emprestimo nesse mês");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Existe {contador} emprestimo(s) neste mês.");
            Console.WriteLine();

            string configuracaColunasTabela = "{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].dataEmprestimo.Month == mes)
                    Console.WriteLine(configuracaColunasTabela,
                        emprestimo[i].id, emprestimo[i].revistinha.id, emprestimo[i].amiguinho.id, emprestimo[i].dataEmprestimo.ToString(),
                        emprestimo[i].dataDevolucao.ToString());
            }
            Console.ReadLine();
        }

        internal void RegistrarDevolucao()
        {
            VisualizarRegistro();

            if (controladorEmprestimo.VerificarVazio())
            {
                Console.ReadLine();
                return;
            }

            if (!controladorEmprestimo.VerificarSeExisteEmprestimosAtivos())
            {
                Console.ReadLine(); return;
            }

            Console.Write("Digite o ID do emprestimo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (!controladorEmprestimo.IdExiste(id))
            {
                Console.Write("Não existe esse ID ");
                Console.ReadLine();
                return;
            }

            Emprestimo emprestimo;

            emprestimo = controladorEmprestimo.SelecionarEmprestimoPorId(id);

            emprestimo.estaAtivo = false;

            Console.Write("Devolvido com sucesso");
            Console.ReadLine();
        }

        override public void VisualizarRegistro()
        {
            ConfigurarTela("Visualizando emprestimos...");

            string configuracaColunasTabela = "{0,-5} | {1,-10} | {2,-10} | {3,-25} | {4,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Emprestimo[] emprestimo = controladorEmprestimo.SelecionarTodosEmprestimos();

            if (emprestimo.Length == 0)
            {
                Console.WriteLine("Nenhum emprestimo ativo");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < emprestimo.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   emprestimo[i].id, emprestimo[i].revistinha.id, emprestimo[i].amiguinho.id, emprestimo[i].dataEmprestimo.ToString(),
                   emprestimo[i].dataDevolucao.ToString());
            }
            Console.WriteLine();
        }


        private void GravarEmprestimo(int id)
        {
            telaAmigo.VisualizarRegistro();

            Console.Write("Digite o ID do amiguinho que esta emprestando: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            telaRevista.VisualizarRegistro();
            Console.Write("Digite o ID da revista que esta emprestando: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.Write("Digite a data do empréstimo: ");
            DateTime ano = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a data de devolução: ");
            DateTime anoD = Convert.ToDateTime(Console.ReadLine());

            controladorEmprestimo.RealizarEmprestimo(id, idAmigo, idRevista, ano, anoD);
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "ID", "ID REVISTA", "ID AMIGO", "Data do Emprestimo", "Data de Devolução");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}
