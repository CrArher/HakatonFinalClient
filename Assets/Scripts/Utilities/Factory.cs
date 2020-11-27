using System;
using System.Collections.Generic;

namespace Utilities
{
    public class Factory
    {
        public readonly Dictionary<string, Func<Dictionary<string, object>, IDescription>> DescriptionFactory;

        public Factory()
        {
            DescriptionFactory = new Dictionary<string, Func<Dictionary<string, object>, IDescription>>()
            {
                // {"items", (node) => new ResourceDescription(node)},
            };
        }
    }
}