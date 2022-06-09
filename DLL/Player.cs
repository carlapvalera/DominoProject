class Player
{
    public List<Piece> Hand { get; }
    public SortedSet<int> IDoNotHaveProvedInGame { get; }
    public int CountPieces { get { return Hand.Count; } }
    string Name { get; }
    double Score { get; set; }
    public Player(string name)
    {
        Name = name;
        Score = 0;
        Hand = new List<Piece>();
        IDoNotHaveProvedInGame = new SortedSet<int>();
    }
    Piece? Play(IStrategy<Piece> strategy, Table table, List<Piece> itIsOkPlayed, int cursor)
    {
        if (itIsOkPlayed.Count == 0)
        {
            IDoNotHaveProvedInGame.Add(table.left);
            IDoNotHaveProvedInGame.Add(table.right);
            return null;
        }
        Piece piece = strategy.PieceToPlay(table, itIsOkPlayed, this, cursor);
        Hand.Remove(piece);
        return piece;
    }
}
