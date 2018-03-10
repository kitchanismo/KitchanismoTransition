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
using kitchanismo_transition;
using System.Runtime.InteropServices;

namespace test
{
    public partial class CustomizeTransition : Form
    {
      
        Kitchanismo kitchan = new Kitchanismo();
        Assembly assembly = Assembly.GetExecutingAssembly();
        Color silver = Color.Silver;
        Color gray = Color.Gray;
        Color dgray = Color.DimGray;
        Color egray = Color.FromArgb(90, 90, 90);
        Point p;

        int loc;
        int speed = 1000;
        IEasing trans_ease;

        public CustomizeTransition()
        {
            InitializeComponent();
           // pnnav.Left = this.Width + pnnav.Width;
            TProperties.initLocation(getGUID());
            TProperties.speed = speed;
        }

        string getGUID()
        {
            var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            return attribute.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            p.Y = pnnav.Location.Y;
            p.X = btntab1.Location.X;
           // kitchan.xylocation_back(pnnav, p, 1200, 100);
            loc = 0;
        
            
        }

        #region drag

        //menu
        private void pnmain_MouseDown(object sender, MouseEventArgs e)
        {
            kitchan.Grab(pnmain);
        }

        private void pnmain_MouseUp(object sender, MouseEventArgs e)
        {
            kitchan.Release();
        }

        private void pnmain_MouseMove(object sender, MouseEventArgs e)
        {
            kitchan.MoveObject(pnmain);
        }
     
        #endregion

        #region tabs

        private void btntab1_Click(object sender, EventArgs e)
        {

            move_accent(btntab1, panel1.BackColor);
            doTransition(panel1);
            kitchan.changeforecolor_control(btntab2, silver);
            kitchan.changeforecolor_control(btntab3, gray);
            kitchan.changeforecolor_control(btntab4, dgray);
            kitchan.changeforecolor_control(btntab5, egray);

        }

        private void btntab2_Click(object sender, EventArgs e)
        {
            move_accent(btntab2, panel2.BackColor);
            doTransition(panel2);
            kitchan.changeforecolor_control(btntab1, silver);
            kitchan.changeforecolor_control(btntab3, silver);
            kitchan.changeforecolor_control(btntab4, gray);
            kitchan.changeforecolor_control(btntab5, dgray);
        }


        private void btntab3_Click(object sender, EventArgs e)
        {
            move_accent(btntab3, panel3.BackColor);
            doTransition(panel3);
            kitchan.changeforecolor_control(btntab1, gray);
            kitchan.changeforecolor_control(btntab2, silver);
            kitchan.changeforecolor_control(btntab4, silver);
            kitchan.changeforecolor_control(btntab5, dgray);
        }

        private void btntab4_Click(object sender, EventArgs e)
        {
            move_accent(btntab4, panel4.BackColor);
            doTransition(panel4);
            kitchan.changeforecolor_control(btntab1, dgray);
            kitchan.changeforecolor_control(btntab2, gray);
            kitchan.changeforecolor_control(btntab3, silver);
            kitchan.changeforecolor_control(btntab5, silver);
        }
        private void btntab5_Click(object sender, EventArgs e)
        {
            move_accent(btntab5, panel5.BackColor);
            doTransition(panel5);
            kitchan.changeforecolor_control(btntab1, egray);
            kitchan.changeforecolor_control(btntab2, dgray);
            kitchan.changeforecolor_control(btntab3, gray);
            kitchan.changeforecolor_control(btntab4, silver);
        }

        #endregion

        #region pointers

        private void rbx_CheckedChanged(object sender, EventArgs e)
        {
            if (rbx.Checked == true)
            {
                TProperties.initlocX = true;
                change_point(rbfl, rbfr);
                rb3.Enabled = false;
                rb1.Checked = true;
            }
        }

        private void rby_CheckedChanged(object sender, EventArgs e)
        {
            if (rby.Checked == true)
            {
                TProperties.initlocY = true;
                change_point(rbfu, rbfd);
                rb3.Enabled = false;
                rb1.Checked = true;
            }
        }
        private void rbxy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbxy.Checked == true)
            {
                TProperties.initlocXY = true;
                change_point(rbfl, rbfr);
                rb3.Enabled = true;
                rb1.Checked = true;
            }
        }

        private void rbyx_CheckedChanged(object sender, EventArgs e)
        {
            if (rbyx.Checked == true)
            {
                TProperties.initlocYX = true;
                change_point(rbfu, rbfd);
                rb3.Enabled = true;
                rb1.Checked = true;
            }
        }

     
        #endregion

        #region methods


        public void doTransition(Control target)
        {
            initType(target);

            //y
            if (rb1.Checked == true && rby.Checked == true && rbfu.Checked == true)
            {
                kitchan.y_swap(true);//swap,y,up
            }

            else if (rb1.Checked == true && rby.Checked == true && rbfd.Checked == true)
            {
                kitchan.y_swap(false);//swap,y,down
            }
            else if (rb2.Checked == true && rby.Checked == true && rbfu.Checked == true)
            {
                kitchan.y_wipe(true);//wipe,y,up
            }

            else if (rb2.Checked == true && rby.Checked == true && rbfd.Checked == true)
            {
                kitchan.y_wipe(false);//wipe,y,down
            }
            

            //x

            if (rb1.Checked == true && rbx.Checked == true && rbfl.Checked == true)
            {
                kitchan.x_swap(true);//swap,x,left
            }

            else if (rb1.Checked == true && rbx.Checked == true && rbfr.Checked == true)
            {
                kitchan.x_swap(false);//swap,x,right
            }
            else if (rb2.Checked == true && rbx.Checked == true && rbfl.Checked == true)
            {
                kitchan.x_wipe(true);//wipe,x,left
            }

            else if (rb2.Checked == true && rbx.Checked == true && rbfr.Checked == true)
            {
                kitchan.x_wipe(false);//wipe,x,right
            }

            //yx

            if (rb1.Checked == true && rbyx.Checked == true && rbfu.Checked == true)
            {
                kitchan.yx_swap(true);//swap,yx,up
            }

            else if (rb1.Checked == true && rbyx.Checked == true && rbfd.Checked == true)
            {

                kitchan.yx_swap(false);//swap,yx,down
            }
            else if (rb2.Checked == true && rbyx.Checked == true && rbfu.Checked == true)
            {
                kitchan.yx_wipe(true);//wipe,yx,up
            }

            else if (rb2.Checked == true && rbyx.Checked == true && rbfd.Checked == true)
            {
                kitchan.yx_wipe(false);//wipe,yx,down
            }

            else if (rb3.Checked == true && rbyx.Checked == true && rbfu.Checked == true)
            {
                kitchan.yx_slide(true);//slide,yx,up
            }

            else if (rb3.Checked == true && rbyx.Checked == true && rbfd.Checked == true)
            {
                kitchan.yx_slide(false);//slide,yx,down
            }
            
            //xy

            if (rb1.Checked == true && rbxy.Checked == true && rbfl.Checked == true)
            {
                kitchan.xy_swap(true);//swap,xy,left
            }

            else if (rb1.Checked == true && rbxy.Checked == true && rbfr.Checked == true)
            {
                kitchan.xy_swap(false);//swap,xy,right
            }
            else if (rb2.Checked == true && rbxy.Checked == true && rbfl.Checked == true)
            {
                kitchan.xy_wipe(true);//wipe,xy,left
            }

            else if (rb2.Checked == true && rbxy.Checked == true && rbfr.Checked == true)
            {
                kitchan.xy_wipe(false);//wipe,xy,right
            }
            else if (rb3.Checked == true && rbxy.Checked == true && rbfl.Checked == true)
            {
                kitchan.xy_slide(true);//slide,xy,up
            }

            else if (rb3.Checked == true && rbxy.Checked == true && rbfr.Checked == true)
            {
                kitchan.xy_slide(false);//slide,xy,down
            }
        }

        void move_accent(Button btn, Color col)
        {
            p.Y = pnnav.Location.Y;
            p.X = btn.Location.X;
            kitchan.move_animation(pnnav, p, 30);
            kitchan.changebackcolor_control(pnnav, col);
            kitchan.changeforecolor_control(btn, Color.White);
            kitchan.changeforecolor_control(lblversion, col);
        }

        void change_point(RadioButton rb1, RadioButton rb2)
        {
            rb1.BringToFront(); rb2.BringToFront();
            rb1.Checked = true;
            move_accent(btntab1, panel1.BackColor);
            //reset tab forecolor
            kitchan.changeforecolor_control(btntab2, silver);
            kitchan.changeforecolor_control(btntab3, gray);
            kitchan.changeforecolor_control(btntab4, dgray);
            kitchan.changeforecolor_control(btntab5, egray);
            //reset panels location
            panel1.BringToFront();
            panel1.Location = new Point(0, 0);
            panel2.Location = new Point(0, 0);
            panel3.Location = new Point(0, 0);
            panel4.Location = new Point(0, 0);
            panel5.Location = new Point(0, 0);
        }

        void initType(Control target)
        {
            //init target move hide
            TProperties.nav = target;

            //init panel
            TProperties.nav1 = panel1;
            TProperties.nav2 = panel2;
            TProperties.nav3 = panel3;
            TProperties.nav4 = panel4;
            TProperties.nav5 = panel5;

            //if less than 5 nav/panel/tab use, assign a new object panel
            //i.e. 
            //TProperties.nav5 = new Panel();

            //init location, speed, ease
            TProperties.loc = loc;
            TProperties.speed = Int32.Parse(num.Value.ToString());
            TProperties.ease = EaseFactory.parseEase(cbo.Text.ToString().ToLower());
        }


        #endregion

       

     

    }
}
