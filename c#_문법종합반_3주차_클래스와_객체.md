## 클래스와 객체
### 객체지향 프로그래밍의 특징
- __캡슐화(Encapsulation)__ : 관련된 데이터와 기능을 하나의 단위로 묶는 것
  - 정보를 은닉
  - 외부의 직접적인 접근 제한 -> 안정성, 유지보수성 ↑
- __상속(Inheritance)__ : 기존 클래스를 확장하여 새로운 클래스를 만드는 매커니즘
  - 부모 클래스(상위 클래스, 슈퍼 클래스)의 특성과 동작을 자식 클래스(하위 클래스, 서브 클래스)가 상속받아 재사용
  - 코드 중복 ↓ 유지보수 용이 ↑
  - 클래스 간 계층 구조 -> 코드의 구조화
- __다형성(Polymorphism)__ : 하나의 인터페이스나 기능을 다양한 방식으로 구현하거나 사용할 수 있는 능력
  - 오버로딩, 오버라이딩 (하나의 메서드 이름이 다양한 객체에서 다르게 동작)
  - 유연성, 확장성, 가독성, 재사용성 ↑
- __추상화(Abstraction)__ : 복잡한 시스템이나 개념을 단순화
  - 세부 구현 내용은 감추고 핵심 개념에 집중
  - 유지보수 용이
- __객체(Object)__ : 클래스로부터 생성된 실체
  - 데이터와 데이터를 조작하는 메서드를 가짐
  - 모듈화, 재사용성 ↑


### 클래스
- 객체를 생성하기 위한 템플릿 / 설계도
- 속성(필드)과 동작(메서드)을 가짐


### 클래스의 구성 요소
1. __필드(Fields)__ : 클래스에서 사용되는 변수
2. __메서드(Methods)__ : 클래스에서 수행되는 동작 정의
3. __생성자(Constructors)__ : 객체를 초기화
   - 클래스와 동일한 이름을 가지며, 반환 타입이 없음
   - new 키워드와 함께 호출
   - 여러 개 정의 가능 -> __생성자 오버로딩__
  ```c
  class Person
  {
    private string name;
    private int age;
    
    // 디폴트 생성자
    public Person()
    {

    }
    
    public Person(string newName, int newAge)
    {
      name = newName;
      age = newAge;
    }
  }
    
  static void Main(string[] args)
  {
    Person person1 = new Person();
    Person person2 = new Person("Potato", 100);
  }
  ```
  
4. __소멸자(Destructors)__ : 메모리나 리소스의 해제 수행
   - 객체가 소멸되는 시점에서 자동으로 호출됨
   - 클래스와 동일한 이름을 가지며, 이름 앞에 ~ 를 붙여 표현
   - 반환 타입, 매개변수 없음. 오버로딩 불가능
   - 명시적 소멸자 호출은 권장 X
  ```c
  class Person
  {
    private string name;
    
    public Person(string newName)
    {
      name = newName;
    }
    
    ~Person()
    {
      Console.WriteLine("Person 객체 소멸");
      }
  }
  ```


### 객체
- 클래스의 인스턴스
- 클래스의 실체화된 형태
- 독립적인 상태를 가짐 (객체마다 고유한 데이터)


```c
class Person
{
  public string Name;
  public int Age;
  
  public void PrintInfo()
  {
    Console.WriteLine("Name: " + Name);
    Console.WriteLine("Age: " + Age);
  }
}

static void Main(string[] args)
{
  Person p = new Person();
  p.Name = "Potato";
  p.Age = 100;
  p.PrintInfo();
}
```
```
Name: Potato
Age: 100
```

### 구조체 vs 클래스
- 사용자 정의 형식을 만드는 데 사용

| 구조체 | 클래스 |
| :---: | :---: |
| 값 형식 | 참조 형식 |
| 스택에 할당 | 힙에 할당 |
| 값이 복사됨 | 참조로 전달 |
| 상속 X | 단일/다중 상속 O|
|작은 크기의 데이터 저장, 단순한 데이터 구조에 적합 | 복잡한 객체 표현과 다양한 기능 제공|


### 접근 제한자
- 클래스, 필드, 메서드 등의 접근 가능한 범위를 지정하는 키워드
- 클래스의 캡슐화를 제어하는 역할
- __public__ : 외부에서 자유롭게 접근 가능
- __private__ : 같은 클래스 내부에서만 접근 가능
- __protected__ : 같은 클래스 내부와 상속받은 클래스에서만 접근 가능
- 보통 클래스의 필드(Fields)는 접근 제한자를 사용하여 외부에서의 직접적인 접근을 제한 -> 필요한 경우 프로퍼티를 통해 간접적으로 접근
- 보통 클래스의 메서드(Methods)는 public 접근 제한자를 사용하여 외부에서 호출할 수 있도록 함

### 프로퍼티(Property)
- 클래스 멤버로서, 객체의 필드 값을 읽거나 설정하는데 사용되는 접근자(Accessor) 메서드의 조합
- 객체 필드에 직접 접근 X -> 간접적으로 값을 읽거나 설정
- 필드에 대한 접근 제어 및 데이터 유효성 검사 가능
- __get__ : 프로퍼티의 값을 반환
- __set__ : 프로퍼티의 값을 설정
  ```c
  class Person
  {
    private string name;
    private int age;
    
    public string Name
    {
      get { return name; }
      set{ name = value; }
    }
    
    public int Age
    {
      get { return age; }
      set { age = value; }
    }
  }
  ```
  ```c
  Person person = new Person();
  person.Name = "Potato";
  person.Age = 100;
  
  Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
  ```
- 접근 제한자 적용 및 유효성 검사 예제
  ```c
  class Person
  {
    private string name;
    private int age;
    
    public string Name
    {
      get { return name; }
      private set{ name = value; } // name 값 설정은 class 내부에서만 가능
    }
    
    public int Age
    {
      get { return age; }
      set 
      {
        if (value >= 0)
          age = value;
      }
    }
  }
  ```
- __자동 프로퍼티(Auto Property)__
  - 프로퍼티를 간단하게 정의하고 사용할 수 있는 기능
  - 필드의 역할도 같이 됨
  - 당장 프로퍼티를 구현하기 귀찮다면 일단 자동 프로퍼티로 구현
    ```c
    class Person
    {
      public string Name { get; set; }
      public int Age { get; set; }
    }
    ```

### Tip
- 클래스와 객체를 사용하여 프로그램을 작성할 때, 객체 지향 프로그래밍(OOP)의 원칙을 지키도록 노력
- 프로퍼티를 사용해 필드 접근을 제한하면 코드의 안정성, 가독성 ↑
- 클래스의 접근 제한자를 적절히 사용해 필요한 부분만 외부에서 접근 가능하게 하는 것이 좋음 
