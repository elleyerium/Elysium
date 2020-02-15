using System;

namespace Game.Difficult
{
    public class BotDifficult
    {
        public float DamageMultiplier { get; }
        public float BlasterReloadDelay { get; }
        public float MissileReloadDelay { get; }
        public float ScoreMultiplier { get; }

        public static DifficultRate DifficultRate;

        public BotDifficult(DifficultRate difficultRate)
        {
            DifficultRate = difficultRate;
            switch (difficultRate)
            {
                case DifficultRate.Easy:
                    DamageMultiplier = 1.0f;
                    BlasterReloadDelay = 1.0f;
                    MissileReloadDelay = 2f;
                    ScoreMultiplier = 1.0f;
                    break;
                case DifficultRate.Medium:
                    DamageMultiplier = 0.9f;
                    BlasterReloadDelay = 1.2f;
                    MissileReloadDelay = 2.5f;
                    ScoreMultiplier = 1.2f;
                    break;
                case DifficultRate.Hard:
                    DamageMultiplier = 0.8f;
                    BlasterReloadDelay = 1.5f;
                    MissileReloadDelay = 3f;
                    ScoreMultiplier = 1.5f;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(difficultRate), difficultRate, null);
            }
        }
    }

    public enum DifficultRate
    {
        Easy,
        Medium,
        Hard
    }
}
