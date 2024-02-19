﻿using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChessLogic;

namespace ChessUI
{
	public static class Images
	{

		private static readonly Dictionary<PieceType, ImageSource> whiteSources = new()
		{
			{PieceType.Pawn,LoadImage("Assets/PawnW.png") },
			{PieceType.Knight,LoadImage("Assets/KnightW.png") },
			{PieceType.Bishop,LoadImage("Assets/BishopW.png") },
			{PieceType.Queen,LoadImage("Assets/QueenW.png") },
			{PieceType.King,LoadImage("Assets/KingW.png") },
			{PieceType.Rook,LoadImage("Assets/RookW.png") }
		};

		private static readonly Dictionary<PieceType, ImageSource> blackSources = new()
		{
			{PieceType.Pawn,LoadImage("Assets/PawnB.png") },
			{PieceType.Knight,LoadImage("Assets/KnightB.png") },
			{PieceType.Bishop,LoadImage("Assets/BishopB.png") },
			{PieceType.Queen,LoadImage("Assets/QueenB.png") },
			{PieceType.King,LoadImage("Assets/KingB.png") },
			{PieceType.Rook,LoadImage("Assets/RookB.png") }
		};


		public static ImageSource LoadImage(string filepath)
		{
			return new BitmapImage(new Uri(filepath,UriKind.Relative));
		}


		public static ImageSource GetImage(Player color,PieceType type)
		{
			return color switch
			{
				Player.White => whiteSources[type],
				Player.Black => blackSources[type],
				_ => null
			};
		}

		public static ImageSource GetImage(Piece piece)
		{
			if (piece == null)
			{
				return null;
			}
			return GetImage(piece.Color, piece.Type);
		}
		
	}
}
