namespace ChessConsole.Pieces;

public class Knight : Piece {
	public Knight(Board board, bool isWhite = false) : base(board, isWhite) { }

	public override string ToString()
		=> IsWhite ? "\u2658" : "\u265E";

	public override bool[,] PossibleMoves() {
		ArgumentNullException.ThrowIfNull(Position);

		bool[,] moves = new bool[Board.Dimensions, Board.Dimensions];

		Position pos = new(Position.Row - 2, Position.Column - 1);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row - 2, Position.Column + 1);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row - 1, Position.Column - 2);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row - 1, Position.Column + 2);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row + 2, Position.Column - 1);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row + 2, Position.Column + 1);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row + 1, Position.Column - 2);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		pos.ChangeValues(Position.Row + 1, Position.Column + 2);
		if (Board.IsValidPosition(pos) && CanMove(pos))
			moves[pos.Row, pos.Column] = true;

		return moves;
	}
}