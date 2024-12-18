namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
        {
            FNext = MoveRules.WallNext;
            FNextDiagonal = MoveRules.WallNextDiagonal;
        }

    }
}
