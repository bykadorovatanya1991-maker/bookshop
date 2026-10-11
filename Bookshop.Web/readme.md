1. Front-end (html, js, css)
   URL 

2. Server side (C#)
   Booksho.Api - https://localhost:6767

   API - set of functions (API endpoints)

   API
      API endpoint (/books)
      API endpoint (/books/{id}), where {id}=[1,2,3,4,5,6]
      API endpoint (/authors)
      API endpoint (/authors/{id}), where {id}=[1,2,3,4,5,6]


   https://localhost:6767/books
   returns JSON
   [
      {
        "id": 1,
        "title": "Der Schimmelreiter",
        "author": "Theodor Storm",
        "image": "book images/Der Schimmelreiter.jpg"
      },
      {
        "id": 2,
        "title": "Wellen",
        "author": "Eduard von Keyserling",
        "image": "book images/Wellen.jpg"
      },
      ....
   ]


   https://localhost:6767/books/1
   returns JSON
    {
      "id": 1,
      "title": "Der Schimmelreiter",
      "author": {
        "id": 2,
        "firstName": "Theodor",
        "lastName": "Storm"
      },
      "description": "keiurgfhi",
      "image": "book images/Der Schimmelreiter.jpg"
    }

3. DB (SQL)


----
Case 1
   Web Site - tanya-bookshop.com
   API      - tanya-bookshop.com/api

Case 2
   Web Site - tanya-bookshop.com
   API      - api.tanya-bookshop.com


Типы данных
простые
 int, string, double, bool, decimal, 'A' char, DateTime
classes
 dto, eentity class

 int a = 3
 string b = " "
 char c ='a'
 decimal d = 12.4M;

 public class Person {
  Person(){
    Age = 67;
  }

  public string Name {get; set;}
  public int Age {get;set;}
  public void SayHello(){
    Console.WriteLine("super sus uvidel mir");
  }
 }

 Person vasya = new Person();
 var isAge67 = vasya.Age == 67; // true
 vasya.Name = "Vasya";
 vasya.SayHello();

Person petya = new Person()
{
  Name = "Petya",
  Age = 24
};

List<Person> people = new List<Person> ();
people.Add()





public class Game = new Game (
  public string Title = {get; set;}
  public int ReleaseYear = {get; set;}
  public double Rating = {get; set;}
);

public List<Games> game = new List<Games> (
  new Game = {
    Title = "Minecraft",
    ReleaseYear = 2011,
    Rating = 9.7m
  }
  new Game = {
    Title = "Cyberpunk 2077",
    ReleaseYear = 2020,
    Rating = 8.5m
  }
  new Game = {
    Title = "The Witcher 3",
    ReleaseYear = 2015,
    Rating = 9.7m
  }
)

foreach(Game game in Games) {
  Console.WriteLine($"{Title} was released in {ReleaseYear}")
}


var coolGame = new Game {
  Title = "abobus"
}





