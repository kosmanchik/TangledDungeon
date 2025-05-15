using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangledDungeon.Domain;
using Label = System.Windows.Forms.Label;

public partial class GameView : Form
{
    private GameController Controller;
    public PictureBox PlayerSprite;
    private PictureBox[] LandSprites;
    private PictureBox ExitSprite;
    private PictureBox[] StaticEnemiesSprites;
    private PictureBox[] LeverSprites;
    private SoundPlayer LevelUpdateSound;

    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // GameView
        // 
        BackColor = SystemColors.ControlLight;
        BackgroundImage = TangledDungeon.Properties.Resources.background;
        ClientSize = new Size(1280, 720);
        KeyPreview = true;
        Name = "GameView";
        KeyDown += GameView_KeyDown;
        KeyPress += GameView_KeyPress;
        KeyUp += GameView_KeyUp;
        ResumeLayout(false);
    }

    public GameView(GameController controller)
    {
        Controller = controller;

        InitPlayer();
        InitLevel(controller.Model.currentLevel);
        InitEnemies(controller.Model.currentLevel);
        LevelUpdateSound = new SoundPlayer("Assets\\levelUpdated.wav");

        InitializeComponent();
    }

    private void InitPlayer()
    {
        PlayerSprite = new PictureBox();
        PlayerSprite.Location = Controller.GetPlayerLocation().ToSystemDrawingPoint();

        PlayerSprite.Image = Image.FromFile("Assets\\adventurer-idle-00.png");
        PlayerSprite.BackColor = Color.Transparent;
        PlayerSprite.Size = new Size(20, 29);

        Controls.Add(PlayerSprite);
    }

    private void InitLevel(Level level)
    {
        var lands = level.GetLands();
        LandSprites = new PictureBox[lands.Length];

        for (int i = 0; i < LandSprites.Length; i++)
        {
            if (lands[i] == Land.EmptyLand)
                continue;

            LandSprites[i] = new PictureBox();
            LandSprites[i].Image = Image.FromFile("Assets\\groundTexture.jpg");
            LandSprites[i].Size = new Size(lands[i].Width, lands[i].Height);
            LandSprites[i].Location = lands[i].Start.ToSystemDrawingPoint();

            Controls.Add(LandSprites[i]);
        }

        var levers = level.GetLevers();
        LeverSprites = new PictureBox[levers.Length];
        for (int i = 0; i < LeverSprites.Length; i++)
        {
            LeverSprites[i] = new PictureBox();
            LeverSprites[i].Image = Image.FromFile("Assets\\lever.png");
            LeverSprites[i].Size = new Size(levers[i].Width, levers[i].Height);
            LeverSprites[i].Location = levers[i].Position.ToSystemDrawingPoint();
            LeverSprites[i].BackColor = Color.Transparent;

            Controls.Add(LeverSprites[i]);
        }

        ExitSprite = new PictureBox();
        ExitSprite.Location = Controller.GetExitLocation().ToSystemDrawingPoint();
        ExitSprite.Image = Image.FromFile("Assets\\exit.png");
        ExitSprite.BackColor = Color.Transparent;

        Controls.Add(ExitSprite);
    }

    private void InitEnemies(Level level)
    {
        StaticEnemiesSprites = new PictureBox[level.GetStaticEnemies().Length];
        var staticEnemies = level.GetStaticEnemies();
        for (int i = 0; i < StaticEnemiesSprites.Length; i++)
        {
            StaticEnemiesSprites[i] = new PictureBox();
            StaticEnemiesSprites[i].Image = Image.FromFile("Assets\\lavaTexture.jpg");
            StaticEnemiesSprites[i].Size = new Size(staticEnemies[i].Width, staticEnemies[i].Height);
            StaticEnemiesSprites[i].SizeMode = PictureBoxSizeMode.StretchImage;
            StaticEnemiesSprites[i].Location = staticEnemies[i].Position.ToSystemDrawingPoint();

            Controls.Add(StaticEnemiesSprites[i]);
        }
    }

    public void Render(GameModel model)
    {
        PlayerSprite.Location = Controller.GetPlayerLocation().ToSystemDrawingPoint();
    }

    private void GameView_KeyDown(object sender, KeyEventArgs e)
    {
        Controller.HandleStartInput(e.KeyCode);
    }

    private void GameView_KeyUp(object sender, KeyEventArgs e)
    {
        Controller.HandleEndInput(e.KeyCode);
    }

    private void GameView_KeyPress(object sender, KeyPressEventArgs e)
    {
        Controller.HandlePressInput(e.KeyChar);
    }

    internal void UpdateLevel(Level level)
    {
        if (level != Level.EmptyLevel)
        {
            LevelUpdateSound.Play();
            Controls.Clear();
            InitPlayer();
            InitLevel(level);
            InitEnemies(level);
        }        
    }
}
