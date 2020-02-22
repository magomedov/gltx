using Galytix.Compute.Interfaces;

namespace Galytix.Compute
{
    public class DefaultParametersConfigProvider : IComputationalParametersProvider
    {
        public ComputationalParameters GetParameters()
        {
            return new ComputationalParameters(new Range<int>(2008, 2015));
        }
    }
}