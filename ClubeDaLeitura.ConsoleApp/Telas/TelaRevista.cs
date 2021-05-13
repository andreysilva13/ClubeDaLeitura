using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaRevista : TelaBase, ICadastravel
    {

        private ControladorRevista controladorRevista;
        private ControladorCaixa controladorCaixa;
        private TelaCaixa telaCaixa;
        public TelaRevista(ControladorRevista controladorR,ControladorCaixa controladorC ,TelaCaixa telaC) : base ("Cadastro de revistinhas")
        {
            controladorRevista = controladorR;
            controladorCaixa = controladorC;
            telaCaixa = telaC;
        }

        override public void InserirRegistro()
        {
            GravarRevista(0);
        }
        override public void VisualizarRegistro()
        {
            ConfigurarTela("Visualizando revistas...");

            string configuracaColunasTabela = "{0,-10} | {1,-20} | {2,-35} | {3,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Revista[] revista = controladorRevista.SelecionarTodasRevistas();

            if (revista.Length == 0)
            {
                Console.WriteLine("Nenhuma revista cadastrada!");
                return;
            }

            for (int i = 0; i < revista.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   revista[i].id, revista[i].tipoColecao, revista[i].numeroEdicao, revista[i].caixa.corCaixa);
            }
        }
        override public void EditarRegistro()
        {   
            Console.Clear();
            ConfigurarTela("Editando revistas...");

            VisualizarRegistro();

            if (controladorCaixa.VerificarVazio())
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine();

            Console.Write("Digite o ID da revista que deseja editar: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            if (!controladorCaixa.IdExiste(idRevista))
            {
            }
            else
            {
                GravarRevista(idRevista);
            }
        }
        public override void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo uma revista...");
            VisualizarRegistro();

            if (controladorRevista.VerificarVazio())
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine();

            Console.Write("Digite o número da ID da revista que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            if (!controladorRevista.IdExiste(idSelecionado))
            {
            }
            else
            {
                controladorRevista.ExcluirRevista(idSelecionado);
            }
        }
        override public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir uma nova revistinha");
            Console.WriteLine("Digite 2 para visualizar as revistas");
            Console.WriteLine("Digite 3 para editar uma revista");
            Console.WriteLine("Digite 4 para excluir uma revista");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        private void GravarRevista(int id)
        {
            telaCaixa.VisualizarRegistro();

            Console.Write("Digite o ID da caixa: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            ConfigurarTela("Inserindo uma nova Revista...");

            Console.Write("Digite o tipo da coleção da revista: ");
            string tipo = Console.ReadLine();

            Console.Write("Digite o numero da edição da revista: ");
            int preco = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data da revista: ");
            DateTime ano = Convert.ToDateTime(Console.ReadLine());

            controladorRevista.RegistrarRevista(id, idCaixa, tipo, preco, ano);
        }
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "ID", "NOME", "NUMERO EDIÇÃO", "ID DA CAIXA");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}
