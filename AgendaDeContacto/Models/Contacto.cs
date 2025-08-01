namespace AgendaDeContacto.Models
{
	public class Contacto
	{
		// Esta clase representa el modelo para un contacto de la agenda.
		// Tiene 3 propiedades:
		public string? Nombre;
		public string? Telefono;
		public string? Correo;

		// Inicializa el nuevo contacto
		public Contacto(string nombre, string telefono, string correo)
		{
			Nombre = nombre;
			Telefono = telefono;
			Correo = correo;
		}
	}
}
