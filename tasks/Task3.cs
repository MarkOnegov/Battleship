using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task3 : BattleshipWithInput
	{
		public Task3()
		{
			Overriden = true;
			Index = 3;
			Name = "Task3";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			GetDirection().ToList().ForEach(v => Console.WriteLine("{0}:\t{1}", v.Key, v.Value));
			Console.ReadKey();
		}
		private Dictionary<string, int> GetDirection()
		{
			Dictionary<string, int> res = new Dictionary<string, int>();
			res.Add("Вертикально", 0);
			res.Add("Горизонтально", 0);
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (field[i, j] > 0)
					{
						if (GetCell(i - 1, j) + GetCell(i, j - 1) == 0)
						{
							if (GetCell(i + 1, j) > 0)
								res["Вертикально"]++;
							else if (GetCell(i, j + 1) > 0)
								res["Горизонтально"]++;
						}
					}
			return res;
		}
	}
}
