## out과 ref
### 정의
- 메서드에서 매개변수를 전달할 때 사용

### 사용법
- __out__ : 메서드에서 반환 값을 매개변수로 전달하는 경우 사용
- __ref__ : 메서드에서 매개변수를 수정하여 원래 값에 영향을 주는 경우 사용
- 메서드에서 값을 반환하는 것이 아닌, 매개변수를 이용하여 값을 전달 가능
- 차이점 : out으로 선언된 매개변수에는 메서드에서 값을 꼭 넣어줘야 함. ref는 값을 넣어주지 않아도 상관 없음.


```cs
// out 키워드 예시
static void Divide(int a, int b, out int quotient, out int remainder)
{
  quotient = a / b;
  remainder = a % b;
}

// ref 키워드 예시
static void Swap(ref int a, ref int b)
{
  int temp = a;
  a = b;
  b= temp;
}

static void Main(string[] args)
{
  int quotient, remainder;
  Divide(7, 3, out quotient, out remainder);
  Console.WriteLine($"{quotient}, {remainder}");
  
  int x = 1, y = 3;
  Swap(ref x, ref y);
  Console.WriteLine($"{x}, {y}");
}
```

### 주의사항
1. ref로 인한 값의 변경 가능성
2. 성능 이슈
   - ref는 매개변수 값을 복사하지 않고 메서드 내에서 직접 접근할 수 있으므로 성능상 이점이 있지만, 가독성과 유지보수성이 저하됨
3. 변수 변경 여부
   - out 매개변수를 전달할 때 해당 변수의 이전 값이 유지되지 않음에 주의