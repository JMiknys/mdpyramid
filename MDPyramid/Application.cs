using MDPyramid.Extensions;
using MDPyramid.Models;
using System;

namespace MDPyramid
{
	public class Application : IApplication
	{
		private readonly IPyramidParser pyramidParser;

		public Application(IPyramidParser pyramidParser)
		{
			this.pyramidParser = pyramidParser;
		}

		public void Run()
		{
			// Use either ParseFromFile() or ParseHardcoded() method
			Pyramid pyramid = pyramidParser.ParseFromFile();

			for (int y = pyramid.Length - 2; y >= 0; y--)
			{
				for (int x = 0; x < pyramid[y].Length; x++)
				{
					PyramidNode chosenPathNode =
						SelectBestCandidateForPath(currentNode: pyramid[y][x], leftCandidate: pyramid[y + 1][x], rightCandidate: pyramid[y + 1][x + 1]);

					if (chosenPathNode == null)
					{
						pyramid[y][x] = null;
					}
					else
					{
						pyramid[y][x].AppendPath(chosenPathNode.Path);
					}
				}
			}

			PyramidNode pyramidTop = pyramid[0][0];

			Console.WriteLine($"Max sum: { pyramidTop.Sum }");
			Console.WriteLine($"Path: { string.Join(", ", pyramidTop.Path) }");
			Console.ReadLine();
		}

		private PyramidNode SelectBestCandidateForPath(PyramidNode currentNode, PyramidNode leftCandidate, PyramidNode rightCandidate)
		{
			PyramidNode chosenPathNode = null;

			if (leftCandidate.HasValidPathBetween(currentNode))
			{
				chosenPathNode = leftCandidate;
			}

			if (rightCandidate.HasValidPathBetween(currentNode))
			{
				if (chosenPathNode == null)
				{
					chosenPathNode = rightCandidate;
				}
				else
				{
					chosenPathNode = leftCandidate.Sum > rightCandidate.Sum ? leftCandidate : rightCandidate;
				}
			}

			return chosenPathNode;
		}
	}
}