using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindMatchesGame
{
    internal class Classes
    {
        public class CustomButton : Button
        {
            public Image mouseDownPNG { get; set; }
            public Image mouseUpPNG { get; set; }

            protected override void OnMouseEnter(EventArgs e)
            {
                base.OnMouseEnter(e);
                FlatAppearance.MouseOverBackColor = BackColor;
            }

            protected override void OnMouseDown(MouseEventArgs mevent)
            {
                base.OnMouseDown(mevent);
                FlatAppearance.MouseDownBackColor = BackColor;
            }

            public void CustomButton_MouseDown(object sender, MouseEventArgs e) => BackgroundImage = mouseDownPNG;
            public void CustomButton_MouseUp(object sender, MouseEventArgs e) => BackgroundImage = mouseUpPNG;
        }
    }
}
