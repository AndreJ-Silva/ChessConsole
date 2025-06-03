namespace ChessConsole.Pieces;

public class Rook : Piece {
	public Rook(Board board, bool isWhite = false) : base(board, isWhite) { }

	public override string ToString()
		=> IsWhite ? "\u2656" : "\u265C";

	public override bool[,] PossibleMoves() {
		ArgumentNullException.ThrowIfNull(Position);

		bool[,] moves = new bool[Board.Dimensions, Board.Dimensions];

		Position pos = new(Position.Row - 1, Position.Column);

		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !Equals(other))
				break;
			pos.Row--;
		}

		pos.ChangeValues(Position.Row + 1, Position.Column);
		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !Equals(other))
				break;
			pos.Row++;
		}

		pos.ChangeValues(Position.Row, Position.Column - 1);
		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !Equals(other))
				break;
			pos.Column--;
		}

		pos.ChangeValues(Position.Row, Position.Column + 1);
		while (Board.IsValidPosition(pos) && CanMove(pos)) {
			moves[pos.Row, pos.Column] = true;
			if (Board[pos] is Piece other && !Equals(other))
				break;
			pos.Column++;
		}

		return moves;
	}
}