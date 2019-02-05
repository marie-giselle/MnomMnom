using Mnom_Mnom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mnom_Mnom.Data
{
    public class DbInitializer
    {
        public static void Initialize(Mnom_MnomContext context)
        {
            if(context.Dish.Any())
            {
                return;
            }

            //TODO: Заполнение тестовыми данными

            context.SaveChanges();
        }
    }
}
