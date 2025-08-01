using AgendaDeContacto.Models;

namespace AgendaDeContacto.Servicios
{
	public class Nodo
	{
		// public int Dato;
		public Contacto Contacto;
		public Nodo Siguiente;

		public Nodo(Contacto contacto)
		{
			Contacto = contacto;
			Siguiente = null!;
		}
	}
}
