using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace PasswordValidator.tests
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void PasswordDigits_IfPasswordHasANum_1returned()
        {
            //arenge
            string password = "Password1"; int expected_score = 1;

            //act
            int actual_score = CalculatePasswordScoreForDigits(password);

            //assert
            Assert.AreEqual(expected_score, actual_score);
        }

        [TestMethod]
        public void PasswordLowercaseLetters_IfPasswordHasLowLetters_1returned()
        {
            //arenge
            string password = "PASSGDG"; int expected_score = 1;

            //act
            int actual_score = CalculatePasswordScoreForLowercase(password);

            //assert
            Assert.AreEqual(expected_score, actual_score);
        }

        [TestMethod]
        public void PasswordUppercaseLetters_IfPasswordHasUpLetters_1returned()
        {
            //arenge
            string password = "fdgfdhsgh"; int expected_score = 1;

            //act
            int actual_score = CalculatePasswordScoreForUppercase(password);

            //assert
            Assert.AreEqual(expected_score, actual_score);
        }

        [TestMethod]
        public void PasswordSpecialCharacters_IfPasswordHasSpecialChar_1returned()
        {
            //arenge
            string password = "Password@123"; int expected_score = 1;

            //act
            int actual_score = CalculatePasswordScoreForSpecialCharacters(password);

            //assert
            Assert.AreEqual(expected_score, actual_score);
        }

        [TestMethod]
        public void PasswordCharacters_IfPasswordHas7Char_1returned()
        {
            //arenge
            string password = "Pass123"; int expected_score = 1;

            //act
            int actual_score = CalculatePasswordScoreForLength(password);

            //assert
            Assert.AreEqual(expected_score, actual_score);
        }

        [TestMethod]
        public void ValidPassword_IfPasswordPassedTheTest_5returned()
        {
            //arenge
            string password = "Pasasd@1"; int expected_score = 5;

            //act
            int actual_score = CalculatePasswordScore(password);

            //assert
            Assert.AreEqual(expected_score, actual_score);
        }

        private int CalculatePasswordScoreForDigits(string password)
        {
            return Regex.IsMatch(password, @"\d") ? 1 : 0;
        }

        private int CalculatePasswordScoreForLowercase(string password)
        {
            return Regex.IsMatch(password, @"[a-z]") ? 1 : 0;
        }

        private int CalculatePasswordScoreForUppercase(string password)
        {
            return Regex.IsMatch(password, @"[A-Z]") ? 1 : 0;
        }

        private int CalculatePasswordScoreForSpecialCharacters(string password)
        {
            return Regex.IsMatch(password, @"[@#$%^&+=]") ? 1 : 0;
        }

        private int CalculatePasswordScoreForLength(string password)
        {
            return password.Length > 7 ? 1 : 0;
        }
        private int CalculatePasswordScore(string password)
        {
            int actual_score = 0;

            if (Regex.IsMatch(password, @"\d"))
                actual_score++;

            if (Regex.IsMatch(password, @"[a-z]"))
                actual_score++;

            if (Regex.IsMatch(password, @"[A-Z]"))
                actual_score++;

            if (Regex.IsMatch(password, @"[@#$%^&+=]"))
                actual_score++;

            if (password.Length > 7)
                actual_score++;

            return actual_score;
        }
    }
}