using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorEmprestimo : ControladorBase
    {
        private ControladorRevista controladorRevista;
        private ControladorAmigo controladorAmigo;

        public ControladorEmprestimo(int n, ControladorRevista controladorR, ControladorAmigo controladorA) : base (n)
        {
            controladorRevista = controladorR;
            controladorAmigo = controladorA;
        }

        public void RealizarEmprestimo(int id, int idA, int idR, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            Emprestimo emprestimo = null;

            int posicao;

            if (id == 0)
            {
                emprestimo = new Emprestimo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Emprestimo(id));
                emprestimo = (Emprestimo)registros[posicao];
            }
            emprestimo.amiguinho = controladorAmigo.SelecionarAmigosPorId(idA);
            emprestimo.revistinha = controladorRevista.SelecionarRevistaPorId(idR);
            emprestimo.dataEmprestimo = dataEmprestimo;
            emprestimo.dataDevolucao = dataDevolucao;
            emprestimo.estaAtivo = true;

            registros[posicao] = emprestimo;
        }

        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            return (Emprestimo)SelecionarRegistroPorId(new Emprestimo(id));
        }

        public Emprestimo[] SelecionarTodosEmprestimos()
        {
            Emprestimo[] emprestimosAux = new Emprestimo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), emprestimosAux, emprestimosAux.Length);

            return emprestimosAux;
        }

        public bool VerificarSeExisteEmprestimosAtivos()
        {
            Emprestimo[] emprestimo = SelecionarTodosEmprestimos();

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].estaAtivo)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarSeRevistaEstaEmprestada(int id)
        {
            Emprestimo[] emprestimo = SelecionarTodosEmprestimos();

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].revistinha.id == id && emprestimo[i].estaAtivo)
                {
                    return true;
                }
            }
            return false;
        }

        internal bool IdExiste(int id)
        {
            Emprestimo[] emprestimo = SelecionarTodosEmprestimos();

            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i].id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarVazio()
        {
            foreach (var r in registros)
            {
                if (r != null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
