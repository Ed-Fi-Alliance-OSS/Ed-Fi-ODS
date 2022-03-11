using System;

namespace EdFi.Security.DataAccess.Utils
{
    public class ResettableLazy<T>
    {
        private readonly Func<T> _valueFactory;
        private Lazy<T> _lazy;

        public bool IsValueCreated => _lazy.IsValueCreated;
        public T Value => _lazy.Value;

        public ResettableLazy(Func<T> valueFactory)
        {
            _valueFactory = valueFactory;
            _lazy = new Lazy<T>(_valueFactory);
        }

        public void Reset()
        {
            _lazy = new Lazy<T>(_valueFactory);
        }
    }
}
