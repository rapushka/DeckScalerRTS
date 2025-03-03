using UnityEngine;

namespace DeckScaler
{
    public interface ITimeService : IService
    {
        float Delta { get; }
    }

    public class TimeService : ITimeService
    {
        public float Delta => Time.deltaTime;
    }
}