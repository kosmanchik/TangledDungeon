using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangledDungeon.Domain;

public class GameController
{
    public readonly GameModel Model;
    private System.Windows.Forms.Timer GameTimer;
    public GameView gameView;

    public Point GetPlayerLocation()
    {
        return Model.Player.Position;
    }

    public GameController(GameModel model)
    {
        Model = model;

        GameTimer = new System.Windows.Forms.Timer();
        GameTimer.Interval = 16; // ~60 FPS
        GameTimer.Tick += GameLoop;
        GameTimer.Start();
    }

    public void HandleInput(Keys key)
    {
        Model.ProcessInput(key);
        gameView.Render(Model);
    }

    private void GameLoop(object sender, EventArgs e)
    {
    }
}
