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
    public class RProductoBL
    {
        public readonly IRProductoServices _repository;

        public RProductoBL()
        {
            _repository = new RProductoRepository();
        }
        public List<RProductoBE> Listar()
        {
            return _repository.Listar();
        }
        public List<MensajeBE> Guardar(RProductoBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular(RProductoBE BE)
        {
            return _repository.Anular(BE);
        }
    }
}
