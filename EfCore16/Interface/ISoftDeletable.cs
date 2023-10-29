using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore16.Interface
{
    public interface ISoftDeletable
    {
        bool IsDeleted {  get; set; }
        DateTime? DateDeleted { get; set; }

        void Delete()
        {
            IsDeleted = true;
            DateDeleted=DateTime.Now;
        }
        void UndoDelete()
        {
            IsDeleted = false;
            DateDeleted = null;
        }
    }
}
