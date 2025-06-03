namespace ChessConsole.Pieces;

public class King : Piece {
	public King(Board board, bool isWhite = false) : base(board, isWhite) { }

	public override string ToString()
		=> IsWhite ? "\u2654" : "\u265A";

	public override bool[,] PossibleMoves() {
		ArgumentNullException.ThrowIfNull(Position);

		bool[,] moves = new bool[Board.Dimensions, Board.Dimensions];

		Position pos = new(Position.Row - 1, Position.Column);

		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row - 1, Position.Column - 1);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row - 1, Position.Column + 1);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row, Position.Column - 1);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row + 1, Position.Column);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row + 1, Position.Column - 1);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row + 1, Position.Column + 1);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row, Position.Column + 1);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		return moves;
	}
}