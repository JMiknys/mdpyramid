using MDPyramid.Models;

namespace MDPyramid.Extensions
{
    public static class PyramidNodeExtensions
    {
		public static bool HasValidPathBetween (this PyramidNode leftCandidate, PyramidNode rightCandidate)
		{
			if (leftCandidate == null || rightCandidate == null)
			{
				return false;
			}

			return rightCandidate.NodeWeight % 2 != leftCandidate.NodeWeight % 2;
		}
    }
}
