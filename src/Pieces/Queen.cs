namespace ChessConsole.Pieces;

public class Queen : Piece {
	public Queen(Board board, bool isWhite = false) : base(board, isWhite) { }

	public override string ToString()
		=> IsWhite ? "\u2655" : "\u265B";

	public override bool[,] PossibleMoves() {
		ArgumentNullException.ThrowIfNull(Position);

		bool[,] moves = new bool[Board.Dimensions, Board.Dimensions];

		Position pos = new(Position.Row - 1, Position.Column);

		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !other.IsWhite.Equals(IsWhite))
				break;
			pos.Row--;
		}

		pos.ChangeValues(Position.Row + 1, Position.Column);
		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !other.IsWhite.Equals(IsWhite))
				break;
			pos.Row++;
		}

		pos.ChangeValues(Position.Row, Position.Column - 1);
		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !other.IsWhite.Equals(IsWhite))
				break;
			pos.Column--;
		}

		pos.ChangeValues(Position.Row, Position.Column + 1);
		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !other.IsWhite.Equals(IsWhite))
				break;
			pos.Column++;
		}

		pos.ChangeValues(Position.Row - 1, Position.Column - 1);
		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !other.IsWhite.Equals(IsWhite))
				break;
			pos.Row--;
			pos.Column--;
		}

		pos.ChangeValues(Position.Row - 1, Position.Column + 1);
		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !other.IsWhite.Equals(IsWhite))
				break;
			pos.Row--;
			pos.Column++;
		}

		pos.ChangeValues(Position.Row + 1, Position.Column - 1);
		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !other.IsWhite.Equals(IsWhite))
				break;
			pos.Row++;
			pos.Column--;
		}

		pos.ChangeValues(Position.Row + 1, Position.Column + 1);
		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !other.IsWhite.Equals(IsWhite))
				break;
			pos.Row++;
			pos.Column++;
		}

		return moves;
	}
}