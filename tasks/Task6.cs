using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task6 : BattleshipWithInput
	{
		public Task6()
		{
			Overriden = true;
			Index = 6;
			Name = "Task6";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			Console.WriteLine("Кол-во кораблей: {0}", CountShip());
			Console.ReadKey();
		}
		private int CountShip()
		{
			int count = 0;
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (field[i, j] > 0)
						if (GetCell(i - 1, j) + GetCell(i, j - 1) == 0)
							count++;
			return count;
		}
	}
}
