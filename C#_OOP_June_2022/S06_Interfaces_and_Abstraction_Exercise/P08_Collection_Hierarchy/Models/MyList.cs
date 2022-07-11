namespace CollectionHierarchy.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class MyList : AddRemoveCollection, IAdd, IRemove
    {
        
        public override string Remove()
        {
            var removedElement = addCollectionOfStrings[0];
            addCollectionOfStrings.Remove(removedElement);
            return removedElement;
        }
    }
}
