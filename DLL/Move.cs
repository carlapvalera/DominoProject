namespace Project;
public class Move : IMove
{
    public List<Piece> itIsAOkPlayed(List<Piece> hand)
    {
        List<Piece> okPlayed = new List<Piece>();
        Action action = new Action();
        if (Table.piecesInGame == null) return hand;
        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i].left == Table.left || hand[i].left == Table.right || hand[i].right == Table.left
                || hand[i].right == Table.right)
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
