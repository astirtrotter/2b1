using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBOBackEnd.Helpers;
using TBOBackEnd.Models;

namespace TBOBackEnd.Services
{

  public interface IAdminService
  {
    Admin Authenticate(string username, string password);
    IEnumerable<Admin> GetAll();
    Admin GetById(string id);
    Admin Create(Admin user, string password);
    void Update(Admin user, string password = null);
    void Delete(string id);
  }

  public class AdminService : IAdminService
  {
    private _AppDbContext _context;

    public AdminService(_AppDbContext context)
    {
      _context = context;
    }

    public Admin Authenticate(string username, string password)
    {
      if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        return null;

      var user = _context.Admins.SingleOrDefault(x => x.Email == username);

      // check if username exists
      if (user == null)
        return null;

      // check if password is correct
      if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        return null;

      // authentication successful
      return user;
    }

    public IEnumerable<Admin> GetAll()
    {
      return _context.Admins;
    }

    public Admin GetById(string id)
    {
      return _context.Admins.Find(id);
    }

    public Admin Create(Admin admin, string password)
    {
      // validation
      if (string.IsNullOrWhiteSpace(password))
        throw new AppException("Password is required");

      if (_context.Admins.Any(x => x.Email == admin.Email))
        throw new AppException("Email \"" + admin.Email + "\" is already taken");

      byte[] passwordHash, passwordSalt;
      CreatePasswordHash(password, out passwordHash, out passwordSalt);

      admin.PasswordHash = passwordHash;
      admin.PasswordSalt = passwordSalt;

      _context.Admins.Add(admin);
      _context.SaveChanges();

      return admin;
    }

    public void Update(Admin adminParam, string password = null)
    {
      var admin = _context.Admins.Find(adminParam.Id);

      if (admin == null)
        throw new AppException("Admin not found");

      // update admin properties
      admin.FirstName = adminParam.FirstName;
      admin.LastName = adminParam.LastName;
      admin.Email = adminParam.Email;

      // update password if it was entered
      if (!string.IsNullOrWhiteSpace(password))
      {
        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(password, out passwordHash, out passwordSalt);

        admin.PasswordHash = passwordHash;
        admin.PasswordSalt = passwordSalt;
      }

      _context.Admins.Update(admin);
      _context.SaveChanges();
    }

    public void Delete(string id)
    {
      var admin = _context.Admins.Find(id);
      if (admin != null)
      {
        _context.Admins.Remove(admin);
        _context.SaveChanges();
      }
    }

    // private helper methods

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      if (password == null) throw new ArgumentNullException("password");
      if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }

    private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
      if (password == null) throw new ArgumentNullException("password");
      if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
      if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
      if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

      using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
      {
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != storedHash[i]) return false;
        }
      }

      return true;
    }
  }
}
