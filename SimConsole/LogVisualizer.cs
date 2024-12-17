using Simulator;
using System.Text;

namespace SimConsole;

public class LogVisualizer
{
    private readonly SimulationHistory _log;

    public LogVisualizer(SimulationHistory log)
    {
        _log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public string Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= _log.TurnLogs.Count)
        {
            return "Invalid turn index.";
        }

        var turnLog = _log.TurnLogs[turnIndex];
        int sizeX = _log.SizeX;
        int sizeY = _log.SizeY;

        var outputBuilder = new StringBuilder();

        outputBuilder.AppendLine(CreateHorizontalBorder(Box.TopLeft, Box.TopMid, Box.TopRight, sizeX));

        for (int y = sizeY - 1; y >= 0; y--)
        {
            var rowBuilder = new StringBuilder();
            rowBuilder.Append(Box.Vertical);
            for (int x = 0; x < sizeX; x++)
            {
                var position = new Point(x, y);
                rowBuilder.Append(turnLog.Symbols.TryGetValue(position, out char symbol) ? symbol : ' ');
                rowBuilder.Append(Box.Vertical);
            }
            outputBuilder.AppendLine(rowBuilder.ToString());

            if (y > 0)
            {
                outputBuilder.AppendLine(CreateHorizontalBorder(Box.MidLeft, Box.Cross, Box.MidRight, sizeX));
            }
        }

        outputBuilder.AppendLine(CreateHorizontalBorder(Box.BottomLeft, Box.BottomMid, Box.BottomRight, sizeX));

        return outputBuilder.ToString();
    }

    private string CreateHorizontalBorder(char left, char mid, char right, int sizeX)
    {
        var borderBuilder = new StringBuilder();
        borderBuilder.Append(left);
        for (int x = 0; x < sizeX - 1; x++)
        {
            borderBuilder.Append(Box.Horizontal);
            borderBuilder.Append(mid);
        }
        borderBuilder.Append(Box.Horizontal);
        borderBuilder.Append(right);
        return borderBuilder.ToString();
    }
}
