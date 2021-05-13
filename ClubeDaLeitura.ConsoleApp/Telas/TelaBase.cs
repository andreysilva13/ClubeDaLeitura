using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public abstract class TelaBase
    {
        private string titulo;

        public string Titulo { get { return titulo; } }

        public TelaBase(string tit)
        {
            titulo = tit;
        }
        protected void ConfigurarTela(string subtitulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();

            Console.WriteLine(subtitulo);

            Console.WriteLine();
        }

        abstract public string ObterOpcao();
        public virtual void InserirRegistro() { }
        public virtual void VisualizarRegistro() { }
        public virtual void EditarRegistro() { }
        public virtual void ExcluirRegistro() { }
    }
}
