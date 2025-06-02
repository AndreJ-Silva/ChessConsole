using ChessConsole;

internal class Program {
	private static void Main(string[] args) {
		Position pos = new(3, 2);

		Console.WriteLine("{0}, {1}", pos.Row, pos.Column);

		Board board = new();
	}
}