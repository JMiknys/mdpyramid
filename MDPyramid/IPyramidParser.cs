using MDPyramid.Models;

namespace MDPyramid
{
	public interface IPyramidParser
	{
		Pyramid ParseHardcoded();

		Pyramid ParseFromFile();
	}
}