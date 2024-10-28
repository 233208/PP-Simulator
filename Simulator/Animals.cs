namespace Simulator
{
    public class Animals
    {
        private string _description = "Unknown";
        private uint _size = 3;
        public required string Description
        {
            get => _description;

            init
            {
                _description = value.Trim();
                if (_description.Length <= 3)
                    _description = _description.PadRight(3, '#');
                if (_description.Length >= 15)
                {
                    _description = _description.Substring(0, 15).Trim();
                    if (_description.Length <= 3)
                        _description = _description.PadRight(3, '#');
                }
                if (char.IsLower(_description[0]))
                    _description = char.ToUpper(_description[0]) + _description.Substring(1);
            }

        }
        public uint Size { get; set; } = 3;
        public string Info => $"{Description} <{Size}>";

    }
}

