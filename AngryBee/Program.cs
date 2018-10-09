using System;

namespace AngryBee
{
    class Program
    {
        static void Main(string[] args)
        {
            byte width = 16;
            byte height = 16;

            var ai = new AI.AI();
            var ai_kousi = new AI.AI_kousi();
            var ai_singlefor = new AI.AI_SingleFor();
            var ai_outside = new AI.AI_outside();
            var ai_hanpuku = new AI.AI_hanpuku();
            var ai_hanpuku_a = new AI.AI_hanpuku_a();
            var ai_hanpuku_sf = new AI.AI_hanpuku_SF();
            var ai_hanpuku_sf_a = new AI.AI_hanpuku_SF_a();
            var game = Boards.BoardSetting.Generate(height, width);

            var meBoard = new Boards.ColoredBoardSmallBigger(height, width);
            var enemyBoard = new Boards.ColoredBoardSmallBigger(height, width);

            meBoard[game.me.Agent1] = true;
            meBoard[game.me.Agent2] = true;

            enemyBoard[game.enemy.Agent1] = true;
            enemyBoard[game.enemy.Agent2] = true;

            Console.WriteLine("{0}", (meBoard.Width, meBoard.Height));

            for (;;)
            {
                while (true)
                {
                    var str = Console.ReadLine();
                    if (str == "") break;
                }
                var sw = System.Diagnostics.Stopwatch.StartNew();

                //var res = ai.Begin(3, game.setting, meBoard, enemyBoard, game.me, game.enemy);

                var before_me_Agent1 = game.me.Agent1;
                var before_me_Agent2 = game.me.Agent2;
                var before_enemy_Agent1 = game.enemy.Agent1;
                var before_enemy_Agent2 = game.enemy.Agent2;
                
                var meBoard_spare = meBoard;
                var enBoard_spare = enemyBoard;

                int ends_1 = 0, ends_2 = 0;
                var res_me = ai_hanpuku_sf.Begin(1000, game.setting, meBoard, enemyBoard, game.me, game.enemy);
                ends_1 = ai_hanpuku_sf.ends;
                ai_hanpuku.ends = 0;
                var res_en = ai_hanpuku.Begin(1000, game.setting, enBoard_spare, meBoard_spare, game.enemy, game.me);
                ends_2 = ai_hanpuku.ends;
                ai_hanpuku.ends = 0;

                game.me = res_me;
                game.enemy = res_en;

                Console.WriteLine("{0}", (res_me.Agent1.X, res_me.Agent1.Y));
                Console.WriteLine("{0}", (res_me.Agent2.X, res_me.Agent2.Y));
                Console.WriteLine("{0}", (res_en.Agent1.X, res_en.Agent1.Y));
                Console.WriteLine("{0}", (res_en.Agent2.X, res_en.Agent2.Y));
                if (res_me.Agent1 == res_me.Agent2 || res_me.Agent1 == res_en.Agent1 || res_me.Agent1 == res_en.Agent2)
                    game.me.Agent1 = before_me_Agent1;
                else if (enemyBoard[res_me.Agent1])
                {
                    enemyBoard[res_me.Agent1] = false;
                    game.me.Agent1 = before_me_Agent1;
                }
                else
                    meBoard[game.me.Agent1] = true;
                if (res_me.Agent2 == game.me.Agent1 || res_me.Agent2 == res_en.Agent1 || res_me.Agent2 == res_en.Agent2)
                    game.me.Agent2 = before_me_Agent2;
                else if (enemyBoard[res_me.Agent2])
                {
                    enemyBoard[res_me.Agent2] = false;
                    game.me.Agent2 = before_me_Agent2;
                }
                else
                    meBoard[game.me.Agent2] = true;
                if (res_en.Agent1 == game.me.Agent1 || res_en.Agent1 == game.me.Agent2 || res_en.Agent1 == res_en.Agent2)
                    game.enemy.Agent1 = before_enemy_Agent1;
                else if (meBoard[res_en.Agent1])
                {
                    meBoard[res_en.Agent1] = false;
                    game.enemy.Agent1 = before_enemy_Agent1;
                }
                else
                    enemyBoard[game.enemy.Agent1] = true;
                if (res_en.Agent2 == game.me.Agent1 || res_en.Agent2 == game.me.Agent2 || res_en.Agent2 == game.enemy.Agent1)
                    game.enemy.Agent2 = before_enemy_Agent2;
                else if (meBoard[res_en.Agent2])
                {
                    meBoard[res_en.Agent2] = false;
                    game.enemy.Agent2 = before_enemy_Agent2;
                }
                else
                    enemyBoard[game.enemy.Agent2] = true;

                sw.Stop();
                Console.ForegroundColor = ConsoleColor.White;

                for (int i = 0; i < game.setting.ScoreBoard.GetLength(0); ++i)
                {
                    for (int m = 0; m < game.setting.ScoreBoard.GetLength(1); ++m)
                    {
                        string strr = game.setting.ScoreBoard[m, i].ToString();
                        int hoge = 4 - strr.Length;

                        if ((game.me.Agent1.X == m && game.me.Agent1.Y == i) || (game.me.Agent2.X == m && game.me.Agent2.Y == i))
                            Console.BackgroundColor = ConsoleColor.Red;
                        else if ((game.enemy.Agent1.X == m && game.enemy.Agent1.Y == i) || (game.enemy.Agent2.X == m && game.enemy.Agent2.Y == i))
                            Console.BackgroundColor = ConsoleColor.Blue;
                        else if (meBoard[(uint)m, (uint)i])
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                        else if (enemyBoard[(uint)m, (uint)i])
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        else
                            Console.BackgroundColor = ConsoleColor.Black;

                        for (int n = 0; n < hoge; ++n)
                            Console.Write(" ");
                        Console.Write(strr);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();

                //Console.WriteLine(res);

                /* Console.WriteLine(res.Item1);

                 for (int i = 0; i < game.setting.ScoreBoard.GetLength(1); ++i)
                 {
                     for (int m = 0; m < game.setting.ScoreBoard.GetLength(0); ++m)
                     {
                         string strr = game.setting.ScoreBoard[m, i].ToString();
                         int hoge = 4 - strr.Length;

                         if (res.Item2[(uint)m, (uint)i])
                             Console.BackgroundColor = ConsoleColor.DarkRed;
                         else if (res.Item3[(uint)m, (uint)i])
                             Console.BackgroundColor = ConsoleColor.DarkBlue;
                         else
                             Console.BackgroundColor = ConsoleColor.Black;

                         for (int n = 0; n < hoge; ++n)
                             Console.Write(" ");
                         Console.Write(strr);
                     }
                     Console.WriteLine();
                 }*/
                 

                PointEvaluator.Normal PointEvaluator = new PointEvaluator.Normal();
                Console.WriteLine("AI1_Points:{0}", PointEvaluator.Calculate(game.setting.ScoreBoard, meBoard, 0));
                Console.WriteLine("AI2_Points:{0}", PointEvaluator.Calculate(game.setting.ScoreBoard, enemyBoard, 0));
                Console.WriteLine("End Nodes:{0}[nodes]", ends_1);
                Console.WriteLine("End Nodes:{0}[nodes]", ends_2);
                Console.WriteLine("Time Elasped:{0}[ms]", sw.ElapsedMilliseconds);
            }
        }
    }
}
