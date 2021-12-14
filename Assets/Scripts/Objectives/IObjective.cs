using System;

public interface IObjective
{
    event Action<IObjective> Completed;
    
    bool IsMain { get; }
    string Description { get; }

    void Init();
}