namespace Project;
public class Move : IMove
{
    Table table;
    public Move(Table table)
    {
        this.table = table;
    }
    public List<Piece> itIsAOkPlayed(List<Piece> hand)
    {
        List<Piece> okPlayed = new List<Piece>();
        Action action = new Action();
        if (table.piecesInGame == null) return hand;
        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i].left == table.left || hand[i].left == table.right || hand[i].right == table.left
                || hand[i].right == table.right)
                okPlayed.Add(hand[i]);
        }
        List<Piece> aux = new();
        if (action.Add == true)
            aux = action.ToAdd(hand);
        foreach (var piece in aux)
        {
            okPlayed.Add(piece);
        }
        return okPlayed;
    }
}
