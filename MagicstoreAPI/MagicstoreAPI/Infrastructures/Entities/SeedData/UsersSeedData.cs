using System;
using System.Security;

namespace MagicstoreAPI.Infrastructures.Entities.SeedData
{
	public class UsersSeedData
	{
		public static List<Users> usersSeed()
		{
            return new List<Users>()
            {
                new Users
                {
                    ID = 1,
                    UserName = "user1",
                    PasswordHash = System.Text.Encoding.UTF8.GetBytes("\\307O\\275\\220v\\371X>k\\\\0W\\304\\344\\003Q\\233C\\216\\240\\344\\355\\251vY\\216uh\\324\\234\\261\\373\\257^\\352\\235\\352\\212z\\213\\307'\\310\\000\\260=\\375D\\205D\\036~\\210\\018S9D\\335"),
                    PasswordSalt = System.Text.Encoding.UTF8.GetBytes("'F\\313\\364\\360\\211\\337P\\346@\\355\\000\\344J\\210\\007,\\326\\367\\004\\262;\\370\\262\\002\\235\\013\\241W\\267MR\\225XD\\366y\\201\\231\\203\\364\\301\\019**\\018x\\212r=\\232rH\\307"),
                    Mail = "user4@example.com", CreationDate = new DateTime(2024, 1, 4)
                 }
            };

        }
	}
}
