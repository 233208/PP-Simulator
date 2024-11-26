using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#nullable enable
namespace SimConsole
{
    public class MapVisualizer
    {
        private readonly string _upperBorder;
        private readonly string _lowerBorder;
        private readonly string _middleBorder;
        private readonly string[] _rowLines;

        private Map Map { get; }

        public MapVisualizer(Map map)
        {
            Map = map;
            _rowLines = new string[Map.SizeY];
            _upperBorder = CreateLine(Box.TopLeft, Box.TopMid, Box.TopRight, Map.SizeX);
            _middleBorder = CreateLine(Box.MidLeft, Box.Cross, Box.MidRight, Map.SizeX);
            _lowerBorder = CreateLine(Box.BottomLeft, Box.BottomMid, Box.BottomRight, Map.SizeX);
        }

        private string CreateLine(char start, char middle, char end, int width)
        {
            return start + string.Concat(Enumerable.Repeat(Box.Horizontal.ToString() + middle, width - 1)) + Box.Horizontal + end;
        }

        private void FillDataLines()
        {
            for (int y = 0; y < Map.SizeY; ++y)
            {
                var charList = new List<char>();
                for (int x = 0; x < Map.SizeX; ++x)
                {
                    var creatureList = Map.At(x, y);
                    char ch = creatureList == null || creatureList.Count == 0 ? ' ' : (creatureList.Count == 1 ? creatureList.First().MapSymbol : 'X');
                    charList.Add(ch);
                }
                _rowLines[y] = Box.Vertical + string.Join(Box.Vertical, charList) + Box.Vertical;
            }
        }

        public void Draw()
        {
            Console.OutputEncoding = Encoding.UTF8;
            FillDataLines();
            var stringList = new List<string> { _upperBorder };
            for (int index = Map.SizeY - 1; index > 0; --index)
            {
                stringList.Add(_rowLines[index]);
                stringList.Add(_middleBorder);
            }
            stringList.Add(_rowLines[0]);
            stringList.Add(_lowerBorder);
            stringList.ForEach(Console.WriteLine);
        }
    }
}
