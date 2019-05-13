using System;
using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;

namespace MyEvernote.BusinessLayer
{
    public class Test
    {
        private readonly Repository<Category> repo_category = new Repository<Category>();
        private readonly Repository<Comment> repo_comment = new Repository<Comment>();
        private readonly Repository<Note> repo_note = new Repository<Note>();
        private readonly Repository<EvernoteUser> repo_user = new Repository<EvernoteUser>();

        public Test()
        {
            var asd = repo_category.IeEnumerableList();
        }

        public void Inserttest()
        {
            var result = repo_user.Insert(new EvernoteUser
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
            var user = repo_user.Find(x => x.Username == "xxx");
            if (user != null) user.Username = "xxsssx";

            //  repo_user.Save();
            repo_user.Update(user);
        }

        public void Deletetest()
        {
            var user = repo_user.Find(x => x.Username == "xxsssx");
            if (user != null) repo_user.Delete(user);
        }

        public void CommentTest()
        {
            var user = repo_user.Find(x => x.Id == 1);
            var note = repo_note.Find(x => x.Id == 3);
            var comment = new Comment
            {
                Text = "Bu 2 Test Comment",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "muratbasaren",
                Note = note,
                Owner = user
            };
            repo_comment.Insert(comment);
        }
    }
}