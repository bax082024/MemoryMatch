namespace MemoryMatchV1
{
    public partial class Form1 : Form
    {
        private List<string> cardValues = new List<string>();
        private Button? firstCard = null, secondCard = null;
        private System.Windows.Forms.Timer flipTimer;
        private int moves = 0;

        private System.Windows.Forms.Timer flipAnimationTimer;
        private Button? animatingCard;
        private bool isShrinking = true;
        private int animationStep = 5;
        private bool isHiding = false;
        private Button? hidingCard = null;
        private int animationProgress = 0;

        private WMPLib.WindowsMediaPlayer player;


        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            player = new WMPLib.WindowsMediaPlayer();

        }

        private void InitializeGame()
        {
            cardValues = new List<string>
            {
                "Images/Cards/card1.png", "Images/Cards/card1.png",
                "Images/Cards/card2.png", "Images/Cards/card2.png",
                "Images/Cards/card3.png", "Images/Cards/card3.png",
                "Images/Cards/card4.png", "Images/Cards/card4.png",
                "Images/Cards/card5.png", "Images/Cards/card5.png",
                "Images/Cards/card6.png", "Images/Cards/card6.png",
                "Images/Cards/card7.png", "Images/Cards/card7.png",
                "Images/Cards/card8.png", "Images/Cards/card8.png",
                "Images/Cards/card9.png", "Images/Cards/card9.png",
                "Images/Cards/card10.png", "Images/Cards/card10.png"
            };


            cardValues = cardValues.OrderBy(x => Guid.NewGuid()).ToList();

            foreach (var value in cardValues)
            {
                var button = new Button
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.LightGray,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    Text = "",
                    Tag = value
                };
                button.Click += Card_Click;
                tableLayoutPanel1.Controls.Add(button);
            }

            flipAnimationTimer = new System.Windows.Forms.Timer
            {
                Interval = 30 // Adjust for smoother or faster animations
            };
            flipAnimationTimer.Tick += FlipAnimationTimer_Tick;


            flipTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // 1 second
            };
            flipTimer.Tick += FlipTimer_Tick;

        }


        private void Card_Click(object sender, EventArgs e)
        {
            var clickedCard = sender as Button;

            if (firstCard == null)
            {
                firstCard = clickedCard;
                ShowCard(firstCard);
                return;
            }

            if (secondCard == null && clickedCard != firstCard)
            {
                secondCard = clickedCard;
                ShowCard(secondCard);

                moves++;
                lblMoves.Text = $"Moves: {moves}";

                if (firstCard.Tag.ToString() == secondCard.Tag.ToString())
                {
                    firstCard.Enabled = false;
                    secondCard.Enabled = false;
                    firstCard = null;
                    secondCard = null;

                    if (tableLayoutPanel1.Controls.Cast<Button>().All(b => !b.Enabled))
                    {
                        MessageBox.Show($"You found all pairs in {moves} moves! Congratulations!");
                    }
                }
                else
                {
                    flipTimer.Start();
                }
            }
        }


        private void FlipTimer_Tick(object sender, EventArgs e)
        {
            flipTimer.Stop();
            HideCard(firstCard, secondCard);
        }

        private void ShowCard(Button card)
        {
            animatingCard = card;
            animationProgress = 0;
            flipAnimationTimer.Start();
        }

        private void HideCard(Button card1, Button card2)
        {
            firstCard = card1;
            secondCard = card2;
            isHiding = true;
            animationProgress = 0;
            flipAnimationTimer.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            moves = 0;
            lblMoves.Text = "Moves: 0";

            cardValues = cardValues.OrderBy(x => Guid.NewGuid()).ToList();

            int i = 0;
            foreach (Button button in tableLayoutPanel1.Controls.OfType<Button>())
            {
                button.Tag = cardValues[i];
                button.Text = "";
                button.BackColor = Color.LightGray;
                button.Enabled = true;
                button.BackgroundImage = null;
                i++;
            }
        }

        private void FlipAnimationTimer_Tick(object sender, EventArgs e)
        {
            if (isHiding)
            {
                if (animationProgress < 5)
                {
                    firstCard.BackColor = Color.Gray;
                    secondCard.BackColor = Color.Gray;
                    animationProgress++;
                }
                else if (animationProgress == 5)
                {
                    firstCard.BackgroundImage = null;
                    firstCard.BackColor = Color.LightGray;

                    secondCard.BackgroundImage = null;
                    secondCard.BackColor = Color.LightGray;

                    animationProgress++;
                }
                else
                {
                    animationProgress = 0;
                    flipAnimationTimer.Stop();

                    firstCard = null;
                    secondCard = null;
                    isHiding = false;
                }
            }
            else
            {
                if (animatingCard == null)
                {
                    flipAnimationTimer.Stop();
                    return;
                }

                if (animationProgress < 5)
                {
                    animatingCard.BackColor = Color.Gray;
                    animationProgress++;
                }
                else if (animationProgress == 5)
                {
                    animatingCard.BackgroundImage = Image.FromFile(animatingCard.Tag.ToString());
                    animatingCard.BackgroundImageLayout = ImageLayout.Stretch;

                    animationProgress++;
                }
                else
                {
                    animationProgress = 0;
                    flipAnimationTimer.Stop();

                    animatingCard = null;
                }
            }
        }

        private void PlaySound()
        {
            player.URL = filePath;
            player.controls.play();
        }


    }
}

