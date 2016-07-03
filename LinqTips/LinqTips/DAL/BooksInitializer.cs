using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTips.DAL
{
    public class BooksInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BooksContext>
    {
        protected override void Seed(BooksContext context)
        {
            base.Seed(context);
        }
    }
}
