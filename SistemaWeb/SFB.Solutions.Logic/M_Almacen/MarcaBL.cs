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
    public class MarcaBL
    {
        private readonly IMarcaServices _repository;
        public MarcaBL()
        {
            _repository = new MarcaRepository();
        }


        public List<MarcaBE> Listar()
        {
            return _repository.Listar();
        }

        public List<MensajeBE> Guardar(MarcaBE BE)
        {
            return _repository.Guardar(BE);
        }

        public MensajeBE Anular(MarcaBE BE)
        {
            return _repository.Anular(BE);
        }

        
    }
}
