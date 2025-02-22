using NewPedidos.Core.Enum;

namespace NewPedidos.Core.Entities
{
    public class User : BaseEntities
    {
        public User(string username, string userEmail,string password):base()
        {
            Username = username;
            UserEmail = userEmail;
            UserLevel = Level.Editor;
            Active = true;
            Password = password;

            OwnedOrder = [];
        }

        public string Username { get; set; }
        public string UserEmail { get; set; }
        public Level UserLevel { get; set; }
        public bool Active { get; set; }
        public string Password { get;  set; }
        public List<Order> OwnedOrder { get; private set; }
        

        public void UpdatePassword(string password)
        {
            Password = password;
            UpdatedAt = DateTime.Now;
        }
    }
}
