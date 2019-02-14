using Mnom_Mnom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Mnom_Mnom.Data
{
    public class DbInitializer
    {
        public static void Initialize(Mnom_MnomContext context)
        {
            if (!context.Dishes.Any())
            {
                string path = Path.Combine(Path.GetFullPath(Properties.Resources.XmlFolder), "Dishes.xml");
                using (Stream reader = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Dish[]), new XmlRootAttribute("Dishes"));
                    Dish[] dishes = (Dish[])serializer.Deserialize(reader);
                    context.Dishes.AddRange(dishes);
                    context.SaveChanges();
                }
            }

            if (!context.User.Any())
            {
                string path = Path.Combine(Path.GetFullPath(Properties.Resources.XmlFolder), "Users.xml");
                using (Stream reader = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(User[]), new XmlRootAttribute("Users"));
                    User[] users = (User[])serializer.Deserialize(reader);
                    foreach (User usr in users)
                    {
                        context.Addresses.AddRange(usr.Addresses);
                    }
                    context.User.AddRange(users);
                    context.SaveChanges();
                }
            }
        }
    }
}
