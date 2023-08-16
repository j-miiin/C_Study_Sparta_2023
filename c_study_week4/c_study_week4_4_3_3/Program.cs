namespace c_study_week4_4_3_3
{
    internal class Program
    {
        class GameCharacter
        {
            private Action<float> healthChangedCallback;

            private float health;

            public float Health
            {
                get { return health; }
                set
                {
                    health = value;
                    healthChangedCallback?.Invoke(health);
                }
            }

            public void SetHealthChangedCallback(Action<float> callback)
            {
                healthChangedCallback = callback;
            }
        }

        static void Main(string[] args)
        {
            GameCharacter character = new GameCharacter();
            character.SetHealthChangedCallback(health =>
            {
                if (health <= 0)
                {
                    Console.WriteLine("캐릭터 사망!");
                }
            });

            character.Health = 0;
        }
    }
}