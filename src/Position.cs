namespace ChessConsole;

public class Position {
	public int Row { get; set; }
	public int Column { get; set; }

	public Position(int row, int column) {
		Row = row;
		Column = column;
	}

	public void ChangeValues(int row, int column) {
		Row = row;
		Column = column;
	}
}