using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class ModuloUsuario: BusinessEntity
    {
        private int idUsuario;
        private int idModulo;
        private bool permiteAlta;
        private bool permiteBaja;
        private bool permiteModificacion;
        private bool permiteConsulta;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdModulo { get => idModulo; set => idModulo = value; }
        public bool PermiteAlta { get => permiteAlta; set => permiteAlta = value; }
        public bool PermiteBaja { get => permiteBaja; set => permiteBaja = value; }
        public bool PermiteModificacion { get => permiteModificacion; set => permiteModificacion = value; }
        public bool PermiteConsulta { get => permiteConsulta; set => permiteConsulta = value; }
    }
}
