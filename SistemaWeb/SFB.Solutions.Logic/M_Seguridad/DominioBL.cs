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
    public class DominioBL
    {
        private readonly IDominioServices _repository;

        public DominioBL()
        {
            _repository = new DominioRepository();
        }
        public List<DominioBE> Listar()
        {
            return _repository.Listar();
        }

        public List<MensajeBE> Guardar(DominioBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular(DominioBE BE)
        {
            return _repository.Anular(BE);
        }
       

    }
}
