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


            var player = new Player(2, new Point(0, 0));

            var model = new GameModel(player);
            var controller = new GameController(model);
            var view = new GameView(controller);

            controller.gameView = view;

            Application.Run(view);
        }
    }
}
