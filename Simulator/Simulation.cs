using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// The simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// The list of mappables moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// The starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables' moves.
    /// Invalid moves are ignored - use DirectionParser.
    /// The first move is for the first mappable, the second for the second, and so on.
    /// When all mappables make their moves,
    /// the next move is again for the first mappable, and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// The list of directions.
    /// </summary>
    private List<Direction> ParsedMoves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Current turn counter.
    /// </summary>
    private int _currentTurn = 0;

    /// <summary>
    /// Valid moves characters.
    /// </summary>
    private readonly HashSet<char> _validMoves = new HashSet<char> { 'l', 'r', 'u', 'd' };

    /// <summary>
    /// The IMappable that will be moving in the current turn.
    /// </summary>
    public IMappable CurrentMappable => Mappables[_currentTurn % Mappables.Count];

    /// <summary>
    /// Lowercase name of the direction that will be used in the current turn.
    /// </summary>
    public string CurrentMoveName => ParsedMoves[_currentTurn % ParsedMoves.Count].ToString().ToLower();

    /// <summary>
    /// Helps to store simulation history.
    /// </summary>
    public SimulationHistory History { get; }

    /// <summary>
    /// Simulation constructor.
    /// Throws exceptions if the mappables' list is empty,
    /// or if the number of mappables differs from
    /// the number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        Map = map ?? throw new ArgumentNullException(nameof(map));

        if (mappables == null || mappables.Count == 0)
            throw new ArgumentException("At least one mappable must be placed on the map.", nameof(mappables));

        if (positions == null || positions.Count != mappables.Count)
            throw new ArgumentException("Invalid number of starting positions provided.", nameof(positions));

        Mappables = mappables;
        Positions = positions;
        Moves = moves ?? throw new ArgumentNullException(nameof(moves));
        ParsedMoves = ParseMoves(moves);
        History = new SimulationHistory();

        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].InitMapAndPosition(map, positions[i]);
        }

        // Record initial state
        History.RecordState(
            _currentTurn,
            Mappables.ToDictionary(m => m, m => positions[Mappables.IndexOf(m)]),
            null,
            null
        );
    }

    /// <summary>
    /// Makes one move of the current mappable in the current direction.
    /// Throws an exception if the simulation is finished.
    /// </summary>
    public void ExecuteTurn()
    {
        if (Finished)
            throw new InvalidOperationException("Cannot execute a turn on a completed simulation.");

        var direction = ParsedMoves[_currentTurn % ParsedMoves.Count];
        CurrentMappable.Go(direction);

        // Record the turn's state
        RecordCurrentState(direction);

        _currentTurn++;
        if (_currentTurn >= ParsedMoves.Count) Finished = true;
    }

    /// <summary>
    /// Records the current state of the simulation in the history.
    /// </summary>
    private void RecordCurrentState(Direction direction)
    {
        History.RecordState(
            _currentTurn,
            Mappables.ToDictionary(m => m, m => m.Position),
            CurrentMappable,
            direction
        );
    }

    /// <summary>
    /// Parses the moves input string into a list of directions.
    /// </summary>
    private List<Direction> ParseMoves(string moves)
    {
        return moves
            .Where(c => _validMoves.Contains(char.ToLower(c)))
            .Select(c => DirectionParser.Parse(c.ToString()).FirstOrDefault())
            .ToList();
    }
}