using SFB.Solutions.Entities;
using SFB.Solutions.Entities.M_Almacen;
using SFB.Solutions.Repository.M_Almacen;
using SFB.Solutions.Sevices.M_Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Solutions.Logic.M_Almacen
{
    public class IngresosSalidasBL
    {
        private readonly IIngresosSalidasServices _repository;
        public IngresosSalidasBL()
        {
            _repository = new IngresosSalidasRepository();
        }
        public List<IngresosSalidasBE> Listar(IngresosSalidasBE BE)
        {
            return _repository.Listar(BE);
        }

        public List<MensajeBE> Guardar(IngresosSalidasBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular(IngresosSalidasBE BE)
        {
            return _repository.Anular(BE);
        }
    }
}
