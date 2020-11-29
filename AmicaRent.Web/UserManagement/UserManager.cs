using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DataAccess;

namespace WebApplication.UserManagement
{
    public class UserManager
    {
        private AmicaRentDBEntities db = new AmicaRentDBEntities();

        public bool UserCorrect(string userName, string password)
        {
            return GetUser(userName, password) != null;
        }
        public void ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (UserCorrect(userName, oldPassword))
            {
                var user = GetUser(userName, oldPassword);
                user.Kullanici_Sifre = newPassword;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Eski şifre yanlış.");
            }
        }
        private Kullanici GetUser(string userName, string password)
        {
            return db.Kullanici.FirstOrDefault(x => x.Kullanici_Adi == userName && x.Kullanici_Sifre == password);
        }

        public List<string> GetRoles(int kullanici_ID)
        {
            var user = db.Kullanici.FirstOrDefault(x => x.Kullanici_ID == kullanici_ID);
            if (user is null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            var userRoles = db.KullaniciRolIliskileri.Where(x => x.Kullanici_ID == user.Kullanici_ID).Select(x=>x.Rol_ID);
            var roleNames = db.KullaniciRolTanimlari.Where(x => userRoles.Contains(x.Rol_ID)).Select(x=>x.Rol_Adi).ToList();
            return roleNames;
        }
    }
}