using Simulator.Maps;
using Simulator;

public class Simulation
{
    private readonly List<Direction> _directions;
    private int _currentCreature;
    private int _currentDirection;
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[_currentCreature];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => _directions[_currentDirection].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        Map = map ?? throw new ArgumentNullException(nameof(map));

        if (creatures == null || creatures.Count == 0)
            throw new ArgumentException("At least one creature must be placed on the map.", nameof(creatures));

        if (positions == null || positions.Count != creatures.Count)
            throw new ArgumentException("Invalid number of starting positions provided.", nameof(positions));

        Creatures = creatures;
        Positions = positions;

        for (int i = 0; i < creatures.Count; ++i)
        {
            Creatures[i].InitMapAndPosition(map, positions[i]);
        }

        Moves = moves ?? throw new ArgumentNullException(nameof(moves));
        _directions = DirectionParser.Parse(moves);

        Finished = _directions.Count == 0;
    }


    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Cannot execute a turn on a completed simulation.");

        var direction = _directions[_currentDirection];
        CurrentCreature.Go(direction);

        _currentCreature = (_currentCreature + 1) % Creatures.Count;
        _currentDirection++;

        if (_currentDirection >= _directions.Count)
            Finished = true;
    }

}