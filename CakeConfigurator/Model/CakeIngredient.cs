using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CakeConfigurator.Model
{
    public class CakeIngredient : INotifyPropertyChanged
    {
        private int _id;
        private int _idNameOfIngredientType;
        private string _nameOfSpecificIngredient;
        private string _unitOfMeasurement;
        private decimal _unitPrice;
        private int _numberOfUnits;
        private double _quantityInUnit;
        private string _code;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public int IdNameOfIngredientType
        {
            get
            {
                return _idNameOfIngredientType;
            }
            set
            {
                _idNameOfIngredientType = value;
                OnPropertyChanged("IdNameOfIngredientType");
            }
        }
        public string NameOfSpecificIngredient
        {
            get
            {
                return _nameOfSpecificIngredient;
            }
            set
            {
                _nameOfSpecificIngredient = value;
                OnPropertyChanged("NameOfSpecificIngredient");
            }
        }
        public string UnitOfMeasurement
        {
            get
            {
                return _unitOfMeasurement;
            }
            set
            {
                _unitOfMeasurement = value;
                OnPropertyChanged("UnitOfMeasurement");
            }
        }
        public decimal UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
                OnPropertyChanged("UnitPrice");
            }
        }
        public int NumberOfUnits
        {
            get
            {
                return _numberOfUnits;
            }
            set
            {
                _numberOfUnits = value;
                OnPropertyChanged("NumberOfUnits");
            }
        }
        public double QuantityInUnit
        {
            get
            {
                return _quantityInUnit;
            }
            set
            {
                _quantityInUnit = value;
                OnPropertyChanged("QuantityInUnit");
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
