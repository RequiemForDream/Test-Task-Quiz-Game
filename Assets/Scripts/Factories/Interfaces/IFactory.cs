using UnityEngine;

namespace Factories.Interfaces
{
    public interface IFactory<out T>
    {
        T Create();
        void Reclaim(Object obj);
    }
}