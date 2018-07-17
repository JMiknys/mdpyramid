using System.Collections.Generic;
using System.Linq;

namespace MDPyramid.Models
{
	public class PyramidNode
	{
		private List<int> path;

		public int Sum
		{
			get
			{
				return path.Sum();
			}
		}

		public int NodeWeight
		{
			get
			{
				return path.First();
			}
		}

		public IReadOnlyList<int> Path
		{
			get
			{
				return path.AsReadOnly();
			}
		}

		public PyramidNode(int nodeWeight)
		{
			path = new List<int>() { nodeWeight };
		}

		public void AppendPath(IEnumerable<int> path)
		{
			this.path.AddRange(path);
		}
	}
}
