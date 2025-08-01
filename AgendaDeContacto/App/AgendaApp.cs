using AgendaDeContacto.Interfaces;
using AgendaDeContacto.Models;
using AgendaDeContacto.Servicios;
using AgendaDeContacto.Utils;

namespace AgendaDeContacto.App
{
	// Clase encargada de la ejecucion interactiva de la agenda de contactos.
	// Presenta un menu en consola para el usuario agregue, busque, elimine y vea contactos.
	public class AgendaApp
	{
		private readonly IListaEnlazada<Contacto> lista;

		// Constructor que inicializa la lista enlazada de contactos.
		public AgendaApp(IListaEnlazada<Contacto> lista)
		{
			this.lista = lista;
		}

		// Inicia el ciclo principal de ejecución mostrando el menú interactivo.
		public void Ejecutar()
		{
			Console.Clear();
			MostrarTitulo("Agenda de Contactos Interactiva.");

			while (true)
			{
				MostrarMenu();

				Console.Write("\n Elige una opcon (1-5): ");
				string? opcion = Console.ReadLine();

				switch (opcion)
				{
					case "1":
						AgregarContactoInteractivo();
						break;
					case "2":
						BuscarContactoInteractivo();
						break;
					case "3":
						EliminarContactoInteractivo();
						break;
					case "4":
						MostrarContactos();
						break;
					case "5":
						ConsolaHelper.TextHelper("\nSaliendo de la agenda. ¡Hasta luego!", ConsoleColor.Cyan);
						return;
					default:
						ConsolaHelper.TextHelper("Opción no válida. Intenta de nuevo.", ConsoleColor.Red);
						break;
				}
				Pausa();
			}
		}

		// Muestra el menú principal de la agenda.
		private void MostrarMenu()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\n================ MENÚ =================");
			Console.WriteLine("1. Agregar contacto");
			Console.WriteLine("2. Buscar contacto por nombre");
			Console.WriteLine("3. Eliminar contacto por nombre");
			Console.WriteLine("4. Mostrar todos los contactos");
			Console.WriteLine("5. Salir");
			Console.WriteLine("=======================================");
			Console.ResetColor();
		}

		// Permite al usuario ingresar los datos de un nuevo contacto para agregarlo.
		private void AgregarContactoInteractivo()
		{
			Console.WriteLine("\n--- Agregar nuevo contacto ---");

			Console.Write("Nombre: ");
			string? nombre = Console.ReadLine();

			Console.Write("Teléfono: ");
			string? telefono = Console.ReadLine();

			Console.Write("Correo: ");
			string? correo = Console.ReadLine();

			Contacto nuevo = new Contacto(nombre!, telefono!, correo!);
			lista.AgregarAlFinal(nuevo);

			ConsolaHelper.TextHelper("Contacto agregado correctamente.", ConsoleColor.Green);
		}

		// Solicita un nombre y muestra si el contacto fue encontrado.
		private void BuscarContactoInteractivo()
		{
			Console.Write("\nIngresa el nombre a buscar: ");
			string? nombre = Console.ReadLine();

			bool encontrado = lista.BuscarContacto(nombre!);

			if (encontrado)
				ConsolaHelper.TextHelper("Contacto encontrado.", ConsoleColor.Green);
			else
				ConsolaHelper.TextHelper("Contacto no encontrado.", ConsoleColor.Red);
		}

		// Solicita un nombre y elimina el contacto si existe.
		private void EliminarContactoInteractivo()
		{
			Console.Write("\nIngresa el nombre a eliminar: ");
			string? nombre = Console.ReadLine();

			bool encontrado = lista.BuscarContacto(nombre!);

			if (encontrado)
			{
				lista.EliminarPorNombre(nombre!);
				ConsolaHelper.TextHelper("Contacto eliminado correctamente.", ConsoleColor.Green);
			}
			else
			{
				ConsolaHelper.TextHelper("Contacto no encontrado.", ConsoleColor.Red);
			}
		}

		// Muestra todos los contactos registrados.
		private void MostrarContactos()
		{
			Console.WriteLine("\n--- Contactos registrados ---");
			lista.MostrarTodos();
		}

		// Muestra un título decorativo centrado.
		private void MostrarTitulo(string titulo)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("=============================================================");
			Console.WriteLine(titulo.ToUpper().PadLeft((60 + titulo.Length) / 2).PadRight(60));
			Console.WriteLine("=============================================================");
			Console.ResetColor();
		}

		// Pausa la aplicación hasta que el usuario presione una tecla.
		private void Pausa()
		{
			Console.WriteLine("\nPresiona una tecla para continuar...");
			Console.ReadKey();
			Console.Clear();
		}
	}
}
