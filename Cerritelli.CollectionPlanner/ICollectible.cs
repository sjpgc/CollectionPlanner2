using System;
using Cerritelli.CollectionPlanner.Interfaces;

namespace Cerritelli.CollectionPlanner
{
    /// <summary>
    /// Placeholder interface for everything that is collectible (i.e. can be part of a collection)
    /// </summary>
    public interface ICollectible : IPersistable, IEquatable<ICollectible>
    {
    }
}