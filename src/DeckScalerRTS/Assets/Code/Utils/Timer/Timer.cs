namespace DeckScaler
{
    public class Timer
    {
        private float _duration;

        public Timer(float duration) => _duration = duration;

        public bool IsElapsed => _duration <= 0f;

        public void Tick(float delta) => _duration -= delta;

        public override string ToString() => IsElapsed ? "elapsed" : $"{_duration:#0.00}s";
    }
}