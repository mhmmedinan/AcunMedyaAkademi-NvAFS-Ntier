﻿using Core.Entities;

namespace Core.Security.Entities;

public class User:BaseEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    public User()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
    }

    public User(Guid id,string firstName, string lastName, string email, byte[] passwordHash, byte[] passwordSalt)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}
