using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace TShirtVoter.Models
{
    public class ContestDbContext : DbContext
{
    public DbSet<ContestEntry> Entries { get; set; }
    public DbSet<ContestVote> Votes { get; set; }
}
}
