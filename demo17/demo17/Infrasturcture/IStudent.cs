using demo17.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace demo17.Infrasturcture
{
    public interface IStudent
    {

        List<Students> GetAll();

        Students GetById(int id);
        void StudentAdd(Students students);
        void Update(Students students);
        void Remove(int? id);

    }
}
