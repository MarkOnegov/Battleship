using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task10 : BattleshipWithInput
	{
		public Task10()
		{
			Overriden = true;
			Index = 10;
			Name = "Task10";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			Console.WriteLine("Корабли раставлены {0}правильно", ValidateField() ? "" : "не");
			Console.ReadKey();
		}
		bool ClearShip(int i, int j, int di, int dj)
		{
			if (di > 0)
			{
				if (GetCell(i, j + 1) + GetCell(i, j - 1) > 1)
					return false;
			}
			else if (dj > 0)
			{
				if (GetCell(i + 1, j) + GetCell(i - 1, j) > 1)
					return false;
			}
			if (GetCell(i, j) > 1)
			{
				field[i, j] = 0;
				return ClearShip(i + di, j + dj, di, dj);
			}
			return true;
		}
		bool ValideteShips()
		{
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (field[i, j] > 0)
					{
						if (
							GetCell(i + 1, j) +
							GetCell(i, j + 1) > 1
							)
							return false;
						if (GetCell(i + 1, j) > 0)
							if (ClearShip(i, j, 1, 0))
								return false;
							else if (GetCell(i, j + 1) > 0)
								if (!ClearShip(i, j, 0, 1))
									return false;
					}
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (field[i, j] > 0)
						return false;
			return true;
		}
		bool ValidatePlaces()
		{
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (field[i, j] > 0)
					{
						if (GetCell(i + 1, j + 1) + GetCell(i + 1, j - 1) > 0)
							return false;
					}
			return true;
		}

		public bool ValidateField()
		{
			if (!ValideteShips())
				return false;
			Dictionary<int, int> ships = GetShips();
			if (ships.Count != 4)
				return false;
			for (int i = 1; i < 5; i++)
			{
				if (!ships.ContainsKey(i))
					return false;
				if (ships[i] != 5 - i)
					return false;
			}
			return ValidatePlaces();
		}
		public Dictionary<int, int> GetShips()
		{
			var res = new Dictionary<int, int>();
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (field[i, j] > 0)
					{
						if (GetCell(i - 1, j) + GetCell(i, j - 1) == 0)
						{
							int l = 1;
							if (GetCell(i + 1, j) > 0)
								for (; GetCell(i + l, j) > 0; l++) ;
							else if (GetCell(i, j + 1) > 0)
								for (; GetCell(i, j + l) > 0; l++) ;
							if (res.ContainsKey(l))
								res[l] = res[l] + 1;
							else
								res.Add(l, 1);
						}
					}
			return res;
		}
	}
}