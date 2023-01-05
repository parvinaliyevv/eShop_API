namespace eShop.xUnitTest.Controllers;

public class AccountControllerTest
{
    [Fact]
    public async void SignInBadModelRequest()
    {
        // Arrange
        
        var mapperMock = new Mock<IMapper>();
        var userManagerMock = new Mock<IUserManager>();
        var tokenGeneratorMock = new Mock<ITokenGeneratorService>();

        var dtoParam = new SignInUserDto() { Email = "johndoegmail.com", Password = "JohnDoeSecret" };

        var controller = new AccountController(userManagerMock.Object, tokenGeneratorMock.Object, mapperMock.Object);
        controller.ModelState.AddModelError("Invalid email address", "email address contain '@' and '.' !");

        // Act

        var result = await controller.SignIn(dtoParam);

        // Assert

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async void SignInNotFoundRequest()
    {
        // Arrange

        var mapperMock = new Mock<IMapper>();
        var userManagerMock = new Mock<IUserManager>();
        var tokenGeneratorMock = new Mock<ITokenGeneratorService>();

        var dtoParam = new SignInUserDto() { Email = "johndoe@gmail.com", Password = "JohnDoeSecret" };

        var controller = new AccountController(userManagerMock.Object, tokenGeneratorMock.Object, mapperMock.Object);

        // Act

        var result = await controller.SignIn(dtoParam);

        // Assert

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async void SignUpBadModelRequest()
    {
        // Arrange

        var mapperMock = new Mock<IMapper>();
        var userManagerMock = new Mock<IUserManager>();
        var tokenGeneratorMock = new Mock<ITokenGeneratorService>();

        var dtoParam = new SignUpUserDto() { Email = "johndoegmail.com", Password = "JohnDoeSecret" };

        var controller = new AccountController(userManagerMock.Object, tokenGeneratorMock.Object, mapperMock.Object);
        controller.ModelState.AddModelError("Invalid email address", "email address contain '@' and '.' !");

        // Act

        var result = await controller.SignUp(dtoParam);

        // Assert

        Assert.IsType<BadRequestObjectResult>(result);
    }
}
