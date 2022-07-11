namespace CollectionHierarchy.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class AddRemoveCollection : AddCollection, IAdd, IRemove
    {
        
        public override int Add(string element)
        {
            addCollectionOfStrings.Insert(0, element);
            return 0;
        }

        public virtual string Remove()
        {
            var removedElement = addCollectionOfStrings[addCollectionOfStrings.Count - 1];
            addCollectionOfStrings.Remove(removedElement);
            return removedElement;
        }
    }
}
