using System;
using System.Data.Entity;
using System.Linq;
using FakeData;
using MyEvernote.Entities;

namespace MyEvernote.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Adding Admin User
            var admin = new EvernoteUser
            {
                Name = "Murat",
                Surname = "Başeren",
                Email = "kadirmuratbaseren@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "muratbaseren",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "muratbaseren"
            };

            //Adding Standart User
            var standartuser = new EvernoteUser
            {
                Name = "Kadir",
                Surname = "Başeren",
                Email = "muratbaseren@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "muratbaseren",
                Password = "654321",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "muratbaseren"
            };

            context.EvernoteUsers.Add(admin);
            context.EvernoteUsers.Add(standartuser);

            for (var z = 0; z < 8; z++)
            {
                var user = new EvernoteUser
                {
                    Name = NameData.GetFirstName(),
                    Surname = NameData.GetSurname(),
                    Email = NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    Username = $"user{z}",
                    Password = "123",
                    CreatedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user{z}"
                };
                context.EvernoteUsers.Add(user);
            }

            context.SaveChanges();

            //Note:UserList for using...
            var userlist = context.EvernoteUsers.ToList();

            //Note: Adding Fake Categories
            for (var i = 0; i < 10; i++)
            {
                var cat = new Category
                {
                    Title = PlaceData.GetStreetName(),
                    Description = PlaceData.GetStreetName(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = "muratbaseren"
                };
                context.Categories.Add(cat);

                //Note:Adding Fake Notes
                for (var k = 0; k < NumberData.GetNumber(5, 9); k++)
                {
                    var note_owner = userlist[NumberData.GetNumber(0, userlist.Count - 1)];
                    var note = new Note
                    {
                        Title = TextData.GetAlphabetical(NumberData.GetNumber(5, 25)),
                        Text = TextData.GetSentences(NumberData.GetNumber(1, 3)),
                        IsDraft = false,
                        LikeCount = NumberData.GetNumber(1, 9),
                        Owner = note_owner,
                        CreatedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = note_owner.Username
                    };
                    cat.Notes.Add(note);
                    //Note:Adding Fake Comments

                    for (var j = 0; j < NumberData.GetNumber(3, 5); j++)
                    {
                        var commentowner = userlist[NumberData.GetNumber(0, userlist.Count - 1)];
                        var comment = new Comment
                        {
                            Text = TextData.GetSentence(),
                            Owner = userlist[NumberData.GetNumber(0, userlist.Count - 1)],
                            CreatedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = commentowner.Username
                        };
                        note.Comments.Add(comment);
                    }

                    //Note:Adding Fake Likes...


                    for (var j = 0; j < note.LikeCount; j++)
                    {
                        var likes = new Liked
                        {
                            LikedUser = userlist[j]
                        };
                        note.Likes.Add(likes);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}