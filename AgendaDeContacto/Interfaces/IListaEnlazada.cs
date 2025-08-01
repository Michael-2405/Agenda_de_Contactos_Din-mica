namespace AgendaDeContacto.Interfaces
{
	// Esta es la interfaz generica que define las operaciones basicas
	// que debe cumplir la lista enlazada. 
	public interface IListaEnlazada<T>
	{
		// Agregar un elemento al inicio de la lista.
		void AgregarAlInicio(T valor);

		// Agregar un elemento al final de la lista.
		void AgregarAlFinal(T valor);

		// Elimino un elemento por nombre de la lista.
		void EliminarPorNombre(string valor);

		// Busca un contacto en la lista, segun un nombre.
		bool BuscarContacto(string valor);

		// Muestra todos los elementos de la lista.
		void MostrarTodos();
	}
}
