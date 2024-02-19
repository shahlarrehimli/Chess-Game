
namespace ChessLogic
{
	public class Bishop:Piece
	{
		public override PieceType Type=>PieceType.Bishop;
		public override Player Color { get; }

		private static readonly Direction[] dirs = new Direction[]
		{
			Direction.NorthWest, 
			Direction.NorthEast, 
			Direction.SouthWest, 
			Direction.SouthEast
		};
		public Bishop(Player color)
		{
			Color = color;
		}
		public override Piece Copy()
		{
			Bishop copy=new Bishop(Color);
			copy.HasMoved = HasMoved;
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
