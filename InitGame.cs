using TangledDungeon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangledDungeon.View;

namespace TangledDungeonInit
{
    internal static partial class InitGame
    {
        /// <summary>
        /// ������� ����� ����� ��� ����������.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var player = new Player(4, new Point(30, 0), levels[0], 20, 29);

            var model = new GameModel(player, levels);
            var controller = new GameController(model);
            var view = new MainMenu(controller);

            model.Width = view.ClientSize.Width;
            model.Height = view.ClientSize.Height;

            Application.Run(view);
        }
    }
}
