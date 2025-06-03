using ChessConsole;

internal class Program {
	private static void Main(string[] args) {
		Game game = new();
		Draw(game);

		while (!game.IsCheckMate) {
			try {
				Console.Write("\nFrom: ");
				Position x = ReadPosition();
				Draw(game, x);
				Console.Write("\nTo: ");
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

	private static void Draw(Game game, Position pos) {
		Console.Clear();
		var moves = game.Board[pos]?.PossibleMoves();

		if (moves is null) {
			Draw(game);
			return;
		}

		for (int i = 0; i < Board.Dimensions; i++) {
			Console.Write("{0} ", (8 - i));
			for (int j = 0; j < Board.Dimensions; j++) {
				if (moves[i, j]) {
					if (i > pos.Row && j == pos.Column)
						Console.Write("{0} ", "\u2193");
					else if (i < pos.Row && j == pos.Column)
						Console.Write("{0} ", "\u2191");
					else if (i == pos.Row && j < pos.Column)
						Console.Write("{0} ", "\u2190");
					else if (i == pos.Row && j > pos.Column)
						Console.Write("{0} ", "\u2192");
					else if (i > pos.Row && j > pos.Column)
						Console.Write("{0} ", "\u2198");
					else if (i < pos.Row && j > pos.Column)
						Console.Write("{0} ", "\u2197");
					else if (i > pos.Row && j < pos.Column)
						Console.Write("{0} ", "\u2199");
					else if (i < pos.Row && j < pos.Column)
						Console.Write("{0} ", "\u2196");
				} else {
					Draw(game.Board[i, j]);
				}
			}
			Console.WriteLine();
		}
		Console.WriteLine("  A B C D E F G H");
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