namespace Project;
public class Piece : IPiece// implementacion de la interface IPieza
{
    public int left { get; set; }
    public int right { get; set; }
    public Piece(int left, int right)
    {
        this.left = left;
        this.right = right;
    }
    public void Turn()
    {
        int temp = left;
        left = right;
        right = temp;
    }
    public string Paint()
    {
        return "[" + this.left + "/" + this.right + "]";
    }
}