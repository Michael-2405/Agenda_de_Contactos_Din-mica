using AgendaDeContacto.Models;

namespace AgendaDeContacto.Servicios
{
	// Esta clase representa un nodo dentro de la lista simplemente enlazada.
	// Cada contiene un objeto de tipo Contacto y a su vez una referencia al siguiente nodo.
	public class Nodo
	{
		// Este es el objeto Contacto, el cual representa la informacion almacenada en el nodo.
		public Contacto Contacto;
		// Esta propiedad es la referencia al siguiente nodo de la lista.
		// Si este nodo es el ultimo nodo de la lista, entonces, el valor es o sera null.
		public Nodo Siguiente;


		// El constructor inicializa el nodo con el objeto de tipo contacto
		public Nodo(Contacto contacto)
		{
			Contacto = contacto;
			Siguiente = null!;
		}
	}
}
