namespace MemoryMatchV1
{
    public partial class Form1 : Form
    {
        private List<string> cardValues;
        private Button firstCard, secondCard;
        private Timer flipTimer;
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
                    Text = "", // Initially hidden
                    Tag = value // Store the card value in Tag
                };
                button.Click += Card_Click;
                tableLayoutPanel1.Controls.Add(button); // Add button to the grid
            }

            // Initialize the flip timer
            flipTimer = new Timer
            {
                Interval = 1000 // 1 second
            };
            flipTimer.Tick += FlipTimer_Tick;

        }


        private void Card_Click(object sender, EventArgs e)
        {
            var clickedCard = sender as Button;



        }







        private void btnStart_Click(object sender, EventArgs e)
        {

        }
    }
}
