using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CEM.WebService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiciosCEM" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiciosCEM.svc o ServiciosCEM.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiciosCEM : IServiciosCEM
    {
        public bool IsAlumnoRegular(int idAlumno)
        {
            return new Negocio.OperacionesUsuarios().Traer(idAlumno).AlumnoRegular == 1;
        }
    }
}
