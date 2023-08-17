## 델리게이트, 람다 및 LINQ
### 델리게이트(delegate)란?
- 메서드를 참조하는 타입
- 다른 프로그래밍 언어에서는 함수 포인터라는 용어로 사용되기도 함
- 메서드를 매개변수로 전달하거나 변수에 할당 가능

### 델리게이트 구현
```cs
delegate int Calculate(int x, int y);

// delegate로 사용하겠다고 한 형식과 동일해야 함
static int Add(int x, int y)
{
  return x + y;
}

static void Main()
{
  Calculate calc = Add;
  
  int result = calc(3, 5);	// Add를 쓰는 것과 같음
  Console.WriteLine("결과: " + result);
}
```
- 여러 개의 메서드 연결
  ```cs
  delegate void MyDelegate(string message);
  
  static void Method1(string message)
  {
    Console.WriteLine("Method1: " + message);
  }
  
  static void Method2(string message)
  {
    Console.WriteLine("Method2: " + message);
  }
  
  static void Main(string[] args)
  {
    MyDelegate myDelegate = Method1;
    myDelegate += Method2;
    
    myDelegate("Hello");
  }
  ```
  ```
  Method1: Hello
  Method2: Hello
  ```
- 예제
  - event는 할당 연산자(=)를 사용할 수 없으며, 클래스 외부에서는 직접 이벤트를 호출할 수 없음
  ```cs
  public delegate void EnemyAttackHandler(float damage);
  
  // 적 클래스
  public class Enemy
  {
    public event EnemyAttackHandler OnAttack;
    
    public void Attack(float damage)
    {
      // 이벤트 호출
      OnAttack?.Invoke(damage);
    }
  }
  
  // 플레이어 클래스
  public class Player
  {
    // 플레이어가 받은 데미지 처리 메서드
    public void HandleDamage(float damage)
    {
      Console.WriteLine("플레이어가 {0}의 데미지를 입었습니다.", damage);
    }
  }
  
  static void Main()
  {
    Enemy enemey = new Enemy();
    
    Player player = new Player();
    
    // 플레이어의 데미지 처리 메서드를 적의 공격 이벤트에 추가
    enemy.OnAttack += player.HandleDamage;
    
    // 적의 공격
    enemy.Attack(10.0f);
  }
  ```
  


### 람다(Lambda)
- 익명 메서드를 만드는 방법
- 델리게이트를 사용하여 변수에 할당하거나 메서드의 매개변수로 전달 가능
- 예제
  ```cs
  delegate void MyDelegate(string message);
  
  class Program
  {
    static void Main()
    {
      MyDelegate myDelegate = (message) => 
      {
        Console.WriteLine("람다식을 통해 전달된 메시지: " + message);
      }
      
      // 델리게이트 호출
      myDelegate("안녕하세요!");
      
      Console.ReadKey();
    }
  }
  ```
  - 게임 분기의 시작을 알리기
    ```cs
    public delegate void GameEvent();
    
    public class EventManager
    {
      public event GameEvent OnGameStart;
      
      public event GameEvent OnGameEnd;
      
      public void RunGame()
      {
        OnGameStart?.Invoke();
        
        // 게임 실행 로직
        
        OnGameEnd?.Invoke();
      }
    }
    
    public class GameMessage
    {
      public void ShowMessage(string message)
      {
        Console.WriteLine(message);
      }
    }
    
    static void Main()
    {
      EventManager eventManager = new EventManager();
      
      GameManager gameMessage = new GameMessage();
      
      eventManager.OnGameStart += () => gameMessage.ShowMessage("게임이 시작됩니다.");
      
      eventManager.OnGameEnd += () => gameMessage.ShowMessage("게임이 종료됩니다.");
      
      gameManager.RunGame();
    }
    ```
    
### Func과 Action
- 델리게이트를 대체하는 미리 정의된 제네릭 형식
- __Func__ : 값을 반환하는 메서드를 나타내는 델리게이트
  - 마지막 제네릭 형식 매개변수는 반환 타입을 나타냄
    ex) Func<int, string> : int를 입력받아 string 반환
- __Actioin__ : 값을 반환하지 않는 델리게이트를 나타냄
  - 매개변수는 받지만 반환 타입 X
    ex) Action<int, string> : int와 string을 입력받고 아무것도 반환하지 않음
- 매개변수와 반환 타입을 간결하게 표현 가능
- Func 예제
  ```cs
  // Func를 사용해 두 개의 정수를 더하는 메서드
  static int Add(int x, int y)
  {
    return x + y;
  }
  
  static void Main()
  {
    Func<int, int, int> addFunc = Add;
    int result = addFunc(3, 5);
    Console.WriteLine("결과: " + result);
  }
   
  ```
- Action 예제
  ```cs
  // Action을 사용해 문자열을 출력하는 메서드
  void PrintMessage(string message)
  {
    Console.WriteLine(message);
  }
  
  Action<string> printAction = PrintMessage;
  printAction("Hello, World!");
  ```
  ```cs
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
  ```


### LINQ(Language Integrated Query)
- .NET 프레임워크에서 제공되는 쿼리 언어 확장
- 데이터 소스(ex: 컬렉션, 데이터베이스, XML 문서 등)에서 데이터를 쿼리하고 조작하는 데 사용
- 데이터베이스 쿼리와 유사한 방식으로 데이터를 필터링, 정렬, 그룹화, 조인 등 할 수 있음
- 구조
  ```cs
  var result = from 변수 in 데이터 소스
              [where 조건식]
              [orderby 정렬식 [, 정렬식...]]
              [select 식];
  ```
  - var : 결과 값의 자료형으로 자동 추론
  - from : 데이터 소스 지정
  - where : 선택적 사용. 조건식을 지정해 데이터 필터링
  - orderby : 선택적 사용. 정렬 방식 지정
  - select : 선택적 사용. 조회할 데이터 지정
- 예제
  ```cs
  List<int> numbers = new List<int>{1, 2, 3, 4, 5};
  
  var evenNumbers = from num in numbers
                    where num % 2 == 0
                    select num;

  foreach(var num in evenNumbers)
  {
    Console.WriteLine(num);
  }
  ```