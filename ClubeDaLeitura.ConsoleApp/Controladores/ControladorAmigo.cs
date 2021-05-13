using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorAmigo : ControladorBase
    {
        public ControladorAmigo(int n) : base(n)
        {
        }

        public void RegistrarAmigo(int id, string nome, string nomeR, string ondeEh, string telefone)
        {
            Amigo amigo;

            int posicao;

            if (id == 0)
            {
                amigo = new Amigo();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Amigo(id));
                amigo = (Amigo)registros[posicao];
            }
            amigo.nomeAmigo = nome;
            amigo.nomeReponsavel = nomeR;
            amigo.deOnde = ondeEh;
            amigo.telefone = telefone;

            registros[posicao] = amigo;
        }
        public Amigo SelecionarAmigosPorId(int id)
        {
            return (Amigo)SelecionarRegistroPorId(new Amigo(id));
        }
        public Amigo[] SelecionarTodosAmigos()
        {
            Amigo[] amigoAux = new Amigo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), amigoAux, amigoAux.Length);

            return amigoAux;
        }
        public bool ExcluirAmigo(int idSelecionado)
        {
            return ExcluirRegistro(new Amigo(idSelecionado));
        }
        internal bool IdExiste(int idSelecionado)
        {
            Amigo[] amigo = SelecionarTodosAmigos();

            for (int i = 0; i < amigo.Length; i++)
            {
                if (amigo[i].id == idSelecionado)
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
