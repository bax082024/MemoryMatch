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
            // Create card values (10 pairs)
            cardValues = new List<string>
            {
                "A", "A", "B", "B", "C", "C", "D", "D", "E", "E",
                "F", "F", "G", "G", "H", "H", "I", "I", "J", "J"
            };

            // Shuffle the card values
            cardValues = cardValues.OrderBy(x => Guid.NewGuid()).ToList();

            // Add buttons to the grid
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
                tableLayoutPanel1.Controls.Add(button); // Add button to the grid
            }

            // Initialize the flip timer
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
                // First card flipped
                firstCard = clickedCard;
                ShowCard(firstCard);
                return;
            }

            if (secondCard == null && clickedCard != firstCard)
            {
                // Second card flipped
                secondCard = clickedCard;
                ShowCard(secondCard);
                moves++;

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
                    // Start timer to flip back unmatched cards
                    flipTimer.Start();
                }
            }
        }

        private void FlipTimer_Tick(object sender, EventArgs e)
        {
            // Hide unmatched cards
            HideCard(firstCard);
            HideCard(secondCard);
            firstCard = null;
            secondCard = null;
            flipTimer.Stop();
        }

        private void ShowCard(Button card)
        {
            // Show the card value
            card.Text = card.Tag.ToString();
            card.BackColor = Color.White;
        }

        private void HideCard(Button card)
        {
            // Hide the card value
            card.Text = "";
            card.BackColor = Color.LightGray;
        }
        
        private void Start_Click(object sender, EventArgs e)
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

