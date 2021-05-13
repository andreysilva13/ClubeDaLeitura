using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Emprestimo : DominioBase
    {
        public Amigo amiguinho;
        public Revista revistinha;
        public DateTime dataEmprestimo, dataDevolucao;
        public bool estaAtivo;
        public Emprestimo()
        {
            id = GerarId.GerarIdEmprestimo();
        }

        public Emprestimo(int idSelecionado)
        {
            id = idSelecionado;
        }

        public override bool Equals(object obj)
        {
            Emprestimo emprestimo = (Emprestimo)obj;

            if (id == emprestimo.id)
                return true;
            else
                return false;
        }
    }
}
