using SFB.Solutions.Entities;
using SFB.Solutions.Entities.M_Almacen;
using SFB.Solutions.Repository.M_Almacen;
using SFB.Solutions.Sevices.M_Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Solutions.Logic.M_Seguridad
{
    public class SubCategoriaBL
    {
        private readonly ISubCategoriaServices _repository;

        public SubCategoriaBL()
        {
            _repository = new SubCategoriaRepository();
        }
        public List<SubCategoriaBE> Listar()
        {
            return _repository.Listar();
        }

        public List<MensajeBE> Guardar(SubCategoriaBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular(SubCategoriaBE BE)
        {
            return _repository.Anular(BE);
        }
    }
}
