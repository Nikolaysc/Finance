using FinanceCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FinanceCore.ViewModel
{
    class MainWindowViewModel: ObservableBase
    {
        ObservableCollection<Event> events;
        FinDbContext db;
        const int pageSize = 100;
        int page;

        public ObservableCollection<Event> Events => events;

        public MainWindowViewModel()
        {
            db = new FinDbContext();
            var firstPage = db.Events
                .Include(x => x.Category)
                .OrderByDescending(x => x.Date)
                .Take(pageSize)
                .ToArray();
           
            page = 0;
            events = new ObservableCollection<Event>(firstPage);
        }

        public override void Dispose()
        {
            db?.Dispose();

            base.Dispose();
        }
    }
}
