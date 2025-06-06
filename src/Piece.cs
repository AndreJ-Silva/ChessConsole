namespace ChessConsole;

public abstract class Piece {
	public Position? Position { get; set; }
	public bool IsWhite { get; private set; }
	public int MoveCount { get; private set; }
	public Board Board { get; private set; }

	public Piece(Board board, bool isWhite) {
		Position = null;
		IsWhite = isWhite;
		MoveCount = 0;
		Board = board;
	}

	protected bool CanMove(Position pos)
		=> Board[pos] is not Piece piece || !IsWhite.Equals(piece.IsWhite);

	public abstract bool[,] PossibleMoves();

	public bool PossibleMove(Position pos)
		=> PossibleMoves()[pos.Row, pos.Column];

	public bool AnyPossibleMove() {
		var moves = PossibleMoves();
		for (int i = 0; i < Board.Dimensions; i++) {
			for (int j = 0; j < Board.Dimensions; j++)
				if (moves[i, j])
					return true;
		}
		return false;
	}

	public void IncreaseMovements()
		=> MoveCount++;

	public void DecreaseMovements()
		=> MoveCount--;
}