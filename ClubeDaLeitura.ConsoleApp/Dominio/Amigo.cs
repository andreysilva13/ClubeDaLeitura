using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Amigo : DominioBase
    {
        public string nomeAmigo;
        public string nomeReponsavel;
        public string telefone;
        public string deOnde;
        public Amigo()
        {
            id = GerarId.GerarIdAmigo();
        }

        public Amigo(int idSelecionado)
        {
            id = idSelecionado;
        }

        public override bool Equals(object obj)
        {
            Amigo amigo = (Amigo)obj;

            if (id == amigo.id)
                return true;
            else
                return false;
        }
    }
}
