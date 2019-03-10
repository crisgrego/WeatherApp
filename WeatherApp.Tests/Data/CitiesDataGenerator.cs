using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Tests.Data
{
    class CitiesDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "London" };
            yield return new object[] { "Madrid" };
            yield return new object[] { "Barcelona" };
            yield return new object[] { "Peterborough" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
