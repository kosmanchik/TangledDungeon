using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangledDungeon.View
{
    public partial class MainMenu : Form
    {
        private GameController Controller;
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // GameMenu
            // 
            BackColor = SystemColors.ControlLight;
            BackgroundImage = Image.FromFile("Assets\\background.jpg");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1280, 720);
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Name = "TangledDungeon Menu";
            ResumeLayout(false);
        }

        public MainMenu(GameController controller)
        {
            Controller = controller;
            InitializeComponent();
            SetupMenu();
        }

        private void SetupMenu()
        {
            Text = "Главное меню игры";

            Label caption = new Label();
            caption.Text = "Tangled Dungeon";
            caption.Width = 500;
            caption.Height = 100;
            caption.Location = new System.Drawing.Point(Width / 2 - 250, 50);
            caption.TextAlign = ContentAlignment.MiddleCenter;
            caption.BackColor = Color.Transparent;
            caption.Font = new Font(GetFontFamily(), 32, FontStyle.Bold);
            caption.ForeColor = Color.FromArgb(255, 185, 101);

            Button startButton = new Button();
            startButton.Text = "Начать игру";
            startButton.Width = 200;
            startButton.Height = 50;
            startButton.Location = new System.Drawing.Point(Width / 2 - 100, 300);
            startButton.Click += StartButton_Click;

            Button controlButton = new Button();
            controlButton.Text = "Управление";
            controlButton.Width = 200;
            controlButton.Height = 50;
            controlButton.Location = new System.Drawing.Point(Width / 2 - 100, 440);
            controlButton.Click += ControlButton_Click;

            Button exitButton = new Button();
            exitButton.Text = "Выход";
            exitButton.Width = 200;
            exitButton.Height = 50;
            exitButton.Location = new System.Drawing.Point(Width / 2 - 100, 580);
            exitButton.Click += ExitButton_Click;

            Controls.Add(startButton);
            Controls.Add(controlButton);
            Controls.Add(exitButton);
            Controls.Add(caption);
        }

        private void ControlButton_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("E - взаимодействие с дверью\nF - взаимодействие с рычагом\nR - рестарт уровня после смерти", "Управление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static FontFamily GetFontFamily()
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("Assets\\Stormfaze.otf");
            FontFamily family = fontCollection.Families[0];
            return family;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            GameView game = new GameView(Controller);
            game.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
