using Simulator.Maps;
using Simulator;

public class Simulation
{
    private readonly List<Direction> _directions;
    private int _currentMappable;
    private int _currentDirection;
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentIMappable => Mappables[_currentMappable];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => _directions[_currentDirection].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
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

        for (int i = 0; i < mappables.Count; ++i)
        {
            Mappables[i].InitMapAndPosition(map, positions[i]);
        }

        Moves = moves ?? throw new ArgumentNullException(nameof(moves));
        _directions = DirectionParser.Parse(moves);

        Finished = _directions.Count == 0;
    }


    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Cannot execute a turn on a completed simulation.");

        var direction = _directions[_currentDirection];
        CurrentIMappable.Go(direction);

        _currentMappable = (_currentMappable + 1) % Mappables.Count;
        _currentDirection++;

        if (_currentDirection >= _directions.Count)
            Finished = true;
    }

}