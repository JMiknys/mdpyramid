using MDPyramid.Models;

namespace MDPyramid
{
    public interface IPyramidParser
    {
		PyramidNode[][] ParseHardcoded();
		PyramidNode[][] ParseFromFile();
	}
}
