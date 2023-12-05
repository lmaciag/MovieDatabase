using MovieDatabase.Core.Exceptions;
using MovieDatabase.Core.ValueObjects;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Core.Tests.ValueObjects;

[TestFixture]
public class PersonNameTests
{
    [TestCase("Adam")]
    [TestCase("Ewa")]
    [TestCase("Jan")]
    [TestCase("Anna")]
    [TestCase("Paweł")]
    [TestCase("Maria")]
    [TestCase("Krzysztof")]
    [TestCase("Agnieszka")]
    [TestCase("Marcin")]
    [TestCase("Katarzyna")]
    [TestCase("Tomasz")]
    [TestCase("Magdalena")]
    [TestCase("Jakub")]
    [TestCase("Aleksandra")]
    [TestCase("Michał")]
    [TestCase("Monika")]
    [TestCase("Piotr")]
    [TestCase("Zuzanna")]
    [TestCase("Szymon")]
    [TestCase("Dorota")]
    [TestCase("Rafał")]
    [TestCase("Marta")]
    [TestCase("Grzegorz")]
    [TestCase("Joanna")]
    [TestCase("Mateusz")]
    [TestCase("Justyna")]
    [TestCase("Sebastian")]
    [TestCase("Barbara")]
    [TestCase("Damian")]
    [TestCase("Elżbieta")]
    [TestCase("David")]
    [TestCase("Emily")]
    [TestCase("Michael")]
    [TestCase("Sarah")]
    [TestCase("James")]
    [TestCase("Jessica")]
    [TestCase("John")]
    [TestCase("Ashley")]
    [TestCase("Robert")]
    [TestCase("Amanda")]
    [TestCase("William")]
    [TestCase("Jennifer")]
    [TestCase("Joseph")]
    [TestCase("Patricia")]
    [TestCase("Charles")]
    [TestCase("Linda")]
    [TestCase("Thomas")]
    [TestCase("Elizabeth")]
    [TestCase("Christopher")]
    [TestCase("Susan")]
    public void ProperNamesShouldCreatePersonName(string name)
    {
        var personName = new PersonName(name);
        
        personName.Value.ShouldBe(name);
    }
    
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void EmptyValuesShouldThrowInvalidPersonNameException(string name)
    {
        Should.Throw<InvalidPersonNameException>(() => new PersonName(name));
    }
}