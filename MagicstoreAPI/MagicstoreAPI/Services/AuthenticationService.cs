using Microsoft.AspNetCore.Mvc;


namespace MagicstoreAPI.Services
{
	public class AuthenticationService
	{

		public AuthenticationService()
		{

		}
		public async Task<string> Authenticate(string Name, string Password)
		{
			if (Name == "testname" && Password == "testpassword")
			{
				return "DummyToken1" ;
			}
			return " ";
		}
	}
}

