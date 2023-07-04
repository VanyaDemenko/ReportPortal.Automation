using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using ReportPortal.Business.Interfaces;

namespace ReportPortal.Tests.Helpers
{
    public static class AssertionHelper
    {
        public static void PropertiesShouldContainEquivalent(this IDataTransferObject actualData, List<Dictionary<string, string>> propertiesToVerify)
        {
            foreach (var (fieldName, value) in propertiesToVerify.Single())
            {
                var actualValue = actualData.GetType().GetProperty(fieldName).GetValue(actualData, null).ToString();
                actualValue.Should().Be(value);
            }
        }

        public static void PropertiesShouldNotContainEquivalent(this IDataTransferObject actualData, List<Dictionary<string, string>> propertiesToVerify)
        {
            foreach (var (fieldName, value) in propertiesToVerify.Single())
            {
                var actualValue = actualData.GetType().GetProperty(fieldName).GetValue(actualData, null).ToString();
                actualValue.Should().NotBe(value);
            }
        }
    }
}
