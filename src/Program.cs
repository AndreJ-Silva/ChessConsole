using ChessConsole;

internal class Program {
	private static void Main(string[] args) {
		Game game = new();
		Draw(game);

		while (!game.IsCheckMate) {
			try {
				Console.Write("From: ");
				Position x = ReadPosition();
				Console.Write("To: ");
				Position y = ReadPosition();

				game.DoMove(x, y);

				Draw(game);
			} catch (Exception e) {
				Draw(game);
				Console.WriteLine(e.Message);
			}
		}
	}

	private static void Draw(Game game) {
		Console.Clear();
		Draw(game.Board);
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

	private static Position ReadPosition() {
		string pos = Console.ReadLine()!;
		char column = pos[0];
		int row = int.Parse(pos[1].ToString());

		if (row <= 0 || row > 8 || column < 'a' || column > 'h')
			throw new InvalidOperationException("Wrong coordinates. Try again");

		return new(8 - row, column - 'a');
	}
}