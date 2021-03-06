using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickGame
{
    public partial class Form1 : Form
    {
        SoundPlayer gameOverSong = new SoundPlayer(Directory.GetParent(Directory.GetCurrentDirectory())
           .Parent.Parent.FullName +  @"\BrickGame\WMPLib\game-over-sound-effect.wav");
        SoundPlayer soundPlayer = new SoundPlayer(Directory.GetParent(Directory.GetCurrentDirectory())
           .Parent.Parent.FullName + @"\BrickGame\WMPLib\Brick Game Tetris 9999 in 1 Music - Sounds.wav");

        bool goLeft;
        bool goRight;
        bool isGameOver;

        int score;
        int ballx;
        int bally;
        int playerSpeed;

        Random rnd = new Random();

        PictureBox[] blocksArray;

        public Form1()
        {
            InitializeComponent();
            //setupGame();
            placeBlocks();
            soundPlayer.Play();
        }

        private void setupGame()
        {
            soundPlayer.Play();
            
            isGameOver=false;
            score = 0;
            ballx = 5;
            bally = 5;
            playerSpeed = 12;
            txtScore.Text = "Score: " + score;


            ball.Left=428;
            ball.Top = 454;
            player.Left = 389;
            player.Top = 475;

            gameOverSong.Stop();
            gameTimer.Start();

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "blocks")
                {
                    x.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                }
            }

        }

        private void gameOver(String message)
        {
            isGameOver = true;
            gameTimer.Stop();

            txtScore.Text = "Score: " + score + " " + message;
            soundPlayer.Stop();
            gameOverSong.Play();
            DialogResult dialogResult = MessageBox.Show("Do you want to start a new game?", "New Game", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                removeBlocks();
                placeBlocks();
                soundPlayer.Play();
            }
            else
                // txtScore.Text = "Thank you for playing !";
                Application.Exit();
        }

        private void placeBlocks()
        {
            
            blocksArray = new PictureBox[36];  
            int a = 0;
            int top = 50;
            int left = 100;
        
            for(int i=0; i<blocksArray.Length; i++)
            {
                blocksArray[i] = new PictureBox();
                blocksArray[i].Height = 32;
                blocksArray[i].Width = 100;
                blocksArray[i].Tag = "blocks";
                blocksArray[i].BackColor = Color.White;

                if(a==6)
                {
                    top = top + 50;
                    left = 100;
                    a = 0;
                }

                if(a<6)
                {
                    a++;
                    blocksArray[i].Left = left;
                    blocksArray[i].Top = top;
                    this.Controls.Add(blocksArray[i]);
                    left += 130;
                }
            }

            setupGame();
        }


        private void removeBlocks()
        {
            foreach(PictureBox p in blocksArray)
            {
                this.Controls.Remove(p);
            }
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score; 
            if(goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }

            if(goRight == true && player.Left < 832)
            {
                player.Left += playerSpeed;
            }

            ball.Left += ballx;
            ball.Top += bally;

            if(ball.Left < 0 || ball.Left > 920) 
            {
                ballx = -ballx;
            }

            if(ball.Top < 0)
            {
                bally = -bally;
            }

            if(ball.Bounds.IntersectsWith(player.Bounds))
            {
                //ball.Top = 698;

                bally *= -1; // bally = rnd.Next(5, 12) * -1;

                if (ballx<0)
                {
                    ballx = rnd.Next(5, 12) * -1;
                }
                else
                {
                    ballx = rnd.Next(5, 12);
                }
            }

            foreach(Control control in this.Controls)
            {
                if(control is PictureBox && (string)control.Tag=="blocks")
                {
                    if(ball.Bounds.IntersectsWith(control.Bounds))
                    {
                        score += 1;
                        bally = - bally;
                        this.Controls.Remove(control);
                    }
                }
            }

            if(score == 36)
            {
                gameOver("You win!");
            }

            if(ball.Top >475)
            {
                gameOver("You lose!");
            }

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }

            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }



        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

          /*  if(e.KeyCode==Keys.Enter && isGameOver == true)
            {
                
                removeBlocks();
                placeBlocks();
                soundPlayer.Play();
            }*/

        }

    }
}
