using FinanceCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interop;
using System.Windows.Navigation;

namespace FinanceCore.ViewModel
{
    class CreateNewViewModel:ObservableBase
    {
        string errorMessage;
        string name;
        decimal amount;
        Category selectedCategory;
        Category[] categories;
        bool isExpense;
        FinDbContext db;
        NavigationService navigation;

        public string ErrorMessage
        {
            get => errorMessage;
            set 
            {
                if (Set(ref errorMessage, value))
                {
                    RaisePropertyChanged(nameof(HasError));
                }
            }
                
        }

        public bool HasError => !string.IsNullOrEmpty(errorMessage);

        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }

        public decimal Amount
        {
            get => amount;
            set => Set(ref amount, value);
        }

        public Category[] Categories => categories;

        

        public RelayCommand<object> CreateCommand { get; }
        public RelayCommand<object> IsExpenseCommand { get; }
        public RelayCommand<object> IsIncomeCommand { get; }

        public CreateNewViewModel(NavigationService navigation)
        {
            CreateCommand = new RelayCommand<object>(OnCreate, IsOnCreateEnabled);
            IsExpenseCommand = new RelayCommand<object>(OnIsExpense);
            IsIncomeCommand = new RelayCommand<object>(OnIsIncome);

            this.navigation = navigation;
            db = new FinDbContext();
            categories = db.Categories
                .OrderBy(x => x.Name)
                .ToArray();
        }

        void OnIsExpense(object o)
        {
            this.isExpense = false;
        }

        void OnIsIncome(object o)
        {
            this.isExpense = true;
        }

        public void SelectectCategory(Category item)
        {
            this.selectedCategory = item;
            CreateCommand.RaiseCanExecuteChanged();
        }

        bool IsOnCreateEnabled(object o)
        {
            if (amount == 0 || selectedCategory == null)
                return false;
            return true;
        }

        void OnCreate(object o)
        {
            var evt = new Event();
            if (isExpense)
                evt.Amount = Math.Abs(amount) * -1;
            else
                evt.Amount = Math.Abs(amount);
            evt.Category = selectedCategory;
            evt.Date = DateTime.Now;
            evt.Name = string.IsNullOrEmpty(Name) ? selectedCategory.Name : Name;

            db.Events.Add(evt);

            db.SaveChanges();
            navigation.GoBack();
        }

        public override void Dispose()
        {
            db?.Dispose();

            base.Dispose();
        }
    }
}
