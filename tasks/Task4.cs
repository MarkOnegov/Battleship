using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task4 : BattleshipWithInput
	{
		public Task4()
		{
			Overriden = true;
			Index = 4;
			Name = "Task4";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			Console.WriteLine("Можно поставить однопалубных: {0}", NewSingleShip());
			Console.ReadKey();
		}
		private int NewSingleShip()
		{
			int count = 0;
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (PosibleCell(i, j))
						count++;
			return count;
		}
	}
}
