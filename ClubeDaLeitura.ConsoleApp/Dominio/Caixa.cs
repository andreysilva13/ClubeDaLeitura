using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Caixa : DominioBase
    {
        public string corCaixa;
        public string etiqueta;
        public int numero;
        public Caixa()
        {
            id = GerarId.GerarIdCaixa();
        }

        public Caixa(int idSelecionado)
        {
            id = idSelecionado;
        }

        public override bool Equals(object obj)
        {
            Caixa caixa = (Caixa)obj;

            if (id == caixa.id)
                return true;
            else
                return false;
        }
    }
}
