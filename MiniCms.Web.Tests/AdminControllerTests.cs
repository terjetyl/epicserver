using MiniCms.Model.Repositories;
using MiniCms.Web.Controllers;
using Moq;
using Xunit;

namespace MiniCms.Web.Tests
{
    public class AdminControllerTests
    {
        [Fact(Skip = "")]
        public void IndexTest()
        {
            var blogRepositoryMock = new Mock<IBlogRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var blogPostRepositoryMock = new Mock<IBlogPostRepository>();
            
            var adminController = new AdminOldController(blogRepositoryMock.Object, userRepositoryMock.Object, blogPostRepositoryMock.Object);
            
            var viewResult = adminController.Index() as System.Web.Mvc.ViewResult;

            Assert.Equal("", viewResult.ViewBag.Title);
        }
    }
}
