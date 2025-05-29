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
    private Dictionary<Keys, Func<Level>> InteractionsDictionary = new Dictionary<Keys, Func<Level>>();

    public Point GetPlayerLocation()
    {
        return new Point(Model.Player.Position);
    }

    public Point GetExitLocation()
    {
        return new Point(Model.currentLevel.GetExitPoint());
    }

    public ILand[] GetLands()
    {
        return Model.currentLevel.GetLands();
    }

    public GameController(GameModel model)
    {
        Model = model;

        StartMovementDictionary.Add(Keys.D, () => Model.Player.MovementCondition = MovementEnum.MovingRight);
        StartMovementDictionary.Add(Keys.A, () => Model.Player.MovementCondition = MovementEnum.MovingLeft);

        EndMovementDictionary.Add(Keys.D, () => Model.Player.MovementCondition = MovementEnum.Staying);
        EndMovementDictionary.Add(Keys.A, () => Model.Player.MovementCondition = MovementEnum.Staying);
    }

    public void StartGameTimer()
    {
        GameTimer = new System.Windows.Forms.Timer();
        GameTimer.Interval = 16; // 60 FPS
        GameTimer.Tick += GameLoop;
        GameTimer.Start();
    }
    public void StopGameTimer() => GameTimer.Stop();

    private void GameLoop(object sender, EventArgs e) 
    {
        if (Model.Player.IsDead)
        {
            GameTimer.Stop();
            gameView.PlayDeathSound();
            Model.RestartLevel();
        }
        else
        {
            Model.Tick();
            gameView.Render(Model);
        }            
    }

    internal void HandleStartInput(Keys key)
    {
        if (StartMovementDictionary.ContainsKey(key))
            StartMovementDictionary[key].Invoke();

        else if (key == Keys.R && !GameTimer.Enabled)
            GameTimer.Start();
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

        else if ((Keys)Char.ToUpper(keyChar) == Keys.E)
        {
            var level = Model.ExitLevel();
            if (level != Level.EmptyLevel && level != null)
                gameView.UpdateLevel(level);
        }
        else if ((Keys)Char.ToUpper(keyChar) == Keys.F)
        {
            var landCommand = Model.PushLever();
            gameView.UpdateLand(landCommand);
        }
    }
}
