public interface ISpeedEffectApply 
{
    ISpeedEffectApplicable effectTarget
    {
        get;
    }

    float effectMultiplier
    {
        get;
    }

    float effectTime
    {
        get;
    }
}
