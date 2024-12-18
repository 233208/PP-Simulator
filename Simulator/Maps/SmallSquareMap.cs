namespace Simulator.Maps
{
    /// <summary>
    /// Small square map with a side size between 5 and 20 points.
    /// </summary>
    public class SmallSquareMap : SmallMap
    {
        public SmallSquareMap(int size) : base(size, size) 
        {
            FNext = MoveRules.WallNext;
            FNextDiagonal = MoveRules.WallNextDiagonal;
        }
        
    }
}