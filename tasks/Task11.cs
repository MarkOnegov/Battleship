using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task11 : BattleshipWithInput
	{
		public Task11()
		{
			Overriden = true;
			Index = 11;
			Name = "Task11";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			Console.WriteLine("Самый большой корабль, который можно поставить: {0}", MaxS(GetPosibleField()));
			Console.ReadKey();
		}
		bool IsRect(byte[,] field, int i, int j, int x, int y)
		{
			for (int x1 = 0; x1 < x; x1++)
				for (int y1 = 0; y1 < y; y1++)
					if (field[i + x1, j + y1] == 0) return false;
			return true;
		}
		int MaxS(byte[,] field)
		{
			int s = 0;
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					for (int x = 1; x <= n - i; x++)
					{
						if (!IsRect(field, i, j, x, 1))
							break;//continue;
						for (int y = 1; y <= m - j; y++)
						{
							if (!IsRect(field, i, j, x, y))
								break;//continue;
							s = Math.Max(x * y, s);
						}
					}
			return s;
		}
		byte[,] GetPosibleField()
		{
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			byte[,] posibleField = new byte[n, m];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (PosibleCell(i, j)) posibleField[i, j] = 1;
					else posibleField[i, j] = 0;
			return posibleField;
		}
	}
}
