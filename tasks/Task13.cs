using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task13 : BattleshipWithInput
	{
		public Task13()
		{
			Overriden = true;
			Index = 13;
			Name = "Task13";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			int x = GetInt("Введите x: ", 1, field.GetLength(1) + 1);
			int y = GetInt("Введите y: ", 1, field.GetLength(0) + 1);
			Console.WriteLine("Повреждено кораблей: {0}", ShipDemaged(y - 1, x - 1));
			Console.ReadKey();
		}
		int ShipDemaged(int i, int j)
		{
			int d = 0;
			for (int x = -1; x < 2; x++)
				for (int y = -1; y < 2; y++)
					if (GetCell(i + x, j + y) > 0)
					{
						d++;
						ClearShip(i + x, j + y);
					}
			return d;
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
	}
}
