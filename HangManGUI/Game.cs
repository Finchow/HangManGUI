using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace HangManGUI
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();
            StartGame();
        }

        GameInfo gameInfo = new();
        private void StartGame()
        {
            gameInfo.CheatsEnabled = true;
            gameInfo.Lives = 11;
            gameInfo.GameWord = WordGen(DifficultySetter(3));
            gameInfo.GameWon = false;
            gameInfo.WordList.Clear();
            foreach (var c in gameInfo.GameWord)
            {
                gameInfo.WordList.Add("_");
            }
            gameInfo.IncorrectGuesses = new();
            gameInfo.Letters = new();
            RefreshUi();
        }

        private void RefreshUi()
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            livesCounter.Text = gameInfo.Lives.ToString();
            int pictureToDisplay = (11 - gameInfo.Lives);
            pictureBox1.ImageLocation = Path.Combine(currentDir, $@"Images\HangMan{pictureToDisplay}.png");
            pictureBox1.Refresh();
            if (gameInfo.WordList[0].Length == gameInfo.GameWord.Length)
            {
                var spacedWord = gameInfo.WordList[0];
                label3.Text = String.Join(" ", spacedWord.ToList());
            }
            else
            {
                label3.Text = StringFormat(gameInfo.WordList, " ");
            }
            incorrectLetters.Text = " ";
            incorrectLetters.Text = StringFormat(gameInfo.IncorrectGuesses, "");
            if (gameInfo.CheatsEnabled)
            {
                label5.Text = (gameInfo.GameWord);
            }
        }

        static string StringFormat(List<string> wordList, string padding)
        {
            string wordString = "";
            foreach (string word in wordList)
            {
                wordString += word + padding;
            }
            return wordString;

        }

        static string WordGen(List<int> difficulty)
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            string PATH = Path.Combine(currentDir, "WordList.txt");
            string text = File.ReadAllText(PATH);
            string[] wordlist = text.Split(",");
            Array.Sort(wordlist, (x, y) => x.Length.CompareTo(y.Length));

            Random r = new();
            int rInt = r.Next(difficulty[0], difficulty[1]);
            return wordlist[rInt];
        }

        static List<int> DifficultySetter(int option)
        {
            List<int> EASY = new() { 0, 820 };
            List<int> NORMAL = new() { 820, 1640 };
            List<int> HARD = new() { 1640, 2460 };

            List<int> difficulty = new() { 1 };

            switch (option)
            {
                case 1:
                    difficulty = EASY;
                    break;
                case 2:
                    difficulty = NORMAL;
                    break;
                case 3:
                    difficulty = HARD;
                    break;
                default:
                    break;
            }

            return difficulty;
        }

        string Validator(string guess, List<string> letters)
        {
            var validChars = new Regex(@"[a-z]+");
            int wordLen = gameInfo.GameWord.Length;
            int keyLen = guess.Length;
            string message = "none";

            if (!validChars.IsMatch(guess))
            {
                message = ($"The letter {guess} is invalid. Try again.");
            }
            else if (letters.Contains(guess))
            {
                message = ("You already entered this letter");
            }
            else
            {
                if (wordLen == keyLen)
                {
                    if (gameInfo.GameWord == guess)
                    {
                        return ("correct word");
                    }
                    else
                    {
                        return ("Incorrect guess -1 life");
                    }
                }
                if (wordLen < keyLen || (keyLen > 1 && keyLen < wordLen))
                {
                    message = ("You can only enter either 1 letter or the word.");
                }
            }

            return message;
        }

        void GameAction()
        {
            var guess = textBox1.Text.ToLower();
            var wordLen = gameInfo.GameWord.Length;
            var guessLen = guess.Length;

            textBox1.Clear();

            if (gameInfo.GameWord.Contains(guess) && Regex.IsMatch(guess, @"^[a-zA-Z]+$") && !(wordLen < guessLen || (guessLen > 1 && guessLen < wordLen)))
            {
                for (int i = 0; i < gameInfo.GameWord.Length; i++)
                {
                    if (gameInfo.GameWord[i] == guess[0])
                    {
                        gameInfo.WordList[i] = guess;
                    }
                }
            }

            RefreshUi();

            var message = Validator(guess, gameInfo.Letters);
            if (message == "none")
            {
                gameInfo.Letters.Add(guess);

                if (!gameInfo.GameWord.Contains(guess))
                {
                    gameInfo.Lives--;

                    if (!gameInfo.IncorrectGuesses.Contains(guess))
                        gameInfo.IncorrectGuesses.Add($" {guess},");
                }
            }
            else if (message == "correct word")
            {
                gameInfo.GameWon = true;
            }
            else if (message == "Incorrect guess -1 life")
            {
                RefreshUi();
                MessageBox.Show(message);
                gameInfo.Lives--;
            }
            else
            {
                RefreshUi();
                MessageBox.Show(message);
            }

            if (StringFormat(gameInfo.WordList, "") == gameInfo.GameWord)
            {
                gameInfo.GameWon = true;
            }

            RefreshUi();

            if (gameInfo.Lives == 0)
            {
                MessageBox.Show($"You lost! The word was {gameInfo.GameWord}.");
                StartGame();
            }
            else if (gameInfo.GameWon)
            {
                MessageBox.Show($"You won with {gameInfo.Lives} {(gameInfo.Lives == 1 ? "try" : "tries")} left.");
                RefreshUi();

                StartGame();
            }

            RefreshUi();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GameAction();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                GameAction();
            }
        }


    }

    public class GameInfo
    {
        public int Lives { get; set; }
        public List<string> IncorrectGuesses { get; set; } = new();
        public bool CheatsEnabled { get; set; }
        public string GameWord { get; set; } = "placeholder";
        public List<string> Letters { get; set; } = new();
        public bool GameWon { get; set; }
        public List<string> WordList { get; set; } = new();
    }
}
