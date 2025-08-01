using AgendaDeContacto.App;
using AgendaDeContacto.Servicios;

class Program
{
	public static void Main(string[] args)
	{
		var impresora = new ImpresoraContactos();
		var lista = new ListaEnlazadaAgenda(impresora);
		var app = new AgendaApp(lista);
		app.Ejecutar();
	}
}