#if NET35
namespace System
{
    enum LazyThreadSafetyMode
    {
        None,
        PublicationOnly,
        ExecutionAndPublication
    }

    class Lazy<T>
    {
        readonly Func<T> valueFactory;
        readonly bool isThreadSafe;
        readonly object _lock = new();
        T? value;

        public Lazy(Func<T> valueFactory)
            : this(valueFactory, true)
        {
        }

        public Lazy(Func<T> valueFactory, LazyThreadSafetyMode mode)
            : this(valueFactory, mode != LazyThreadSafetyMode.None)
        {
        }

        public Lazy(Func<T> valueFactory, bool isThreadSafe)
        {
            this.valueFactory = valueFactory;
            this.isThreadSafe = isThreadSafe;
        }

        public T Value
        {
            get
            {
                if (value == null)
                {
                    if (!isThreadSafe)
                    {
                        return value = valueFactory();
                    }
                    lock (_lock)
                    {
                        if (value == null)
                        {
                            value = valueFactory();
                        }
                    }
                }
                return value;
            }
        }
    }
}
#endif