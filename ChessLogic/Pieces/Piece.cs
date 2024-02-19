namespace ChessLogic
{
	public abstract class Piece
	{
		public abstract PieceType Type { get; }
		public abstract Player Color { get; }

		public bool HasMoved { get; set; } = false;
		public abstract Piece Copy();

		/*
		 * 2
		 */
		public abstract IEnumerable<Move> GetMoves(Position from, Board board);

		protected IEnumerable<Position> MovePositionsInDir(Position from, Board board, Direction dir)
		{
			for (Position pos = from + dir; Board.IsInside(pos); pos += dir)
			{
				if (!board.IsEmpty(pos))
				{

					Piece piece = board[pos];

					if (piece.Color != Color)
					{
						yield return pos;
					}
					break;
				}
				yield return pos;
			}
		}
	
		protected IEnumerable<Position>MovePositionsInDirs(Position from, Board board, Direction[] dirs)
		{
			return dirs.SelectMany(dir=>MovePositionsInDir(from, board, dir)); //The SelectMany method is a LINQ (Language Integrated Query) extension method in C# that is used to flatten a sequence of sequences. It is often used when you have a collection of elements, and each element contains another collection, and you want to work with the individual elements of these inner collections as a single flattened sequence.

		}

		public virtual bool CanCaptureOpponentKing(Position from,Board board)
		{
			return GetMoves(from, board).Any(move =>
			{
				Piece piece = board[move.ToPos];
				return piece != null && piece.Type == PieceType.King;
			});
		}
	}
}
