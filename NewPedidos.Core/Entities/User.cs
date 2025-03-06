using NewPedidos.Core.Enum;

namespace NewPedidos.Core.Entities
{
    public class User : BaseEntities
    {
        public User()
        {
            
        }
        public User(string userName, string userEmail,string password):base()
        {
            UserName = userName;
            UserEmail = userEmail;
            UserLevel = Level.Editor;
            Password = password;

            OwnedOrder = [];
        }

        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public Level UserLevel { get; set; }
        public string Password { get;  set; }
        public List<Order> OwnedOrder { get; private set; }
        

        public void UpdateUser(string userName, string userEmail, string password)
        {
            UserName = userName;
            UserEmail = userEmail;
            Password = password;
            UpdatedAt = DateTime.Now;
        }

        public void Administrator()
        {
            if (UserLevel != Level.Editor && UserLevel != Level.Reader)
            {
                UserLevel = Level.Administrator;
                UpdatedAt = DateTime.Now;
            }
        }

        public void Reader()
        {
            if (UserLevel != Level.Editor && UserLevel != Level.Administrator)
            {
                UserLevel = Level.Reader;
                UpdatedAt = DateTime.Now;
            }
        }
    }
}
