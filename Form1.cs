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
                "Image/Cards/1.png", "Image/Cards/1.png",
                "Image/Cards/2.png", "Image/Cards/2.png",
                "Image/Cards/3.png", "Image/Cards/3.png",
                "Image/Cards/4.png", "Image/Cards/4.png",
                "Image/Cards/5.png", "Image/Cards/5.png",
                "Image/Cards/6.png", "Image/Cards/6.png",
                "Image/Cards/7.png", "Image/Cards/7.png",
                "Image/Cards/8.png", "Image/Cards/8.png",
                "Image/Cards/9.png", "Image/Cards/9.png",
                "Image/Cards/10.png", "Image/Cards/10.png"
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
            card.Text = card.Tag.ToString();
            card.BackColor = Color.White;
        }

        private void HideCard(Button card)
        {
            card.Text = "";
            card.BackColor = Color.LightGray;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            firstCard = null;
            secondCard = null;
            moves = 0;

            cardValues = new List<string>
            {
                "A", "A", "B", "B", "C", "C", "D", "D", "E", "E",
                "F", "F", "G", "G", "H", "H", "I", "I", "J", "J"
            };
            cardValues = cardValues.OrderBy(x => Guid.NewGuid()).ToList();

            int i = 0;
            foreach (Button button in tableLayoutPanel1.Controls.OfType<Button>())
            {
                button.Text = "";
                button.Tag = cardValues[i];
                button.BackColor = Color.LightGray;
                button.Enabled = true;
                i++;
            }
        }
    }
}

