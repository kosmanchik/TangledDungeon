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
    private PictureBox PlayerSprite;

    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.ClientSize = new System.Drawing.Size(1280, 720);
        this.Name = "GameView";
        this.KeyPreview = true;
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameView_KeyDown);
        this.ResumeLayout(false);
    }

    public GameView(GameController controller)
    {
        Controller = controller;
        PlayerSprite = new PictureBox();
        PlayerSprite.Location = new System.Drawing.Point(Controller.GetPlayerLocation().X, Controller.GetPlayerLocation().Y);

        try
        {
            PlayerSprite.Image = Image.FromFile("Assets\\adventurer-idle-00.png");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
        }
        
        Controls.Add(PlayerSprite);

        InitializeComponent();
    }

    public void Render(GameModel model)
    {
        PlayerSprite.Location = Controller.GetPlayerLocation().ToSystemDrawingPoint() ;
    }

    private void GameView_KeyDown(object sender, KeyEventArgs e)
    {
        Controller.HandleInput(e.KeyCode);
    }
}
