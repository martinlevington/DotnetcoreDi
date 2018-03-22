using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetcoreDiFactory.Domain;

namespace DotnetcoreDiFactory.Infrastructure
{
    public class FruitFactory :  IServiceFactory<Apple>
    {

    

        public Apple Build()
        {
            return new Apple();
        }
    }
}
