using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Repository
{
    public class PagingConfig
    {
        public PagingConfig(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
