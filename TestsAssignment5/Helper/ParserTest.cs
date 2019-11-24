using Assignment5.Helper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsAssignment5.Helper
{
    class ParserTest
    {

        [Test]
        public void NullOrEmptyStringThrowsANE()
        {
            // Assemble
            string input = "";
            // Act
            // Assert
            Assert.That(() => Parser.ParseInputToString(input),
                Throws.Exception.TypeOf<ArgumentNullException>());
            // Act
            input = "   ";
            // Assert
            Assert.That(() => Parser.ParseInputToString(input),
                Throws.Exception.TypeOf<ArgumentNullException>());
            // Act
            // Assert
            Assert.That(() => Parser.ParseInputToString(null),
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void AllUpperCaseReturnsLowerCase()
        {
            // Assemble
            string input = "TESTE CASE";
            string expected = input.ToLower();
            // Act
            string actual = Parser.ParseInputToString(input);
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        
        [Test]
        public void RandomUpperCaseReturnsLowerCase()
        {
            // Assemble
            string input = "TEst casE";
            string expected = input.ToLower();
            // Act
            string actual = Parser.ParseInputToString(input);
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void ConvertInputToInteger()
        {
            // Assemble
            string input = "1234";
            int expected = 1234;
            // Act
            int actual = Parser.ParseToInt(input);
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        
        [Test]
        public void NegativeIntegerThrowsException()
        {
            // Assemble
            string input = "-1234";
            // Act & Assert
            Assert.Throws<FormatException>(() => Parser.ParseToInt(input));
        }

        [Test]
        public void DoubleThrowsException()
        {
            // Assemble
            string input = "12.34";
            // Act & Assert
            Assert.That(() => Parser.ParseToInt(input), Throws.Exception.TypeOf<FormatException>());
        }

        [Test]
        public void ElevenDigitIntegerThrowsException()
        {
            // Assemble
            string input = "444444444444";
            // Act & Assert
            Assert.That(() => Parser.ParseToInt(input), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void MenuSelectsA()
        {
            // Assemble
            string input = "a";
            int expected = 1;
            // Act
            int actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            
            // Assemble
            input = "1";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "1-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "a-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "create-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "new";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void MenuSelectsB()
        {
            // Assemble
            string input = "b";
            int expected = 2;
            // Act
            int actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));

            // Assemble
            input = "2";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "2-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "b-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "existing-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "display";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void MenuSelectsC()
        {
            // Assemble
            string input = "c";
            int expected = 3;
            // Act
            int actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));

            // Assemble
            input = "3";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "3-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "c-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "edit-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "change";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void MenuSelectsD()
        {
            // Assemble
            string input = "d";
            int expected = 4;
            // Act
            int actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));

            // Assemble
            input = "4";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "4-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "d-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "exit";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assemble
            input = "exit-";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
            // Assemble
            input = "adios";
            // Act
            actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void MenuInvalidSelection()
        {
            // Assemble
            string input = "g";
            int expected = 0;
            // Act
            int actual = Parser.ParseInputToMenu(input);
            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}
