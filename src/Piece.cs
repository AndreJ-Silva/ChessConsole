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

	public override bool Equals(object? obj) {
		if (obj is not Piece other)
			return false;
		return IsWhite.Equals(other.IsWhite);
	}

	public override int GetHashCode()
		=> IsWhite.GetHashCode();

	protected bool CanMove(Position pos)
		=> Board[pos] is not Piece piece || !Equals(piece);

	public abstract bool[,] PossibleMoves();

	public void IncreaseMovements()
		=> MoveCount++;

	public void DecreaseMovements()
		=> MoveCount--;
}