using demo17.Infrasturcture;
using demo17.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo17.RepoSrevice
{
    public class Studentrepo : IStudent
    {
        private readonly AppDBContext _appDBContext;
        public Studentrepo(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
            
        public List<Students> GetAll()
        {

            return _appDBContext.Student.ToList();


        }
        public Students GetById(int id)
        {

            return _appDBContext.Student.FirstOrDefault(x => x.id == id);

        }
        public void StudentAdd(Students student) {

            
            _appDBContext.Student.Add(student);
            _appDBContext.SaveChanges();
        }   
        public void Update(Students students) {

            _appDBContext.Entry(students).State = EntityState.Modified;
            _appDBContext.SaveChanges();
            
            
        }
        public void Remove(int? id) {
            
            var stud = _appDBContext.Student.Find(id);
            _appDBContext.Student.Remove(stud);
            _appDBContext.SaveChanges();
        }

       
    }
}
