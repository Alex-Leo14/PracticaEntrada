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
    public class GrupoCajaBL
    {
        private readonly IGrupoCajaServices _repository;

        public GrupoCajaBL()
        {
            _repository = new GrupoCajaRepository();
        }
        public List<GrupoCajaBE> Listar()
        {
            return _repository.Listar();
        }
        public List<MensajeBE> Guardar(GrupoCajaBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular(GrupoCajaBE BE)
        {
            return _repository.Anular(BE);
        }
    }
}
