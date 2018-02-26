using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility.Helpers
{
    public class StringEnumerator : IEnumerator<string>
    {
        private readonly string _complete;
        private readonly string[] _rows;

        public readonly char Split;
        public int RowIndex;
        public int RowCount;

        public StringEnumerator(string complete, char split = '\n')
        {
            _complete = complete;
            _rows = complete.Split(split);

            Split = split;
            RowCount = _rows.Length - 1;
        }


        #region Implementation of IDisposable

        /// <inheritdoc />
        public void Dispose() { }

        #endregion

        #region Implementation of IEnumerator

        /// <inheritdoc />
        public bool MoveNext()
        {
            if (RowIndex > RowCount)
                return false;

            Current = _rows[RowIndex] + (RowIndex < RowCount && RowIndex != 0 ? Split.ToString() : "");
            RowIndex++;

            return true;
        }

        /// <inheritdoc />
        public void Reset()
        {
            RowIndex = 0;
            RowCount = _rows.Length - 1;
        }

        /// <inheritdoc />
        public string Current { get; private set; }

        /// <inheritdoc />
        object IEnumerator.Current => Current;

        #endregion
    }
}
