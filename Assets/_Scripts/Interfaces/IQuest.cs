using System;

namespace PlatformerMVC.Interfaces
{
    
    public interface IQuest: IDisposable
    {
        event EventHandler<IQuest> Completed;
        bool IsComppleted { get; }
        void Reset();
    }
}