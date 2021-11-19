public class MapGenetratorCell
{
    public int X;
    public int Z;

    public bool WallLeft;
    public bool WallBottom;
    public bool Floor;
    public bool DeadZone;
    public bool isVisited;

    public MapGenetratorCell(int x, int z, bool wallLeft = true, bool wallBottom = true,bool floor = true)
    {
        X = x;
        Z = z;
        WallLeft = wallLeft;
        WallBottom = wallBottom;
        Floor = floor;
    }
}
