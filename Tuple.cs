using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace BLK10.Collections
{
    /// <summary>Helper so we can call some tuple methods recursively without knowing the underlying types.</summary>
    internal interface ITuple
    {
        string ToString(StringBuilder sb);
        int    GetHashCode(IEqualityComparer comparer);
        int    Size { get; }

    }

    public interface IStructuralEquatable
    {
        bool Equals(object other, IEqualityComparer comparer);
        int  GetHashCode(IEqualityComparer comparer);
    }

    public interface IStructuralComparable
    {
        int CompareTo(object other, IComparer comparer);
    }

    public static class Tuple
    {
        public static Tuple<T1> Create<T1>(T1 item1)
        {
            return (new Tuple<T1>(item1));
        }

        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return (new Tuple<T1, T2>(item1, item2));
        }

        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return (new Tuple<T1, T2, T3>(item1, item2, item3));
        }

        public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            return (new Tuple<T1, T2, T3, T4>(item1, item2, item3, item4));
        }

        public static Tuple<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            return (new Tuple<T1, T2, T3, T4, T5>(item1, item2, item3, item4, item5));
        }
         
       
        // From System.Web.Util.HashCodeCombiner
        internal static int CombineHashCodes(int h1, int h2)
        {
            return (((h1 << 5) + h1) ^ h2);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3)
        {
            return (Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2), h3));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4)
        {
            return (Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2), Tuple.CombineHashCodes(h3, h4)));
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5)
        {
            return (Tuple.CombineHashCodes(Tuple.CombineHashCodes(h1, h2, h3, h4), h5));
        }
                
    }


    [Serializable]
    public class Tuple<T1> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        [SerializeField]
        private T1 _item1;

        public T1 Item1 { get { return (this._item1); } }

        public Tuple(T1 item1)
        {
            this._item1 = item1;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null) return false;

            Tuple<T1> objTuple = other as Tuple<T1>;

            if (objTuple == null)
            {
                return false;
            }

            return comparer.Equals(this._item1, objTuple._item1);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return (1);

            Tuple<T1> objTuple = other as Tuple<T1>;

            if (objTuple == null)
            {
                throw new ArgumentException("object other type");                
            }

            return comparer.Compare(this._item1, objTuple._item1);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return comparer.GetHashCode(this._item1);
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder().Append("(");

            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            return (sb.Append(this._item1)
                      .Append(")")
                      .ToString());            
        }

        int ITuple.Size
        {
            get { return (1); }
        }
    }

    [Serializable]
    public class Tuple<T1, T2> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        [SerializeField]
        private T1 _item1;
        [SerializeField]
        private T2 _item2;

        public T1 Item1 { get { return (this._item1); } }
        public T2 Item2 { get { return (this._item2); } }

        public Tuple(T1 item1, T2 item2)
        {
            this._item1 = item1;
            this._item2 = item2;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default); ;
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null) return false;

            Tuple<T1, T2> objTuple = other as Tuple<T1, T2>;

            if (objTuple == null)
            {
                return (false);
            }

            return comparer.Equals(this._item1, objTuple._item1) && comparer.Equals(this._item2, objTuple._item2);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return (1);

            Tuple<T1, T2> objTuple = other as Tuple<T1, T2>;

            if (objTuple == null)
            {
                throw new ArgumentException("object other type");                
            }

            int c = 0;
            c = comparer.Compare(this._item1, objTuple._item1);

            if (c != 0)
                return (c);

            return comparer.Compare(this._item2, objTuple._item2);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return (Tuple.CombineHashCodes(comparer.GetHashCode(this._item1), comparer.GetHashCode(this._item2)));
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder().Append("(");

            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            return (sb.Append(this._item1)
                      .Append(", ")
                      .Append(this._item2)
                      .Append(")")
                      .ToString());
        }

        int ITuple.Size
        {
            get { return (2); }
        }
    }

    [Serializable]
    public class Tuple<T1, T2, T3> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        [SerializeField]
        private T1 _item1;
        [SerializeField]
        private T2 _item2;
        [SerializeField]
        private T3 _item3;

        public T1 Item1 { get { return (this._item1); } }
        public T2 Item2 { get { return (this._item2); } }
        public T3 Item3 { get { return (this._item3); } }

        public Tuple(T1 item1, T2 item2, T3 item3)
        {
            this._item1 = item1;
            this._item2 = item2;
            this._item3 = item3;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default); ;
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return (false);

            Tuple<T1, T2, T3> objTuple = other as Tuple<T1, T2, T3>;

            if (objTuple == null)
            {
                return (false);
            }

            return comparer.Equals(this._item1, objTuple._item1) && comparer.Equals(this._item2, objTuple._item2) && comparer.Equals(this._item3, objTuple._item3);
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return (1);

            Tuple<T1, T2, T3> objTuple = other as Tuple<T1, T2, T3>;

            if (objTuple == null)
            {
                throw new ArgumentException("object other type");                
            }

            int c = 0;
            c = comparer.Compare(this._item1, objTuple._item1);

            if (c != 0)
                return (c);

            c = comparer.Compare(this._item2, objTuple._item2);

            if (c != 0)
                return (c);

            return comparer.Compare(this._item3, objTuple._item3);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return (Tuple.CombineHashCodes(comparer.GetHashCode(this._item1), comparer.GetHashCode(this._item2), comparer.GetHashCode(this._item3)));
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder().Append("(");

            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            return (sb.Append(this._item1)
                      .Append(", ")
                      .Append(this._item2)
                      .Append(", ")
                      .Append(this._item3)
                      .Append(")")
                      .ToString());
        }

        int ITuple.Size
        {
            get { return (3); }
        }
    }

    [Serializable]
    public class Tuple<T1, T2, T3, T4> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        [SerializeField]
        private T1 _item1;
        [SerializeField]
        private T2 _item2;
        [SerializeField]
        private T3 _item3;
        [SerializeField]
        private T4 _item4;

        public T1 Item1 { get { return (this._item1); } }
        public T2 Item2 { get { return (this._item2); } }
        public T3 Item3 { get { return (this._item3); } }
        public T4 Item4 { get { return (this._item4); } }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            this._item1 = item1;
            this._item2 = item2;
            this._item3 = item3;
            this._item4 = item4;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default); ;
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return (false);

            Tuple<T1, T2, T3, T4> objTuple = other as Tuple<T1, T2, T3, T4>;

            if (objTuple == null)
            {
                return (false);
            }

            return (comparer.Equals(this._item1, objTuple._item1) && comparer.Equals(this._item2, objTuple._item2) &&
                    comparer.Equals(this._item3, objTuple._item3) && comparer.Equals(this._item4, objTuple._item4));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return (1);

            Tuple<T1, T2, T3, T4> objTuple = other as Tuple<T1, T2, T3, T4>;

            if (objTuple == null)
            {
                throw new ArgumentException("object other type");                
            }

            int c = 0;

            c = comparer.Compare(this._item1, objTuple._item1);

            if (c != 0)
                return (c);

            c = comparer.Compare(this._item2, objTuple._item2);

            if (c != 0)
                return (c);

            c = comparer.Compare(this._item3, objTuple._item3);

            if (c != 0)
                return (c);

            return comparer.Compare(this._item4, objTuple._item4);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return Tuple.CombineHashCodes(comparer.GetHashCode(this._item1), comparer.GetHashCode(this._item2), comparer.GetHashCode(this._item3), comparer.GetHashCode(this._item4));
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder().Append("(");

            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            return (sb.Append(this._item1)
                      .Append(", ")
                      .Append(this._item2)
                      .Append(", ")
                      .Append(this._item3)
                      .Append(", ")
                      .Append(this._item4)
                      .Append(")")
                      .ToString());
        }

        int ITuple.Size
        {
            get { return (4); }
        }
    }

    [Serializable]
    public class Tuple<T1, T2, T3, T4, T5> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
    {
        [SerializeField]
        private T1 _item1;
        [SerializeField]
        private T2 _item2;
        [SerializeField]
        private T3 _item3;
        [SerializeField]
        private T4 _item4;
        [SerializeField]
        private T5 _item5;

        public T1 Item1 { get { return (this._item1); } }
        public T2 Item2 { get { return (this._item2); } }
        public T3 Item3 { get { return (this._item3); } }
        public T4 Item4 { get { return (this._item4); } }
        public T5 Item5 { get { return (this._item5); } }

        public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            this._item1 = item1;
            this._item2 = item2;
            this._item3 = item3;
            this._item4 = item4;
            this._item5 = item5;
        }

        public override bool Equals(object obj)
        {
            return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default); ;
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null)
                return (false);

            Tuple<T1, T2, T3, T4, T5> objTuple = other as Tuple<T1, T2, T3, T4, T5>;

            if (objTuple == null)
            {
                return (false);
            }

            return (comparer.Equals(this._item1, objTuple._item1) && comparer.Equals(this._item2, objTuple._item2) &&
                    comparer.Equals(this._item3, objTuple._item3) && comparer.Equals(this._item4, objTuple._item4) && comparer.Equals(this._item5, objTuple._item5));
        }

        int IComparable.CompareTo(object obj)
        {
            return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null)
                return (1);

            Tuple<T1, T2, T3, T4, T5> objTuple = other as Tuple<T1, T2, T3, T4, T5>;

            if (objTuple == null)
            {
                throw new ArgumentException("object other type");                
            }

            int c = 0;

            c = comparer.Compare(this._item1, objTuple._item1);

            if (c != 0)
                return (c);

            c = comparer.Compare(this._item2, objTuple._item2);

            if (c != 0)
                return (c);

            c = comparer.Compare(this._item3, objTuple._item3);

            if (c != 0)
                return (c);

            c = comparer.Compare(this._item4, objTuple._item4);

            if (c != 0)
                return (c);

            return comparer.Compare(this._item5, objTuple._item5);
        }

        public override int GetHashCode()
        {
            return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return (Tuple.CombineHashCodes(comparer.GetHashCode(this._item1), comparer.GetHashCode(this._item2), comparer.GetHashCode(this._item3), comparer.GetHashCode(this._item4), comparer.GetHashCode(this._item5)));
        }

        int ITuple.GetHashCode(IEqualityComparer comparer)
        {
            return ((IStructuralEquatable)this).GetHashCode(comparer);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder().Append("(");

            return ((ITuple)this).ToString(sb);
        }

        string ITuple.ToString(StringBuilder sb)
        {
            return (sb.Append(_item1)
                      .Append(", ")
                      .Append(_item2)
                      .Append(", ")
                      .Append(_item3)
                      .Append(", ")
                      .Append(_item4)
                      .Append(", ")
                      .Append(_item5)
                      .Append(")")
                      .ToString());
        }

        int ITuple.Size
        {
            get { return (5); }
        }
    }
        
}