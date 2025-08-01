using AgendaDeContacto.Models;

namespace AgendaDeContacto.Interfaces
{
	public interface IImpresora
	{
		void Imprimir(Contacto contacto, int indice);
		void ImprimirVacio();
	}
}
