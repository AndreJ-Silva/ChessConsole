using ChessConsole.Pieces;

namespace ChessConsole;

public class Game {
	public Board Board { get; private set; }
	public int Turn { get; private set; }
	public bool IsWhiteTurn { get; private set; }
	public bool IsCheckMate { get; private set; }

	public Game() {
		Board = new();
		Turn = 1;
		IsWhiteTurn = true;
		IsCheckMate = false;
		AddPieces();
	}

	public void AddPieces() {
		{ // White pieces
			Rook rook = new(Board, true);
			Board.Add(rook, new Position(7, 0));

			rook = new Rook(Board, true);
			Board.Add(rook, new Position(7, 7));

			King king = new King(Board, true);
			Board.Add(king, new Position(7, 4));
		}

		{ // Black pieces
			Rook rook = new(Board);
			Board.Add(rook, new Position(0, 0));

			rook = new Rook(Board);
			Board.Add(rook, new Position(0, 7));

			King king = new King(Board);
			Board.Add(king, new Position(0, 4));
		}
	}

	public Piece? DoMove(Position posX, Position posY) {
		Piece? piece = Board.RemoveAt(posX);

		ArgumentNullException.ThrowIfNull(piece);

		piece.IncreaseMovements();

		Piece? target = Board.RemoveAt(posY);

		Board.Add(piece, posY);

		return target;
	}
}