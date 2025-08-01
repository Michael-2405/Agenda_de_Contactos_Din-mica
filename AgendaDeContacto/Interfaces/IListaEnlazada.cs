namespace AgendaDeContacto.Interfaces
{
	public interface IListaEnlazada<T>
	{
		void AgregarAlInicio(T valor);
		void AgregarAlFinal(T valor);
		void EliminarPorNombre(string valor);
		bool BuscarContacto(string valor);
		void MostrarTodos();
	}
}
