using AngryBee.Boards;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngryBee.AI
{
    public class hanpuku
    {/*
        Rule.MovableChecker Checker = new Rule.MovableChecker();
        PointEvaluator.Normal PointEvaluator = new PointEvaluator.Normal();

        public Player Begin(int deepness, BoardSetting setting, ColoredBoardSmallBigger MeBoard, ColoredBoardSmallBigger EnemyBoard, Player Me, in Player Enemy)
        {
            (int DestX, int DestY)[] WayEnumerator = { (1, 1), (1, -1), (-1, 1), (-1, -1), (0, 1), (-1, 0), (1, 0), (0, -1) };
            Me = Search(deepness, WayEnumerator, MeBoard, EnemyBoard, Me, Enemy, setting.ScoreBoard);

            return Me;
        }

        Tuple<int, (int,int)>[] dp = new Tuple<int, (int,int)>[100];
        int cnt = 1;

        Player Search(int deepness, in (int DestX, int DestY)[] WayEnumerator, in ColoredBoardSmallBigger MeBoard, in ColoredBoardSmallBigger EnemyBoard, in Player Me, in Player Enemy, in sbyte[,] ScoreBoard)
        {
            
            Player BestWay;

            while(deepness > cnt)
            {
                BestWay = MyTurn(cnt, WayEnumerator, MeBoard, EnemyBoard, Enemy, ScoreBoard).Item4;
                cnt++;
            }

            return BestWay;
        }

        

        Tuple<int, ColoredBoardSmallBigger, ColoredBoardSmallBigger, Player, Player> MyTurn(int deepness, in (int DestX, int DestY)[] WayEnumerator, in ColoredBoardSmallBigger MeBoard, in ColoredBoardSmallBigger EnemyBoard, in Player Me, in Player Enemy, in sbyte[,] ScoreBoard, int alpha, int beta)
        {
            if(deepness == 0)
            {
                return Tuple.Create(PointEvaluator.Calculate(ScoreBoard, MeBoard, 0) - PointEvaluator.Calculate(ScoreBoard, EnemyBoard, 0), MeBoard, EnemyBoard, Me, Enemy);
            }

            Tuple<int, ColoredBoardSmallBigger, ColoredBoardSmallBigger, Player, Player> result = Tuple.Create(alpha, new ColoredBoardSmallBigger(), new ColoredBoardSmallBigger(), Me, Enemy);
            for (int i = 0; i < WayEnumerator.Length; ++i)
                for (int m = 0; m < WayEnumerator.Length; ++m)
                {

                    Player newMe = Me;
                    newMe.Agent1 += WayEnumerator[i];
                    newMe.Agent2 += WayEnumerator[m];

                    var movable = Checker.MovableCheck(MeBoard, EnemyBoard, newMe, Enemy);

                    if (!movable.IsMovable) continue;

                    Tuple<int, ColoredBoardSmallBigger, ColoredBoardSmallBigger, Player, Player> cache = null;
                    var newMeBoard = MeBoard;

                    if (movable.IsEraseNeeded)
                    {
                        var newEnBoard = EnemyBoard;

                        if (movable.Me1 == Rule.MovableResultType.EraseNeeded)
                        {
                            newEnBoard[newMe.Agent1] = false;
                            newMe.Agent1 = Me.Agent1;
                        }
                        else
                            newMeBoard[newMe.Agent1] = true;

                        if (movable.Me2 == Rule.MovableResultType.EraseNeeded)
                        {
                            newEnBoard[newMe.Agent2] = false;
                            newMe.Agent2 = Me.Agent2;
                        }
                        else
                            newMeBoard[newMe.Agent2] = true;

                        cache = EnemyTurn(deepness, WayEnumerator, newMeBoard, newEnBoard, newMe, Enemy, ScoreBoard, result.Item1, beta);
                    }
                    else
                    {
                        newMeBoard[newMe.Agent1] = true;
                        newMeBoard[newMe.Agent2] = true;

                        cache = EnemyTurn(deepness, WayEnumerator, newMeBoard, EnemyBoard, newMe, Enemy, ScoreBoard, result.Item1, beta);
                    }

                    if (result.Item1 < cache.Item1)
                    {
                        result = cache;
                        if (deepness == cnt)
                        {
                            dp[cnt].Item2 = WayEnumerator[i];
                        }
                    }

                    if (result.Item1 >= beta)
                    {
                        return result;
                    }

                }
            return result;
        }

        Tuple<int, ColoredBoardSmallBigger, ColoredBoardSmallBigger, Player, Player> EnemyTurn(int deepness, in (int DestX, int DestY)[] WayEnumerator, in ColoredBoardSmallBigger MeBoard, in ColoredBoardSmallBigger EnemyBoard, in Player Me, in Player Enemy, in sbyte[,] ScoreBoard, int alpha, int beta)
        {

        }
        */
    }
}
