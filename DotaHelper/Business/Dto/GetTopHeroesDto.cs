using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class GetTopHeroesDto
    {
        public List<int> Team1 { get; set; }
        public List<int> Team2 { get; set; }
    }
}
