using MyFlat.Common;
using MyFlat.Dto;
using System;
using Xunit;

namespace Tests.Common
{
    public class CounterChildDtoExtensionsTests
    {
        [Fact]
        public void GetDate_CorrectValue_ValidResult()
        {
            var expected = new DateTime(2021, 7, 22, 21, 13, 6);
            var actual = new CounterChildDto
            { Dt_last_indication = "2021-07-22 21:13:06.0" }.GetDate();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetDate_InvalidValue_ValidResult()
        {
            Assert.Throws<FormatException>(() =>
                new CounterChildDto { Dt_last_indication = "2021-07-22 21:13" }.GetDate());
        }
    }
}
