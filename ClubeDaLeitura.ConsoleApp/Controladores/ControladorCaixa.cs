using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorCaixa : ControladorBase
    {
        public ControladorCaixa(int n) : base(n)
        {
        }
        public void RegistrarCaixa(int id, string cor, int numero, string etiqueta)
        {
            Caixa caixa = null;

            int posicao;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Caixa(id));
                caixa = (Caixa)registros[posicao];
            }
            caixa.corCaixa = cor;
            caixa.numero = numero;
            caixa.etiqueta = etiqueta;

            registros[posicao] = caixa;
        }

        public Caixa SelecionarCaixasPorId(int id)
        {
            return (Caixa)SelecionarRegistroPorId(new Caixa(id));
        }

        public Caixa[] SelecionarTodasCaixas()
        {
            Caixa[] caixasAux = new Caixa[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), caixasAux, caixasAux.Length);

            return caixasAux;
        }

        internal bool IdExiste(int id)
        {
            Caixa[] caixa = SelecionarTodasCaixas();

            for (int i = 0; i < caixa.Length; i++)
            {
                if (caixa[i].id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExcluirCaixa(int idSelecionado)
        {
            return ExcluirRegistro(new Caixa(idSelecionado));
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
