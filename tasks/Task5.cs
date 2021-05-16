using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task5 : BattleshipWithInput
	{
		public Task5()
		{
			Overriden = true;
			Index = 5;
			Name = "Task5";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			Console.WriteLine("Можно поставить двухпалубных: {0}", NewDoubleShip());
			Console.ReadKey();
		}
		private int NewDoubleShip()
		{
			int count = 0;
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (PosibleCell(i, j))
					{
						if (PosibleCell(i + 1, j))
							count++;
						if (PosibleCell(i, j + 1))
							count++;
					}
			return count;
		}
	}
}
