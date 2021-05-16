using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task7 : BattleshipWithInput
	{
		public Task7()
		{
			Overriden = true;
			Index = 7;
			Name = "Task7";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			Console.WriteLine("Можно установить корабль длиной {0}", MaxNewShip());
			Console.ReadKey();
		}
		private int MaxNewShip()
		{
			int maxLen = 0;
			int n = field.GetLength(0);
			int m = field.GetLength(1);
			for (int i = 0; i < n; i++)
				for (int j = 0; j < m; j++)
					if (PosibleCell(i, j))
					{
						int len;
						for (len = 1; PosibleCell(i + len, j); len++) ;
						maxLen = Math.Max(maxLen, len);
						for (len = 1; PosibleCell(i, j + len); len++) ;
						maxLen = Math.Max(maxLen, len);
					}
			return maxLen;
		}
	}
}
