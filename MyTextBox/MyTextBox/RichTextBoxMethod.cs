using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTextBox
{
    public static class RichTextBoxMethod
    {
        public static int GetCurrentLineNumber(this RichTextBox rtb)
        {
            int cursorPosition = rtb.SelectionStart;
            int lineIndex = rtb.GetLineFromCharIndex(cursorPosition);
            string lineText = rtb.Lines.ElementAt(lineIndex);
            return lineIndex;
        }

        public static string GetCurrentLine(this RichTextBox rtb)
        {
            int cursorPosition = rtb.SelectionStart;
            int lineIndex = rtb.GetLineFromCharIndex(cursorPosition);
            string lineText = rtb.Lines.ElementAt(lineIndex);
            return lineText;
        }

        public static int GetLineFromMouseClick(this RichTextBox rtb, Point pt)
        {
            int charIndex = rtb.GetCharIndexFromPosition(pt);
            int lineIndex = rtb.GetLineFromCharIndex(charIndex);
            return lineIndex;
        }

        public static int GetFirstVisiableLine(this RichTextBox rtb)
        {
            int topIndex = rtb.GetCharIndexFromPosition(new Point(1, 1));
            int topLine = rtb.GetLineFromCharIndex(topIndex);
            return topLine;
        }

        public static int GeLastVisiableLine(this RichTextBox rtb)
        {
            int topIndex = rtb.GetCharIndexFromPosition(new Point(1, rtb.Height - 1));
            int topLine = rtb.GetLineFromCharIndex(topIndex);
            return topLine;
        }
    }
}
