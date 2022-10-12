using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrelationEngine
{
    public interface IRecommender
    {
        
        double GetCorellation(int[] baseData, int[] otherData);
    }
}
