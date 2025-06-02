namespace ChessConsole.Pieces;

public class Rook : Piece {
	public Rook(Board board, bool isWhite = false) : base(board, isWhite) { }

	public override string ToString()
		=> IsWhite ? "\u2656" : "\u265C";
}