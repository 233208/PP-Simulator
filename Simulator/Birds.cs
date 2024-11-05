namespace Simulator
{
    public class Birds : Animals
    {
        private bool _canFly = true;
        public override string Info
        {
            get => $"{Description}  ({(_canFly ? "fly+" : "fly-")}) <{Size}>";
        }
    }
}
