using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArtistsRankTest
{
    public class AssemblyLoader
    {
        public Assembly Assembly { get; set; }
        public AssemblyLoader()
        {
            Assembly = Assembly.Load("ArtistsRanking");
        }
    }
}
