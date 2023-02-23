using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SplitWebAPI.DataBase;
using SplitWebAPI.Models;

namespace SplitWebAPI.Controllers
{
    [ApiController]
    public class ExpenseController : Controller
    {
        [HttpPost("NewExpense")]
        public string NewExpense(string jsonForm)
        {
            Expense jsonFormDeserialized = JsonConvert.DeserializeObject<Expense>(jsonForm);

            using (SplitContext db = new())
            {
                Expense newexpense = jsonFormDeserialized; //Приведение к объекту класса Экспенс, Бенефитерсы включены

                db.Expenses.Add(newexpense);
                db.SaveChanges();
                return $"Expense counted with Id #{newexpense.ExpenseId}";
            }
        }
    }
}