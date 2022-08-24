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
    public class SeriesBL
    {
        private readonly ISeriesServices _repository;

        public SeriesBL()
        {
            _repository = new SeriesRepository();
        }
        public List<SeriesBE> Listar(SeriesBE BE)
        {
            return _repository.Listar(BE);
        }

        public List<MensajeBE> Guardar(SeriesBE BE)
        {
            return _repository.Guardar(BE);
        }
        public MensajeBE Anular(SeriesBE BE)
        {
            return _repository.Anular(BE);
        }
    }
}
