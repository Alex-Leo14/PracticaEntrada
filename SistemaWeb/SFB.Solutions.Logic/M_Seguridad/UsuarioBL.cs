using SFB.Solutions.Entities;
using SFB.Solutions.Entities.M_Seguridad;
using SFB.Solutions.Repository.M_Seguridad;
using SFB.Solutions.Sevices.M_Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Solutions.Logic.M_Seguridad
{
    public class UsuarioBL
    {
        private readonly IUsuarioServices _repository;
        public UsuarioBL()
        {
            _repository = new UsuarioRepository();
        }


        public List<UsuarioBE> Listar()
        {
            return _repository.Listar();
        }

        public List<MensajeBE> Guardar(UsuarioBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular(UsuarioBE BE)
        {
            return _repository.Anular(BE);
        }

        public MensajeBE Validar(UsuarioBE BE)
        {
            return _repository.Validar(BE);
        }
        public List<MensajeBE>CambiarClave(UsuarioBE BE)
        {
            return _repository.CambiarClave(BE);
        }

    }
}
