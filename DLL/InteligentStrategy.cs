namespace Project;
public class InteligentStrategy : IStrategy
{
    public Piece PieceToPlay(List<Piece> itIsOkPlayed, Player player, int cursor)
    {
        List<int> aux = new List<int>();
        for (int i = 0; i < itIsOkPlayed.Count; i++)
        {
            if (Table.left == itIsOkPlayed[i].left || Table.right == itIsOkPlayed[i].left)
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
        int piecesNotGame = Table.piecesTotal.Count - Table.piecesInGame.Count;

        int[] statsAux = Table.stats;
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