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
    public class CanalBL
    {
        private readonly ICanalServices _repository;

        public CanalBL()
        {
            _repository = new CanalRepository();
        }
        public List<CanalBE> Listar()
        {
            return _repository.Listar();
        }
        public List<MensajeBE> Guardar(CanalBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular(CanalBE BE)
        {
            return _repository.Anular(BE);
        }

    }
}
