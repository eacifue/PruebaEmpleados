

namespace MG.Empleados.BM
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using MG.Empleados.AD;
    using MG.Empleados.DT;
    using System.Threading.Tasks;
    public class BMData
    {
        public List<DTRespuestaApi> ConsultarData()
        {

            List<DTRespuestaApi> objRespuestaApi = new List<DTRespuestaApi>();

            try
            {
                Task<string> taskEmpleados = Task.Run(async () => await ADCallApi.ConsultarDataGET());
                taskEmpleados.Wait();

                objRespuestaApi = JsonConvert.DeserializeObject<List<DTRespuestaApi>>(taskEmpleados.Result);
            }
            catch (Exception ex)
            {

            }
            return objRespuestaApi;
        }
    }
}
