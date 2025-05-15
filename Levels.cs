using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangledDungeon.Domain;

namespace TangledDungeonInit
{
    internal static partial class InitGame
    {
        static Level[] levels = new Level[2]
        {
            new Level(
                [
                    new Land(new Point(0, 50), 300, 10),
                    new Land(new Point(300, 50), 300, 10),

                    new Land(new Point(0, 200), 150, 10),
                    new Land(new Point(0, 300), 100, 10),
                    new Land(new Point(110, 200), 500, 10),

                    new Land(new Point(650, 160), 50, 10),
                    new Land(new Point(720, 220), 50, 10),
                    new Land(new Point(850, 250), 150, 10),
                    new Land(new Point(1070, 270), 100, 10),
                    new Land(new Point(840, 300), 500, 10),

                    new Land(new Point(720, 350), 400, 10),
                ],
                new Exit(new Point(25, 250)),
                [
                    new StaticEnemy(new Point(600, 0), 10, 50),
                    new StaticEnemy(new Point(620, 300), 220, 10),
                    new StaticEnemy(new Point(0, 0), 10, 60)
                ],
                [
                    new Lever(new Point(550, 20), 1),
                    new Lever(new Point(1120, 235), 9),
                    new Lever(new Point(950, 314), 2)
                ]
            ),

            new Level(
                [new Land(new Point(0, 300), 500, 10), new Land(new Point(200, 270), 200, 5)],
                new Exit(new Point(250, 220)),
                [],
                []
            )
        };
    }
}
