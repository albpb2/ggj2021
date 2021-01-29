public interface IPlayerState
{ 
    IPlayerState EnterState();

    IPlayerState Update();
}