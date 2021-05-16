using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task8 : BattleshipWithInput
	{
		public Task8()
		{
			Overriden = true;
			Index = 8;
			Name = "Task8/Task9";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			Console.WriteLine("Кол-во караблей: {0}", CountShip());
			Console.ReadKey();
		}
		private void ClearShip(int i, int j)
		{
			if (GetCell(i, j) > 0)
			{
				field[i, j] = 0;
				ClearShip(i - 1, j);
				ClearShip(i + 1, j);
				ClearShip(i, j - 1);
				ClearShip(i, j + 1);
			}
		}

		int CountShip()
		{
			int count = 0;
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (field[i, j] > 0)
					{
						count++;
						ClearShip(i, j);
					}
			return count;
		}
	}
}
