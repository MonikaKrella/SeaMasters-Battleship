namespace SeaMasters;

public class Field
{
    public Coordinates Coordinates { get; }

    public bool IsEmpty { get; set; } = true;
    public bool IsShooted { get; set; } = false;

    public Field(int argX, int argY)
    {
        Coordinates = new Coordinates(argX:argX, argY:argY);
    }  
}