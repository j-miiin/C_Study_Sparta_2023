namespace c_study_week3_3_2_2
{
    internal class Program
    {
        public class Unit
        {
            public virtual void Move()  // 자식이 재정의를 했을 수 있다!
            {
                Console.WriteLine("두 발로 걷기");
            }

            public void Attack()
            {
                Console.WriteLine("Unit 공격");
            }
        }
        
        public class Marine : Unit
        {

        }

        public class Zergling : Unit
        {
            public override void Move()
            {
                Console.WriteLine("네 발로 걷기");
            }
        }

        static void Main(string[] args)
        {
            Marine marine = new Marine();
            marine.Move();
            marine.Attack();

            Zergling zergling = new Zergling();
            zergling.Move();
            zergling.Attack();

            // Unit : 참조의 형태
            // Marine, Zergling : 실제 형태
            List<Unit> list = new List<Unit>();
            list.Add(new Marine());
            list.Add(new Zergling());

            foreach (Unit unit in list)
            {
                unit.Move();
            }
        }
    }
}