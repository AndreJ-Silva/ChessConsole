namespace ChessConsole;

public class Piece {
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
}