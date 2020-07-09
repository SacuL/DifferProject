using Differ.Domain.Interfaces;
using Differ.Domain.Models;
using Differ.Domain.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Differ.Tests.Unit
{
    public class DiffDomainServiceTests
    {
        private readonly Mock<IDiffRepository> _diffRepositoryMock;

        public DiffDomainServiceTests()
        {
            _diffRepositoryMock = new Mock<IDiffRepository>();
        }

        [Theory]
        [InlineData("abcd", "abcde", "Left size != Right size")]
        [InlineData("abcde", "abcd", "Left size != Right size")]
        [InlineData("abc", "abc", "There are no differences")]
        [InlineData("", "", "There are no differences")]
        [InlineData("aaa", "bbb", "There is 1 difference")]
        [InlineData("aaaaa", "bbbaa", "There is 1 difference")]
        [InlineData("aaaaa", "abbaa", "There is 1 difference")]
        [InlineData("aaaaa", "abbbb", "There is 1 difference")]
        [InlineData("abc", "efg", "There is 1 difference")]
        [InlineData("aaxaaxxaax", "aayaayyaay", "There are 3 differences")]
        public async Task CalculateDiffTest(string leftDiffData, string rightDiffData, string expectecMessage)
        {
            //Arrange
            Guid fakeGuid = new Guid();
            Diff fakeDiffData = new Diff(fakeGuid, leftDiffData, rightDiffData);

            _diffRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(Task.FromResult(fakeDiffData));

            //Act
            var diffDomainService = new DiffDomainService(_diffRepositoryMock.Object);
            DiffResult diffResult = await diffDomainService.CalculateDiff(fakeGuid);

            //Assert
            Assert.Equal(diffResult.Message, expectecMessage);
        }
    }
}