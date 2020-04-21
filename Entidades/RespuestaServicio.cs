using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

	public class Customer
	{
		public string username { get; set; }
		public string password { get; set; }
	}
	public class Afiliado
	{
		public Customer customer { get; set; }
		public string TipoDocu { get; set; }
		public string NroDocu { get; set; }

	}

	

	

	public class RespuestaRegistroAfiliado
	{
		public string codigo { get; set; }
		public string mensaje { get; set; }				
	}

	public class DatosAcumulacion
	{
		public string TipoDocumento { get; set; } 
		public string NroDocumento { get; set; }
		public string Correo { get; set; }
		public string NombreEvento { get; set; }
		public string MetodoPago { get; set; }
		public string MontoUnitario { get; set; }
		public string Producto { get; set; }
		public string Cantidad { get; set; }
		public string MontoTotal { get; set; }
		public string FechaCompra { get; set; }
		public string HoraCompra { get; set; }

	}
	public class RegistrarAcumulacion
	{
		public Customer customer { get; set; }
		public DatosAcumulacion datosacumulacion { get; set; }
	}

	public class RespuestaAcumulacion
	{
		public string codigo { get; set; }
		public string mensaje { get; set; }
		public string PuntosGanados { get; set; }
		public string SaldoActual { get; set; }
	}

	public class DatosCanje
	{
		public string TipoDocumento { get; set; }
		public string NroDocumento { get; set; }
		public string NombrePersona { get; set; }
		public string MetodoPago { get; set; }		
		public string FechaCanje { get; set; }
		public string HoraCanje { get; set; }
		public string MontoTotal { get; set; }
		public string PuntosTotal {get ; set; }
	}

	public class DetDatosCanje
	{		
		public string Producto { get; set; }
		public string Cantidad { get; set; }
		public string PrecioUnitario { get; set; }		
		public string puntosConsumidos { get; set; }
	}
	public class RegistrarCanje
	{
		public Customer customer { get; set; }
		public DatosCanje cabeceracanje { get; set; }
		public List<DetDatosCanje> detallecanje { get; set; }

	}

	public class RespuestaRegistrarCanje
	{
		public string codigo { get; set; }
		public string mensaje { get; set; }
		public int SaldoCuenta { get; set; }
	}

	public class ObtenerSaldo
	{
		public Customer customer { get; set; }
		public string TipoDocu { get; set; }
		public string NroDocu { get; set; }
	}

	public class RespuestaObtenerSaldo
	{
		public string codigo { get; set; }
		public string mensaje { get; set; }

		public int SaldoCuenta { get; set; }
	}

	public class Movimientos
	{
		public string FechaProceso { get; set; }
		public string FechaTransaccion { get; set; }
				
		public string Descripcion { get; set; }
		public int Puntos { get; set; }				
		

	}
	public class ObtenerMovimientos
	{
		public Customer customer { get; set; }
		public string TipoDocu { get; set; }
		public string NroDocu { get; set; }

	}
	public class RespuestaMovimientos
	{
		public string codigo { get; set; }
		public string mensaje { get; set; }
		public IList<Movimientos> movimientos { get; set; }
	}


}
