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
    public class ModuloBL
    {
        private readonly IModuloServices _repository;

        public ModuloBL()
        {
            _repository = new ModuloRepository();
        }
        public List<ModuloBE> Listar(ModuloBE BE)
        {
            return _repository.Listar(BE);
        }

        public List<MensajeBE> Guardar(ModuloBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular(ModuloBE BE)
        {
            return _repository.Anular(BE);
        }
    }
}
