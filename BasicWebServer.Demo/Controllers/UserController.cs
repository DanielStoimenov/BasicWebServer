using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Demo.Controllers
{
    public class UserController : Controller
    {
        private const string Username = "user";

        private const string Password = "user123";

        private const string LoginForm = @"<form action='/Login' method='POST'>
                Username: <input type='text' name='Username'/>
                Password: <input type='password' name='Password'/>
                <input type='submit' value ='Log In' /> 
            </form>";

        public UserController(Request request)
            : base(request)
        {
        }

        public Response Login() => Html(LoginForm);

        public Response LoginUser()
        {
            Request.Session.Clear();

            var bodyText = "";

            var usernameMatches = Request.Form["Username"] == Username;
            var passwordMatches = Request.Form["Password"] == Password;

            if (usernameMatches && passwordMatches)
            {
                Request.Session[Session.SessionUserKey] = "MyUserId";
                CookieCollection cookies = new CookieCollection();
                cookies.Add(Session.SessionCookieName, Request.Session.Id);

                bodyText = "<h3>Logged successfully!</h3>";

                return Html(bodyText, cookies);
            }
            else
            {
                bodyText = LoginForm;
            }

            return Html(bodyText);
        }

        public Response GetUserData()
        {
            if (Request.Session.ContainsKey(Session.SessionUserKey))
            {
               return Html($"<h3>Currently logged-in user is with username '{Username}'</h3>") ;
            }

            return Redirect("/login");
        }

        public Response Logout()
        {
            Request.Session.Clear();

            return Html("<h3>Logged out successfully!</h3>");
        }
    }
}