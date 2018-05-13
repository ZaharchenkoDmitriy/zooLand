using ConsoleApplication1.server;

namespace ConsoleApplication1.DataBase.Repositories
{
    public class AnimalRepository
    {
        public Animal getById(int id)
        {
            foreach (Animal animal in DB.animals)
            {
                if (animal.ID == id)
                    return animal;
            }

            return null;
        }
    }
}