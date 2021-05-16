using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Battleship
{
	class BattleshipWithInput : Battleship
	{
		public override void Solve()
		{
			base.Solve();
			field = Select();
			Console.Clear();
		}
		public List<FileInfo> GetFiles()
		{
			try { return new DirectoryInfo(Directory.GetCurrentDirectory() + "\\maps").GetFiles().ToList(); }
			catch { return new List<FileInfo>(); }
		}
		public byte[,] Select()
		{
			while (true)
			{
				Console.Clear();
				var f = GetFiles();
				var i = 0;
				for (; i < f.Count; i++)
					Console.WriteLine("{0})\t{1}", i + 1, f[i].Name);
				Console.WriteLine("{0})\tВвести вручную", ++i);
				Console.WriteLine("0)\tВыйти");
				var index = Convert.ToInt32(Console.ReadLine());
				if (index == i)
				{
					var field = EnterField();
					if (field != null) return field;
				}
				else if (index == 0) return null;
				else if (index > 0 && index < i)
				{
					var field = SelectFile(f[index - 1]);
					if (field != null) return field;
				}
			}
		}
		public int GetInt(string q, int min = int.MinValue, int max = int.MaxValue)
		{
			while (true)
			{
				try
				{
					Console.Write(q);
					int x = Convert.ToInt32(Console.ReadLine());
					if (x < max && x >= min) return x;
					throw new Exception();
				}
				catch (Exception)
				{
					Console.WriteLine("Ошибка ввода");
				}

			}
		}
		public byte[,] EnterField()
		{
			Console.Clear();
			int w = GetInt("Введите ширину: ", 1);
			int h = GetInt("Введите высоту: ", 1);
			return new EnterField(w, h).GetField();
		}
		public byte[,] SelectFile(FileInfo file)
		{
			Console.Clear();
			Console.WriteLine(file.Name);
			byte[,] res = ReadField(file.FullName);
			PrintField(res);
			Console.WriteLine("Нажмите Enter, чтобы выбрать данное поле,");
			Console.WriteLine("или любую другую клавишу для отмены");
			if (Console.ReadKey().Key == ConsoleKey.Enter) return res;
			return null;
		}
		byte[,] ReadField(string path)
		{
			byte[,] res;
			using (StreamReader sr = new StreamReader(path))
			{
				string[] size = sr.ReadLine().Split(' ');
				int n = Convert.ToInt32(size[0]);
				int m = Convert.ToInt32(size[1]);
				res = new byte[n, m];
				for (int i = 0; i < n; i++)
				{
					string vals = sr.ReadLine();
					for (int j = 0; j < m; j++)
						res[i, j] = (byte)(vals[j] - '0');
				}
			}
			return res;
		}
	}
}
