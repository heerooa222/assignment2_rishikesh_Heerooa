using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment2
{
    public partial class Form1 : Form
    {
        Greyhound[] dogsArray = new Greyhound[4];
        private Timer timer1;
        private readonly IContainer components;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        int zackBet = 0;
        int nickBet = 0;
        int taylorBet = 0;
        bool Bet = false;
        public string winningDog;
        decimal dbOddsAgainst;
        public decimal Test;





        Guy[] guyArray = new Guy[3];
        private Label lblZack;
        private Label lblNick;
        private Label lblTaylor;
        private NumericUpDown numericUpDown2;
        private ComboBox comboBox1;
        private Label lblOdds;
        public Label lblDBOdds;
        private Label LROdds;
        private Label MOdds;
        private Label SSOdds;
        Random Randomizer = new Random();

       
        public Form1()
        {
            InitializeComponent();
            dogsArray[0] = new Greyhound() { MyPictureBox = pictureBox1, Name = "Day Break", RaceTrackLength = racetrackPictureBox.Width - pictureBox1.Width, StartingPosition = pictureBox1.Left, Randomizer = Randomizer, oddsFor = Randomizer.Next(1, 3), oddsAgainst = Randomizer.Next(2, 8) };
            dogsArray[1] = new Greyhound() { MyPictureBox = pictureBox2, Name = "Lightning's Revenge", RaceTrackLength = racetrackPictureBox.Width - pictureBox1.Width, StartingPosition = pictureBox2.Left, Randomizer = Randomizer, oddsFor = Randomizer.Next(1, 3), oddsAgainst = Randomizer.Next(2, 14) };
            dogsArray[2] = new Greyhound() { MyPictureBox = pictureBox3, Name = "Mytosis", RaceTrackLength = racetrackPictureBox.Width - pictureBox1.Width, StartingPosition = pictureBox3.Left, Randomizer = Randomizer, oddsFor = Randomizer.Next(1, 3), oddsAgainst = Randomizer.Next(2, 12) };
            dogsArray[3] = new Greyhound() { MyPictureBox = pictureBox4, Name = "Sleeping Sycamore", RaceTrackLength = racetrackPictureBox.Width - pictureBox1.Width, StartingPosition = pictureBox4.Left, Randomizer = Randomizer, oddsFor = Randomizer.Next(1, 3), oddsAgainst = Randomizer.Next(2, 10) };

            guyArray[0] = new Guy() { MyBet = null, Name = "Zack", Cash = 50, MyLabel = lblZack, MyRadioButton = rdbtnZack, MyLabel2 = lblZackBet };
            guyArray[1] = new Guy() { MyBet = null, Name = "Nick", Cash = 75, MyLabel = lblNick, MyRadioButton = rdbtnNick, MyLabel2 = lblNickBet };
            guyArray[2] = new Guy() { MyBet = null, Name = "Taylor", Cash = 45, MyLabel = lblTaylor, MyRadioButton = rdbtnTaylor, MyLabel2 = lblTaylorBet };

            guyArray[0].UpdateLabels();
            guyArray[1].UpdateLabels();
            guyArray[2].UpdateLabels();


            if (dogsArray[0].oddsFor.ToString() == dogsArray[0].oddsAgainst.ToString())
                lblDBOdds.Text = "Even";
            else
                lblDBOdds.Text = dogsArray[0].oddsAgainst.ToString() + " : " + dogsArray[0].oddsFor.ToString();
            if (dogsArray[1].oddsFor.ToString() == dogsArray[1].oddsAgainst.ToString())
                LROdds.Text = "Even";
            else
                LROdds.Text = dogsArray[1].oddsAgainst.ToString() + " : " + dogsArray[1].oddsFor.ToString();
            if (dogsArray[2].oddsFor.ToString() == dogsArray[2].oddsAgainst.ToString())
                MOdds.Text = "Even";
            else
                MOdds.Text = dogsArray[2].oddsAgainst.ToString() + " : " + dogsArray[2].oddsFor.ToString();
            if (dogsArray[3].oddsFor.ToString() == dogsArray[3].oddsAgainst.ToString())
                SSOdds.Text = "Even";
            else
                SSOdds.Text = dogsArray[3].oddsAgainst.ToString() + " : " + dogsArray[3].oddsFor.ToString();
        }

        private void lblBetter_Click(object sender, EventArgs e)
        {

        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            dogsArray[0].TakeStartingPosition();
            dogsArray[1].TakeStartingPosition();
            dogsArray[2].TakeStartingPosition();
            dogsArray[3].TakeStartingPosition();
            zackBet = 0;
            nickBet = 0;
            taylorBet = 0;
            btnRace.Enabled = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdbtnZack_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnZack.Enabled)
                lblBetter.Text = "Zack";
        }

        private void rdbtnNick_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnNick.Enabled)
                lblBetter.Text = "Nick";
        }

        private void rdbtnTaylor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTaylor.Enabled)
                lblBetter.Text = "Taylor";
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToString() == "Day Break")
                Test = dogsArray[0].oddsAgainst / dogsArray[0].oddsFor;
            if (comboBox1.Text.ToString() == "Lightning's Revenge")
                Test = dogsArray[1].oddsAgainst / dogsArray[1].oddsFor;
            if (comboBox1.Text.ToString() == "Mytosis")
                Test = dogsArray[2].oddsAgainst / dogsArray[2].oddsFor;
            if (comboBox1.Text.ToString() == "Sleeping Sycamore")
                Test = dogsArray[3].oddsAgainst / dogsArray[3].oddsFor;

            if (lblBetter.Text == "Zack")
            {
                if (zackBet == 0)
                {

                    Bet = guyArray[0].PlaceBet(Convert.ToInt16(numericUpDown2.Value), comboBox1.Text.ToString(), Test);
                    if (Bet == true)
                    {
                        zackBet = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Zack has already placed a bet.");
                }

            }
            if (lblBetter.Text == "Nick")
            {
                if (nickBet == 0)
                {
                    Bet = guyArray[1].PlaceBet(Convert.ToInt16(numericUpDown2.Value), comboBox1.Text.ToString(), Test);
                    if (Bet == true)
                    {
                        nickBet = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Nick has already placed a bet.");
                }

            }
            if (lblBetter.Text == "Taylor")
            {
                if (taylorBet == 0)
                {
                    Bet = guyArray[2].PlaceBet(Convert.ToInt16(numericUpDown2.Value), comboBox1.Text.ToString(), Test);
                    if (Bet = true)
                    {
                        taylorBet = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Taylor has already placed a bet.");
                }

            }
        }
    }
}
        
    
    
