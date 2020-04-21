using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosNacionCrema.Utilitario
{
	public class Constantes
	{
		public class Estado
		{
			public const int ACTIVO = 1;
			public const int INACTIVO = 0;
		}

		public class MensajesParseo
		{

			public const string PARSEO_ESTRUCTURA = "Error de Parseo,No existe estructura";
			public const string OBJETIVO_DEX = "DESGLOSE COMUNICACIÓN GANAMAS DEX";
			//public const string OBJETIVO_JCC = "DESGLOSE COMUNICACIÓN GANAMAS JCC";
			public const string BASEDATOS = "BASE DATOS DETALLE PARTICIPANTES";
		}

	}
}