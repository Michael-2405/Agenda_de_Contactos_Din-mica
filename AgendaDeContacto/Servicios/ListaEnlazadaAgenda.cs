using AgendaDeContacto.Interfaces;
using AgendaDeContacto.Models;
using AgendaDeContacto.Utils;

namespace AgendaDeContacto.Servicios
{
	// Esta es la implementacion de una lista simplemente enlazada, para almacenar objetos de tipo Contacto.
	// Esta clase permite agregar, buscar, eliminar y mostrar contactos.
	public class ListaEnlazadaAgenda : IListaEnlazada<Contacto>
	{
		// Este nodo representa el inicio (la cabeza) de la lista.
		private Nodo cabeza;
		private readonly IImpresora impresora;
		
		// Este constructor inicializa la lista vacia.
		public ListaEnlazadaAgenda(IImpresora impresora)
		{
			this.impresora = impresora;
			cabeza = null!;
		}

		// agrega un contacto al inicio de la lista.
		public void AgregarAlInicio(Contacto contacto)
		{
			Nodo nuevo = new Nodo(contacto);
			nuevo.Siguiente = cabeza;
			cabeza = nuevo;
		}
		
		// agrega un contaco al final de la lista.
		public void AgregarAlFinal(Contacto contacto)
		{
			Nodo nuevo = new Nodo(contacto);
			if(cabeza == null)
			{
				cabeza = nuevo;
				return;
			}

			Nodo actual = cabeza;
			while(actual.Siguiente != null)
			{
				actual = actual.Siguiente;
			}
			actual.Siguiente = nuevo;
		}

		// elimina un contacto por nombre.
		public void EliminarPorNombre(string nombre)
		{
			if (cabeza == null) return;

			if(cabeza.Contacto.Nombre == nombre)
			{
				cabeza = cabeza.Siguiente;
				return;
			}

			Nodo actual = cabeza;
			while (actual.Siguiente != null && actual.Siguiente.Contacto.Nombre != nombre)
			{
				actual = actual.Siguiente;
			}

			if (actual.Siguiente != null)
			{
				actual.Siguiente = actual.Siguiente.Siguiente;
			}
			else
			{
				ConsolaHelper.TextHelper($"No se encontro el contacto con nombre: {nombre}", ConsoleColor.Red);
			}
		}

		// buscar un contacto, si este existe, por su nombre.
		public bool BuscarContacto(string nombre)
		{
			Nodo actual = cabeza;
			while (actual != null)
			{
				if (actual.Contacto.Nombre == nombre)
					return true;
				actual = actual.Siguiente;
			}
			return false;
		}       

		// mostrar todos los contactos guardados en la lista.
		public void MostrarTodos()
		{
			Nodo actual = cabeza;
			int i = 1;
			while (actual != null)
			{
				impresora.Imprimir(actual.Contacto, i++);
				actual = actual.Siguiente;
			}
			Console.ResetColor();
			if (i == 1)
			{
				impresora.ImprimirVacio();
			}
		}
	}
}
