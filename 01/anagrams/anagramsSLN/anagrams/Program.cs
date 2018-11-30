using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace anagrams
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(" - Insert a word to look for it Anagram ! -");
			// -- start program
			InputProcessing.ProcessInput();

			// -- end program
			Console.ReadLine();
		}

	}

	class FileProcessing {

		public static StreamReader FileToRead()
		{
			Variables vars = new Variables
			{
			// -- setting path to file
				ListPath = Path.Combine(Directory.GetCurrentDirectory(), "wordList.txt")
			};

			// -- read file
			StreamReader file = new StreamReader(vars.ListPath);
			return file;
		}

		public static bool CompareCharArrays(char[] arr1, char[] arr2)
		{
			List<char> list1 = new List<char>(arr1);
			List<char> list2 = new List<char>(arr2);
			list1.Sort();
			list2.Sort();
			if (list1.SequenceEqual(list2))
			{
				return true;
			}
			return false;
		}

		public static void ReadLinesInFile(char[] value)
		{
			Variables vars = new Variables
			{
				File = FileToRead(),
			};

			while ((vars.Line = vars.File.ReadLine()) != null)
			{
				vars.Counter++;
				if (value.Length == vars.Line.Length)
				{
					if (CompareCharArrays(vars.Line.ToCharArray(), value))
					{
						SuccessResult(value, vars.Line, vars.Counter);
						break;
					}
				}
			}
			vars.File.Close();
		}
		
		public static void SuccessResult(char[] value, string line, int counter) {
			Console.WriteLine($"User value is :{string.Join("", value)} anagram find in our list : {line} , in Line : {counter}");
		}

	}

	class InputProcessing {

		public static char[] ReadInput()
		{
			return Console.ReadLine().ToCharArray();
		}

		public static void ProcessInput()
		{
			//variables
			Variables vars = new Variables
			{
				// --- read input from user
				ValueToRead = ReadInput()
			};
			FileProcessing.ReadLinesInFile(vars.ValueToRead);
		}
	}

	class Variables
	{
		public char[] ValueToRead { get; set; }
		public int Counter { get ; set; } = 0;
		public string Line { get; set; }
		public string ListPath { get; set; }
		public StreamReader File { get; set; }
	}
}
