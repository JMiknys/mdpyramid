namespace MDPyramid.Models
{
	public class Pyramid
	{
		private readonly PyramidNode[][] pyramidNodes;

		public Pyramid(PyramidNode[][] pyramidNodes)
		{
			this.pyramidNodes = pyramidNodes;
		}

		public PyramidNode[] this[int i]
		{
			get
			{
				return pyramidNodes[i];
			}
		}

		public PyramidNode this[int i, int j]
		{
			get
			{
				return pyramidNodes[i][j];
			}
		}

		public int Length
		{
			get
			{
				return pyramidNodes.Length;
			}
		}
	}
}