
using MongoDB.Entities;

namespace Hepsiyemek.infrastructure.Entites
{
    public class EmptyBaseEntity:Entity
    {
        public EmptyBaseEntity()
        {
            base.ID = GenerateNewID();
        }
   
        
    }
}
