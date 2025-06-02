namespace ChessConsole;

public class Board {
	public static readonly int Dimensions = 8;
	private readonly Piece?[,] _pieces;

	public Board()
		=> _pieces = new Piece[Dimensions, Dimensions];
}