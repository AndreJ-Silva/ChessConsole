namespace ChessConsole;

public class Board {
	public static readonly int Dimensions = 8;
	private readonly Piece?[,] _pieces;

	public Board()
		=> _pieces = new Piece[Dimensions, Dimensions];

	public Piece? this[int row, int column] {
		get {
			if (!IsValidPosition(new Position(row, column)))
				throw new IndexOutOfRangeException("Invalid Position");
			return _pieces[row, column];
		}
	}

	public Piece? this[Position pos] {
		get {
			if (!IsValidPosition(pos))
				throw new IndexOutOfRangeException("Invalid Position");
			return _pieces[pos.Row, pos.Column];
		}
	}

	public bool IsValidPosition(Position pos)
		=> pos.Row >= 0 && pos.Row < Dimensions && pos.Column >= 0 && pos.Column < Dimensions;

	public bool HasPiece(Position pos)
		=> this[pos.Row, pos.Column] is not null;

	public void Add(Piece piece, Position pos) {
		if (HasPiece(pos))
			throw new InvalidOperationException("There is a piece in that position!");
		piece.Position = pos;
		_pieces[pos.Row, pos.Column] = piece;
	}
}