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
        public static Level[] levels = new Level[3]
        {
            new Level(
                [
                    new HorizontalLand(new Point(0, 50), 300, 10),
                    new HorizontalLand(new Point(300, 150), 500, 10),
                    new HorizontalLand(new Point(850, 120), 50, 10),
                    new HorizontalLand(new Point(1000, 95), 50, 10),
                    new HorizontalLand(new Point(1150, 70), 50, 10),

                    new HorizontalLand(new Point(0, 200), 300, 10),
                    
                    new HorizontalLand(new Point(350, 270), 100, 10),
                    new HorizontalLand(new Point(550, 340), 100, 10),
                    new HorizontalLand(new Point(750, 400), 50, 10),
                    new HorizontalLand(new Point(900, 450), 50, 10),
                    new HorizontalLand(new Point(980, 470), 100, 10),
                    new HorizontalLand(new Point(1180, 510), 100, 10),
                    new HorizontalLand(new Point(1050, 560), 100, 10),
                    new HorizontalLand(new Point(950, 600), 50, 10),

                    new HorizontalLand(new Point(300, 690), 980 , 30), 

                    new HorizontalLand(new Point(800, 650), 100, 10),
                    new HorizontalLand(new Point(650, 590), 100, 10),
                    new HorizontalLand(new Point(550, 620), 100, 10),

                    new HorizontalLand(new Point(170, 650), 100, 10),
                    new HorizontalLand(new Point(100, 610), 50, 10),
                    new HorizontalLand(new Point(0, 570), 50, 10),
                    new HorizontalLand(new Point(70, 520), 230, 10),

                    new VerticalLand(new Point(0, 0), 10, 60),
                    new VerticalLand(new Point(300, 0), 10, 60),
                    new VerticalLand(new Point(300, 60), 10, 100),

                    new VerticalLand(new Point(150, 60), 10, 150),

                    new VerticalLand(new Point(300, 210), 10, 290),

                    new VerticalLand(new Point(300, 500), 10, 200),
                    new VerticalLand(new Point(150, 210), 10, 310)
                ],
                new Exit(new Point(25, 150)),
                [
                    new StaticEnemy(new Point(800, 150), 480, 10),
                    new StaticEnemy(new Point(300, 500), 750, 10),
                    new StaticEnemy(new Point(0, 690), 300, 30)
                ],
                [
                    new Lever(new Point(200, 10), 23),
                    new Lever(new Point(1150, 30), 24),
                    new Lever(new Point(1150, 655), 27),
                    new Lever(new Point(550, 580), 28),
                    new Lever(new Point(200, 480), 25)
                ]
            ),

            new Level
            (
                [
                    new HorizontalLand(new Point(0, 200), 400, 20),
                    new HorizontalLand(new Point(450, 150), 250, 10),
                    
                    new HorizontalLand(new Point(250, 100), 100, 10),
                    new HorizontalLand(new Point(0, 50), 200, 10),
                    
                    new HorizontalLand(new Point(800, 200), 100, 20),
                    new HorizontalLand(new Point(900, 200), 380, 20),
                    
                    new HorizontalLand(new Point(900, 150), 50, 10),
                    new HorizontalLand(new Point(1050, 125), 100, 10),
                    
                    new HorizontalLand(new Point(950, 350), 320, 20),
                    
                    new HorizontalLand(new Point(400, 450), 400, 20),
                    new HorizontalLand(new Point(550, 400), 100, 10),

                    new HorizontalLand(new Point(400, 700), 880, 20),
                    new HorizontalLand(new Point(0, 500), 250, 10),
                    new HorizontalLand(new Point(300, 570), 100, 10),
                    new HorizontalLand(new Point(450, 620), 50, 10),
                    new HorizontalLand(new Point(550, 670), 50, 10),

                    new VerticalLand(new Point(950, 470), 10, 250),
                    new VerticalLand(new Point(750, 470), 10, 250)
                ], 
                new Exit(new Point(1050, 650)), 
                [
                    new StaticEnemy(new Point(400, 200), 400, 20),
                    new StaticEnemy(new Point(800, 450), 480, 20),
                    new StaticEnemy(new Point(0, 700), 400, 20)
                ], 
                [
                    new Lever(new Point(1100, 85), 5),
                    new Lever(new Point(550, 110), 8),
                    new Lever(new Point(570, 370), 17),
                    new Lever(new Point(50, 20), 16)
                ]
            ),

            new Level
            (
                [
                    new HorizontalLand(new Point(500, 670), 780, 50),
                    new VerticalLand(new Point(1150, 500), 10, 180),

                    new HorizontalLand(new Point(350, 620), 100, 10),
                    new HorizontalLand(new Point(250, 580), 50, 10),
                    new HorizontalLand(new Point(100, 530), 100, 10),

                    new HorizontalLand(new Point(250, 470), 1030, 20),
                    new VerticalLand(new Point(950, 320), 10, 150),

                    new HorizontalLand(new Point(500, 420), 100, 10),
                    new HorizontalLand(new Point(650, 370), 100, 10),
                    new HorizontalLand(new Point(800, 320), 50, 10),
                    new HorizontalLand(new Point(900, 320), 380, 10),

                    new VerticalLand(new Point(950, 170), 10, 150)
                ],
                new Exit(new Point(1200, 620)),
                [
                    new StaticEnemy(new Point(0, 670), 500, 50),
                ],
                [
                    new Lever(new Point(900, 630), 6),
                    new Lever(new Point(1050, 430), 11),
                    new Lever(new Point(1050, 280), 1)
                ]
            )
        };
    }
}
