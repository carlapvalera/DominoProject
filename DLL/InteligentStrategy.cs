namespace Project;
public class IntelligentStrategy : IStrategy
{

    List<Piece> itIsOkPlayed = new List<Piece>();
    Player player;
    int cursor = 0;
    Table table;
    public IntelligentStrategy(List<Piece> itIsOkPlayed, Player player, int cursor, Table table)
    {
        this.itIsOkPlayed = itIsOkPlayed;
        this.player = player;
        this.cursor = cursor;
        this.table = table; 
    }
    public Piece PieceToPlay(List<Piece> itIsOkPlayed, Player player, int cursor)
    {
        List<int> aux = new List<int>();
        for (int i = 0; i < itIsOkPlayed.Count; i++)
        {
            if (table.left == itIsOkPlayed[i].left || table.right == itIsOkPlayed[i].left)
            {
                aux.Add(itIsOkPlayed[i].right);
            }
            else
            {
                aux.Add(itIsOkPlayed[i].left);
            }
        }
        List<int> list = new List<int>();
        foreach (var item in player.IDoNotHaveProvedInGame)
        {
            for (int j = 0; j < aux.Count; j++)
            {
                if (item == aux[j])
                    return itIsOkPlayed[j];
            }
        }
        int piecesNotGame = table.piecesTotal.Count - table.piecesInGame.Count;

        int[] statsAux = table.stats;
        for (int i = 0; i < player.Hand.Count; i++)
        {
            statsAux[player.Hand[i].left]++;
            statsAux[player.Hand[i].right]++;
        }
        double[] probabilities = new double[aux.Count];
        double min = double.MaxValue;
        int indexAux = 0;
        for (int i = 0; i < probabilities.Length; i++)
        {
            probabilities[i] = 1 / ((double)(statsAux.Length + 1 - statsAux[aux[i]]) * piecesNotGame);
            if (min > probabilities[i])
            {
                min = probabilities[i];
                indexAux = i;
            }
        }
        return itIsOkPlayed[indexAux];
    }
}