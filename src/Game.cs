using ChessConsole.Pieces;

namespace ChessConsole;

public class Game {
	private readonly HashSet<Piece> _pieces;
	private readonly HashSet<Piece> _captured;
	public Board Board { get; private set; }
	public int Turn { get; private set; }
	public bool IsWhiteTurn { get; private set; }
	public bool IsCheckMate { get; private set; }
	public bool Check { get; private set; }

	public Game() {
		Board = new();
		Turn = 1;
		IsWhiteTurn = true;
		IsCheckMate = false;
		Check = false;
		_pieces = [];
		_captured = [];
		AddPieces();
	}

	public void Move(Position posX, Position posY) {
		Piece? target = DoMove(posX, posY);

		if (IsInCheck(IsWhiteTurn)) {
			UndoMove(posX, posY, target);
			throw new InvalidOperationException("You can't put yourself in check");
		}

		Check = IsInCheck(!IsWhiteTurn);

		if (Checkmate(!IsWhiteTurn))
			IsCheckMate = true;
		else
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

	private bool IsInCheck(bool isWhite) {
		Piece? k = GetKing(isWhite);
		ArgumentNullException.ThrowIfNull(k);

		foreach (Piece piece in AvailablePieces(!isWhite)) {
			var moves = piece.PossibleMoves();
			if (moves[k.Position!.Row, k.Position.Column])
				return true;
		}

		return false;
	}

	private bool Checkmate(bool isWhite) {
		if (!IsInCheck(isWhite))
			return false;

		foreach (Piece piece in AvailablePieces(isWhite)) {
			var moves = piece.PossibleMoves();
			for (int i = 0; i < Board.Dimensions; i++) {
				for (int j = 0; j < Board.Dimensions; j++) {
					if (moves[i, j]) {
						Position posX = piece.Position!;
						Position posY = new(i, j);
						Piece? target = DoMove(posX, posY);
						bool isCheckmate = IsInCheck(isWhite);
						UndoMove(posX, posY, target);
						if (!isCheckmate)
							return false;
					}
				}
			}
		}

		return true;
	}

	private void AddPieces() {
		{ // White pieces
			Rook rook = new(Board, true);
			Board.Add(rook, new Position(7, 0));
			_pieces.Add(rook);

			rook = new Rook(Board, true);
			Board.Add(rook, new Position(1, 7));
			_pieces.Add(rook);

			King king = new(Board, true);
			Board.Add(king, new Position(7, 4));
			_pieces.Add(king);
		}

		{ // Black pieces
			Rook rook = new(Board);
			Board.Add(rook, new Position(0, 1));
			_pieces.Add(rook);

			rook = new Rook(Board);
			Board.Add(rook, new Position(0, 7));
			_pieces.Add(rook);

			King king = new(Board);
			Board.Add(king, new Position(0, 0));
			_pieces.Add(king);
		}
	}

	private Piece? DoMove(Position posX, Position posY) {
		Piece? piece = Board.RemoveAt(posX);

		piece!.IncreaseMovements();

		Piece? target = Board.RemoveAt(posY);

		Board.Add(piece, posY);

		if (target is not null)
			_captured.Add(target);

		return target;
	}

	private void UndoMove(Position posX, Position posY, Piece? target) {
		Piece? piece = Board.RemoveAt(posY);
		piece!.DecreaseMovements();

		if (target is not null) {
			Board.Add(target, posY);
			_captured.Remove(target);
		}

		Board.Add(piece!, posX);
	}

	private void TurnRound() {
		IsWhiteTurn = !IsWhiteTurn;
		Turn++;
	}

	private HashSet<Piece> Captured(bool isWhite)
		=> _captured.Where(x => x.IsWhite.Equals(isWhite)).ToHashSet();

	private HashSet<Piece> AvailablePieces(bool isWhite) {
		var pieces = _pieces.Where(x => x.IsWhite.Equals(isWhite)).ToHashSet();
		pieces.ExceptWith(Captured(isWhite));
		return pieces;
	}

	private Piece? GetKing(bool isWhite)
		=> AvailablePieces(isWhite).SingleOrDefault(x => x is King);
}