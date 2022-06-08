using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {

        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }

        private T left;
        private T right;

        public T Left
        {
            get { return left; }
            set { left = value; }
        }


        public T Right
        {
            get { return right; }
            set { right = value; }
        }



        public bool AreEqual()
        {
            return Left.Equals(Right);
        }

    }
}
