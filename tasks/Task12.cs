using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task12 : BattleshipWithInput
	{
		public Task12()
		{
			Overriden = true;
			Index = 12;
			Name = "Task12";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			Console.WriteLine("Повреждено кораблей: {0}",
				ShipDemaged(GetInt("Введите строку: ", 1, field.GetLength(0) + 1) - 1));
			Console.ReadKey();
		}
		private int ShipDemaged(int i)
		{
			int d = 0;
			int m = field.GetLength(1);
			for (int j = 0; j < m; j++)
				if (GetCell(i, j) > 0 && GetCell(i, j + 1) == 0)
					d++;
			return d;
		}
	}
}
