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
    public class EmpresaBL
    {
        private readonly IEmpresaServices _repository;
        public EmpresaBL()
        {
            _repository = new EmpresaRepository();
        }


        public List<EmpresaBE> Listar()
        {
            return _repository.Listar();
        }
    }
}
