using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JeyDotC.JustCs.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Moq;
using Xunit;

namespace JeyDotC.JustCs.Mvc.Tests
{
    public class HtmlOutputFormatterTests
    {
        public static IEnumerable<object[]> CanWriteResultData()
        {
            yield return new object[] { typeof(IView), new View<Div>(), true };
            yield return new object[] { typeof(View<>), new View<Div>(), true };
            yield return new object[] { typeof(object), new { }, false };

            yield return new object[] { typeof(IView), null, false };
            yield return new object[] { typeof(View<>), null, false };
        }

        public static IEnumerable<object[]> WriteAsyncData()
        {
            // Direct Implementation of IView
            var someComponent = new Mock<IView>();
            someComponent.Setup(c => c.GetElement())
                .Returns(new Div());

            yield return new object[] { someComponent.Object, (int)HttpStatusCode.OK, new Dictionary<string, string[]>() };

            // Using View<>
            yield return new object[] { new View<Div>(), (int)HttpStatusCode.OK, new Dictionary<string, string[]>() };

            // Using View<> with different status code
            yield return new object[] { new View<Div>(null, HttpStatusCode.NotFound), (int)HttpStatusCode.NotFound, new Dictionary<string, string[]>() };

            // Using View<> with extra headers
            yield return new object[] { new View<Div>().WithHeader("X-Special-Header", "true"), (int)HttpStatusCode.OK, new Dictionary<string, string[]> { ["X-Special-Header"] = new string[] { "true" } } };
        }

        [Theory]
        [MemberData(nameof(CanWriteResultData))]
        public void CanWriteResult_ShouldReturnTrueWhenControllerReturnValueIsView(Type type, object @object, bool expectsToWriteResult)
        {
            // Arrange
            var contextMock = new Mock<OutputFormatterCanWriteContext>();
            contextMock.SetupGet(c => c.ObjectType).Returns(type);
            contextMock.SetupGet(c => c.Object).Returns(@object);

            var context = contextMock.Object;

            var outputFormatter = new HtmlOutputFormatter();

            // Act
            var canWriteResult = outputFormatter.CanWriteResult(context);

            // Assert
            Assert.Equal(expectsToWriteResult, canWriteResult);
        }

        [Theory]
        [MemberData(nameof(WriteAsyncData))]
        public void WriteAsync_ShouldProduceHtmlDocumentResponse(object view, int expectedStatusCode, IDictionary<string, string[]> expectedHeaders)
        {
            // Arrange
            var responseHeaders = new HeaderDictionary();
            var responseMock = new Mock<HttpResponse>();
            responseMock.SetupProperty(r => r.StatusCode);
            responseMock.SetReturnsDefault(Task.CompletedTask);
            responseMock.SetupGet(r => r.Body)
                .Returns(Mock.Of<Stream>());
            responseMock.SetupGet(r => r.Headers)
                .Returns(responseHeaders);

            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.SetupGet(h => h.Response).Returns(responseMock.Object);

            var streamWriterMock = new Mock<TextWriter>();

            Func<Stream, Encoding, TextWriter> writerFactory = (stream, encoding) => streamWriterMock.Object;

            var context = new OutputFormatterWriteContext(
                httpContextMock.Object,
                writerFactory,
                view.GetType(),
                view
            );

            var outputFormatter = new HtmlOutputFormatter();

            // Act
            outputFormatter.WriteAsync(context).Wait();

            // Assert
            Assert.Equal("text/html", context.ContentType);
            Assert.Equal(expectedStatusCode, context.HttpContext.Response.StatusCode);

            foreach (var header in expectedHeaders)
            {
                Assert.Equal(header.Value, context.HttpContext.Response.Headers[header.Key]);
            }
        }
    }
}
