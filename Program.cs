using TangledDungeon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TangledDungeon
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var level = new Level(new Land[1] {new Land(new Point(0, 200), 1000, 10)});
            var player = new Player(2, new Point(0, 100), level, 50, 37);

            var model = new GameModel(player, level);
            var controller = new GameController(model);
            var view = new GameView(controller);

            model.Width = view.ClientSize.Width - view.PlayerSprite.Width;
            model.Height = view.ClientSize.Height;

            controller.gameView = view;

            Application.Run(view);
        }
    }
}
