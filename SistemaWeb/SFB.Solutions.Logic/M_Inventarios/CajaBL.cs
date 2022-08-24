using SFB.Solutions.Entities;
using SFB.Solutions.Entities.M_Inventarios;
using SFB.Solutions.Repository.M_Inventarios;
using SFB.Solutions.Sevices.M_Inventarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Solutions.Logic.M_Inventarios
{
    public class CajaBL
    {
        private readonly ICajaServices _repository;

        public CajaBL()
        {
            _repository = new CajaRepository();
        }
        public List<CajaBE> Listar()
        {
            return _repository.Listar();
        }
        public List<MensajeBE> Guardar(CajaBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular(CajaBE BE)
        {
            return _repository.Anular(BE);
        }

        
    }
}
