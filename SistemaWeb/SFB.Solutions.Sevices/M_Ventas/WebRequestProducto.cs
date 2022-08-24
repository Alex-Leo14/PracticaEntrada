using Newtonsoft.Json;
using RestSharp;
using SFB.Solutions.Entities.M_Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Solutions.Sevices.M_Ventas
{
    public class WebRequestProducto
    {
        ProductoBE _ProductoBE;
        List<ProductoBE> _lstProd;
        public List<ProductoBE> Listar(ProductoBE BE)
        {
            string json = JsonConvert.SerializeObject(BE);
            _lstProd = new List<ProductoBE>();


            RestClient client = new RestClient("https://localhost:44310/api/Producto/ListarTodo");
            RestRequest request = new RestRequest(Method.GET);
            request.Timeout = -1;
            request.AddHeader("Content-type", "application/json");
            //request.AddJsonBody(json);
            IRestResponse<List<Dictionary<String, Object>>> response = client.Execute<List<Dictionary<String, Object>>>(request);
            List<Dictionary<String, Object>> rst = response.Data;

            _lstProd = JsonConvert.DeserializeObject<List<ProductoBE>>(response.Content);
           

            return _lstProd;
        }

        public ProductoBE Insertar(ProductoBE BE)
        {
            string json = JsonConvert.SerializeObject(BE);
            _ProductoBE = new ProductoBE();

            RestClient client = new RestClient("https://localhost:44310/api/Producto/Insertar");
            RestRequest request = new RestRequest(Method.POST);
            request.Timeout = -1;
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(json);
            IRestResponse<List<Dictionary<String, Object>>> response = client.Execute<List<Dictionary<String, Object>>>(request);

            _ProductoBE = JsonConvert.DeserializeObject<ProductoBE>(response.Content);

            return _ProductoBE;
        }

        public ProductoBE Actualizar(ProductoBE BE)
        {
            string json = JsonConvert.SerializeObject(BE);
            _ProductoBE = new ProductoBE();

            RestClient client = new RestClient("https://localhost:44310/api/Producto/Actualizar");
            RestRequest request = new RestRequest(Method.PUT);
            request.Timeout = -1;
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(json);
            IRestResponse<List<Dictionary<String, Object>>> response = client.Execute<List<Dictionary<String, Object>>>(request);

            _ProductoBE = JsonConvert.DeserializeObject<ProductoBE>(response.Content);

            return _ProductoBE;
        }
        public ProductoBE Anular(ProductoBE BE)
        {
            int intProductoId = BE.intProductoId;
            string json = JsonConvert.SerializeObject(BE);
            _ProductoBE = new ProductoBE();

            RestClient client = new RestClient("https://localhost:44310/api/Producto/Eliminar");
            RestRequest request = new RestRequest(Method.POST);
            request.Timeout = -1;
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(json);
            IRestResponse<List<Dictionary<String, Object>>> response = client.Execute<List<Dictionary<String, Object>>>(request);

            _ProductoBE = JsonConvert.DeserializeObject<ProductoBE>(response.Content);

            return _ProductoBE;
        }
    }
}
