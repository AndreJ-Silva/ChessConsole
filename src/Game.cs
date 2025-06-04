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

	public void Move(Position posX, Position posY) {
		Piece? target = DoMove(posX, posY);

		TurnRound();
	}

	public void ValidateMoveFrom(Position posX) {
		if (Board[posX] is not Piece piece)
			throw new InvalidOperationException("There is no piece in the selected position");

		if (!piece.IsWhite.Equals(IsWhiteTurn))
			throw new InvalidOperationException("The select piece is not yours");

		if (!piece.AnyPossibleMove())
			throw new InvalidOperationException("The are no possible movements for the select piece");
	}

	public void ValidateMoveTo(Position posX, Position posY) {
		if (!Board[posX]!.PossibleMove(posY))
			throw new InvalidOperationException("Invalid movement");
	}

	private void AddPieces() {
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

	private Piece? DoMove(Position posX, Position posY) {
		Piece? piece = Board.RemoveAt(posX);

		piece!.IncreaseMovements();

		Piece? target = Board.RemoveAt(posY);

		Board.Add(piece, posY);

		return target;
	}

	private void TurnRound() {
		IsWhiteTurn = !IsWhiteTurn;
		Turn++;
	}
}