using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Concentration_Game
{
    public partial class memoryGameForm : Form
    {
        //Variables
        Random location = new Random(); //Selects a random value, and we use it in our loop to place our cards in random places
        List<Point> points = new List<Point>(); //a list to use for the position of the cards
       

        PictureBox pendingImage1;// store first flipped card
        PictureBox pendingImage2;// store second flipped card

        //bool playAgain = false; // a bool fuction to play again or not


        public memoryGameForm()
        {
            InitializeComponent();
        }

        private void memoryGameForm_Load(object sender, EventArgs e)
        {
            timeCountLabel.Text = "3";

            foreach (PictureBox picture in gamePanel.Controls)
            {
                picture.Enabled = false;
                points.Add(picture.Location); //we add every picture location to our points List
            }
            foreach (PictureBox picture in gamePanel.Controls)
            {
                int nextLocation=location.Next(points.Count); //we count each location to nextLocation and then move to another
                Point p = points[nextLocation];
                picture.Location = p;   
                points.Remove(p);  //we need to remove it because some of them has the same value and we will be missing some cards
            }


            timer2.Start();
            timer1.Start();// we start our timer and after 5 seconds the cards will flip

            //Initialize our images
            card1.Image = Properties.Resources.Card1;
            dupCard1.Image = Properties.Resources.Card1;
            card2.Image = Properties.Resources.Card2;
            dupCard2.Image = Properties.Resources.Card2;
            card3.Image = Properties.Resources.Card3;
            dupCrad3.Image = Properties.Resources.Card3;
            card4.Image = Properties.Resources.Card4;
            dupCard4.Image= Properties.Resources.Card4;
            card5.Image = Properties.Resources.Card5;
            dupCard5.Image= Properties.Resources.Card5;
            card6.Image = Properties.Resources.Card6;  
            dupCard6.Image= Properties.Resources.Card6;
            card7.Image = Properties.Resources.Card7;
            dupCard7.Image= Properties.Resources.Card7; 
            card8.Image = Properties.Resources.Card8;
            dupCard8.Image= Properties.Resources.Card8;
            card9.Image = Properties.Resources.Card9;
            dupCard9.Image= Properties.Resources.Card9;
            card10.Image= Properties.Resources.Card10;
            dupCard10.Image= Properties.Resources.Card10;
            card11.Image= Properties.Resources.Card11;
            dupCard11.Image= Properties.Resources.Card11;
            card12.Image= Properties.Resources.Card12;
            dupCard12.Image= Properties.Resources.Card12;
          
        }

        //After 5 seconds the cards will fli to the cover image
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); //we stop the timer because we dont need it after this and save memory
           foreach(PictureBox picture in gamePanel.Controls)
            {
              picture.Enabled=false; //we cannot interact with our pictures before the timer stops
              picture.Cursor = Cursors.Hand; //we added a hand cursor for style
              picture.Image = Properties.Resources.Cover;
            }
        }
     
        private void timer2_Tick(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(timeCountLabel.Text);// we use this to countdown in our label
            timer = timer - 1;//for our timer to decreased
            timeCountLabel.Text=Convert.ToString(timer);

            if (timer ==0)
            {
                timer2.Stop(); //we stop our secodnd timer to save memory again
            }
        }

        //in this region we contain the change value of the cards functions
        #region Cards
        private void card1_Click(object sender, EventArgs e)
        {
            card1.Image = Properties.Resources.Card1;

            if(pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card1;
            }
            else if (pendingImage1 != null && pendingImage2 ==null) //if we use the first one then we use the second one
            {
                pendingImage2 = card1;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card1.Enabled = false; //this is so we cant click on the same card again after we match a pair
                    dupCard1.Enabled = false;
                    counterLabel.Text =Convert.ToString(Convert.ToInt32 (counterLabel.Text) + 10); // i found it much nicer to add a score instead of how many times you click on a image
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            } 
        }

        private void dupCard1_Click(object sender, EventArgs e)
        {
            dupCard1.Image = Properties.Resources.Card1;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCard1;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCard1;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card2.Enabled = false;
                    dupCard2.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void card2_Click(object sender, EventArgs e)
        {
            card2.Image = Properties.Resources.Card2;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card2;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = card2;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card2.Enabled = false;
                    dupCard2.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void dupCard2_Click(object sender, EventArgs e)
        {
            dupCard2.Image = Properties.Resources.Card2;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCard2;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCard2;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card2.Enabled = false;
                    dupCard2.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void card3_Click(object sender, EventArgs e)
        {
            card3.Image = Properties.Resources.Card3;


            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card3;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = card3;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card3.Enabled = false;
                    dupCrad3.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void dupCrad3_Click(object sender, EventArgs e)
        {
            dupCrad3.Image = Properties.Resources.Card3;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCrad3;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCrad3;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card3.Enabled = false;
                    dupCrad3.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void card4_Click(object sender, EventArgs e)
        {
            card4.Image = Properties.Resources.Card4;


            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card4;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = card4;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card4.Enabled = false;
                    dupCard4.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void dupCard4_Click(object sender, EventArgs e)
        {
            dupCard4.Image = Properties.Resources.Card4;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCard4;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCard4;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card4.Enabled = false;
                    dupCard4.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void card5_Click(object sender, EventArgs e)
        {
            card5.Image = Properties.Resources.Card5;


            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card5;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = card5;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card5.Enabled = false;
                    dupCard5.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void dupCard5_Click(object sender, EventArgs e)
        {
            dupCard5.Image = Properties.Resources.Card5;


            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCard5;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCard5;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card5.Enabled = false;
                    dupCard5.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void card6_Click(object sender, EventArgs e)
        {
            card6.Image = Properties.Resources.Card6;


            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card6;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = card6;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card6.Enabled = false;
                    dupCard6.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void dupCard6_Click(object sender, EventArgs e)
        {
            dupCard6.Image = Properties.Resources.Card6;


            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCard6;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCard6;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card6.Enabled = false;
                    dupCard6.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void card7_Click(object sender, EventArgs e)
        {
            card7.Image = Properties.Resources.Card7;


            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card7;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = card7;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card7.Enabled = false;
                    dupCard7.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void dupCard7_Click(object sender, EventArgs e)
        {
            dupCard7.Image = Properties.Resources.Card7;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCard7;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCard7;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card7.Enabled = false;
                    dupCard7.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void card8_Click(object sender, EventArgs e)
        {
            card8.Image = Properties.Resources.Card8;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card8;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = card8;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card8.Enabled = false;
                    dupCard8.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void dupCard8_Click(object sender, EventArgs e)
        {
            dupCard8.Image = Properties.Resources.Card8;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCard8;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCard8;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card8.Enabled = false;
                    dupCard8.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void card9_Click(object sender, EventArgs e)
        {
            card9.Image = Properties.Resources.Card9;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card9;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = card9;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card9.Enabled = false;
                    dupCard9.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void dupCard9_Click(object sender, EventArgs e)
        {
            dupCard9.Image = Properties.Resources.Card9;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCard9;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCard9;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card9.Enabled = false;
                    dupCard9.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void card10_Click(object sender, EventArgs e)
        {
            card10.Image = Properties.Resources.Card10;


            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card10;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = card10;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card10.Enabled = false;
                    dupCard10.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void dupCard10_Click(object sender, EventArgs e)
        {
            dupCard10.Image = Properties.Resources.Card10;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCard10;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCard10;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card10.Enabled = false;
                    dupCard10.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void card11_Click(object sender, EventArgs e)
        {
            card11.Image = Properties.Resources.Card11;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card11;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = card11;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card11.Enabled = false;
                    dupCard11.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void dupCard11_Click(object sender, EventArgs e)
        {
            dupCard11.Image = Properties.Resources.Card11;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCard11;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCard11;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card11.Enabled = false;
                    dupCard11.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void card12_Click(object sender, EventArgs e)
        {
            card12.Image = Properties.Resources.Card12;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = card12;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = card12;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card12.Enabled = false;
                    dupCard12.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }

        private void dupCard12_Click(object sender, EventArgs e)
        {
            dupCard12.Image = Properties.Resources.Card12;

            if (pendingImage1 == null)  // if we dont use the first one, then we can use it
            {
                pendingImage1 = dupCard12;
            }
            else if (pendingImage1 != null && pendingImage2 == null) //if we use the first one then we use the second one
            {
                pendingImage2 = dupCard12;
            }
            if (pendingImage1 != null && pendingImage2 != null) //if we use the first one then we use the second one
            {
                if (pendingImage1.Tag == pendingImage2.Tag) //we use the tags to identify each set of pair
                {
                    pendingImage1 = null;
                    pendingImage2 = null;
                    card12.Enabled = false;
                    dupCard12.Enabled = false;
                    counterLabel.Text = Convert.ToString(Convert.ToInt32(counterLabel.Text) + 10);
                }
                else
                {
                    timer3.Start(); //we start our timer so we can be able to see both cards at the same time
                }
            }
        }
        #endregion
        //

        private void timer3_Tick(object sender, EventArgs e) //we added this counter to show the pair for 0.3 and then proceed
        {
            timer3.Stop();

            pendingImage1.Image = Properties.Resources.Cover; //if there are not similar we flip both of them back again
            pendingImage2.Image = Properties.Resources.Cover;

            pendingImage1 = null; //we send them back to null again so we can use them again in other cards
            pendingImage2 = null;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memoryGameForm_Load(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
    }
}
