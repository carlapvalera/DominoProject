namespace Project;
public class Player : IPlayer//implementacion de la interface
{
    public List<Piece> Hand { get; }
    public SortedSet<int> IDoNotHaveProvedInGame { get; }
    public int CountPieces { get { return Hand.Count; } }
    public string Name { get; }
    public double Score { get; set; }

    IStrategy strategy;
    IMove move;

    public Player(string name, double score, IStrategy strategy)
    {
        Name = name;
        Score = score;
        Hand = new List<Piece>();
        IDoNotHaveProvedInGame = new SortedSet<int>();
        this.strategy = strategy;
    }
    public Piece Play(int cursor,Table table)
    {
        List<Piece> itIsOkPlayed = new();
        itIsOkPlayed = move.itIsAOkPlayed(Hand);
        if (itIsOkPlayed.Count == 0)
        {
            IDoNotHaveProvedInGame.Add(table.left);
            IDoNotHaveProvedInGame.Add(table.right);
            table.Pass.Add(this);
            return null;
        }
        Piece piece = strategy.PieceToPlay(itIsOkPlayed, this, cursor);
        Hand.Remove(piece);
        return piece;
    }
}
