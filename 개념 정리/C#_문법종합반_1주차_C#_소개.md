## C# 소개
### C# 특징
- 객체지향 프로그래밍 언어
- __강력한 형식 시스템__
  - 변수나 객체의 자료형이 미리 정의되어 있어, 데이터 타입에 대한 안정성과 정확성을 보장하는 시스템
  - 안전한 코드 작성 가능
- __가비지 컬렉션 기능__
  - 동적 할당된 메모리를 자동으로 회수해주는 기능
  - .NET 프레임워크에서 가비지 수집기가 자동으로 메모리를 해제
- 다양한 플랫폼에서 사용 가능
- .NET 프레임워크에서 실행됨
 

### .NET 프레임워크
- Microsoft에서 개발한 프로그래밍 플랫폼 
- 다양한 프로그래밍 언어를 제공
- 프로그래머가 개발 -> 중간 언어 생성 -> 각각의 플랫폼에서 변환하여 사용
  

### 자동 완성
1. 클래스, 메서드, 변수 이름을 입력할 때 Tab 키
2. Console.WriteLine -> Console. 까지 입력하고 Tab
3. 메서드나 변수 입력 도중 Ctrl + Space 로 IntelliSense 호출 -> 해당 메서드나 변수에 대한 정보와 예제 볼 수 있음
4. 코드나 코드 템플릿 사용
  ex) for 입력하고 Tab 키 두번 누르면 for문의 기본적인 코드 템플릿 자동 생성

</br>

## 프로그래밍 기본 요소
### using
- 네임스페이스를 호출
- using System; : Console 클래스를 사용하기 위해 필요

### namespace 
- 코드를 구성하는 데 사용됨, 클래스 및 기타 네임스페이스의 컨테이너
![](https://velog.velcdn.com/images/lazypotato/post/4af88af5-c2d8-4050-8924-838da237047c/image.png)

### Console.Write
- WriteLine과 비슷하지만 끝에 줄바꿈 문자열을 추가하지 않음

### 이스케이프 시퀀스(Escape Sequence)
- 문자열 내에 특수한 문자를 포함시키기 위해 사용

  | 이스케이프 시퀀스 | 설명 | 
  | :---: | :---: | 
  | \' | 작은 따옴표(') 삽입|
  | \" | 큰 따옴표(") 삽입|
  | \\ | 역슬래시(\) 삽입|
  | \n | 줄바꿈 삽입|
  | \r | 현재 줄 맨 앞으로 이동|
  | \t | Tab 삽입|
  | \b | 백스페이스 삽입|

- 예시
  - "Hello" 까지 입력하고 맨 앞으로 이동해서 다시 World를 입력하므로 World만 출력 
  ![](https://velog.velcdn.com/images/lazypotato/post/ae04600a-8817-4508-9406-5c6ef464f68b/image.png)
  
### 주석(Comments)
- 코드의 설명이나 개발자 간의 의사소통을 위해 사용
- // : 한 줄 주석. 해당 줄 끝까지 주석 처리
- /* */ : 여러 줄 주석. 시작과 끝을 명시하여 주석 처리
- 주석의 내용은 정확하고 명확하게
- 주석은 업데이트 되어야 하며, 필요한 경우에만 사용
