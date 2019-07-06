using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DanceParties.Data
{
    public class AsyncEnumerableQuery<T> : EnumerableQuery<T>, IAsyncEnumerable<T>
    {
        public AsyncEnumerableQuery(IEnumerable<T> enumerable) : base(enumerable)
        {
        }

        public AsyncEnumerableQuery(Expression expression) : base(expression)
        {
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new InMemoryDbAsyncEnumerator<T>(((IEnumerable<T>)this).GetEnumerator());
        }

        public IAsyncEnumerator<T> GetEnumerator()
        {
            return GetAsyncEnumerator();
        }        

        private class InMemoryDbAsyncEnumerator<T> : IAsyncEnumerator<T>
        {
            private readonly IEnumerator<T> _enumerator;

            public InMemoryDbAsyncEnumerator(IEnumerator<T> enumerator)
            {
                _enumerator = enumerator;
            }

            public void Dispose()
            {
            }

            public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(_enumerator.MoveNext());
            }

            public Task<bool> MoveNext(CancellationToken cancellationToken)
            {
                return Task.FromResult(_enumerator.MoveNext());
            }

            public T Current => _enumerator.Current;
        }
    }
}
