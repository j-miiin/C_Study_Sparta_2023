## 다형성
- 같은 타입이지만 다양한 동작을 수행할 수 있는 능력

### 가상(Virtual) 메서드
- 기본적으로 부모 클래스에서 정의되고, 자식 클래스에서 필요에 따라 재정의할 수 있는 메서드
- __virtual__ 키워드 사용
- 예시
  ```cs
  public class Unit
  {
    public void Move() 
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
    public void Move()
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
  }
  ```
  ```
  두 발로 걷기
  Unit 공격
  네 발로 걷기
  Unit 공격
  ```
  - 많은 수의 Marine과 Zergling들을 함께 관리하기 위해 Unit을 담는 list를 생성
    - Marine과 Zergling의 Move가 아닌 Unit의 Move가 실행됨
    ```cs
    static void Main(string[] args)
    {
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
    ```
    ```
    두 발로 걷기
    두 발로 걷기
    ```
  - Unit의 Move를 __virtual__로 선언 -> 자식 클래스가 이 메서드를 재정의했을 수도 있음을 알려줌
  - Zergling은 Move 선언시 __override__ 명시
    - Move 실행시 자식 클래스에 방문해서 Move 함수를 재정의했는지 확인 -> 재정의한 함수를 먼저 사용
    ```cs
    public class Unit
    {
      public virtual void Move() 
      {
        Console.WriteLine("두 발로 걷기");
      }
      ...
    }
    
    public class Zergling : Unit
    {
      public override void Move()
      {
        Console.WriteLine("네 발로 걷기");
      }
    }
    ```
    ```
    두 발로 걷기
    네 발로 걷기
    ```
   

### 추상(Abstract) 클래스와 메서드
- 추상 클래스 : 직접적으로 인스턴스를 생성할 수 없는 클래스로, 상속을 위한 베이스 클래스로 사용됨
- 추상 메서드 : 구현부가 없는 메서드로, 자식 클래스에서 반드시 구현되어야 함
- 가상 메서드와의 차이점 : 자식 클래스에게 강제성을 부여함 -> 무조건 재정의해야 한다!
```cs
abstract class Shape
{
  public abstract void Draw();
}

class Circle :  Shape
{
  public override void Draw()
  {
    Console.WriteLine("Drawing Circle");
  }
}

class Square : Shape
{
  public override void Draw()
  {
    Console.WriteLine("Drawing Square");
  }
}

class Triangle : Shape
{
  public override void Draw()
  {
    Console.WriteLine("Drawing Triangle");
  }
}

static void Main(string[] args)
{
  // Shape shape = new Shape(); -> 객체화 불가능
  List<Shape> list = new List<Shape>();
  list.Add(new Circle());
  list.Add(new Square());
  list.Add(new Triangle());
  
  foreach (Shape shape in list)
  {
    // Draw는 abstract이므로 무조건 재정의가 되어있음 -> 자식 클래스 방문
    shape.Draw(); 
  }
}
```
```
Drawing Circle
Drawing Square
Drawing Triangle
```


### 오버라이딩과 오버로딩
- __오버라이딩(Overriding)__ : 부모 클래스에서 이미 정의된 메서드를 자식 클래스에서 재정의하는 것
  - 상속 관계에 있는 클래스 간에 발생
  - 이름, 매개변수, 반환 타입이 동일해야 함
- __오버로딩(Overloading)__ : 동일한 메서드 이름을 가지고 있지만, 매개변수의 개수, 타입 또는 순서가 다른 여러 개의 메서드를 정의하는 것