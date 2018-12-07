using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CakeConfigurator.Model
{
    public class Cake : INotifyPropertyChanged
    {
        private decimal _totalCost;
        private double _totalWeight;
        private string _code;
        private ObservableCollection<CakeIngredient> _selectedIngredients;

        public ObservableCollection<CakeIngredient> SelectedIngredients
        {
            get
            {                
                return _selectedIngredients;
            }
            set
            {
                _selectedIngredients = value;
                OnPropertyChanged("SelectedIngredients");
            }
        }

        public decimal TotalCost
        {
            get
            {
                return _totalCost;
            }
            set
            {
                _totalCost = value;
                OnPropertyChanged("TotalCost");
            }
        }

        public double TotalWeight
        {
            get
            {
                return _totalWeight;
            }
            set
            {
                _totalWeight = value;
                OnPropertyChanged("TotalWeight");
            }
        }

        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }


        public Cake()
        {
            _selectedIngredients = new ObservableCollection<CakeIngredient>();
        }

        public void CalcTotalCost()
        {
            TotalCost = 0;
            foreach (var Ingredient in _selectedIngredients)
            {
                TotalCost = TotalCost + Ingredient.NumberOfUnits * Ingredient.UnitPrice;
            }
        }

        public void CalcTotalWeight(int setIdCream=2, int setIdCakeLayer=1)
        {
            TotalWeight = 0;
            CakeIngredient cream = _selectedIngredients.Where(x => x.IdNameOfIngredientType == setIdCream).DefaultIfEmpty(new CakeIngredient {Id= setIdCream, QuantityInUnit = 0 }).First();
            if (cream.QuantityInUnit !=0)
            {
                foreach (var Ingredient in _selectedIngredients)
                {
                    if (Ingredient.IdNameOfIngredientType == setIdCakeLayer && Ingredient.NumberOfUnits != 0)
                        TotalWeight = TotalWeight + (double) Ingredient.NumberOfUnits * cream.QuantityInUnit;
                }
            }
        }

        public void CalcCode()
        {
            Code = "";
            foreach (var Ingredient in _selectedIngredients)
            {
                if (Ingredient.NumberOfUnits == 1)
                {
                    Code = Code + Ingredient.Code;
                }
                else if (Ingredient.NumberOfUnits >= 1 && Ingredient.NumberOfUnits <= 5)
                {
                    Code = Code + Ingredient.NumberOfUnits.ToString() + Ingredient.Code;
                }
                Code = Code +"|";
            }

            Code = Code.Remove(Code.Length-1,1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
