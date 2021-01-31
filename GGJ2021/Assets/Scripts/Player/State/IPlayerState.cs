public interface IPlayerState
{
    bool IsCrouched { get; }

    IPlayerState EnterState();

    IPlayerState Update();
}