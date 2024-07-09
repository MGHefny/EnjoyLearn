using learnApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//service function for Categories
namespace learnApp.services
{
    public interface ICategoryService
    {
        int Update(category updatedcategory);
        List<category> ReadAll();
        int Create(category newcategory);
        category ReadById(int id);
        bool Delete(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly enjoy_learn_DBEntities db;
        public CategoryService()
        {
            db = new enjoy_learn_DBEntities();
        }

        public int Create(category newcategory)
        {
            var categoryName = newcategory.category_name.ToLower();
            var categoryNameExist = db.categories.Where(c => c.category_name.ToLower() == categoryName).Any();
            if (categoryNameExist)
            {
                return -2;
            }
            db.categories.Add(newcategory);
            return db.SaveChanges();
            
        }

        public bool Delete(int id)
        {
            var category = ReadById(id);

            if( category != null)
            {
                db.categories.Remove(category);
                return db.SaveChanges() > 0 ? true : false;
            }
            return false;
        }

        public List<category> ReadAll()
        {
            return db.categories.ToList();
        }

        public category ReadById(int id)
        {
            return db.categories.Find(id);
        }

        public int Update(category updatedcategory)
        {
            var categoryName = updatedcategory.category_name.ToLower();
            var categoryNameExist = db.categories.Where(c => c.category_name.ToLower() == categoryName).Any();
            if (categoryNameExist)
            {
                return -2;
            }
            db.categories.Attach(updatedcategory);
            db.Entry(updatedcategory).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}