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

        }

        // Shuffle the card values
        cardValues = cardValues.OrderBy(x => Guid.NewGuid()).ToList();





        private void btnStart_Click(object sender, EventArgs e)
        {

        }
    }
}
