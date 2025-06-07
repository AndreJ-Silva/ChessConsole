namespace ChessConsole.Pieces;

public class Pawn : Piece {
	public Pawn(Board board, bool isWhite = false) : base(board, isWhite) { }

	public override string ToString()
		=> IsWhite ? "\u2659" : "\u265F";

	public override bool[,] PossibleMoves() {
		ArgumentNullException.ThrowIfNull(Position);

		bool[,] moves = new bool[Board.Dimensions, Board.Dimensions];

		if (IsWhite) {
			Position pos = new(Position.Row - 1, Position.Column);
			if (Board.IsValidPosition(pos) && Board[pos] is null)
				moves[pos.Row, pos.Column] = true;

			Position pos2 = new(Position.Row - 2, Position.Column);
			if (Board.IsValidPosition(pos2) && Board.IsValidPosition(pos) && Board[pos2] is null && MoveCount == 0)
				moves[pos2.Row, pos2.Column] = true;

			pos.ChangeValues(Position.Row - 1, Position.Column - 1);
			if (Board.IsValidPosition(pos) && Board[pos] is Piece other && !other.IsWhite.Equals(IsWhite))
				moves[pos.Row, pos.Column] = true;

			pos.ChangeValues(Position.Row - 1, Position.Column + 1);
			if (Board.IsValidPosition(pos) && Board[pos] is Piece other2 && !other2.IsWhite.Equals(IsWhite))
				moves[pos.Row, pos.Column] = true;
		} else {
			Position pos = new(Position.Row + 1, Position.Column);
			if (Board.IsValidPosition(pos) && Board[pos] is null)
				moves[pos.Row, pos.Column] = true;

			Position pos2 = new(Position.Row + 2, Position.Column);
			if (Board.IsValidPosition(pos2) && Board.IsValidPosition(pos) && Board[pos2] is null && MoveCount == 0)
				moves[pos2.Row, pos2.Column] = true;

			pos.ChangeValues(Position.Row + 1, Position.Column - 1);
			if (Board.IsValidPosition(pos) && Board[pos] is Piece other && !other.IsWhite.Equals(IsWhite))
				moves[pos.Row, pos.Column] = true;

			pos.ChangeValues(Position.Row + 1, Position.Column + 1);
			if (Board.IsValidPosition(pos) && Board[pos] is Piece other2 && !other2.IsWhite.Equals(IsWhite))
				moves[pos.Row, pos.Column] = true;
		}

		return moves;
	}
}