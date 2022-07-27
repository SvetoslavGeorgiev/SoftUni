using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void ConstructorShouldReturnCorrectResult()
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.AreEqual(0, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateMethodShouldReturnCorrectMessage()
    {
        HeroRepository heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 15);
        heroRepository.Create(hero);

        var hero1 = new Hero("Gosho", 10);

        var message = $"Successfully added hero Gosho with level 10";

        Assert.AreEqual(1, heroRepository.Heroes.Count);

        Assert.AreEqual(message, heroRepository.Create(hero1));

    }


    [Test]
    public void CreateMethodShouldThrowArgumentNullExceptionIfNameIsNull()
    {
        HeroRepository heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 15);


        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }


    [Test]
    public void CreateMethodShouldThrowArgumentNullExceptionIfNameIsAlreadyExist()
    {
        HeroRepository heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 15);
        heroRepository.Create(hero);

        var hero1 = new Hero("Pesho", 10);




        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero1));
    }


    [Test]
    public void RemoveMethodShouldReturnTrueAndReduceCount()
    {
        HeroRepository heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 15);
        heroRepository.Create(hero);

        heroRepository.Remove("Pesho");



        Assert.AreEqual(0, heroRepository.Heroes.Count);

        heroRepository.Create(hero);

        Assert.AreEqual(true, heroRepository.Remove("Pesho"));

    }

    [Test]
    public void RemoveMethodShouldThrowArgumentNullExceptionIfNameIsNull()
    {
        HeroRepository heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 15);
        heroRepository.Create(hero);

        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
    }

    [Test]
    public void GetHeroMethodShouldReturnCorrectObject()
    {
        HeroRepository heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 15);
        heroRepository.Create(hero);

        var hero1 = heroRepository.GetHero("Pesho");


        Assert.AreEqual(hero.Name, hero1.Name);
        Assert.AreEqual(hero.Level, hero1.Level);
        
    }


    [Test]
    public void GetHeroWithHighestLevelShouldReturnObjectWithTheHighestLevelFromAll()
    {
        HeroRepository heroRepository = new HeroRepository();

        var hero = new Hero("Pesho", 35);
        heroRepository.Create(hero);
        var hero2 = new Hero("Gosho", 25);
        heroRepository.Create(hero2);
        var hero3 = new Hero("Lucho", 15);
        heroRepository.Create(hero3);
        var hero4 = new Hero("Sasho", 5);
        heroRepository.Create(hero4);

        var hero1 = heroRepository.GetHeroWithHighestLevel();


        Assert.AreEqual(hero.Name, hero1.Name);
        Assert.AreEqual(hero.Level, hero1.Level);

    }

}