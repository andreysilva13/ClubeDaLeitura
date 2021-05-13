using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Revista : DominioBase
    {
        public string tipoColecao;
        public int numeroEdicao;
        public DateTime anoDaRevista;
        public Caixa caixa;

        public Revista()
        {
            id = GerarId.GerarIdRevista();
        }

        public Revista(int idSelecionado)
        {
            id = idSelecionado;
        }

        public override bool Equals(object obj)
        {
            Revista revista = (Revista)obj;

            if (id == revista.id)
                return true;
            else
                return false;
        }
    }
}
