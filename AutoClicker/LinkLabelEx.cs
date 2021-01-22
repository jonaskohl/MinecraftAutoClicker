using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker
{
    public class LinkLabelEx : LinkLabel
    {
        public LinkLabelEx()
        {
            LinkBehavior = LinkBehavior.SystemDefault;
        }

        private const int IDC_HAND = 32649;
        private const int WM_SETCURSOR = 0x0020;
        private const int HTCLIENT = 1;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(HandleRef hcursor);

        private static readonly Cursor SystemHandCursor = new Cursor(LoadCursor(IntPtr.Zero, IDC_HAND));

        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_SETCURSOR)
                WmSetCursor(ref msg);
            else
                base.WndProc(ref msg);
        }

        private void WmSetCursor(ref Message m)
        {
            if (m.WParam == (IsHandleCreated ? Handle : IntPtr.Zero) && (unchecked((int)(long)m.LParam) & 0xffff) == HTCLIENT)
            {
                if (OverrideCursor != null)
                {
                    if (OverrideCursor == Cursors.Hand)
                        SetCursor(new HandleRef(SystemHandCursor, SystemHandCursor.Handle));
                    else
                        SetCursor(new HandleRef(OverrideCursor, OverrideCursor.Handle));
                }
                else
                {
                    SetCursor(new HandleRef(Cursor, Cursor.Handle));
                }
            }
            else
            {
                DefWndProc(ref m);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            base.OnPaint(e);
        }
    }
}
