namespace CollectionHierarchy.Models
{
    using Contracts;
    using System.Collections.Generic;

    public class AddCollection : IAdd
    {

        protected IList<string> addCollectionOfStrings;

        public AddCollection()
        {
            addCollectionOfStrings = new List<string>();
        }

        public IReadOnlyCollection<string> AddCollectionOfStrings
        {
            get { return (IReadOnlyCollection<string>)addCollectionOfStrings; }
        }
        public virtual int Add(string element)
        {
            addCollectionOfStrings.Add(element);
            return addCollectionOfStrings.Count - 1;
        }
    }
}
