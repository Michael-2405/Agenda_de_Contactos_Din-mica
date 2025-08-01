using AgendaDeContacto.Interfaces;
using AgendaDeContacto.Models;
using AgendaDeContacto.Utils;

namespace AgendaDeContacto.Servicios
{
	public class ListaEnlazadaAgenda : IListaEnlazada<Contacto>
	{
		private Nodo cabeza;
		public ListaEnlazadaAgenda()
		{
			cabeza = null!;
		}

		// agregando un contacto al inicio
		public void AgregarAlInicio(Contacto contacto)
		{
			Nodo nuevo = new Nodo(contacto);
			nuevo.Siguiente = cabeza;
			cabeza = nuevo;
		}
		
		// agregando un contaco al final
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

		// eliminando un contacto por nombre
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

		// buscar un contacto
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

		// mostrar todos los contactos
		public void MostrarTodos()
		{
			Nodo actual = cabeza;
			int i = 1;
			while (actual != null)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"{i++}. Nombre: {actual.Contacto.Nombre}");
				Console.WriteLine($"   Teléfono: {actual.Contacto.Telefono}");
				Console.WriteLine($"   Correo: {actual.Contacto.Correo}");
				Console.WriteLine("   -------------------------------");
				actual = actual.Siguiente;
			}
			Console.ResetColor();
			if (i == 1)
			{
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("   (Sin contactos)");
				Console.ResetColor();
			}
		}
	}
}
