using MDPyramid.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MDPyramid
{
	public class PyramidParser : IPyramidParser
	{
		private readonly static string inputResourceName = "MDPyramid.Input.txt";

		public Pyramid ParseHardcoded()
		{
			return new Pyramid(new PyramidNode[][]
			{
				new PyramidNode[] { new PyramidNode(1) },
				new PyramidNode[] { new PyramidNode(8), new PyramidNode(9) },
				new PyramidNode[] { new PyramidNode(1), new PyramidNode(5), new PyramidNode(9) },
				new PyramidNode[] { new PyramidNode(4), new PyramidNode(5), new PyramidNode(2), new PyramidNode(3) },
			});
		}

		public Pyramid ParseFromFile()
		{
			List<List<PyramidNode>> pyramid = new List<List<PyramidNode>>();
			Assembly assembly = Assembly.GetExecutingAssembly();

			using (Stream stream = assembly.GetManifestResourceStream(inputResourceName))
			using (StreamReader reader = new StreamReader(stream))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					List<PyramidNode> parsedNodes = line
						.Split(" ")
						.Select(number => new PyramidNode(Int32.Parse(number)))
						.ToList();

					pyramid.Add(parsedNodes);
				}
			}

			// TODO: Return read only collection
			return new Pyramid(pyramid.Select(nodes => nodes.ToArray()).ToArray());
		}
	}
}