using System;

namespace Core.Interfaces
{
    public interface IGameEnd
    {
        event Action OnGameEnded;
    }
}