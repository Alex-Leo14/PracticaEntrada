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
    public class TDocumentoBL
    {
        private readonly ITDocumentoServices _repository;
        public TDocumentoBL()
        {
            _repository = new TDocumentoRepository();
        } 
        public List<TDocumentoBE> Listar (TDocumentoBE BE)
        {
            return _repository.Listar(BE);
        }
        
        public List<MensajeBE> Guardar (TDocumentoBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular (TDocumentoBE BE)
        {
            return _repository.Anular(BE);
        }
    }
}
