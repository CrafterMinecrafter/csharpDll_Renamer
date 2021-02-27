using System;
using System.IO;
using System.Reflection;

internal class Program
{
	public static void Main(string[] dlls)
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("Created by CrafterMinecrafter | https://github.com/CrafterMinecrafter");
		Console.ForegroundColor = ConsoleColor.DarkRed;
		foreach (string text in dlls)
		{
			Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(text), "renamed"));
			string assemblyName = Assembly.ReflectionOnlyLoad(File.ReadAllBytes(text)).FullName.Split(new char[]
			{
				','
			})[0];
			string destFileName = Path.Combine(Path.GetDirectoryName(text), "renamed\\" + assemblyName + ".dll");
			File.Copy(text, destFileName);
			Console.WriteLine(text + " Copied to " + destFileName);
		}
		Console.ReadLine();
	}
}
