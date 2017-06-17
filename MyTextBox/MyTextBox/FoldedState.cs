using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBox
{
    class FoldedState: System.IEquatable<FoldedState>
    {
        public int Header;
        public string Content;

        public bool Equals(FoldedState other)
        {
            return this.Header == other.Header;
        }
    }
}
