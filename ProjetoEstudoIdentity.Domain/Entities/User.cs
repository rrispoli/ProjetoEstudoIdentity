using System;
using System.Collections.Generic;

namespace ProjetoEstudoIdentity.Domain.Entities
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}