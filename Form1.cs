using System.Drawing.Drawing2D;
using WMPLib;


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
                    BackColor = Color.LightCoral, // Set a nice color
                    Font = new Font("Comic Sans MS", 14, FontStyle.Bold), // Use a fun font
                    Text = "",
                    Tag = value,
                    FlatStyle = FlatStyle.Flat, // Use flat style for modern appearance
                };

                // Customize the button border
                button.FlatAppearance.BorderSize = 2;
                button.FlatAppearance.BorderColor = Color.White;

                // Add hover effects
                button.MouseEnter += (s, e) => button.BackColor = Color.Orange; // Hover color
                button.MouseLeave += (s, e) => button.BackColor = Color.LightCoral; // Default color

                button.Click += Card_Click; // Existing click event
                tableLayoutPanel1.Controls.Add(button); // Add button to the grid
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
                PlaySound("Sounds/flip.mp3");

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
                    PlaySound("Sounds/match.mp3");

                    firstCard.Enabled = false;
                    secondCard.Enabled = false;
                    firstCard = null;
                    secondCard = null;

                    if (tableLayoutPanel1.Controls.Cast<Button>().All(b => !b.Enabled))
                    {
                        PlaySound("Sounds/win.mp3");
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

            PlaySound("Sounds/flip.mp3");

            HideCard(firstCard, secondCard);
        }

        private void ShowCard(Button card)
        {
            animatingCard = card;
            animationProgress = 0;
            flipAnimationTimer.Start();

            // Play flip sound
            PlaySound("Sounds/flip.mp3");
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

            PlaySound("Sounds/start.mp3");
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

        private void PlaySound(string filePath)
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory; // Base path (bin/Debug)
                string fullPath = Path.Combine(basePath, filePath); // Combine base path with relative path


                player.settings.volume = 100; // Ensure volume is set
                player.URL = fullPath; // Use the full path
                player.controls.play(); // Play the sound
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.DarkSlateBlue, // Top color
                Color.MediumPurple,  // Bottom color
                LinearGradientMode.Vertical)) // Gradient direction
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void Default_Click(object sender, EventArgs e)
        {
            ApplyTheme(
                Color.DarkSlateBlue,  // Top gradient
                Color.MediumPurple,   // Bottom gradient
                Color.LightCoral,     // Button default
                Color.Orange,         // Button hover
                Color.White           // Text color
            );
        }

        private void Matrix_Click(object sender, EventArgs e)
        {
            ApplyTheme(
                Color.Black,          // Top gradient
                Color.Black,          // Bottom gradient
                Color.DarkGreen,      // Button default
                Color.LimeGreen,      // Button hover
                Color.LimeGreen       // Text color
            );
        }


    }
}

