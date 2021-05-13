using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorRevista : ControladorBase
    {   
        private ControladorCaixa controladorCaixa;

        public ControladorRevista (int n, ControladorCaixa controladorC) : base(n)
        {
            controladorCaixa = controladorC;
        }
        public void RegistrarRevista(int id, int idC, string nome, int numero, DateTime ano)
        {
            Revista revista = null;

            int posicao;

            if (id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Revista(id));
                revista = (Revista)registros[posicao];
            }
            revista.caixa = controladorCaixa.SelecionarCaixasPorId(idC);
            revista.tipoColecao = nome;
            revista.numeroEdicao = numero;
            revista.anoDaRevista = ano;

            registros[posicao] = revista;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistroPorId(new Revista(id));
        }

        public Revista[] SelecionarTodasRevistas()
        {
            Revista[] revistaAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistaAux, revistaAux.Length);

            return revistaAux;
        }

        internal bool IdExiste(int idSelecionado)
        {
            Revista[] revista = SelecionarTodasRevistas();

            for (int i = 0; i < revista.Length; i++)
            {
                if (revista[i].id == idSelecionado)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
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
