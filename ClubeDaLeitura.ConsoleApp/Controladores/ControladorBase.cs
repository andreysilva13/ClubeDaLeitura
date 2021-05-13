using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorBase
    {   
        protected DominioBase[] registros = null;

        public ControladorBase(int n)
        {
            registros = new DominioBase[n];
        }

        protected bool ExcluirRegistro(DominioBase obj)
        {
            bool conseguiu = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].id == obj.id)
                {
                    registros[i] = null;
                    conseguiu = true;
                    break;
                }
            }
            return conseguiu;
        }
        public object SelecionarRegistroPorId(object obj)
        {
            object registro = null;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
                {
                    registro = registros[i];

                    break;
                }
            }

            return registro;
        }
        protected object SelecionarRegistro(DominioBase obj)
        {
            foreach (var item in registros)
            {
                if (item != null && item.Equals(obj))
                {
                    return item;
                }
            }
            return null;
        }
        protected int ObterPosicaoVaga()
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        protected int ObterPosicaoOcupada(DominioBase obj)
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj)) //editando...
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        protected object[] SelecionarTodosRegistros()
        {
            object[] registrosAux = new object[QtdRegistrosCadastrados()];

            int i = 0;

            foreach (object registro in registros)
            {
                if (registro != null)
                    registrosAux[i++] = registro;
            }

            return registrosAux;
        }
        protected int QtdRegistrosCadastrados()
        {
            int numeroRegistrosCadastrados = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    numeroRegistrosCadastrados++;
                }
            }
            return numeroRegistrosCadastrados;
        }
    }
}
