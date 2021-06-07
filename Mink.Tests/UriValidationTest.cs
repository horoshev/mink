using System;
using FluentAssertions;
using Xunit;

namespace Mink.Tests
{
    public class UriValidationTest
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("     ", false)]
        [InlineData("localhost", false)]
        [InlineData("https://2gis.ru", true)]
        [InlineData("http://tiny.cc/3cmytz", true)]
        [InlineData("vk.com", true)]
        [InlineData("https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.sha256?view=net-5.0", true)]
        [InlineData("https://go+ogle.com", false)]
        [InlineData("https://go=ogle.com", false)]
        [InlineData("https://go,ogle.com", false)]
        [InlineData("https://go;ogle.com", false)]
        [InlineData("https://go:ogle.com", false)]
        [InlineData("https://go&ogle.com", false)]
        [InlineData("https://go?ogle.com", false)]
        [InlineData("https://go@ogle.com", false)]
        [InlineData("https://go#ogle.com", false)]
        [InlineData("https://go ogle.com", false)]
        [InlineData("https://go/ogle.com", false)]
        [InlineData("https://go<>ogle.com", false)]
        [InlineData("https://go()ogle.com", false)]
        [InlineData("https://go[]ogle.com", false)]
        [InlineData("https://go{}ogle.com", false)]
        [InlineData("https://go|ogle.com", false)]
        [InlineData("https://go\\ogle.com", false)]
        [InlineData("https://go^ogle.com", false)]
        [InlineData("https://go%ogle.com", false)]
        [InlineData("https://go!ogle.com", false)]
        [InlineData("https://go*ogle.com", false)]
        [InlineData("https://go~ogle.com", false)]
        [InlineData("https://go`ogle.com", false)]
        [InlineData("https://go$ogle.com", false)]
        [InlineData("https://go\"ogle.com", false)]
        public void TestUri(string uri, bool expected)
        {
            Uri.IsWellFormedUriString(uri, UriKind.Absolute).Should().Be(expected);
            // _uriService.MinifyUri()
        }
    }
}