﻿using SplitWebAPI.DataBase;
using SplitWebAPI.Models;

namespace SplitWebAPI.BLL
{
    public interface IBLL
    {
        public static void CountExpense(double amount, int userIdFrom, List<Benefiter> benefitersList) //Учитывает трату, меняет баланс в базе
        {
            using(SplitContext _db = new())
            {
                User userFrom = _db.Users.Find(userIdFrom);
                userFrom.UserBalance += amount;
                foreach(Benefiter b in benefitersList)
                {
                    User userToBenefit = _db.Users.Find(b.UserId);
                    userToBenefit.UserBalance -= amount * b.BenefiterPercent/100;
                }
                _db.SaveChanges();
            }
        }
    }
}
