# Modulo2-Nurbnb

Api Nurbnb corresponde al microservicio de Pagos y Devoluciones del proyecto final del módulo 2-DESARROLLO DIRIGIDO POR EL DOMINIO Y ARQUITECTURA LIMPIA, la implementación  sigue  las buenas prácticas de  Domain Driven Design, Arquitectura Limpia, y CQRS aprendidos durante el presente módudo. Para el desarrollo se utilizo .Net Core, c# y SqlLite.
El diagrama de clases se encuentra en la solucion del proyecto WebApi , archivo Diagrama-De-Clases.PNG
Entre las funcionalidades implementadas se listas las siguientes:
1. Método Post CatalogoPago, permite parametrizar los catálogos de pagos habilitados y su correspondiente porcentaje de Aplicación.

   Request.-
    {              
       "tipo": 0,                        Tipo de Pago valores 0= cobro, 1= reserva
       "descripcion": "string",          Nombre o descripción del catálogo
       "porcentaje": 0                   Valor del porcentaje entre 0 y 100
    }
	Response.-
		Identificador del CatalogoPago realizado
		
2. Método Get CatalogoPago, lista los catálogos de pago registrado permite filtrar la búsqueda por el  valor de la descripción.

    Request.-
   {
      "searchTerm":"valor de búsqueda"
   }
   Response.-
   [
     {
		"catalogoId": "3866a038-1e89-4213-9aaa-a188ff0f1b85",		Identificador del Catálogo
		"descripcion": "Reserva Hospedaje",							Nombre o descripción del Catálogo
		"porcentaje": 30,											Valor de porcentaje
		"tipo": "Reserva"											Identifica el tipo de catalogo
     }
   ]
   
3. Método Post CatalogoDevolucion, permite parametrizar los catálogos de devoluciones habilitados y su correspondiente porcentaje de Aplicación.

   Request.-
    {              
       "descripcion": 0,				Nombre o descripción del catalogo
       "nroDias": "string",          	Representa el número de dias al inicio del hospedaje
       "porcentajeDescuento": 0         Valor del porcentaje de descuento a aplicar
    }
	Response.-
		Identificador del CatalogoDevolucion realizado
		
4. Método Get ObtenerCatalogoDevolucion, permite obtener el catalogo devolución a aplicar en base a una fecha de inicio y fecha fin.

   Request.-
    {              
       "fechaAprobacionReserva": "mm-dd-yyyy",		    Representa la fecha de aprobación de una reserva
       "fechaInicioEstadia": "mm-dd-yyyy",          	Representa la fecha de inicio del hospedaje
    }
		
	Response.-

	{
	"catalogoDevolucionId": "1d8790f8-e8cf-46fb-8c64-37fcc3328fea",		Identificador del catálogo devolución 
	"descripcion": "Devolucion a 11 dias de inicio de hospedaje",		Nombre o descripcion del catálogo devolución
	"nroDias": 11,														Representa el número de dias al inicio del hospedaje
	"porcentajeDescuento": 50											Valor del porcentaje de descuento a aplicar
	} 

5. Método POST Devolucion, permite registrar una devolución del pago de reserva realizado

   Request.-
   {
       "pagoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",				Representa el identificador del pago
       "catalogoDevolucionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"   Representa el identificador del catalogo de devolución , de acuerdo al valor obtenido con el método ObtenerCatalogoDevolucion
    }
	Response.-
		Identificador de la Devolucion realizado
		
6. Método GET Devolucion, Lista las devoluciones registradas permite filtrar la búsqueda por el id del pago.

    Request.-
   {
      "searchTerm":"valor de búsqueda"
   }
   Response.-
   
   [
  
	  {
		"devolucionId": "0aec0be7-fe3f-485f-8644-e7425a660cf5",				Identificador de la Devolucion
		"fechaRegistro": "2023-08-08T19:39:41.6586052",						Fecha de Registro de la Devolucion
		"pagoId": "9fec8dc8-89ab-4467-9a46-d1700f704941",					Identificador del pago
		"catalogoDevolucionId": "1d8790f8-e8cf-46fb-8c64-37fcc3328fea",     Identificador del catalogo de devolucion
		"porcentajeDevolucion": 50,											Representa el porcentaje de descuento aplicado
		"importePago": 150,													Importe del pago realizado
		"totalDevolucion": 75												Importe de la devolucion
	  }
    ]

7. Método POST Pago,  permite registrar un pago .

   Request.-
   {
		"tipoPago": 0,												Tipo de Pago valores 0= cobro, 1= reserva
		"operacionId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",  	Representa el identificador de una reserva u hospedaje
		"costoTotalRenta": 0,										Representa el importe total del hospedaje
		"cuentaOrigen": "string",									Valor de la cuenta origen de donde se debitará el importe del pago
		"bcoOrigen": "string",										Valor del banco origen que pertenece la cuenta origen
		"detalle": [
		{
		  "catalogoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"		Identificador del catalogo de pago 
		}
		]
	}
	Response.-
		Identificador del Pago realizado
		
8. Método GET Pago, lista los  pago registrados permite filtrar la búsqueda por el  valor del id de la operacion.

   Request.-
   {
      "searchTerm":"valor de búsqueda"
   }
   Response.-
   [
  {
    "pagoId": "9fec8dc8-89ab-4467-9a46-d1700f704941",				Identificador el pago
    "fechaRegistro": "2023-08-08T19:29:15.51403",					Fecha de registro del pago
    "fechaCancelacion": null,										Fecha de cancelación
    "tipoPago": "Reserva",										    Representa el tipo de pago, valores Reserva y Cobro
    "operacionId": "3866a038-1e89-4213-9aaa-a188ff0f1b85",			Identificador de la operación que invoca el pago , una reserva o un hospedaje
    "costoTotalRenta": 500,											Importe del hospedaje
    "estado": "Procesado",											Estado de la operación de pago
    "cuentaOrigen": "123456",										Valor de la cuenta origen de donde se debitará el importe del pago
    "bcoOrigen": "054",												Valor del banco origen que pertenece la cuenta origen
    "detalle": [
      {
        "id": "decdce2f-66de-470b-987f-e0282c740afc",				Identificador del detalle de pago
        "catalogoId": "3866a038-1e89-4213-9aaa-a188ff0f1b85",		Identificador del catalogo de pago
        "pagoId": "9fec8dc8-89ab-4467-9a46-d1700f704941",			Identificador del pago
        "porcentaje": 30,											Porcentaje aplicado en el pago con relación al importe del hospedaje				
        "total": 150												Total importe del pago aplicado
      }
    ]
  }
]
   
