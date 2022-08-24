using SFB.Solutions.Sevices.M_Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFB.Solutions.Entities.M_Almacen;
using SFB.Solutions.Repository.M_Almacen;
using SFB.Solutions.Entities;

namespace SFB.Solutions.Logic.M_Almacen
{
    public class CategoriaBL
    {
        private readonly ICategoriaServices _repository;
        public CategoriaBL()
        {
            _repository = new CategoriaRepository();
        }


        public List<CategoriaBE> Listar()
        {
            return _repository.Listar();
        }

        public List<MensajeBE> Guardar (CategoriaBE BE)
        {
            return _repository.Guardar(BE);
        }
            
        public MensajeBE Anular(CategoriaBE BE)
        {
            return _repository.Anular(BE);
        }


    }
}
