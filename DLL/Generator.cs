namespace Project;
public class Generator//genera la cantidad de piezas del juego en base a uma cantida  determinada de valores
{
    public Generator(int amount)
    {
        PiecesGenerator(amount);
    }
    public void PiecesGenerator(int amount)
    {
        List<Piece> total = new List<Piece>();
        for (int i = 0; i <= amount; i++)
        {
            for (int j = i; j <= amount; j++)
            {
                total.Add(new Piece(i, j));
            }
        }
        Table.piecesTotal = total;
    }
}
