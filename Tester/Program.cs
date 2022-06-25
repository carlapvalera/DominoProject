﻿namespace Project;
class Coach
{
    //Distribute distribute = new Distribute(players);
    static List<Player> players = new();
    public static void Jugadores(Table table)
    {
        for (int i = 0; i < 4; i++)
        {
            players.Add(new Player(i.ToString(), 0, new IntelligentRandom(table)));
        }

    }
    static void Main()
    {
        Table table = new(4);
        Jugadores(table);
        for (int i = 0; i < players.Count; i++)
        {
            Console.WriteLine(players[i].Name);
        }
        Generator generator = new Generator(9, table);
        Distribute distribute = new Distribute(players, 10, table);
        Final final = new Final(table);
        ClassicStart start = new ClassicStart(players, table.piecesOutGame);
        int count = 0;
        //int cursor = 0;
        int cursoractual = 0;
        while (!final.EndGame(players))
        {
            if (count == 0)
            {
                Player player = new Player(table);
                player = start.First();
                Pass pass = new Pass(players, start.First());
                cursoractual = Evaluate(start.First());
                table.Eject(player.Play(Cursor(players, cursoractual)));
                count++;
            }
            else if (count == 1)
            {
                Player player = new Player(table);
                player = start.First();
                Pass pass = new Pass(players, start.First());
                cursoractual = Evaluate(pass.GetEnumerator());
                table.Eject(player.Play(Cursor(players, cursoractual)));
                count++;
            }
            else
            {
                Player player = new Player(table);
                player = start.First();
                Pass pass = new Pass(players, players[Cursor(players, cursoractual)]);
                int lastcursor = cursoractual;
                cursoractual = Evaluate(pass.GetEnumerator());
                table.Eject(player.Play(Cursor(players, cursoractual)));
                count++;
            }

            foreach (var piece in table.piecesInGame)
            {
                Console.Write(piece.Paint());
                Console.WriteLine("");
            }

        }


        //foreach (var item in players)
        //{
        //    Console.WriteLine(item.Name);
        //    foreach (var x in item.Hand)
        //    {
        //        Console.WriteLine(x.Paint());
        //    }
        //}

        //foreach (var item in Table.piecesTotal)
        //{
        //    Console.Write(item.Paint().ToString() + "   ");

        //}

    }
    private static int Evaluate(IEnumerator<Player> player)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] == player)
                return i;
        }
        return 0;
    }
    private static int Evaluate(Player player)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i] == player)
                return i;
        }
        return 0;
    }
    private static int Cursor(List<Player> players, int actual)
    {
        if (actual == players.Count - 1)
        {
            return 0;
        }
        else
            return actual++;
    }
    //private static int Next(List<Player> players , Player player)
    //{
    //    for (int i = 0; i < players.Count; i++)    
    //    {
    //        if (players[i] == player)
    //        {
    //            if (i < players.Count - 1)
    //                return i++;
    //            else
    //                return 0;
    //        }
    //        else
    //            return -1;
    //    }
    //    return -2;
    //}
}
