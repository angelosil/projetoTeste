using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixaSaqueConsole.model
{
    public class Nota
    {
        private int valorNota;
        private int quantNota;

        public int ValorNota { get => valorNota; set => valorNota = value; }
        public int QuantNota { get => quantNota; set => quantNota = value; }
    }
}
