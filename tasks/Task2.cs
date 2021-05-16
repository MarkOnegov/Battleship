using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.tasks
{
	class Task2 : BattleshipWithInput
	{
		public Task2()
		{
			Overriden = true;
			Index = 2;
			Name = "Task2";
		}
		public override void Solve()
		{
			base.Solve();
			if (field == null) return;
			PrintField(field);
			int x = GetInt("Введите x: ", 1, field.GetLength(1) + 1);
			int y = GetInt("Введите y: ", 1, field.GetLength(0) + 1);
			switch (Shot(x - 1, y - 1))
			{
				case 0:
					Console.WriteLine("Промах");
					break;
				case 1:
					Console.WriteLine("Попал");
					break;
				case 2:
					Console.WriteLine("Потопил");
					break;
			}
			field = null;
			Console.ReadKey();
		}
		private byte Shot(int i, int j)
		{
			if (GetCell(i, j) == 0)
				return 0;
			if (
				GetCell(i - 1, j) +
				GetCell(i + 1, j) +
				GetCell(i, j - 1) +
				GetCell(i, j + 1) > 0
				)
				return 1;
			return 2;
		}
	}
}
