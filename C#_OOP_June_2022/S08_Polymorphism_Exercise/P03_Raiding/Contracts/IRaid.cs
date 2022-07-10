using Raiding.Models;
using System.Collections.Generic;

namespace Raiding.Contracts
{
    internal interface IRaid
    {
        IReadOnlyCollection<BaseHero> Heroes { get; }
    }
}
