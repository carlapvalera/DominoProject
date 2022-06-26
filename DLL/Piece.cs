namespace Project;
public class Piece : IPiece// implementacion de la interface IPieza
{
    public int left { get; set; }
    public int right { get; set; }
    public Piece(int left, int right)//constructor
    {
        this.left = left;
        this.right = right;
    }
    public void Turn()// Girar la ficha
    {
        int temp = left;
        left = right;
        right = temp;
    }
    public string Paint()// pintar la ficha
    {
        return "[" + this.left + "/" + this.right + "]";
    }
}