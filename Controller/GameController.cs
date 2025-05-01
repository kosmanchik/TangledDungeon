using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangledDungeon.Domain;

public class GameController
{
    public readonly GameModel Model;
    private System.Windows.Forms.Timer GameTimer;
    public GameView gameView;
    private Dictionary<Keys, Action> StartMovementDictionary = new Dictionary<Keys, Action>();
    private Dictionary<Keys, Action> EndMovementDictionary = new Dictionary<Keys, Action>();

    public Point GetPlayerLocation()
    {
        return new Point(Model.Player.Position);
    }

    public Land[] GetLands()
    {
        return Model.Level.GetLands();
    }

    public GameController(GameModel model)
    {
        Model = model;

        StartMovementDictionary.Add(Keys.D, () => Model.Player.MovementCondition = MovementEnum.MovingRight);
        StartMovementDictionary.Add(Keys.A, () => Model.Player.MovementCondition = MovementEnum.MovingLeft);

        EndMovementDictionary.Add(Keys.D, () => Model.Player.MovementCondition = MovementEnum.Staying);
        EndMovementDictionary.Add(Keys.A, () => Model.Player.MovementCondition = MovementEnum.Staying);

        GameTimer = new System.Windows.Forms.Timer();
        GameTimer.Interval = 16; // ~60 FPS
        GameTimer.Tick += GameLoop;
        GameTimer.Start();
    }

    public void HandleJump(char key)
    {
        if (key == ' ')
            Model.Player.JumpCondition = JumpingEnum.Jumping;
    }

    private void GameLoop(object sender, EventArgs e)
    {
        Model.Tick();
        gameView.Render(Model);            
    }

    internal void HandleStartInput(Keys key)
    {
        if (StartMovementDictionary.ContainsKey(key))
            StartMovementDictionary[key].Invoke();
    }

    internal void HandleEndInput(Keys keyCode)
    {
        if (EndMovementDictionary.ContainsKey(keyCode))
            EndMovementDictionary[keyCode].Invoke();
    }

    internal void HandlePressInput(char keyChar)
    {
        if (keyChar == ' ')
            Model.Player.JumpCondition = JumpingEnum.Jumping;
    }
}
