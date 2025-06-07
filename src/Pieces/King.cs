namespace ChessConsole.Pieces;

public class King : Piece {
    private readonly Game _game;
    public King(Game game, Board board, bool isWhite = false) : base(board, isWhite) {
        _game = game;
    }

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

        ShortCastling(moves);

        LongCastling(moves);

        return moves;
    }

    private void ShortCastling(bool[,] moves) {
        if (MoveCount == 0 && !_game.Check) {
            Position rookPos = new(Position!.Row, Position.Column + 3);
            if (Board[rookPos] is Rook rook && IsWhite.Equals(rook.IsWhite) && rook.MoveCount == 0) {
                Position pos1 = new(Position.Row, Position.Column + 1);
                Position pos2 = new(Position.Row, Position.Column + 2);
                if (!Board.HasPiece(pos1) && !Board.HasPiece(pos2))
                    moves[pos2.Row, pos2.Column] = true;
            }
        }
    }

    private void LongCastling(bool[,] moves) {
        if (MoveCount == 0 && !_game.Check) {
            Position rookPos = new(Position!.Row, Position.Column - 4);
            if (Board[rookPos] is Rook rook && IsWhite.Equals(rook.IsWhite) && rook.MoveCount == 0) {
                Position pos1 = new(Position.Row, Position.Column - 1);
                Position pos2 = new(Position.Row, Position.Column - 2);
                Position pos3 = new(Position.Row, Position.Column - 3);
                if (!Board.HasPiece(pos1) && !Board.HasPiece(pos2) && !Board.HasPiece(pos3))
                    moves[pos2.Row, pos2.Column] = true;
            }
        }
    }
}