namespace AgendaDeContacto.Models
{
	public class Contacto
	{
		public string? Nombre;
		public string? Telefono;
		public string? Correo;
		public Contacto(string nombre, string telefono, string correo)
		{
			Nombre = nombre;
			Telefono = telefono;
			Correo = correo;
		}
	}
}
