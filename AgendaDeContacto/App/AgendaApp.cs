using AgendaDeContacto.Models;
using AgendaDeContacto.Servicios;
using AgendaDeContacto.Utils;

namespace AgendaDeContacto.App
{
	public class AgendaApp
	{
		private readonly ListaEnlazadaAgenda lista;

		public AgendaApp()
		{
			lista = new ListaEnlazadaAgenda();
		}

		public void Ejecutar()
		{
			Console.Clear();
			MostrarTitulo("Agenda de Contactos Dinamica.");

			AgregarContactos();
			Pausa();

			MostrarSeccion("Contactos Registrados.");
			lista.MostrarTodos();
			Pausa();

			MostrarSeccion("Buscar Contactos.");
			BuscarContactos();
			Pausa();

			MostrarSeccion("Eliminar Contact Existente.");
			lista.EliminarPorNombre("Fulano");
			Pausa();

			MostrarSeccion("Estado Final de la Agenda.");
			lista.MostrarTodos();
		}

		private void AgregarContactos()
		{
			lista.AgregarAlInicio(new Contacto("Michael", "809-010-0011", "michael@gmail.com"));
			lista.AgregarAlInicio(new Contacto("Alexander", "829-020-0022", "alexander@gmail.com"));
			lista.AgregarAlFinal(new Contacto("Carlos", "829-030-0033", "carlos@gmail.com"));
			lista.AgregarAlFinal(new Contacto("Francis", "809-040-0044", "francis@gmail.com"));
		}

		private void BuscarContactos()
		{
			Buscar("Francis");
			Buscar("carlos");
		}

		private void Buscar(string nombre)
		{
			bool encontrado = lista.BuscarContacto(nombre);
			ConsoleColor color = encontrado ? ConsoleColor.Green : ConsoleColor.Red;
			ConsolaHelper.TextHelper($"Buscar {nombre}: {(encontrado ? "Encontrado" : "No encontrado")}", color);
		}

		// Presentacion visual
		private void MostrarTitulo(string titulo)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("=============================================================");
			Console.WriteLine(titulo.ToUpper().PadLeft((60 + titulo.Length) / 2).PadRight(60));
			Console.WriteLine("=============================================================");
			Console.ResetColor();
		}

		private void MostrarSeccion(string texto)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\n-------------------------------------------------------------");
			Console.WriteLine(texto.ToUpper().PadLeft((60 + texto.Length) / 2).PadRight(60));
			Console.WriteLine("-------------------------------------------------------------");
			Console.ResetColor();
		}

		private void Pausa()
		{
			Console.WriteLine("\nPresiona cualquier tecla para continuar...");
			Console.ReadKey();
			Console.Clear();
		}
	}
}
