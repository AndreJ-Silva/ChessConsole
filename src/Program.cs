using ChessConsole;
using ChessConsole.Pieces;

internal class Program {
	private static void Main(string[] args) {
		Board board = new();
		board.Add(new Rook(board), new Position(0, 0));
		board.Add(new Rook(board), new Position(1, 2));
		board.Add(new Rook(board), new Position(2, 4));
		Draw(board);
	}

	private static void Draw(Board board) {
		for (int i = 0; i < Board.Dimensions; i++) {
			Console.Write("{0} ", (8 - i));
			for (int j = 0; j < Board.Dimensions; j++)
				Draw(board[i, j]);
			Console.WriteLine();
		}
		Console.WriteLine("  A B C D E F G H");
	}

	private static void Draw(Piece? piece) {
		if (piece is not null)
			Console.Write("{0} ", piece);
		else
			Console.Write("{0} ", "\u00B7");
	}
}