using CakeConfigurator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CakeConfigurator.ViewModel
{
    public class ConfiguratorManagement:INotifyPropertyChanged
    {
        //Названия добавок
        //-----------------------------------------------------------------
        public ObservableCollection<Title> TitlesDisplay { get; set; }
        private List<Title> _titles;
        private List<CakeIngredient> _listCakeIngredients;

        public ConfiguratorManagement(List<Title> titles, List<CakeIngredient> listCakeIngredients)
        {
            TitlesDisplay =new ObservableCollection<Title>(titles);
            _listCakeIngredients = listCakeIngredients;
            CakeIngredients = new ObservableCollection<CakeIngredient>();
            NewCake = new Cake();
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        //------------------------------------------------------------------


        //Обработка выбора добавки
        //------------------------------------------------------------------
        private CommandHandler _сakeFillerHandler;
        public CommandHandler CakeFillerHandler => _сakeFillerHandler ??
            (_сakeFillerHandler = new CommandHandler(obj =>
            {
                //MessageBox.Show("Yes");
                CakeIngredients.Clear();
                _listCakeIngredients.Where(x => x.IdNameOfIngredientType ==(int) obj ).ToList().ForEach(x=>CakeIngredients.Add(x));
            },
            (obj) =>
            {
                return true;
            }
            ));

        //-----------------------------------------------------------------

        //Список ингредиентов
        //----------------------------------------------------------------
        public ObservableCollection<CakeIngredient> CakeIngredients { get; set; }

        //
        private CommandHandler _addIngredient;
        public CommandHandler AddIngredient => _addIngredient ??
            (_addIngredient = new CommandHandler(obj =>
            {
                var selectIngredient = CakeIngredients.Where(x => x.Id == (int)obj).First();
                if (selectIngredient.NumberOfUnits == 0)
                {
                    NewCake.SelectedIngredients.Add(selectIngredient);
                }
                //Валидация Коржей
                if (selectIngredient.IdNameOfIngredientType == 1)
                {
                    int countCakeLayer = 0;
                    foreach(var ingredient in NewCake.SelectedIngredients)
                    {
                        if (ingredient.IdNameOfIngredientType == 1)
                        {
                            countCakeLayer = countCakeLayer + ingredient.NumberOfUnits;
                        }
                    }
                    if (countCakeLayer < 5)
                    {
                        selectIngredient.NumberOfUnits++;
                    }

                }

                //Валидация Крема
                if (selectIngredient.IdNameOfIngredientType == 2)
                {
                    int countCream = 0;
                    foreach (var ingredient in NewCake.SelectedIngredients)
                    {
                        if (ingredient.IdNameOfIngredientType == 2 )
                        {
                            countCream ++;
                        }
                    }

                    if (countCream ==0)
                    {
                        selectIngredient.NumberOfUnits++;
                    }
                }
                //Валидация Дополнительной начинки
               /* if (selectIngredient.IdNameOfIngredientType == 3)
                {
                    int countAdditionalStuffing = 0;
                    foreach (var ingredient in NewCake.SelectedIngredients)
                    {
                        if (ingredient.IdNameOfIngredientType == 3)
                        {
                            countAdditionalStuffing++;
                        }
                    }

                    if (countCream < 1)
                    {
                        selectIngredient.NumberOfUnits++;
                    }
                }*/

                NewCake.CalcTotalCost();
                NewCake.CalcTotalWeight();
                NewCake.CalcCode();
            },
            (obj) =>
            {
                return true;
            }
            ));

        private CommandHandler _delIngredient;
        public CommandHandler DelIngredient => _delIngredient ??
            (_delIngredient = new CommandHandler(obj =>
            {
                var selectIngredient=CakeIngredients.Where(x => x.Id == (int)obj).First();

                if (selectIngredient.NumberOfUnits > 0)
                {
                    selectIngredient.NumberOfUnits--;
                    NewCake.CalcTotalCost();                    
                    NewCake.CalcTotalWeight();
                    NewCake.CalcCode();
                    if (selectIngredient.NumberOfUnits == 0)
                        NewCake.SelectedIngredients.Remove(selectIngredient);
                    
                }
                    
   
            },
            (obj) =>
            {
                return true;
            }
            ));


        //-----------------------------------------------------------------------------------------------


        //Выбранные ингредиенты
        //-----------------------------------------------------------------------------------------------
        //private Cake _newCake;
        public Cake NewCake { get; set; }
        
        


      
        
    }
}
