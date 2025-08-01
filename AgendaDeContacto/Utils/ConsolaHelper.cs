namespace AgendaDeContacto.Utils
{
	public static class ConsolaHelper
	{
		public static void TextHelper(string mensaje, ConsoleColor color)
		{
			var originalColor = Console.ForegroundColor;
			Console.ForegroundColor = color;
			Console.WriteLine(mensaje);
			Console.ForegroundColor = originalColor;
		}
	}
}
