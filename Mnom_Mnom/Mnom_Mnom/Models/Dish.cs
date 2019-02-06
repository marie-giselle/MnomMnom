using System;
using System.Collections.Generic;

namespace Mnom_Mnom.Models
{
    public enum DishType
    {
        Appetizers,     //Холодные закуски
        Salads,         //Салаты
        Soups,          //Супы
        Sandwiches,     //Сэндвичи
        MainCourse,     //Горячее
        Sides,          //Гарниры
        Beverages,      //Напитки
        Desserts        //Десерты
    }
    public class Dish
    {
        public int DishID { get; set; }
        public string Title { get; set; }
        public DishType Type { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
