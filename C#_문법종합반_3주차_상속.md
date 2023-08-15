## 상속
### 개념
- 기존의 클래스(부모 클래스/상위 클래스)를 확장하거나 재사용하여 새로운 클래스(자식 클래스/하위 클래스)를 생성하는 것
- 자식 클래스는 부모 클래스의 멤버(필드, 메서드, 프로퍼티)를 상속받아 사용 가능

### 장점
- 코드의 재사용
- 계층 구조 표현
- 유지보수성 향상

### 종류
- 단일 상속 : 하나의 자식 클래스가 하나의 부모 클래스만 상속받음
- 다중 상속 : 하나의 자식 클래스가 여러 개의 부모 클래스를 동시에 상속받음 but __C#에서는 다중 상속 지원 X (인터페이스만 가능)__
- 인터페이스 상속 : 클래스가 인터페이스를 상속받는 것

### 특징
- 부모 클래스의 멤버에 접근 가능
- 부모 클래스의 메서드 재정의
- 상속의 깊이 : 다수의 계층적인 상속 구조 가능

### 접근 제한자와 상속
- 부모 클래스의 멤버 접근 제한자에 따라 자식 클래스에서 해당 멤버에 접근할 수 있는 범위가 결정됨

```cs
// 부모 클래스
public class Animal
{
  public string Name { get; set; }
  public int Age { get; set; }
  
  public void Eat()
  {
    Console.WriteLine("Animal is eating");
  }
  
  public void Sleep()
  {
    Console.WriteLine("Animal is sleeping");
  }
}

// 자식 클래스
public class Dog : Animal
{
  public void Bark()
  {
    Console.WriteLine("Dog is bark");
  }
}

public class Cat : Animal
{
  public void Meow()
  {
    Console.WriteLine("Cat is meow.");
  }
  
  public void Sleep()
  {
    Console.WriteLine("Cat Sleep!");
  }
}

static void Main(string[] args)
{
  Dog dog = new Dog();
  dog.Name = "Potato";
  dog.Age = 3;
    
  dog.Eat();
  dog.Sleep();
  dog.Bark();
  
  Cat cat = new Cat();
  cat.Name = "Tomato";
  cat.Age = 5;
  
  cat.Eat();
  cat.Sleep();
  cat.Meow();
}
```
```
Animal is eating
Animal is sleeping
Dog is bark
Animal is eating
Cat Sleep!
Cat is meow.
```