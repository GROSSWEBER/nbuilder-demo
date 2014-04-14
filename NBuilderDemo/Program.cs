using System;
using System.Collections.Generic;

using FizzWare.NBuilder;

namespace NBuilderDemo
{
  class Person
  {
    public string Name { get; set; }
    public int Age { get; set; }

    public void RenameTo(string newName)
    {
      Name = newName;
    }

    public override string ToString()
    {
      return string.Format("Name: {0}, Age: {1}", Name, Age);
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var persons = Builder<Person>
        .CreateListOfSize(10)
        .All()
        .Have(x => x.Name = "some name")
        .Build();

      Print(persons);
      
      var persons2 = Builder<Person>
        .CreateListOfSize(10)
        .All()
        .Do(x=> x.RenameTo("Peter"))
        .Build();
      
      Print(persons2);

      var persons3 = Builder<Person>
        .CreateListOfSize(10)
        .Random(5)
        .Have(x => x.Name = "special name")
        .Build();

      Print(persons3);

      Console.ReadKey();
    }

    static void Print(IList<Person> persons)
    {
      foreach (var person in persons)
      {
        Console.WriteLine(person);
      }
      Console.WriteLine("---");
    }
  }
}
