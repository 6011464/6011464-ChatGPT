using MauiAppEjemplo.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiAppEjemplo.Servicios
{
    public interface IEjerciciosService
    {
        Task<List<EjercicioAdvice>> ObtenerConsejos(string prompt);
    }
}
