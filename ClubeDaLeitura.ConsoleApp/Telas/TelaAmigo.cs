using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaAmigo : TelaBase, ICadastravel
    {
        private ControladorAmigo controladorAmigo;
        public TelaAmigo(ControladorAmigo controlador) : base ("Cadastro de amigos")
        {
            controladorAmigo = controlador;
        }
        override public void InserirRegistro()
        {
            GravarAmigo(0);
        }
        override public void VisualizarRegistro()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Amigo[] amigo = controladorAmigo.SelecionarTodosAmigos();

            if (amigo.Length == 0)
            {
                Console.WriteLine("Nenhum amiguinho registrado!");
                return;
            }

            for (int i = 0; i < amigo.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   amigo[i].id, amigo[i].nomeAmigo, amigo[i].deOnde);
            }
        }
        override public void EditarRegistro()
        {
            Console.Clear();

            VisualizarRegistro();

            if (controladorAmigo.VerificarVazio())
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine();

            Console.Write("Digite o ID do do amiguinho que deseja editar: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            if (!controladorAmigo.IdExiste(idAmigo))
            {
            }
            else
            {
                GravarAmigo(idAmigo);
            }
        }
        override public void ExcluirRegistro()
        {
            VisualizarRegistro();

            if (controladorAmigo.VerificarVazio())
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine();

            Console.Write("Digite o ID do do amiguinho que deseja excluir: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            if (!controladorAmigo.IdExiste(idAmigo))
            {
                Console.WriteLine("Não existe este Id!");
            }
            else
            {
                controladorAmigo.ExcluirAmigo(idAmigo); 
            }
        }
        override public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir um novo amiguinho");
            Console.WriteLine("Digite 2 para visualizar os amiguinhos");
            Console.WriteLine("Digite 3 para editar um amiguinho");
            Console.WriteLine("Digite 4 para excluir um amiguinho");


            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        private void GravarAmigo(int id)
        {
            Console.Write("Digite o nome do amiguinho: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeR = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite de onde é o amiguinho: ");
            string ondeEh = Console.ReadLine();

            controladorAmigo.RegistrarAmigo(id, nome, nomeR, ondeEh, telefone);
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "ID", "AMIGO", "ONDE É");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}
