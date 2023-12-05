using MovieDatabase.Core.Exceptions;
using MovieDatabase.Core.ValueObjects;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Core.Tests.ValueObjects;

[TestFixture]
public class MovieBoxOfficeTests
{
    [TestCase(1000000.00)] // 1 million
    [TestCase(5000000.00)] // 5 million
    [TestCase(10000000.00)] // 10 million
    [TestCase(15000000.00)] // 15 million
    [TestCase(20000000.00)] // 20 million
    [TestCase(25000000.00)] // 25 million
    [TestCase(30000000.00)] // 30 million
    [TestCase(35000000.00)] // 35 million
    [TestCase(40000000.00)] // 40 million
    [TestCase(45000000.00)] // 45 million
    [TestCase(50000000.00)] // 50 million
    [TestCase(55000000.00)] // 55 million
    [TestCase(60000000.00)] // 60 million
    [TestCase(65000000.00)] // 65 million
    [TestCase(70000000.00)] // 70 million
    [TestCase(75000000.00)] // 75 million
    [TestCase(80000000.00)] // 80 million
    [TestCase(85000000.00)] // 85 million
    [TestCase(90000000.00)] // 90 million
    [TestCase(95000000.00)] // 95 million
    [TestCase(100000000.00)] // 100 million
    [TestCase(105000000.00)] // 105 million
    [TestCase(110000000.00)] // 110 million
    [TestCase(115000000.00)] // 115 million
    [TestCase(120000000.00)] // 120 million
    [TestCase(125000000.00)] // 125 million
    [TestCase(130000000.00)] // 130 million
    [TestCase(135000000.00)] // 135 million
    [TestCase(140000000.00)] // 140 million
    [TestCase(145000000.00)] // 145 million
    [TestCase(150000000.00)] // 150 million
    [TestCase(155000000.00)] // 155 million
    [TestCase(160000000.00)] // 160 million
    [TestCase(165000000.00)] // 165 million
    [TestCase(170000000.00)] // 170 million
    [TestCase(175000000.00)] // 175 million
    [TestCase(180000000.00)] // 180 million
    [TestCase(185000000.00)] // 185 million
    [TestCase(190000000.00)] // 190 million
    [TestCase(195000000.00)] // 195 million
    [TestCase(200000000.00)] // 200 million
    [TestCase(205000000.00)] // 205 million
    [TestCase(210000000.00)] // 210 million
    [TestCase(215000000.00)] // 215 million
    [TestCase(220000000.00)] // 220 million
    [TestCase(225000000.00)] // 225 million
    [TestCase(230000000.00)] // 230 million
    [TestCase(235000000.00)] // 235 million
    [TestCase(240000000.00)] // 240 million
    [TestCase(245000000.00)] // 245 million
    public void ProperValuesShouldCreateMovieBoxOffice(decimal income)
    {
        var movieBoxOffice = new MovieBoxOffice(income);
        
        movieBoxOffice.Value.ShouldBe(income);
    }
    
    [TestCase(0.00)]
    [TestCase(-0.01)]
    [TestCase(-0.02)]
    [TestCase(-0.03)]
    [TestCase(-0.04)]
    [TestCase(-0.05)]
    [TestCase(-0.06)]
    [TestCase(-0.07)]
    [TestCase(-0.08)]
    [TestCase(-0.09)]
    [TestCase(-0.10)]
    [TestCase(-0.20)]
    [TestCase(-0.30)]
    [TestCase(-0.40)]
    [TestCase(-0.50)]
    [TestCase(-0.60)]
    [TestCase(-0.70)]
    [TestCase(-0.80)]
    [TestCase(-0.90)]
    [TestCase(-1.00)]
    [TestCase(-1.50)]
    [TestCase(-2.00)]
    [TestCase(-2.50)]
    [TestCase(-3.00)]
    [TestCase(-3.50)]
    [TestCase(-4.00)]
    [TestCase(-4.50)]
    [TestCase(-5.00)]
    [TestCase(-5.50)]
    [TestCase(-6.00)]
    [TestCase(-6.50)]
    [TestCase(-7.00)]
    [TestCase(-7.50)]
    [TestCase(-8.00)]
    [TestCase(-8.50)]
    [TestCase(-9.00)]
    [TestCase(-9.50)]
    [TestCase(-10.00)]
    [TestCase(-15.00)]
    [TestCase(-20.00)]
    [TestCase(-25.00)]
    [TestCase(-30.00)]
    [TestCase(-35.00)]
    [TestCase(-40.00)]
    [TestCase(-45.00)]
    [TestCase(-50.00)]
    [TestCase(-55.00)]
    [TestCase(-60.00)]
    [TestCase(-65.00)]
    [TestCase(-70.00)]
    public void LowerOrEqualZeroValuesShouldThrowInvalidMovieBoxOfficeException(decimal income)
    {
        Should.Throw<InvalidMovieBoxOfficeException>(() => new MovieBoxOffice(income));
    }
}