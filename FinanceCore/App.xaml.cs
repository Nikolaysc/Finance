using FinanceCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bg = CultureInfo.GetCultureInfo("bg-BG"); ;

            CultureInfo.CurrentCulture = bg;
            CultureInfo.CurrentUICulture = bg;
            CultureInfo.DefaultThreadCurrentCulture = bg;

            using (var db = new FinDbContext())
            {
                //db.Database.EnsureCreated();
                db.Database.Migrate();

                int id = 1;
                var seededCategories = new Category[]
                {
                    new Category() { CategoryId=id++, Name="Транспорт"},
                    new Category() { CategoryId = id++, Name = "Храна" },
                    new Category() { CategoryId = id++, Name = "Дрехи" },
                    new Category() { CategoryId = id++, Name = "Ток" },
                    new Category() { CategoryId = id++, Name = "Вода" },
                };

                bool added = false;
                foreach (var c in seededCategories)
                {
                    var existing = db.Categories.Find(c.CategoryId);
                    if (existing == null)
                    {
                        db.Categories.Add(c);
                        added = true;
                    }
                }

                if (added)
                {
                    db.SaveChanges();
                }
            }
        }
    }
}
