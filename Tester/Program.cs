namespace Project;
class Coach
{
    


    //Distribute distribute = new Distribute(players);
    static List<Player> players = new();
    public static void Jugadores()
    {
        for (int i = 0; i < 4; i++)
        {
            players.Add(new Player(i.ToString(), 0, new IntelligentRandom()));
        }

    }
    static void Main()
    {
        Jugadores();
        for (int i = 0; i < players.Count; i++)
        {
            Console.WriteLine(players[i].Name);
        }
        Generator generator = new Generator(9);
        Distribute distribute = new Distribute(players, 10);
        Final final = new Final();
        ClassicStart start = new ClassicStart(players, Table.piecesOutGame);
        int count = 0;
        int cursor = 0;
        int cursoractual = 0;
        while (!final.EndGame(players))
        {
            if (count == 0)
            {
                Pass pass = new Pass(players, start.First());
                cursor = Evaluate(start.First());
                Table.Eject(start.First().Play(cursor));
                count++;
            }
            else if (count == 1)
            {
                Pass pass = new Pass(players, start.First());
                cursoractual = Evaluate(pass.Current);
                Table.Eject(players[cursoractual].Play(cursor));
                count++;
            }
            else
            {
                Pass pass = new Pass(players, players[cursoractual]);
                int lastcursor = cursoractual;
                cursoractual = Evaluate(pass.Current);
                Table.Eject(players[cursoractual].Play(lastcursor));
                count++;
            }

            foreach (var table in Table.stats)
            {
                Console.Write(table);
            }
            Console.WriteLine("");    
            
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
        private static int Evaluate (Player player)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] == player)
                    return i;
            }
            return 0;
        }

}
