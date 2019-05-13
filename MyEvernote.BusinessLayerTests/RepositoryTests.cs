using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyEvernote.Entities;

namespace MyEvernote.BusinessLayer.Tests
{
    [TestClass()]
    public class RepositoryTests
    {
         private Repository<EvernoteUser> repo_user = new Repository<EvernoteUser>();
        
        [TestMethod()]
        public void UpdateTest()
        
      
        {
            EvernoteUser user = repo_user.Find(x => x.Username == "xxx");
            if (user !=null)
            {
                user.Username = "xxsssx";
                
            }

            //  repo_user.Save();
            repo_user.Update(user);
            
            
            Assert.Fail();
        }
    }
}