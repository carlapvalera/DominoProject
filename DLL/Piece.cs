class Piece{
    public int left{get;private set;}
    public int right{get;private set;}
    public Piece(int left,int right){
        this.left=left;
        this.right=right;
    }
    public void Turn(){
        int temp=left;
        left=right;
        right=temp;
    }
}