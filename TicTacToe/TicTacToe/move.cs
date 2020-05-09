public struct Move
{
    /// <summary>
    /// Variables with AutoProperties
    /// </summary>
    public int x { get; set; }
    public int y { get; set; }

    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="newX"></param>
    /// <param name="newY"></param>
    public Move(int newX, int newY)
    {        
        x = newX;
        y = newY;
    }
}