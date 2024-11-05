namespace Simulator
{
    public class Animals
    {
        private string _description = "Unknown";
        private uint _size = 3;
        public required string Description
        {
            get => _description;
            init => _description = Validator.Shortener(value, 3, 15, '#');
        }
        public uint Size { get; set; } = 3;
        public virtual string Info => $"{Description} <{Size}>";
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
        

    }
}

