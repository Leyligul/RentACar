using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand:Entity
    {
        public string Name { get; set; }

        //virtual kullanmak zorunda değiliz ilişkilndirme yaparken. EntityFramework'de
        //virtual kullanmazsak sıkıntı olmuyor. Ama gerekli olan ORM olabilir.
        public virtual ICollection<Model> Models{ get; set; }
        public Brand()
        {

        }

        public Brand(int ıd,string name):this()
        {
            Id = Id;
            Name = name;

        }

    }
}
