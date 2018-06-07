using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Reflection;
using Kitchanismo;
using System.Runtime.InteropServices;

namespace test
{
    public partial class Customize : Form
    {

        private KitchanismoTransition transition = new KitchanismoTransition();
        private KitchanismoAnimation animation = new KitchanismoAnimation();

        private Color silver;
        private Color gray;
        private Color dgray;
        private Color egray;
        private Point point;

        public Customize()
        {
            InitializeComponent();
            InitializeColor();
        }

        private void InitializeColor()
        {
            silver = Color.Silver;
            gray = Color.Gray;
            dgray = Color.DimGray;
            egray = Color.FromArgb(90, 90, 90);
        }

        private void InitializeTransition()
        {
            transition.TabArray(panel1, panel2, panel3, panel4, panel5);
           
            var origin = new Point(0, 0);

            panel1.Location = origin;
            panel2.Location = origin;
            panel3.Location = origin;
            panel4.Location = origin;
            panel5.Location = origin;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTransition();
        }

        #region btns

        private void btntab1_Click(object sender, EventArgs e)
        {
            RunAccentBar(btntab1, panel1.BackColor);
            DoTransition(panel1);

            FadeColor(btntab2, silver);
            FadeColor(btntab3, gray);
            FadeColor(btntab4, dgray);
            FadeColor(btntab5, egray);
        }

        private void btntab2_Click(object sender, EventArgs e)
        {
            RunAccentBar(btntab2, panel2.BackColor);
            DoTransition(panel2);

            FadeColor(btntab1, silver);
            FadeColor(btntab3, silver);
            FadeColor(btntab4, gray);
            FadeColor(btntab5, dgray);
        }


        private void btntab3_Click(object sender, EventArgs e)
        {
            RunAccentBar(btntab3, panel3.BackColor);
            DoTransition(panel3);

            FadeColor(btntab1, gray);
            FadeColor(btntab2, silver);
            FadeColor(btntab4, silver);
            FadeColor(btntab5, dgray);
        }

        private void btntab4_Click(object sender, EventArgs e)
        {
            RunAccentBar(btntab4, panel4.BackColor);
            DoTransition(panel4);

            FadeColor(btntab1, dgray);
            FadeColor(btntab2, gray);
            FadeColor(btntab3, silver);
            FadeColor(btntab5, silver);
        }
        private void btntab5_Click(object sender, EventArgs e)
        {
            RunAccentBar(btntab5, panel5.BackColor);
            DoTransition(panel5);

            FadeColor(btntab1, egray);
            FadeColor(btntab2, dgray);
            FadeColor(btntab3, gray);
            FadeColor(btntab4, silver);
        }

        private void rbx_CheckedChanged(object sender, EventArgs e)
        {
            if (rbx.Checked == true)
            {
                transition.X = true;
                ChangeShift(rbfl, rbfr);
                rbIntersect.Enabled = false;
                rbSwap.Checked = true;
            }
        }

        private void rby_CheckedChanged(object sender, EventArgs e)
        {
            if (rby.Checked == true)
            {
                transition.Y = true;
                rbIntersect.Enabled = false;
                rbSwap.Checked = true;
                ChangeShift(rbfu, rbfd);
            }
        }
        private void rbxy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbxy.Checked == true)
            {
                transition.XY = true;
                rbIntersect.Enabled = true;
                rbSwap.Checked = true;
                ChangeShift(rbfl, rbfr);
            }
        }

        private void rbyx_CheckedChanged(object sender, EventArgs e)
        {
            if (rbyx.Checked == true)
            {
                transition.YX = true;
                rbIntersect.Enabled = true;
                rbSwap.Checked = true;
                ChangeShift(rbfu, rbfd);
            }
        }

        #endregion

        #region methods

        private void ChangeShift(RadioButton rb1, RadioButton rb2)
        {
            rb1.BringToFront(); rb2.BringToFront();
            rb1.Checked = true;

            FadeColor(btntab2, silver);
            FadeColor(btntab3, gray);
            FadeColor(btntab4, dgray);
            FadeColor(btntab5, egray);

            RunAccentBar(btntab1, panel1.BackColor);
            InitializeTransition();
        }

        private void FadeColor(Control btn, Color color)
        {
            animation.ColorSpeed = (int)num.Value;
            animation.Color = color;
            animation.ChangeForeColor(btn);
        }

        private void RunAccentBar(Button btn, Color col)
        {
            point.Y = pnnav.Location.Y;
            point.X = btn.Location.X;

            animation.AccentSpeed = 25;
            animation.Color = col;
            animation.Location = point;

            animation.MoveAccentBar(pnnav);
            animation.ChangeBackColor(pnnav);

            FadeColor(btn, Color.White);
            FadeColor(lblversion, col);

            animation.ChangeBackColor(pncontainer);
        }

        private void DoTransition(Control ctrl)
        {
            transition.Speed = Int32.Parse(num.Value.ToString());
            transition.Ease = EaseFactory.ParseEase(cbo.Text.ToString().ToLower());

            //y

            if (rbSwap.Checked == true && rby.Checked == true && rbfu.Checked == true)
            {
                transition.ReverseShift = false;
                transition.Type = TypeTransition.Swap;
                transition.Shift = ShiftTransition.Y;
                transition.Run(ctrl);
                return;
            }

            else if (rbSwap.Checked == true && rby.Checked == true && rbfd.Checked == true)
            {
                transition.ReverseShift = true;
                transition.Type = TypeTransition.Swap;
                transition.Shift = ShiftTransition.Y;
                transition.Run(ctrl);
                return;
            }
            else if (rbPush.Checked == true && rby.Checked == true && rbfu.Checked == true)
            {
                transition.ReverseShift = false;
                transition.Type = TypeTransition.Push;
                transition.Shift = ShiftTransition.Y;
                transition.Run(ctrl);
                return;
            }

            else if (rbPush.Checked == true && rby.Checked == true && rbfd.Checked == true)
            {
                transition.ReverseShift = true;
                transition.Type = TypeTransition.Push;
                transition.Shift = ShiftTransition.Y;
                transition.Run(ctrl);
                return;
            }

            //x

            if (rbSwap.Checked == true && rbx.Checked == true && rbfl.Checked == true)
            {
                transition.ReverseShift = false;
                transition.Type = TypeTransition.Swap;
                transition.Shift = ShiftTransition.X;
                transition.Run(ctrl);
                return;
            }

            else if (rbSwap.Checked == true && rbx.Checked == true && rbfr.Checked == true)
            {
                transition.ReverseShift = true;
                transition.Type = TypeTransition.Swap;
                transition.Shift = ShiftTransition.X;
                transition.Run(ctrl);
                return;
            }
            else if (rbPush.Checked == true && rbx.Checked == true && rbfl.Checked == true)
            {
                transition.ReverseShift = true;
                transition.Type = TypeTransition.Push;
                transition.Shift = ShiftTransition.X;
                transition.Run(ctrl);
                return;
            }

            else if (rbPush.Checked == true && rbx.Checked == true && rbfr.Checked == true)
            {
                transition.ReverseShift = false;
                transition.Type = TypeTransition.Push;
                transition.Shift = ShiftTransition.X;
                transition.Run(ctrl);
                return;
            }

            //yx

            if (rbSwap.Checked == true && rbyx.Checked == true && rbfu.Checked == true)
            {
                transition.ReverseShift = false;
                transition.Type = TypeTransition.Swap;
                transition.Shift = ShiftTransition.YX;
                transition.Run(ctrl);
                return;
            }

            else if (rbSwap.Checked == true && rbyx.Checked == true && rbfd.Checked == true)
            {
                transition.ReverseShift = true;
                transition.Type = TypeTransition.Swap;
                transition.Shift = ShiftTransition.YX;
                transition.Run(ctrl);
                return;
            }
            else if (rbPush.Checked == true && rbyx.Checked == true && rbfu.Checked == true)
            {
                transition.ReverseShift = false;
                transition.Type = TypeTransition.Push;
                transition.Shift = ShiftTransition.YX;
                transition.Run(ctrl);
                return;
            }

            else if (rbPush.Checked == true && rbyx.Checked == true && rbfd.Checked == true)
            {
                transition.ReverseShift = true;
                transition.Type = TypeTransition.Push;
                transition.Shift = ShiftTransition.YX;
                transition.Run(ctrl);
                return;
            }

            else if (rbIntersect.Checked == true && rbyx.Checked == true && rbfu.Checked == true)
            {
                transition.ReverseShift = true;
                transition.Type = TypeTransition.Intersect;
                transition.Shift = ShiftTransition.YX;
                transition.Run(ctrl);
                return;
            }

            else if (rbIntersect.Checked == true && rbyx.Checked == true && rbfd.Checked == true)
            {
                transition.ReverseShift = false;
                transition.Type = TypeTransition.Intersect;
                transition.Shift = ShiftTransition.YX;
                transition.Run(ctrl);
            }

            //xy

            if (rbSwap.Checked == true && rbxy.Checked == true && rbfl.Checked == true)
            {
                transition.ReverseShift = false;
                transition.Type = TypeTransition.Swap;
                transition.Shift = ShiftTransition.XY;
                transition.Run(ctrl);
                return;
            }

            else if (rbSwap.Checked == true && rbxy.Checked == true && rbfr.Checked == true)
            {
                transition.ReverseShift = true;
                transition.Type = TypeTransition.Swap;
                transition.Shift = ShiftTransition.XY;
                transition.Run(ctrl);
                return;
            }
            else if (rbPush.Checked == true && rbxy.Checked == true && rbfl.Checked == true)
            {
                transition.ReverseShift = false;
                transition.Type = TypeTransition.Push;
                transition.Shift = ShiftTransition.XY;
                transition.Run(ctrl);
                return;
            }

            else if (rbPush.Checked == true && rbxy.Checked == true && rbfr.Checked == true)
            {
                transition.ReverseShift = true;
                transition.Type = TypeTransition.Push;
                transition.Shift = ShiftTransition.XY;
                transition.Run(ctrl);
                return;
            }
            else if (rbIntersect.Checked == true && rbxy.Checked == true && rbfl.Checked == true)
            {
                transition.ReverseShift = true;
                transition.Type = TypeTransition.Intersect;
                transition.Shift = ShiftTransition.XY;
                transition.Run(ctrl);
                return;
            }

            else if (rbIntersect.Checked == true && rbxy.Checked == true && rbfr.Checked == true)
            {
                transition.ReverseShift = false;
                transition.Type = TypeTransition.Intersect;
                transition.Shift = ShiftTransition.XY;
                transition.Run(ctrl);
                return;
            }


        }

        #endregion

        #region drag

        private void pnmain_MouseDown(object sender, MouseEventArgs e)
        {
            animation.Grab(pnmain);
        }

        private void pnmain_MouseUp(object sender, MouseEventArgs e)
        {
            animation.Release();
        }

        private void pnmain_MouseMove(object sender, MouseEventArgs e)
        {
            animation.Move(pnmain);
        }

        #endregion

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            
            var generate= new GeneratedForm(GeneratedTransition());
            generate.Show();
        }

        private KitchanismoTransition GeneratedTransition()
        {
            var _transition = new KitchanismoTransition();
            
            _transition.Speed = (int)num.Value;
            _transition.Type = GeneratedType();
            _transition.ReverseShift = NegateShift(IsReverseShit());
            _transition.Shift = GeneratedShift();
            _transition.Ease = EaseFactory.ParseEase(cbo.Text.ToString().ToLower());

            return _transition;
        }

        private TypeTransition GeneratedType()
        {
            if (rbSwap.Checked)
            {
                return TypeTransition.Swap;
            }
            if (rbPush.Checked)
            {
                return TypeTransition.Push;
            }
            if (rbIntersect.Checked)
            {
                return TypeTransition.Intersect;
            }
            return TypeTransition.Swap;
        }


        private bool NegateShift(bool b)
        {
            if ((rbPush.Checked && rbx.Checked) || (rbIntersect.Checked && rbxy.Checked) || (rbIntersect.Checked && rbyx.Checked))
            {
                return !b;
            }
            return b;
        }

        private bool IsReverseShit()
        {
            if (rbfu.Checked == true)
            {
                return false;
            }
            if (rbfd.Checked == true)
            {
                return true;
            }
            if (rbfl.Checked == true)
            {
                return false;
            }
            if (rbfr.Checked == true)
            {
                return true;
            }
            return false;
        }

        private ShiftTransition GeneratedShift()
        {
            if (rby.Checked == true)
            {
                return ShiftTransition.Y;
            }
            if (rbx.Checked == true)
            {
                return ShiftTransition.X;
            }
            if (rbyx.Checked == true)
            {
                return ShiftTransition.YX;
            }
            if (rbxy.Checked == true)
            {
                return ShiftTransition.XY;
            }
            return ShiftTransition.Y;
        }
    }
}
