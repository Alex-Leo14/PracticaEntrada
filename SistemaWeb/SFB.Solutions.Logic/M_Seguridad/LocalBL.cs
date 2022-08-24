
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
    public class LocalBL
    {
        private readonly ILocalServices _repository;

        public LocalBL()
        {
            _repository = new LocalRepository();
        }
        public List<LocalBE> Listar(LocalBE BE)
        {
            return _repository.Listar(BE);
        }

        public List<MensajeBE> Guardar(LocalBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular(LocalBE BE)
        {
            return _repository.Anular(BE);
        }
    }
}
