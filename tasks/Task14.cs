using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task14 : Battleship
	{
		static Random random = new Random();
		static bool Dir => random.Next() % 2 == 0;
		public Task14()
		{
			Overriden = true;
			Index = 14;
			Name = "Task14";
		}
		public override void Solve()
		{
			base.Solve();
			field = new byte[10, 10];
			PrintField(GetRandomField());
			Console.ReadKey();
		}
		bool IsPosible(byte[,] field, bool dir, int l, int i, int j)
		{
			for (int l0 = 0; l0 < l; l0++)
				try { if (!PosibleCell(i + (dir ? l0 : 0), j + (dir ? 0 : l0))) return false; }
				catch { return false; }
			return true;
		}

		List<object> GetPosible(byte[,] field, bool dir, int l)
		{
			var res = new List<object>();
			for (int i = 0; i < 10; i++)
				for (int j = 0; j < 10; j++)
					if (IsPosible(field, dir, l, i, j))
						res.Add(new int[] { i, j });
			return res;
		}

		private byte[,] GetRandomField()
		{
			for (int l = 4; l > 0; l--)
			{
				for (int k = 0; k < 5 - l; k++)
				{
					byte[,] posible = GetPosibleField();
					List<object> posibleVertical = GetPosible(posible, true, l);
					List<object> posibleHorisontal = GetPosible(posible, false, l);
					List<object> selected = posibleHorisontal;
					bool dir = false;
					if (posibleVertical.Count > 0 && posibleHorisontal.Count > 0)
						selected = (dir = Dir) ? posibleVertical : posibleHorisontal;
					else if (posibleVertical.Count > 0)
					{
						dir = true;
						selected = posibleVertical;
					}
					int[] point = (int[])selected[random.Next(selected.Count)];
					for (int l0 = 0; l0 < l; l0++)
						field[point[0] + (dir ? l0 : 0), point[1] + (dir ? 0 : l0)] = 1;
				}
			}
			return field;
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
