using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MontebankGame
{
    public partial class Form2 : Form
    {

        public CardController cardController = new CardController();

        public BetController betController = new BetController();

        public Bet bet = new Bet();

        public List<Layout> cardLayout = new List<Layout>() { new Layout(), new Layout() };

        public Card card = new Card(2, "cr");

        public List<Card> cardDeck = new List<Card>() 
        { 
            new Card(2, "boob"), new Card(3, "boob"), new Card(4, "boob"), new Card(5, "boob"), new Card(6, "boob"), new Card(7, "boob"), new Card(8, "boob"), new Card(9, "boob"), new Card(10, "boob"), new Card(11, "boob"),
            new Card(2, "cher"), new Card(3, "cher"), new Card(4, "cher"), new Card(5, "cher"), new Card(6, "cher"), new Card(7, "cher"), new Card(8, "cher"), new Card(9, "cher"), new Card(10, "cher"), new Card(11, "cher"),
            new Card(2, "pika"), new Card(3, "pika"), new Card(4, "pika"), new Card(5, "pika"), new Card(6, "pika"), new Card(7, "pika"), new Card(8, "pika"), new Card(9, "pika"), new Card(10, "pika"), new Card(11, "pika"),
            new Card(2, "cr"), new Card(3, "cr"), new Card(4, "cr"), new Card(5, "cr"), new Card(6, "cr"), new Card(7, "cr"), new Card(8, "cr"), new Card(9, "cr"), new Card(10, "cr"), new Card(11, "cr"), 
        };

        public Form1 form1;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;

            labelBalance.Text = cardController.balance.ToString();

            cardController.GetCard(cardDeck, cardLayout);

            labelCoutCard.Text = cardDeck.Count.ToString();

            card = cardLayout[0].tuplecard.Item1;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile($"C:\\Users\\Daniil\\Desktop\\C#\\MontebankGame\\Images\\{card.rating + card.color}.jpg");

            card = cardLayout[0].tuplecard.Item2;

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = Image.FromFile($"C:\\Users\\Daniil\\Desktop\\C#\\MontebankGame\\Images\\{card.rating + card.color}.jpg");

            card = cardLayout[1].tuplecard.Item1;

            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Image = Image.FromFile($"C:\\Users\\Daniil\\Desktop\\C#\\MontebankGame\\Images\\{card.rating + card.color}.jpg");

            card = cardLayout[1].tuplecard.Item2;

            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.Image = Image.FromFile($"C:\\Users\\Daniil\\Desktop\\C#\\MontebankGame\\Images\\{card.rating + card.color}.jpg");
        }

        private new void FormClosed(object sender, FormClosingEventArgs e)
        {
            form1.Close();
        }

        private void ratingBet10_Click(object sender, EventArgs e)
        {
            bet.ratingBet = 10;
        }

        private void ratingBet30_Click(object sender, EventArgs e)
        {
            bet.ratingBet = 30;
        }

        private void ratingBet50_Click(object sender, EventArgs e)
        {
            bet.ratingBet = 50;
        }

        private void ratingBet100_Click(object sender, EventArgs e)
        {
            bet.ratingBet = 100;
        }

        private void ratingBet200_Click(object sender, EventArgs e)
        {
            bet.ratingBet = 200;
        }

        private void buttonAddBetTop_Click(object sender, EventArgs e)
        {
            betController.SetBet(bet, cardLayout[0], cardController);

            labelBalance.Text = cardController.balance.ToString();
            labelSumBetTop.Text = cardLayout[0].sumBet.ToString();
            
        }

        private void buttonAddBetDown_Click(object sender, EventArgs e)
        {
            betController.SetBet(bet, cardLayout[1], cardController);

            labelBalance.Text = cardController.balance.ToString();
            labelSumBetDown.Text = cardLayout[1].sumBet.ToString();

        }

        private void buttonCancelBetTop_Click(object sender, EventArgs e)
        {
            cardController.balance += cardLayout[0].sumBet;
            cardLayout[0].sumBet = 0;

            labelBalance.Text = cardController.balance.ToString();
            labelSumBetTop.Text = cardLayout[0].sumBet.ToString();

        }

        private void buttonCancelBetDown_Click(object sender, EventArgs e)
        {
            cardController.balance += cardLayout[1].sumBet;
            cardLayout[1].sumBet = 0;

            labelBalance.Text = cardController.balance.ToString();
            labelSumBetDown.Text = cardLayout[1].sumBet.ToString();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            card = cardController.GetLastCard(cardDeck, cardLayout);

            labelCoutCard.Text = cardDeck.Count.ToString();
            pictureBoxLastCard.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLastCard.Image = Image.FromFile($"C:\\Users\\Daniil\\Desktop\\C#\\MontebankGame\\Images\\{card.rating + card.color}.jpg");

            //List<Layout> testL = new List<Layout>() {new Layout(), new Layout() };

            //Card cardTest = new Card(2, "boob");

            //testL[0].tuplecard = new Tuple<Card, Card>(cardTest, cardTest);
            //testL[1].tuplecard = new Tuple<Card, Card>(cardTest, cardTest);

            //cardController.GetLastCard(cardDeck, testL);

            if (cardLayout[0].statusChekCard)
            {
                labelWinOrLose.Text = "Вы выиграли!";

                cardController.balance += cardLayout[0].sumBet * 2;
                cardLayout[0].sumBet = 0;            

            }
            else if(cardLayout[1].statusChekCard)
            {
                labelWinOrLose.Text = "Вы выиграли!";

                cardController.balance += cardLayout[1].sumBet * 2;
                cardLayout[1].sumBet = 0;
            }
            else 
            {
                labelWinOrLose.Text = "Вы проиграли!";
                cardLayout[0].sumBet = 0;
                cardLayout[1].sumBet = 0;
            }

            labelBalance.Text = cardController.balance.ToString();
            labelSumBetTop.Text = "0";
            labelSumBetDown.Text = "0";

            cardLayout[1].statusChekCard = false;
            cardLayout[0].statusChekCard = false;

            buttonAddBetTop.Enabled = false;
            buttonAddBetDown.Enabled = false;
            buttonCancelBetTop.Enabled = false;
            buttonCancelBetDown.Enabled = false;

            buttonCheck.Enabled = false;
            buttonСontinue.Enabled = true;

        }

        private void buttonСontinue_Click(object sender, EventArgs e)
        {
            if (cardController.balance != 0)
            {
                buttonCheck.Enabled = true;
                buttonСontinue.Enabled = false;

                buttonAddBetTop.Enabled = true;
                buttonAddBetDown.Enabled = true;
                buttonCancelBetTop.Enabled = true;
                buttonCancelBetDown.Enabled = true;

                if (cardDeck.Count < 5)
                {
                    cardDeck = new List<Card>()
                {
                    new Card(2, "boob"), new Card(3, "boob"), new Card(4, "boob"), new Card(5, "boob"), new Card(6, "boob"), new Card(7, "boob"), new Card(8, "boob"), new Card(9, "boob"), new Card(10, "boob"), new Card(11, "boob"),
                    new Card(2, "cher"), new Card(3, "cher"), new Card(4, "cher"), new Card(5, "cher"), new Card(6, "cher"), new Card(7, "cher"), new Card(8, "cher"), new Card(9, "cher"), new Card(10, "cher"), new Card(11, "cher"),
                    new Card(2, "pika"), new Card(3, "pika"), new Card(4, "pika"), new Card(5, "pika"), new Card(6, "pika"), new Card(7, "pika"), new Card(8, "pika"), new Card(9, "pika"), new Card(10, "pika"), new Card(11, "pika"),
                    new Card(2, "cr"), new Card(3, "cr"), new Card(4, "cr"), new Card(5, "cr"), new Card(6, "cr"), new Card(7, "cr"), new Card(8, "cr"), new Card(9, "cr"), new Card(10, "cr"), new Card(11, "cr"),
                };
                }

                cardController.GetCard(cardDeck, cardLayout);

                labelCoutCard.Text = cardDeck.Count.ToString();
                labelWinOrLose.Text = "";
                pictureBoxLastCard.Image = null;

                card = cardLayout[0].tuplecard.Item1;

                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile($"C:\\Users\\Daniil\\Desktop\\C#\\MontebankGame\\Images\\{card.rating + card.color}.jpg");

                card = cardLayout[0].tuplecard.Item2;

                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = Image.FromFile($"C:\\Users\\Daniil\\Desktop\\C#\\MontebankGame\\Images\\{card.rating + card.color}.jpg");

                card = cardLayout[1].tuplecard.Item1;

                pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox3.Image = Image.FromFile($"C:\\Users\\Daniil\\Desktop\\C#\\MontebankGame\\Images\\{card.rating + card.color}.jpg");

                card = cardLayout[1].tuplecard.Item2;

                pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox4.Image = Image.FromFile($"C:\\Users\\Daniil\\Desktop\\C#\\MontebankGame\\Images\\{card.rating + card.color}.jpg");
            }
            else 
            {
                labelWinOrLose.Text = "Вы не можете продолжить игру!\nУ вас не достаточно денег!";
                buttonMainMenu.Visible = true;
            }
        }

        private void buttonMainMenu_Click(object sender, EventArgs e)
        {
            form1.Visible = true;
            this.Visible = false;
        }

        
    }
}
