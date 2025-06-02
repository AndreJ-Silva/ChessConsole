namespace ChessConsole.Pieces;

public class King : Piece {
	public King(Board board, bool isWhite = false) : base(board, isWhite) { }

	public override string ToString()
		=> IsWhite ? "\u2654" : "\u265A";

}