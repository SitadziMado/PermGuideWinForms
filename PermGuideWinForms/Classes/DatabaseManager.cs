using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PermGuideWinForms.Queries;

namespace PermGuideWinForms.Classes
{
    public sealed class DatabaseManager
    {
        public DatabaseManager()
        {
            Container = new PermGuideContainer();

            mSets = new Dictionary<Type, object>();

            // При добавлении класса следует обновить
            /*mSets = new Dictionary<Type, object>
            {
                { typeof(Article), Container.ContentSet }, // ArticleSet },
                { typeof(Excursion), Container.ContentSet }, // ExcursionSet },
                { typeof(File), Container.FileSet },
                { typeof(Region), Container.RegionSet },
                { typeof(Review), Container.ReviewSet },
                { typeof(Sight), Container.ContentSet }, // SightSet },
                { typeof(Timetable), Container.TimetableSet },
                { typeof(User), Container.UserSet },

                { typeof(DbSet<Article>), Container.ContentSet }, // ArticleSet },
                { typeof(DbSet<Excursion>), Container.ContentSet }, // ExcursionSet },
                { typeof(DbSet<File>), Container.FileSet },
                { typeof(DbSet<Region>), Container.RegionSet },
                { typeof(DbSet<Review>), Container.ReviewSet },
                { typeof(DbSet<Sight>), Container.ContentSet }, // SightSet },
                { typeof(DbSet<Timetable>), Container.TimetableSet },
                { typeof(DbSet<User>), Container.UserSet },
            };*/

            /*var thisAsm = Assembly.GetExecutingAssembly();
            var contType = Container.GetType();

            var keys = from v
                       in thisAsm.DefinedTypes
                       where v.Name != "" && v.Name.Contains("")
                       select v;

            var values = from v
                         in contType.GetProperties()
                         where v.Name.Contains("Set")
                         select v;

            foreach (var k in keys)
                foreach (var v in values)
                {
                    var vType = v.PropertyType.GenericTypeArguments[0];

                    if (k.IsSubclassOf(vType) || k == vType)
                        mSets.Add(k, v.GetValue(Container));
                }*/

            /* var thisAsm = Assembly.GetExecutingAssembly();
            var contType = Container.GetType();

            var values = from v
                         in contType.GetProperties()
                         where v.Name.Contains("Set")
                         select v.Name.Substring(0, v.Name.Length - 3);

            var set = new HashSet<string>(values);

            var keys = from v
                       in thisAsm.DefinedTypes
                       where set.Contains(v.Name)
                       select v;

            mDbTypes = new HashSet<Type>(keys); */

            mDbTypes = new HashSet<Type>
            {
                typeof(Article),
                typeof(Content),
                typeof(Excursion),
                typeof(MediaFile),
                typeof(Review),
                typeof(Sight),
                // typeof(Timetable),
                typeof(User),
            };
        }

        public IEnumerable<string> EnumerateDbTypes()
        {
            return from v
                   in mDbTypes
                   select v.Name;
        }

        public bool Exists<T>(T item) where T : class
        {
            DbSet<T> set = GetSet<T>();
            return set.Contains(item);
        }

        public DbSet<T> GetSet<T>() where T : class
        {
            try
            {
                DbSet<T> t = (DbSet<T>)mSets[typeof(T)];
                return t;
            }
            catch (KeyNotFoundException)
            {
                Debug.WriteLine($"Класс {typeof(T).Name} еще не существует.");
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                throw;
            }
        }

        public User Register(
            string login, 
            string password, 
            string nickname = "", 
            UserStatus status = UserStatus.User
        )
        {
            var user = new User(
                login,
                password,
                status, 
                new BanStatus
                {
                    IsBanned = false,
                    BannedTill = DateTime.Now
                });

            user.SetData(password, nickname);

            var ans = from v
                      in Container.UserSet
                      where v.Login == login
                      select v;

            if (ans.Count() != 0)
                throw new UserNotRegisteredException();
            
            Container.UserSet.Add(user);
            Container.SaveChanges();

            return user;

            // return new User(this, user);
        }

        public User Login(string login, string password)
        {
            var encryptedPassword = password.Encrypt();

            var ans = from v
                      in Container.UserSet
                      where v.Login == login && v.Password == encryptedPassword
                      select v;

            User result;

            try
            {
                result = ans.Single();

                // result = new User();

                /*var rec = ans.Single();

                switch (rec.Status)
                {
                    case UserStatus.User: result = new User(rec); break;
                    case UserStatus.Moderator: result = new Moderator(rec); break;
                    case UserStatus.Administrator: result = new Administrator(rec); break;
                    default: throw new UserNotRegisteredException();
                }*/
            }
            catch (InvalidOperationException)
            {
                throw new UserNotRegisteredException();
            }

            return result;
        }

        public IEnumerable<User> GetUsers()
        {
            return from v
                   in Container.UserSet
                   select v;
        }

        public IEnumerable<Article> GetArticles()
        {
            return from v
                   in Container.ContentSet
                   where v is Article && v.ProposalStatus == ProposalStatus.Added
                   select v as Article;
        }

        public IEnumerable<Excursion> GetExcursions()
        {
            return from v
                   in Container.ContentSet
                   where v is Excursion && v.ProposalStatus == ProposalStatus.Added
                   select v as Excursion;
        }

        public IEnumerable<Sight> GetSights()
        {
            return from v
                   in Container.ContentSet
                   where v is Sight && v.ProposalStatus == ProposalStatus.Added
                   select v as Sight;
        }

        public IEnumerable<Timetable> GetTimetables()
        {
            return from v
                   in Container.TimetableSet
                   select v;
        }
        
        public void LeaveReview(
            Content self,
            User sender,
            int mark,
            string review
        )
        {
            var record = new Review(sender, self)
            {
                // Id = ...,
                CreationDate = DateTime.Now,
                Mark = mark,
                Text = review,
            };

            Container.ReviewSet.Add(record);
        }
        
        public void AddArticle(
            User sender,
            string name,
            string content = ""
        )
        {
            var status = sender.IsModerator
               ? ProposalStatus.Added
               : ProposalStatus.Proposed;

            var record = new Article(sender, name, status);
            var file = AddMediaFile(sender, record, content);

            record.AddFile(sender, file);

            Container.ContentSet.Add(record);
        }

        public void AddSight(
            User sender,
            string name,
            string address,
            string location = ""
        )
        {
            var status = sender.IsModerator
                ? ProposalStatus.Added
                : ProposalStatus.Proposed;

            var record = new Sight(
                sender, 
                name,
                status, 
                address, 
                location
            );

            Container.ContentSet.Add(record);
        }

        public void AddExcursion(
            User sender,
            string name
        )
        {
            var status = sender.IsModerator
               ? ProposalStatus.Added
               : ProposalStatus.Proposed;

            var record = new Excursion(sender, name, status);

            Container.ContentSet.Add(record);
        }

        public MediaFile AddMediaFile(
            User sender,
            Article article,
            string content
        )
        {
            var record = MediaFile.FromString(
                sender, 
                content
            );

            record.AddArticle(article);

            Container.MediaFileSet.Add(record);

            return record;
        }
        
        public void TestQueryConstructor()
        {
            /* QueryConstructor qc = new QueryConstructor(
                "Article",
                "Content",
                "Excursion",
                "File",
                "Region",
                "Review",
                "Sight",
                "Timetable",
                "User"
            );

            var root = qc.GetAttributes("User");

            root.Children[1].Criterium = "sunmax1234@mail.ru";

            var query = qc.Query(Container.UserSet, root).ToArray(); */

            try
            {
                Register("b", "b", "tema", UserStatus.Administrator);
                Register("a", "a", "tema");
                Register("artem", "1234", "tema");
                Register("arixhan", "1234", "jeembo");
                Register("nobu", "1234", "drake");
                Register("max", "1234", "future");
                Register("ilya", "1234", "the weeknd");
                Register("adrax", "1234", "the weeknd");
                Register("shitajimado", "1234", "future");
            }
            catch (Exception e)
            {

            }

            var qc = new QueryConstructor(
                "User", 
                typeof(User)
            );

            var node = qc.GetNode("Nickname");

            node.Criterium = "future";
            node.ComparisonOperator = BooleanOperator.NotEqual;

            var users = qc.Query(Container.UserSet).ToArray();
        }

        public IEnumerable<Article> Articles =>
            from v
            in Container.ContentSet // ArticleSet.AsEnumerable();
            where v is Article
            select v as Article;
        
        /* private const string UserStatusString = "user";
        private const string ModeratorStatusString = "moderator";
        private const string AdministratorStatusString = "administrator"; */

        public PermGuideContainer Container { get; internal set; }

        private Dictionary<Type, object> mSets;
        private static int mId = 0;
        private static object mIdLock = new object();
        private HashSet<Type> mDbTypes;
    }
}
