using FakeData;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyEvernote.DataAccessLayer
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Adding Admin User
            EvernoteUser admin = new EvernoteUser
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
            EvernoteUser standartuser = new EvernoteUser
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

            for (int z = 0; z < 8; z++)
            {
                EvernoteUser user = new EvernoteUser
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
            List<EvernoteUser> userlist = context.EvernoteUsers.ToList();
            
            //Note: Adding Fake Categories
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category
                {
                    Title = PlaceData.GetStreetName(),
                    Description = PlaceData.GetStreetName(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = "muratbaseren"
                };
                context.Categories.Add(cat);

                //Note:Adding Fake Notes
                for (int k = 0; k < NumberData.GetNumber(5, 9); k++)
                {
                    EvernoteUser note_owner = userlist[NumberData.GetNumber(0, userlist.Count - 1)];
                    Note note = new Note
                    {
                        Title = TextData.GetAlphabetical(NumberData.GetNumber(5, 25)),
                        Text = TextData.GetSentences(NumberData.GetNumber(1, 3)),
                        IsDraft = false,
                        LikeCount = NumberData.GetNumber(1, 9),
                        Owner = note_owner,
                        CreatedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = note_owner.Username,
                    };
                    cat.Notes.Add(note);
                    //Note:Adding Fake Comments

                    for (int j = 0; j < NumberData.GetNumber(3, 5); j++)
                    {
                        EvernoteUser commentowner = userlist[NumberData.GetNumber(0, userlist.Count - 1)];
                        Comment comment = new Comment
                        {
                            Text = TextData.GetSentence(),
                            Owner = userlist[NumberData.GetNumber(0,userlist.Count -1)],
                            CreatedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = commentowner.Username
                        };
                        note.Comments.Add(comment);
                    }

                    //Note:Adding Fake Likes...

                
                    for (int j = 0; j < note.LikeCount; j++)
                    {
                        Liked likes = new Liked
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