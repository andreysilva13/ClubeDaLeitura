using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaCaixa : TelaBase, ICadastravel
    {
        private ControladorCaixa controladorCaixa;
        public TelaCaixa(ControladorCaixa controlador) : base ("Cadastro de caixas")
        {
            controladorCaixa = controlador;
        }
        override public void InserirRegistro()
        {
            GravarCaixa(0);
        }
        override public void VisualizarRegistro()
        {
            ConfigurarTela("Visualizando revistas...");
            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Caixa[] caixa = controladorCaixa.SelecionarTodasCaixas();

            if (caixa.Length == 0)
            {
                Console.WriteLine("Nenhuma caixa cadastrada!");
                return;
            }

            for (int i = 0; i < caixa.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   caixa[i].id, caixa[i].corCaixa, caixa[i].etiqueta);
            }
        }

        override public void EditarRegistro()
        {
            Console.Clear();
            ConfigurarTela("Editando uma caixa...");
            VisualizarRegistro();

            if (controladorCaixa.VerificarVazio())
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine();

            Console.Write("Digite o ID do do amiguinho que deseja editar: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            if (!controladorCaixa.IdExiste(idCaixa))
            {
            }
            else
            {
                GravarCaixa(idCaixa);
            }
        }
        override public void ExcluirRegistro()
        {
            VisualizarRegistro();
            ConfigurarTela("Excluindo uma caixa...");
            if (controladorCaixa.VerificarVazio())
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine();

            Console.Write("Digite o ID da caixa que deseja excluir: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            if (!controladorCaixa.IdExiste(idCaixa))
            {
                Console.WriteLine("Não existe este Id!");
            }
            else
            {
                controladorCaixa.ExcluirCaixa(idCaixa);
            }
        }
        override public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir uma nova caixa");
            Console.WriteLine("Digite 2 para visualizar as caixas");
            Console.WriteLine("Digite 3 para editar uma caixa");
            Console.WriteLine("Digite 4 para excluir uma ");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        private void GravarCaixa(int id)
        {
            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Digite o numero da caixa: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a etiqueta da caixa: ");
            string etiq = Console.ReadLine();

            controladorCaixa.RegistrarCaixa(id, cor, numero, etiq);
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "ID", "COR", "ETIQUETA");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}
