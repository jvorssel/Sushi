using System.Collections;
using System.Collections.Generic;

namespace Sushi.Helpers
{
    /// <summary>
    ///     Split the given <see cref="string"/> with a specific <see cref="char"/> and iterate over each occurrence.
    /// </summary>
    public class StringEnumerator : IEnumerator<string>, IEnumerable<string>
    {
        private readonly string _complete;
        private readonly string[] _split;

        public readonly char Split;
        public int Index;
        public int Count;

        public StringEnumerator(string complete, char split = '\n')
        {
            _complete = complete;
            _split = complete.Split(split);

            Split = split;
            Count = _split.Length - 1;
        }


        #region Implementation of IDisposable

        /// <inheritdoc />
        public void Dispose() { }

        #endregion

        #region Implementation of IEnumerator

        /// <inheritdoc />
        public bool MoveNext()
        {
            if (Index > Count)
                return false;

            Current = _split[Index] + (Index < Count ? Split.ToString() : "");
            Index++;

            return true;
        }

        /// <inheritdoc />
        public void Reset()
        {
            Index = 0;
            Count = _split.Length - 1;
        }

        /// <inheritdoc />
        public string Current { get; private set; }

        /// <inheritdoc />
        object IEnumerator.Current => Current;

        #endregion

        #region Implementation of IEnumerable

        /// <inheritdoc />
        public IEnumerator<string> GetEnumerator() => this;

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
