using AgendaDeContacto.Interfaces;
using AgendaDeContacto.Models;

namespace AgendaDeContacto.Servicios
{
	public class ImpresoraContactos : IImpresora
	{
		public void Imprimir(Contacto contacto, int indice)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"{indice}. Nombre: {contacto.Nombre}");
			Console.WriteLine($"   Teléfono: {contacto.Telefono}");
			Console.WriteLine($"   Correo: {contacto.Correo}");
			Console.WriteLine("   -------------------------------");
			Console.ResetColor();
		}

		public void ImprimirVacio()
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("   (Sin contactos)");
			Console.ResetColor();
		}
	}
}
