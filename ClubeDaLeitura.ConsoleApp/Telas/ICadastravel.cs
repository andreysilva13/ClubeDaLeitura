using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public interface ICadastravel
    {
        void InserirRegistro();

        void VisualizarRegistro();

        void EditarRegistro();

        void ExcluirRegistro();

        string ObterOpcao();
    }
}
