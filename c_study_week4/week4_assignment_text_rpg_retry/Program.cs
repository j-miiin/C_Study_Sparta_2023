namespace week4_assignment_text_rpg_retry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior player = new Warrior("감자");

            Monster goblin = new Goblin("Goblin");

            Monster dragon = new Dragon("Dragon");

            List<IItem> itemList = new List<IItem> { new HealthPotion(), new StrengthPotion() };

            Stage stage = new Stage(player, goblin, itemList);
            stage.Start();

            if (player.IsDead) return;

            stage = new Stage(player, dragon, itemList);
            stage.Start();
        }
    }
}