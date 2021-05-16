using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
	class Battleship
	{
		internal byte[,] field;
		public bool Overriden { get; set; }
		public string Name { get; set; }
		public int Index { get; set; }
		public virtual void Solve()
		{
			Console.Clear();
		}
		public byte GetCell(int i, int j)
		{
			if (i < 0 || j < 0 || i >= field.GetLength(0) || j >= field.GetLength(1))
				return 0;
			return field[i, j];
		}
		public bool PosibleCell(int i, int j)
		{
			if (i < 0 || j < 0 || i >= field.GetLength(0) || j >= field.GetLength(1))
				return false;
			for (int x = -1; x < 2; x++)
				for (int y = -1; y < 2; y++)
					if (GetCell(i + x, j + y) > 0)
						return false;
			return true;
		}
		public void PrintField(byte[,] field)
		{
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
					Console.Write(field[i, j] > 0 ? '#' : '.');
				Console.WriteLine();
			}
		}
	}
}
