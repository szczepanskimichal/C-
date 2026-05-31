namespace DiscountRefactor.Test
{
    public class DiscountCodeTest
    {
        [Test]
        public void TestExpiredCode()
        {
            // arrange

            // act
            var exception = Assert.Throws<ArgumentException>(
                () => new DiscountCode(
                    "",
                    new DateTime(2000, 1, 1),
                    false,
                    0,
                    0,
                    0
                )
            );

            // assert

            Assert.That(exception!.Message, Is.EqualTo("Discount code has expired."));
        }


        [Test]
        public void TestExpiredCodeManualExceptionCheck()
        {
            // arrange

            // act
            try
            {
                new DiscountCode(
                    "",
                    new DateTime(2000, 1, 1),
                    false,
                    0,
                    0,
                    0
                );
            }
            catch
            {
                Assert.Pass();
            }
            finally
            {
                // eks: lukk db connection
            }

            // assert
            Assert.Fail();
        }
    }
}
