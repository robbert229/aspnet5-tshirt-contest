using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TShirtVoter.Models
{
    public class ContestStatus
    {
        public ContestEntry Winner { get; set; }
        public List<ContestVote> Votes { get; set; }
    }
}
