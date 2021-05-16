using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.tasks
{
	class Task1 : BattleshipWithInput
	{
		public Task1()
		{
			Overriden = true;
			Index = 1;
			Name = "Task1";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			Console.WriteLine("Палубность: Кол-во кораблей");
			GetShips().OrderBy(val => val.Key)
				.ToList()
				.ForEach(
					val =>
						Console.WriteLine("{0,10}: {1}", val.Key, val.Value)
					);
			field = null;
			Console.ReadKey();
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
