using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    private readonly List<State> _history = new();

    /// <summary>
    /// Records the state of the simulation at a specific turn.
    /// </summary>
    public void RecordState(int turn, Dictionary<IMappable, Point> positions, IMappable currentMappable, Direction? currentMove)
    {
        var state = new State
        {
            Turn = turn,
            CurrentMappable = currentMappable,
            CurrentMove = currentMove,
            Positions = new Dictionary<IMappable, Point>(positions)
        };

        _history.Add(state);
    }

    /// <summary>
    /// Displays the state of the simulation at a given turn.
    /// </summary>
    public void DisplayState(int turn)
    {
        if (turn < 0 || turn >= _history.Count)
        {
            Console.WriteLine("Invalid turn number.");
            return;
        }

        var state = _history[turn];
        Console.WriteLine($"Turn: {turn}");

        if (state.CurrentMappable != null && state.CurrentMove.HasValue)
        {
            Console.WriteLine($"{state.CurrentMappable} moved {state.CurrentMove}");
        }

        foreach (var entry in state.Positions)
        {
            Console.WriteLine($"{entry.Key} is at {entry.Value}");
        }
    }

    /// <summary>
    /// Private class to store the state of the simulation at a specific turn.
    /// </summary>
    private class State
    {
        public int Turn { get; set; }
        public IMappable? CurrentMappable { get; set; }
        public Direction? CurrentMove { get; set; }
        public Dictionary<IMappable, Point> Positions { get; set; } = new();
    }
}