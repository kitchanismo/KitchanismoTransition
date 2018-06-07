using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kitchanismo;

namespace test
{
    public partial class GeneratedForm : Form
    {
        KitchanismoTransition transition = new KitchanismoTransition();
        KitchanismoAnimation animation = new KitchanismoAnimation();
        Transparent transparent = new Transparent();
        
        public GeneratedForm(KitchanismoTransition _transition)
        {
            transparent.Show();
            InitializeComponent();
            InitializePanel();
            transition = _transition;
            InitializeTabArray();
            
        }

        //aligning all panels inside panel wrapper to its origin
        private void InitializePanel()
        {
            var origin = new Point(0,0);

            TabGreen.Location = origin;
            TabGold.Location   = origin;
            TabIndigo.Location = origin;
        }

        //transition requirements
        private void InitializeTabArray()
        {
            //2 or more Controls
            //first array should be the Active Tab
            transition.TabArray(TabGreen, TabIndigo, TabGold);
        }
        
        private void BtnGreen_Click(object sender, EventArgs e)
        {
            doTransition(TabGreen);
            doAnimation(BtnGreen);
        }

        private void BtnIndigo_Click(object sender, EventArgs e)
        {
            doTransition(TabIndigo);
            doAnimation(BtnIndigo);
        }

        private void BtnGold_Click(object sender, EventArgs e)
        {
            doTransition(TabGold);
            doAnimation(BtnGold);
        }

        //assigning Control as Active Tab
        void doTransition(Control ctrl)
        {
            transition.Run(ctrl);
        }

        void doAnimation(Control btn)
        {
            var point = new Point();

            //set new location of PanelBar
            point.X = btn.Location.X;
            point.Y = PanelBar.Location.Y;

            //initialize animation
            animation.AccentSpeed = 25;
            animation.Location    = point;
            animation.Color       = btn.ForeColor;
            animation.ColorSpeed  = transition.Speed;

            //set PanelBar as Target to move
            animation.MoveAccentBar(PanelBar);

            //set PanelBar as Target to change BackColor
            animation.ChangeBackColor(PanelBar);

            //set PanelWrapper as Target to change BackColor
            animation.ChangeBackColor(PanelWrapper);

            //type can be specify
            //animation.ChangeBackColor<Panel>(PanelWrapper);
            //animation.MoveAccentBar<Panel>(PanelBar);
        }

        #region drag

        private void GeneratedForm_MouseDown(object sender, MouseEventArgs e)
        {
            animation.Grab(this);
        }

        private void GeneratedForm_MouseUp(object sender, MouseEventArgs e)
        {
            animation.Release();
        }

        private void GeneratedForm_MouseMove(object sender, MouseEventArgs e)
        {
            animation.Move(this);
        }

        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            transparent.Hide();
            this.Hide();
        }
    }
}
