using CakeConfigurator.Model;
using CakeConfigurator.ViewModel;
using DAL;
using DAL.Entities;
using DALWordProc.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CakeConfigurator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*List<Title> titles=new List<Title>()/* { new Title { Id=1,Name="Коржи"}, new Title { Id = 2, Name = "Крема" } , new Title { Id = 3, Name = "Дополнительные начинки" },
            new Title { Id=4,Name="Украшения"},new Title { Id=5,Name="Упаковки"},new Title { Id=6,Name="Лента для перевязки"}}*/;

           /* List< CakeIngredient> listCakeIngredients = new List<CakeIngredient>()/* { new CakeIngredient { Id=1,IdNameOfIngredientType=1,NameOfSpecificIngredient="Бисквит",UnitOfMeasurement="шт",NumberOfUnits=0, UnitPrice=10,QuantityInUnit=1},
            new CakeIngredient { Id=2,IdNameOfIngredientType=1,NameOfSpecificIngredient="Вафельный",UnitOfMeasurement="шт",NumberOfUnits=0, UnitPrice=5,QuantityInUnit=1},
            new CakeIngredient { Id=3,IdNameOfIngredientType=2,NameOfSpecificIngredient="Взбитые сливки",UnitOfMeasurement="г",NumberOfUnits=0, UnitPrice=15,QuantityInUnit=300}}*/;

            CakeConfiguratorDB contextCakeConfigurator = new CakeConfiguratorDB();
            GenericRepository<Unit> units = new GenericRepository<Unit>(contextCakeConfigurator);
            GenericRepository<UnitCode> codes = new GenericRepository<UnitCode>(contextCakeConfigurator);
            GenericRepository<UnitName> names = new GenericRepository<UnitName>(contextCakeConfigurator);
            GenericRepository<UnitOfMeasurement> snitOfMeasurements = new GenericRepository<UnitOfMeasurement>(contextCakeConfigurator);
            GenericRepository<UnitPrice> prices = new GenericRepository<UnitPrice>(contextCakeConfigurator);
            GenericRepository<UnitType> types = new GenericRepository<UnitType>(contextCakeConfigurator);
            GenericRepository<QuantityInUnit> quantitys = new GenericRepository<QuantityInUnit>(contextCakeConfigurator);
            var listCakeIngredients = (from u in contextCakeConfigurator.Units
                                join um in contextCakeConfigurator.UnitOfMeasurements on u.IdUnitOfMeasurement equals um.Id
                                join c in contextCakeConfigurator.Codes on u.IdUnitCode equals c.Id
                                join p in contextCakeConfigurator.Prices on u.IdUnitPrice equals p.Id
                                join n in contextCakeConfigurator.Names on u.IdUnitName equals n.Id
                                join t in contextCakeConfigurator.Types on u.IdUnitType equals t.Id
                                join q in contextCakeConfigurator.QuantityInUnits on u.IdQuantityInUnit equals q.Id
                                 select new CakeIngredient { Id = u.Id, IdNameOfIngredientType =t.Id, NameOfSpecificIngredient =n.Name, UnitOfMeasurement = um.Name, NumberOfUnits = 0, UnitPrice =p.Price, QuantityInUnit =q.Quantity,Code=c.Code }).ToList();
            List<Title> titles= (from t in contextCakeConfigurator.Types
                                 select new Title { Id = t.Id, Name = t.Type}).ToList();
           // MessageBox.Show(contextCakeConfigurator.Names.ToList().Count.ToString());
            
            DataContext = new ConfiguratorManagement(titles, listCakeIngredients);
        }
    }
}
