namespace MemoryMatchV1
{
    public partial class Form1 : Form
    {
        private List<string> cardValues = new List<string>();
        private Button? firstCard = null, secondCard = null;
        private System.Windows.Forms.Timer flipTimer;
        private int moves = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
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

                // Increment moves counter
                moves++;
                lblMoves.Text = $"Moves: {moves}";

                // Check for match
                if (firstCard.Tag.ToString() == secondCard.Tag.ToString())
                {
                    firstCard.Enabled = false;
                    secondCard.Enabled = false;
                    firstCard = null;
                    secondCard = null;

                    // Check if all pairs are found
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
            HideCard(firstCard);
            HideCard(secondCard);
            firstCard = null;
            secondCard = null;
            flipTimer.Stop();
        }

        private void ShowCard(Button card)
        {
            card.Text = "";
            card.BackColor = Color.White;
            card.BackgroundImage = Image.FromFile(card.Tag.ToString());
            card.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void HideCard(Button card)
        {
            card.Text = "";
            card.BackColor = Color.LightGray;
            card.BackgroundImage = null;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Reset moves counter
            moves = 0;
            lblMoves.Text = "Moves: 0";

            // Shuffle card values
            cardValues = cardValues.OrderBy(x => Guid.NewGuid()).ToList();

            // Assign each card value to a button
            int i = 0;
            foreach (Button button in tableLayoutPanel1.Controls.OfType<Button>())
            {
                button.Tag = cardValues[i]; // Assign image file path to Tag
                button.Text = ""; // Hide text
                button.BackColor = Color.LightGray; // Reset color
                button.Enabled = true; // Enable button
                button.BackgroundImage = null; // Clear any existing image
                i++;
            }
        }
    }
}

