namespace ChessConsole.Pieces;

public class Pawn : Piece {
	private readonly Game _game;
	public Pawn(Game game, Board board, bool isWhite = false) : base(board, isWhite) {
		_game = game;
	}

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

		EnPassant(moves);

		return moves;
	}

	private void EnPassant(bool[,] moves) {
		if (Position!.Row == 3) {
			Position leftPos = new(Position.Row, Position.Column - 1);
			if (Board.IsValidPosition(leftPos) && Board[leftPos] is Piece left
				&& !IsWhite.Equals(left.IsWhite) && left == _game.VulnerableEnPassant)
				moves[leftPos.Row - 1, leftPos.Column] = true;

			Position rightPos = new(Position.Row, Position.Column + 1);
			if (Board.IsValidPosition(rightPos) && Board[rightPos] is Piece right
				&& !IsWhite.Equals(right.IsWhite) && right == _game.VulnerableEnPassant)
				moves[leftPos.Row - 1, leftPos.Column] = true;
		} else if (Position!.Row == 4) {
			Position leftPos = new(Position.Row, Position.Column - 1);
			if (Board.IsValidPosition(leftPos) && Board[leftPos] is Piece left
				&& !IsWhite.Equals(left.IsWhite) && left == _game.VulnerableEnPassant)
				moves[leftPos.Row + 1, leftPos.Column] = true;

			Position rightPos = new(Position.Row, Position.Column + 1);
			if (Board.IsValidPosition(rightPos) && Board[rightPos] is Piece right
				&& !IsWhite.Equals(right.IsWhite) && right == _game.VulnerableEnPassant)
				moves[rightPos.Row + 1, rightPos.Column] = true;
		}
	}
}