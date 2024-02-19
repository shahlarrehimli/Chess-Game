namespace ChessLogic
{

	public class Rook : Piece
	{
		public override PieceType Type => PieceType.Rook;
		public override Player Color { get; }

		private static readonly Direction[] dirs = new Direction[]
		{
			Direction.North,
			Direction.South,
			Direction.East,
			Direction.West
		};

		public Rook(Player color)
		{
			Color = color;
		}
		public override Piece Copy()
		{
			Rook copy = new(Color)
			{
				HasMoved = HasMoved
			};
			return copy;
		}


		private IEnumerable<Position> MovePositionsInDir(Position from, Board board, Direction[] dirs)
		{
			foreach (var dir in dirs)
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
		}
		public override IEnumerable<Move> GetMoves(Position from, Board board)
		{
			return MovePositionsInDir(from, board, dirs).Select(to => new NormalMove(from, to));
		}

	}
}
