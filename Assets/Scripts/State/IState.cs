using Unity.VisualScripting;

public interface IState
{
    BabyController baby
    {
        get;
    }

    public void Enter();

    public void Update();

    public void Exit();
}
