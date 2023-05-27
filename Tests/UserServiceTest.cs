namespace Tests
{
    public class Tests
    {
        private Mock<IUserRepository> _userRepository;
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_userRepository.Object);
        }

        [Test]
        public void UserService_RegisterUser_ValidUser()
        {
            _userRepository.Setup(x => x.GetAllUsers()).Returns(new List<User>());
            _userRepository.Setup(x => x.AddUser(It.IsAny<User>())).Returns((User u) => u);

            const string userLogin = "login";
            const string userPassword = "password";

            var result = _userService.RegisterUser(userLogin, userPassword);

            Assert.That(result.Login, Is.EqualTo(userLogin));
        }
        
        [Test]
        public void UserService_RegisterUser_DuplicateLogin()
        {
            User existingUser = new User { Login = "login", Password = "password" };

            _userRepository.Setup(x => x.GetAllUsers()).Returns(new List<User>() { existingUser });
            _userRepository.Setup(x => x.AddUser(It.IsAny<User>())).Returns((User u) => u);

            Assert.Throws<ArgumentException>(() => _userService.RegisterUser("login", "password"));
        }

        [Test]
        public void UserService_FindUserByCredentials_Succsesfull()
        {
            List<User> list = new List<User> {
                new User() {
                    Id = 1,
                    Login = "login",
                    Password = "password",
                },
                new User() {
                    Id = 2,
                    Login = "login2",
                    Password = "password2",
                },
                new User() {
                    Id = 3,
                    Login = "login3",
                    Password = "password3",
                }
            };

            _userRepository.Setup(x => x.GetAllUsers()).Returns(list);

            var user = _userService.FindUserByCredentials("login", "password");

            var expectedUser = new User()
            {
                Id = 1,
                Login = "login",
                Password = "password",
            };

            Assert.That(expectedUser.Id, Is.EqualTo(user.Id));
        }

        [Test]
        public void UserService_FindUserByCredentials_Succsesfull2()
        {
            var list = new List<User>() {
                new User(){
                    Id = 1,
                    Login = "login",
                    Password = "password"
                },
                 new User(){
                    Id = 2,
                    Login = "login2",
                    Password = "password"
                }
            };

            _userRepository.Setup(x => x.GetAllUsers()).Returns(list);

            var user = _userService.FindUserByCredentials("login2", "password");

            var expectedUser = new User()
            {
                Id = 2,
                Login = "login2",
                Password = "password"
            };

            Assert.That(expectedUser.Id, Is.EqualTo(user.Id));
        }

        [Test]
        public void UserService_FindUserByCredentials_InvalidCredentials()
        {
            var list = new List<User>() {
                new User(){
                    Id = 1,
                    Login = "login",
                    Password = "password"
                },
                 new User(){
                    Id = 2,
                    Login = "login2",
                    Password = "password"
                }
            };

            _userRepository.Setup(x => x.GetAllUsers()).Returns(list);

            Assert.Throws<UnauthorizedAccessException>(() => _userService.FindUserByCredentials("login2", "invalid_password"));
        }
    }
}