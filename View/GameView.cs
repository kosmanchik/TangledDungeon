using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangledDungeon.Domain;

public partial class GameView : Form
{
    private GameController Controller;
    public readonly PictureBox PlayerSprite;
    private PictureBox[] landSprites;

    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // GameView
        // 
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

        landSprites = new PictureBox[Controller.GetLands().Length];
        var lands = Controller.GetLands();
        for (int i = 0; i < landSprites.Length; i++)
        {
            landSprites[i] = new PictureBox();
            landSprites[i].Image = Image.FromFile("Assets\\groundTexture.jpg");
            landSprites[i].Size = new Size(lands[i].Width, lands[i].Height);
            landSprites[i].Location = lands[i].Start.ToSystemDrawingPoint();

            Controls.Add(landSprites[i]);
        }

        PlayerSprite = new PictureBox();
        PlayerSprite.Location = Controller.GetPlayerLocation().ToSystemDrawingPoint();

        PlayerSprite.Image = Image.FromFile("Assets\\adventurer-idle-00.png");
        PlayerSprite.Size = new System.Drawing.Size(50, 37);

        Controls.Add(PlayerSprite);

        InitializeComponent();
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
}
