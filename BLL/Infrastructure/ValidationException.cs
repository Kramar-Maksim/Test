using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }  //Это свойство позволяет сохранить название свойства модели, которое некорректно и не проходит валидацию. 
        public ValidationException(string message, string prop) : base(message)     // И также передавая в конструктор базового класса параметр message, мы определяем сообщение, которое будет выводиться для некорректного свойства в Property.
        {
            Property = prop;
        }
    }
} 