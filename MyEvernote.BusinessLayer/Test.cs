using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEvernote.DataAccessLayer;
using MyEvernote.Entities;

namespace MyEvernote.BusinessLayer
{
    public class Test
    {
        private Repository<EvernoteUser> repo_user = new Repository<EvernoteUser>();
        private Repository<Category> repo_category = new Repository<Category>();

        public Test()
        {
            var asd = repo_category.List();
        }

        public void Inserttest()
        {
           
            var result = repo_user.Insert(new EvernoteUser()
            {
                Name = "barbar",
                Surname = "bbb",
                Email = "kadirmuratbaseren@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "aabb",
                Password = "111",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "aaa"
            });
        }

        public void Updatetest()
        {
            EvernoteUser user = repo_user.Find(x => x.Username == "xxx");
            if (user !=null)
            {
                user.Username = "xxsssx";
                
            }

            //  repo_user.Save();
            repo_user.Update(user);
        }
    }
}
