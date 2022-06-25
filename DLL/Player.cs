namespace Project;
public class Player : IPlayer//implementacion de la interface
{
    Table table;
    public Player(Table table)
    {
        this.table = table;
    }
    public List<Piece> Hand { get; }
    public SortedSet<int> IDoNotHaveProvedInGame { get; }
    public int CountPieces { get { return Hand.Count; } }
    public string Name { get; }
    public double Score { get; set; }

    IStrategy strategy;

    public Player(string name, double score, IStrategy strategy)
    {
        Name = name;
        Score = score;
        Hand = new List<Piece>();
        IDoNotHaveProvedInGame = new SortedSet<int>();
        this.strategy = strategy;
    }
    public Piece Play(int cursor)
    {
        Move move = new Move(table);
        List<Piece> itIsOkPlayed = new();
        itIsOkPlayed = move.itIsAOkPlayed(Hand);
        if (itIsOkPlayed.Count == 0)
        {
            IDoNotHaveProvedInGame.Add(table.left);
            IDoNotHaveProvedInGame.Add(table.right);
            return null;
        }
        Piece piece = strategy.PieceToPlay(itIsOkPlayed, this, cursor);
        Hand.Remove(piece);
        if (piece == null)
        {
            if (table.Pass == null)
            {
                table.Pass = new List<Player>();
                table.Pass.Add(this);
            }
            else
                table.Pass.Add(this);

        }
        return piece;
    }
}
