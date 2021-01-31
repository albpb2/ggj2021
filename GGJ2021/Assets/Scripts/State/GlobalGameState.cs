public class GlobalGameState : Singleton<GlobalGameState>
{
    public int GrandpaHouseCinematicIndex { get; set; }
    
    public bool WarSceneCinematicPlayed { get; set; }
}